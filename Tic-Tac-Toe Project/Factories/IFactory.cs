namespace Tic_tac_toe.Factories
{
    public interface IFactory<T>
    {
        public T GenerateType(string type);
    }
}
