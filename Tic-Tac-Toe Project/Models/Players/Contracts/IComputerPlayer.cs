namespace Tic_tac_toe.Models.Players.Contracts
{
    public interface IComputerPlayer
    {
        public void MakeTurn(string[,] field);
    }
}
