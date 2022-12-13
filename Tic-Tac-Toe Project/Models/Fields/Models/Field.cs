namespace Tic_tac_toe.Models.Fields.Models
{
    using Contracts;
    public class Field : IField
    {
        private string[,] _matrix;

        public Field()
        {
          
            Matrix = new string[3, 3];
        }
        public string[,] Matrix
        {
            get => _matrix;
            private set => _matrix = value;
        }


        public void GenerateField()
        {
            for (int row = 0; row < Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < Matrix.GetLength(1); col++)
                {
                    Matrix[row, col] = " ";
                }
            }
        }
    }
}
