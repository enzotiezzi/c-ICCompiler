using System;
using System.Collections.Generic;
using System.Text;

namespace Interpretador.Compiler
{
	public class TokenParser
	{
		private string input;
		private int index, line, column, nextIndex, nextLine, nextColumn;
		private string errorDescription;
		private StringBuilder sb;

		public TokenParser(string input)
		{
			this.input = input;
			this.sb = new StringBuilder();
			line = 1;
			column = 1;
			nextLine = 1;
			nextColumn = 1;
		}

		public int Line
		{
			get
			{
				return nextLine;
			}
		}

		public int Column
		{
			get
			{
				return column;
			}
		}

		public string ErrorDescription
		{
			get
			{
				return errorDescription;
			}
		}

		public bool HasError
		{
			get
			{
				return (errorDescription != null);
			}
		}

		public bool IsEOF
		{
			get
			{
				return (index >= input.Length);
			}
		}

		private string EatString()
		{
			sb.Remove(0, sb.Length);
			
			while (index < input.Length)
			{
				char c = input[index];
				index++;
				switch (c)
				{
					case '\"':
						column++;
						return sb.ToString();
					case '\n':
					case '\r':
						errorDescription = "Quebra de linha dentro de string!";
						return null;
					case '\\':
						column++;
						if (index >= input.Length)
						{
							errorDescription = "Fim de arquivo inesperado ao processar string!";
							return null;
						}
						c = input[index];
						index++;
						column++;
						switch (c)
						{
							case 'n':
								sb.Append('\n');
								break;
							case 't':
								sb.Append('\t');
								break;
							case '\"':
								sb.Append('\"');
								break;
							case '\\':
								sb.Append('\\');
								break;
							default:
								errorDescription = "Sequência de escape inválida: \"\\" + c + "\"";
								return null;
						}
						break;
					default:
						column++;
						sb.Append(c);
						break;
				}
			}

			errorDescription = "Fim de arquivo inesperado ao processar string!";
			return null;
		}

		private void EatLine()
		{
			while (index < input.Length)
			{
				switch (input[index])
				{
					case '\n':
						column = 1;
						line++;
						index++;
						return;
					case '\r':
						index++;
						if (index < input.Length)
						{
							if (input[index] == '\n')
								index++;
						}
						column = 1;
						line++;
						return;
				}
				column++;
				index++;
			}
		}

		private void EatComment()
		{
			while (index < input.Length)
			{
				switch (input[index])
				{
					case '*':
						if ((index + 1) < input.Length)
						{
							if (input[index + 1] == '/')
							{
								column += 2;
								index += 2;
								return;
							}
						}
						column++;
						index++;
						break;
					case '\n':
						column = 1;
						line++;
						index++;
						break;
					case '\r':
						index++;
						if (index < input.Length)
						{
							if (input[index] == '\n')
								index++;
						}
						column = 1;
						line++;
						break;
					default:
						column++;
						index++;
						break;
				}
			}
			errorDescription = "Fim de arquivo inesperado ao processar comentário!";
		}

		public void CommitPeek()
		{
			nextIndex = index;
			nextLine = line;
			nextColumn = column;
		}

		public Token GetNext()
		{
			Token r = PeekNext();
			nextIndex = index;
			nextLine = line;
			nextColumn = column;
			return r;
		}

		public Token PeekNext()
		{
			index = nextIndex;
			line = nextLine;
			column = nextColumn;

			if (index >= input.Length || errorDescription != null)
				return null;

			int startCol;
			string s;

			while (index < input.Length)
			{
				char c = input[index];
				index++;
				switch (c)
				{
					case '\"':
						startCol = column;
						column++;
						s = EatString();
						if (s == null)
						{
							column = startCol;
							return null;
						}
						return new Token(s, false, line, startCol);
					case '{':
						column++;
						return new Token(TokenType.OpenBracket, line, column - 1);
					case '}':
						column++;
						return new Token(TokenType.CloseBracket, line, column - 1);
					case '(':
						column++;
						return new Token(TokenType.OpenPar, line, column - 1);
					case ')':
						column++;
						return new Token(TokenType.ClosePar, line, column - 1);
					case '+':
						column++;
						return new Token(TokenType.OperatorAdd, line, column - 1);
					case '-':
						column++;
						return new Token(TokenType.OperatorSub, line, column - 1);
					case '*':
						column++;
						return new Token(TokenType.OperatorMul, line, column - 1);
					case '/':
						column++;
						if (index < input.Length)
						{
							switch (input[index])
							{
								case '/':
									column++;
									index++;
									EatLine();
									continue;
								case '*':
									column++;
									index++;
									EatComment();
									continue;
							}
						}
						return new Token(TokenType.OperatorDiv, line, column - 1);
					case '%':
						column++;
						return new Token(TokenType.OperatorMod, line, column - 1);
					case '\n':
						column = 1;
						line++;
						break;
					case '\r':
						if (index < input.Length)
						{
							if (input[index] == '\n')
								index++;
						}
						column = 1;
						line++;
						break;
					default:
						if (char.IsWhiteSpace(c))
						{
							column++;
							continue;
						}
						if (c == '.' || (c >= '0' && c <= '9'))
						{
							sb.Remove(0, sb.Length);
							sb.Append(c);

							startCol = column;
							column++;
							while (index < input.Length)
							{
								c = input[index];

								if (c != '.' && c != '_' && !char.IsLetterOrDigit(c) && !char.IsSurrogate(c))
									break;
								column++;
								index++;
								sb.Append(c);
							}
							double v;
							if (!double.TryParse(sb.ToString(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out v))
							{
								column = startCol;
								errorDescription = "Número inválido: " + sb.ToString();
								return null;
							}
							return new Token(v, line, startCol);
						}
						else if (c == '_' || char.IsLetterOrDigit(c) || char.IsSurrogate(c))
						{
							sb.Remove(0, sb.Length);
							sb.Append(c);

							startCol = column;
							column++;
							while (index < input.Length)
							{
								c = input[index];

								if (c != '_' && !char.IsLetterOrDigit(c) && !char.IsSurrogate(c))
									break;
								column++;
								index++;
								sb.Append(c);
							}
							s = sb.ToString();
							switch (s)
							{
								case "e":
									return new Token(TokenType.OperatorBand, line, startCol);
								case "ou":
									return new Token(TokenType.OperatorBor, line, startCol);
								case "nao":
								case "não":
									return new Token(TokenType.OperatorBnot, line, startCol);
								case "numero":
									return new Token(TokenType.DataTypeNumber, line, startCol);
								case "texto":
									return new Token(TokenType.DataTypeString, line, startCol);
								case "booleano":
									return new Token(TokenType.DataTypeBoolean, line, startCol);
								case "se":
									return new Token(TokenType.If, line, startCol);
								case "senao":
								case "senão":
									return new Token(TokenType.Else, line, startCol);
								case "repita":
									return new Token(TokenType.Repeat, line, startCol);
								case "enquanto":
									return new Token(TokenType.While, line, startCol);
							}

							return new Token(sb.ToString(), true, line, startCol);
						}
						errorDescription = "Caractere inválido: \"" + c + "\"";
						return null;
				}
			}
			return null;
		}
	}
}
