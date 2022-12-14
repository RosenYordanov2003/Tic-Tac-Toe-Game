namespace Tic_tac_toe.Models.Validators.Contracts
{
    public interface IValidator<T>
    {
        public bool Validate(T value);
    }
}
