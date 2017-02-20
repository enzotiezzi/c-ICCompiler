using System;
using System.Collections.Generic;
using System.Text;

namespace Interpretador.Compiler.Syntax
{
	public abstract class Expression
	{
		public abstract double Evaluate();

		public static Expression Parse(TokenParser p)
		{
			return Sum.Parse(p);
		}
	}
}
