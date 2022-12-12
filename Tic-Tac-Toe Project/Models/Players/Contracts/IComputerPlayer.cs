namespace Tic_tac_toe.Models.Players.Contracts
{
    public interface IComputerPlayer : IPlayer
    {
        public void MakeTurnAutomatically(string[,] field);
    }
}
