using System;
using System.Collections.Generic;
using System.Text;

namespace Interpretador.Compiler.Syntax
{
	public abstract class BooleanExpression
	{
		public abstract bool Evaluate();
	}
}
