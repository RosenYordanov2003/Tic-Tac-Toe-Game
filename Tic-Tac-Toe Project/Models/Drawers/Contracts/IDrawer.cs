namespace Tic_tac_toe.Models.Drawers.Contracts
{
    public interface IDrawer<T>
    {
        public void Draw(T value);

        public void DrawAt(T value, int leftX, int topY);
    }
}
