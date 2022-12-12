namespace Tic_tac_toe.Models.Fields.Contracts
{
    using Tic_tac_toe.Models.Drawers.Contracts;
    using Tic_tac_toe.Models.Validators.Contracts;

    public interface IField
    {
        public string[,] Matrix { get; }

        public IValidator Validator { get; }

        public IDraw Drawer { get; }

        public void GenerateField();
    }

}
