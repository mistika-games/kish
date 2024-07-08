using System;

namespace Core.Either
{
    public class Left<TLeft, TRight> : Core.Either.Either<TLeft, TRight>
    {
        public Left(TLeft left) => this.AsLeft = left;

        public override TLeft AsLeft { get; }

        public override TRight AsRight => throw new InvalidCastException();

        public override bool IsLeft => true;

        public override bool IsRight => false;
    }
}