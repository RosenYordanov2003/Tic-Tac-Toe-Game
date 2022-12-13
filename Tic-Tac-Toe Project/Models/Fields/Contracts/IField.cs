namespace Tic_tac_toe.Models.Fields.Contracts
{
    
    public interface IField
    {
        public string[,] Matrix { get; }


        public void GenerateField();
    }

}
