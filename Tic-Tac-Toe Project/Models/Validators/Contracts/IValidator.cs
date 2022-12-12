namespace Tic_tac_toe.Models.Validators.Contracts
{
    public interface IValidator
    {
        public bool Validate(string[,] field);
    }
}
