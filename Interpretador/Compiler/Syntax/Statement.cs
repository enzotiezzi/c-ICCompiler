using System;
using System.Collections.Generic;
using System.Text;

namespace Interpretador.Compiler.Syntax
{
	public abstract class Statement
	{
		public abstract void Execute();

		public static Statement Parse(TokenParser p)
		{
			return null;
		}
	}
}
