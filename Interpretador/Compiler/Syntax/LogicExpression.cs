using System;
using System.Collections.Generic;
using System.Text;

namespace Interpretador.Compiler.Syntax
{
	public abstract class LogicExpression : BooleanExpression
	{
		public readonly BooleanExpression c1, c2;

		public LogicExpression(BooleanExpression c1, BooleanExpression c2)
		{
			this.c1 = c2;
			this.c2 = c2;
		}

		public static BooleanExpression Parse(TokenParser p)
		{
			return null;
		}
	}
}
