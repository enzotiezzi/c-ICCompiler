using System;
using System.Collections.Generic;
using System.Text;

namespace Interpretador.Compiler.Syntax
{
	public abstract class Program
	{
		public static Token ErrorToken;
		public static string ErrorDescription;

		//public static List<Statement> Parse(TokenParser p)
		public static Expression Parse(TokenParser p)
		{
			ErrorToken = null;
			ErrorDescription = null;

			Expression e = Expression.Parse(p);
			if (e == null)
				return null;
			Token t = p.GetNext();
			if (t != null)
			{
				ErrorToken = t;
				ErrorDescription = "Símbolo inválido! Era esperado fim de arquivo";
				return null;
			}
			if (p.HasError)
				return null;
			return e;
		}
	}
}
