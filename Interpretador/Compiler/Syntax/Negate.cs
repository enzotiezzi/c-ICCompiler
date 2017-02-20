using System;
using System.Collections.Generic;
using System.Text;

namespace Interpretador.Compiler.Syntax
{
	public sealed class Negate : Value
	{
		public readonly Token t;
		public readonly Value e;

		public Negate(Token t, Value e)
		{
			this.t = t;
			this.e = e;
		}

		public override double Evaluate()
		{
			return -e.Evaluate();
		}
	}
}
