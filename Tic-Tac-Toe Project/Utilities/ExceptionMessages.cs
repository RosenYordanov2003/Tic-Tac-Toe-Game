namespace Tic_tac_toe.Utilities
{
    public static class ExceptionMessages
    {
        public const string InvalidPlayerName =
            "Player UserName can't be null or white space or less than 3 characters";

        public const string InvalidSymbol = "Invalid symbol. Symbol can't be different from X or O";

        public const string InvalidDrawer = "Drawer can't be null";

        public const string InvalidValidator = "ResultValidator can't be null";

        public const string InvalidColor = "Invalid Color {0}";

        public const string SignIsNtAvailable = "Sign {0} is already taken";

        public const string NoExistingPlayer = "Player {0} does not exist in our application";

    }
}
