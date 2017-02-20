using System;
using System.Collections.Generic;
using System.Text;

namespace Interpretador.Compiler.Syntax
{
	public abstract class Comparison : BooleanExpression
	{
		public readonly Expression e1, e2;

		public Comparison(Expression e1, Expression e2)
		{
			this.e1 = e1;
			this.e2 = e2;
		}

		public static Comparison Parse(TokenParser p)
		{
			return null;
		}
	}
}
