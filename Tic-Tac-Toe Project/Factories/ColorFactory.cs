namespace Tic_tac_toe.Factories
{
    using System;
    using System.Collections.Generic;
    using Utilities;
    public class ColorFactory : IFactory<ConsoleColor>
    {
        private readonly Dictionary<string, ConsoleColor> _colors;

        public ColorFactory()
        {
            _colors = new Dictionary<string, ConsoleColor>();
            _colors["red"] = ConsoleColor.Red;
            _colors["dark red"] = ConsoleColor.DarkRed;
            _colors["yellow"] = ConsoleColor.Yellow;
            _colors["dark yellow"] = ConsoleColor.DarkYellow;
            _colors["dark blue"] = ConsoleColor.DarkBlue;
            _colors["blue"] = ConsoleColor.Blue;
            _colors["cyan"] = ConsoleColor.Cyan;
            _colors["green"] = ConsoleColor.Green;
            _colors["dark green"] = ConsoleColor.DarkGreen;
            _colors["white"] = ConsoleColor.White;
            _colors["pink"] = ConsoleColor.Magenta;
            _colors["dark pink"] = ConsoleColor.DarkMagenta;
            _colors["dark cyan"] = ConsoleColor.DarkCyan;
            _colors["dark gray"] = ConsoleColor.DarkGray;
            _colors["gray"] = ConsoleColor.Gray;
        }
        public ConsoleColor GenerateType(string type)
        {
            type = type.ToLower();
            if (!_colors.ContainsKey(type))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidColor, type));
            }

            return _colors[type];
        }
    }
}
