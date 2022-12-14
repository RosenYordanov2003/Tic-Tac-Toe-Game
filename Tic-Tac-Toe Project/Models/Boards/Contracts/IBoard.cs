namespace Tic_tac_toe.Models.Boards.Contracts
{
    using Tic_tac_toe.Models.Fields.Contracts;
    public interface IBoard<T> : IField<string[,]>
    {
        public T PlayerOne { get; }
        public T PlayerTwo { get; }

    }
}
