namespace Tic_tac_toe.Models.Fields.Models
{
    using System;
    using Contracts;
    using Tic_tac_toe.Models.Drawers.Contracts;
    using Utilities;
    using Tic_tac_toe.Models.Validators.Contracts;

    public class Field : IField
    {
        private string[,] _matrix;

        private IDraw _drawer;

        private IValidator _validator;
        public Field(IDraw drawer, IValidator validator)
        {
            Drawer = drawer;
            Validator = validator;
            Matrix = new string[3, 3];
        }
        public string[,] Matrix
        {
            get => _matrix;
            private set => _matrix = value;
        }

        public IDraw Drawer
        {
            get => _drawer;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDrawer);
                }

                _drawer = value;
            }
        }

        public IValidator Validator
        {
            get => _validator;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidValidator);
                }
                _validator = value;
            }
        }

        public void GenerateField()
        {
            for (int row = 0; row < Matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < Matrix.GetLength(1); col++)
                {
                    Matrix[row, col] = input[col];
                }
            }
        }

    }
}
