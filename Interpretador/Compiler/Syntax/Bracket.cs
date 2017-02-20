using System;
using System.Collections.Generic;
using System.Text;

namespace Interpretador.Compiler.Syntax
{
	public class Bracket : Value
	{
		public readonly Token t1, t2;
		public readonly Expression e;

		public Bracket(Token t1, Expression e, Token t2)
		{
			this.t1 = t1;
			this.e = e;
			this.t2 = t2;
		}

		public override double Evaluate()
		{
			return e.Evaluate();
		}
	}
}
