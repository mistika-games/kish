using System;

namespace Core.Either
{
    public class Right<TLeft, TRight> : Core.Either.Either<TLeft, TRight>
    {
        public Right(TRight right) => this.AsRight = right;

        public override TLeft AsLeft =>  throw new InvalidCastException();

        public override TRight AsRight { get; }

        public override bool IsLeft => false;

        public override bool IsRight => true;
    }
}