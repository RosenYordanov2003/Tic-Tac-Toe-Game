namespace Tic_tac_toe.Models.Drawers.Contracts
{
    public interface IDrawer
    {
        public void Draw(object obj);

        public void DrawAt(object obj, int leftX, int topY);
    }
}
