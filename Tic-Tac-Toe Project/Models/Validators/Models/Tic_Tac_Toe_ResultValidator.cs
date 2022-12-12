namespace Tic_tac_toe.Models.Validators.Models
{
    using Contracts;

    public class Tic_Tac_Toe_ResultValidator : IValidator
    {
        public bool Validate(string[,] field)
        {
            if (field[0, 0] == field[0, 1] && field[0, 0] == field[0, 2] && (field[0,0]!=" " && field[0,1]!=" " && field[0,2]!=" "))
            {
                return true;
            }
            else if (field[1, 0] == field[1, 1] && field[1, 0] == field[1, 2] && (field[1,0]!=" " && field[1,1]!=" " && field[1,2]!=" "))
            {
                return true;
            }
            else if (field[2, 0] == field[2, 1] && field[2, 0] == field[2, 2] && field[2, 0] != " " && field[2, 1] != " " && field[2, 2] != " ")
            {
                return true;
            }
            else if (field[0, 0] == field[1, 0] && field[0, 0] == field[2, 0] && (field[0,0]!=" " && field[1,0]!=" " && field[2,0]!=" "))
            {
                return true;
            }
            else if (field[0, 1] == field[1, 1] && field[0, 1] == field[2, 1] && (field[0,1]!=" " && field[1,1]!=" " && field[2,1]!=" "))
            {
                return true;
            }
            else if (field[0, 2] == field[1, 2] && field[0, 2] == field[2, 2] && (field[0,2]!=" " && field[1,2]!=" " && field[2,2]!=" "))
            {
                return true;
            }
            else if (field[0, 0] == field[1, 1] && field[0, 0] == field[2, 2] && (field[0, 0] != " " && field[1, 1] != " " && field[2, 2] != " "))
            {
                return true;
            }
            else if (field[0, 2] == field[1, 1] && field[0, 2] == field[2, 0] && (field[0,2]!=" " && field[1,1]!=" " && field[0,2]!=" "))
            {
                return true;
            }
            return false;
        }
    }
}
