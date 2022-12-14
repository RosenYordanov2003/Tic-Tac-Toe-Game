namespace Tic_tac_toe.Models.Fields.Contracts
{
    
    public interface IField<T>
    {
        public T Matrix { get; }


        public void GenerateField();
    }

}
