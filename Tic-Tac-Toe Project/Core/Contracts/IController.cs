
namespace Tic_tac_toe.Core.Contracts
{
    using Tic_tac_toe.Models.Drawers.Contracts;
    public interface IController
    {
        public void PlayRound(IDrawer<string[,]> drawer);
        public void Exit();

        public string PlayerInfo(string playerName);
    }
}
