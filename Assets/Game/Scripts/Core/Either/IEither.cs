namespace Core.Either
{

    public interface IEither<out TLeft, out TRight>
    {
        TLeft AsLeft { get; }

        TRight AsRight { get; }

        bool IsLeft { get; }

        bool IsRight { get; }
    }

    public abstract class Either<TLeft, TRight> : IEither<TLeft, TRight>
    {
        public abstract TLeft AsLeft { get; }

        public abstract TRight AsRight { get; }

        public abstract bool IsLeft { get; }

        public abstract bool IsRight { get; }
    }
}