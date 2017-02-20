using System;
using System.Collections.Generic;
using System.Text;

namespace Interpretador.Compiler.Syntax
{
	public sealed class Constant : Value
	{
		public readonly Token t;

		public Constant(Token t)
		{
			this.t = t;
		}

		public override double Evaluate()
		{
			return t.DValue;
		}
	}
}
