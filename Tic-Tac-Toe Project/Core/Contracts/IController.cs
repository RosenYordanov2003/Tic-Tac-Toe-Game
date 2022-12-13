namespace Tic_tac_toe.Core.Contracts
{
    public interface IController
    {
        public void PlayRound();
        public void Exit();

        public string PlayerInfo(string playerName);
    }
}
