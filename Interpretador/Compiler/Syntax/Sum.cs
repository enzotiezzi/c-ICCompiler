using System;
using System.Collections.Generic;
using System.Text;

namespace Interpretador.Compiler.Syntax
{
	public abstract class Sum : Expression
	{
		public readonly Expression v1, v2;

		public Sum(Expression v1, Expression v2)
		{
			this.v1 = v1;
			this.v2 = v2;
		}

		private sealed class A : Sum
		{
			public A(Expression v1, Expression v2)
				: base(v1, v2)
			{
			}
			public override double Evaluate()
			{
				return v1.Evaluate() + v2.Evaluate();
			}
		}

		private sealed class S : Sum
		{
			public S(Expression v1, Expression v2)
				: base(v1, v2)
			{
			}
			public override double Evaluate()
			{
				return v1.Evaluate() - v2.Evaluate();
			}
		}

		public new static Expression Parse(TokenParser p)
		{
			Expression v1 = Mul.Parse(p);
			if (v1 == null)
				return null;

			Expression v2;
			Token t = p.PeekNext();
			if (t == null)
				return v1;

			switch (t.Type)
			{
				case TokenType.OperatorAdd:
					p.CommitPeek();
					v2 = Parse(p);
					if (v2 == null)
						return null;
					return new A(v1, v2);
				case TokenType.OperatorSub:
					p.CommitPeek();
					v2 = Parse(p);
					if (v2 == null)
						return null;
					return new S(v1, v2);
			}

			return v1;
		}
	}
}
