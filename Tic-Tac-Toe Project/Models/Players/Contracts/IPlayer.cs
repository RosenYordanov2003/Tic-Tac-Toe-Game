using System.Data;

namespace Tic_tac_toe.Models.Players.Contracts
{
    public interface IPlayer
    {
        public string UserName { get; }

        public int Points { get; }

        public string Symbol { get; }

        public void Win();

    }
}
