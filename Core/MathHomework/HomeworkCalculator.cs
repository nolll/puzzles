using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using Core.Tools;

namespace Core.MathHomework
{
    public class HomeworkCalculator
    {
        private const string Addition = "+";
        private const string Multiplication = "*";
        private const char GroupStart = '(';
        private const char GroupEnd = ')';

        public long SumOfAll(string input)
        {
            var rows = PuzzleInputReader.ReadLines(input);
            return rows.Sum(Sum);
        }

        public long Sum(string input)
        {
            var parts = input.Split(' ');

            var mode = Addition;
            CompositeExpression currentExpression = new CompositeAdditionExpression(null);
            var rootExpression = currentExpression;
            foreach (var p in parts)
            {
                var endGroupCount = 0;
                var s = p;
                if (s == Addition || s == Multiplication)
                {
                    mode = s;
                    continue;
                }

                while (s.StartsWith(GroupStart))
                {
                    s = s.Substring(1);
                    var innerExpression = mode == Addition
                        ? (CompositeExpression)new CompositeAdditionExpression(currentExpression)
                        : new CompositeMultiplicationExpression(currentExpression);
                    currentExpression.Add(innerExpression);
                    currentExpression = innerExpression;
                    mode = Addition;
                }

                if (s.EndsWith(GroupEnd))
                {
                    endGroupCount = s.ToCharArray().Count(o => o == GroupEnd);
                    s = s.TrimEnd(GroupEnd);
                }

                var n = long.Parse(s);

                var newExpression = mode == Addition
                    ? (Expression)new AdditionExpression(n, currentExpression)
                    : new MultiplicationExpression(n, currentExpression);

                currentExpression.Add(newExpression);

                while (endGroupCount > 0)
                {
                    currentExpression = currentExpression.ParentExpression;
                    mode = currentExpression.LastOperator == Operator.Multiplication
                        ? Multiplication
                        : Addition;
                    endGroupCount -= 1;
                }
            }

            return rootExpression.Result;
        }

        public enum Operator
        {
            Addition,
            Multiplication
        }

        public abstract class Expression
        {
            public CompositeExpression ParentExpression { get; }

            protected Expression(CompositeExpression parentExpression)
            {
                ParentExpression = parentExpression;
            }

            public abstract Operator Operator { get; }
            public abstract long Result { get; }
        }

        public abstract class CompositeExpression : Expression
        {
            private readonly List<Expression> _expressions;
            public Operator LastOperator => _expressions.LastOrDefault()?.Operator ?? Operator.Addition;

            protected CompositeExpression(CompositeExpression parentExpression)
                : base(parentExpression)
            {
                _expressions = new List<Expression>();
            }

            public void Add(Expression e)
            {
                _expressions.Add(e);
            }

            public override long Result => DefaultResult;

            private long DefaultResult
            {
                get
                {
                    long result = 0;
                    foreach (var expression in Expressions)
                    {
                        if (expression.Operator == Operator.Multiplication)
                            result *= expression.Result;
                        else
                            result += expression.Result;
                    }

                    return result;
                }
            }

            private List<Expression> Expressions => _expressions;
        }

        public class AdditionExpression : Expression
        {
            public override long Result { get; }
            public override Operator Operator => Operator.Addition;

            public AdditionExpression(long num, CompositeExpression parentExpression)
                : base(parentExpression)
            {
                Result = num;
            }
        }

        public class MultiplicationExpression : Expression
        {
            public override long Result { get; }
            public override Operator Operator => Operator.Multiplication;

            public MultiplicationExpression(long num, CompositeExpression parentExpression)
                : base(parentExpression)
            {
                Result = num;
            }
        }

        public class CompositeAdditionExpression : CompositeExpression
        {
            public override Operator Operator => Operator.Addition;

            public CompositeAdditionExpression(CompositeExpression parentExpression)
                : base(parentExpression)
            {
            }
        }

        public class CompositeMultiplicationExpression : CompositeExpression
        {
            public override Operator Operator => Operator.Multiplication;

            public CompositeMultiplicationExpression(CompositeExpression parentExpression)
                : base(parentExpression)
            {
            }
        }
    }
}