namespace Tic_tac_toe.Models.Boards.Contracts
{
    using Tic_tac_toe.Models.Players.Contracts;
    using Tic_tac_toe.Models.Fields.Contracts;
    public interface IBoard<T> :IField
    {
        public T PlayerOne { get; }
        public IPlayer PlayerTwo { get; }

    }
}
