using System;
using System.Collections.Generic;
using System.Text;

namespace Interpretador.Compiler
{
	public enum TokenType
	{
		DataTypeNumber = 0,
		DataTypeString = 1,
		DataTypeBoolean = 2,
		Number = 3,
		String = 4,
		Boolean = 5,
		Identifier = 6,
		OpenBracket = 7,
		CloseBracket = 8,
		OpenPar = 9,
		ClosePar = 10,
		Comma = 11,
		Semicolon = 12,
		If = 13,
		Else = 14,
		Repeat = 15,
		While = 16,
		OperatorAdd = 1000,
		OperatorSub = 1001,
		OperatorMul = 1002,
		OperatorDiv = 1003,
		OperatorMod = 1004,
		OperatorBeq = 1005,
		OperatorBdif = 1006,
		OperatorBgt = 1007,
		OperatorBlt = 1008,
		OperatorBgtEq = 1009,
		OperatorBltEq = 1010,
		OperatorBand = 1011,
		OperatorBor = 1012,
		OperatorBnot = 1013,
	}

	public class Token
	{
		public readonly double DValue;
		public readonly string SValue;
		public readonly TokenType Type;
		public readonly int Line, Column;

		public Token(TokenType type, int line, int column)
		{
			this.DValue = double.NaN;
			this.Type = type;
			this.Line = line;
			this.Column = column;
		}

		public Token(double value, int line, int column)
		{
			this.DValue = value;
			this.Type = TokenType.Number;
			this.Line = line;
			this.Column = column;
		}

		public Token(string value, bool identifier, int line, int column)
		{
			this.DValue = double.NaN;
			this.SValue = value;
			this.Type = (identifier ? TokenType.Identifier : TokenType.String);
			this.Line = line;
			this.Column = column;
		}

		public bool IsDataType
		{
			get
			{
				return ((int)Type <= (int)TokenType.DataTypeBoolean);
			}
		}

		public override string ToString()
		{
			if (Type == TokenType.Number)
				return DValue.ToString(System.Globalization.CultureInfo.InvariantCulture);// +" (" + Line + ", " + Column + ")";
			if (Type == TokenType.String)
				return "\"" + SValue + "\"";
			if (Type == TokenType.Identifier)
				return SValue; // +" (" + Line + ", " + Column + ")";
			return Type.ToString();// +" (" + Line + ", " + Column + ")";
		}
	}
}
