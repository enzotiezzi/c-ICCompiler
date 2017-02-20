using System;
using System.Collections.Generic;
using System.Text;

namespace Interpretador.Compiler.Syntax
{
	public abstract class Mul : Expression
	{
		public readonly Expression v1, v2;

		public Mul(Expression v1, Expression v2)
		{
			this.v1 = v1;
			this.v2 = v2;
		}

		private sealed class M : Mul
		{
			public M(Expression v1, Expression v2)
				: base(v1, v2)
			{
			}
			public override double Evaluate()
			{
				return v1.Evaluate() * v2.Evaluate();
			}
		}

		private sealed class D : Mul
		{
			public D(Expression v1, Expression v2)
				: base(v1, v2)
			{
			}
			public override double Evaluate()
			{
				return v1.Evaluate() / v2.Evaluate();
			}
		}

		public new static Expression Parse(TokenParser p)
		{
			Value v1 = Value.Parse(p);
			if (v1 == null)
				return null;

			Expression v2;
			Token t = p.PeekNext();
			if (t == null)
				return v1;

			switch (t.Type)
			{
				case TokenType.OperatorMul:
					p.CommitPeek();
					v2 = Parse(p);
					if (v2 == null)
						return null;
					return new M(v1, v2);
				case TokenType.OperatorDiv:
					p.CommitPeek();
					v2 = Parse(p);
					if (v2 == null)
						return null;
					return new D(v1, v2);
			}

			return v1;
		}
	}
}
