namespace Tic_tac_toe.Core.Contracts
{
    public interface IController
    {
        public void Play(bool isPlayerOneTurn);

        public void Exit();
    }
}
