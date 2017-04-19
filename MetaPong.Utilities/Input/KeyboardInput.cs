namespace MetaPong.Utilities.Input
{
    using System;
    using Enumeration;


    public class KeyboardInput
    {
        public Command Listen()
        {
            var next = Console.ReadKey(true);
            switch (next.Key.ToString())
            {
                case "UpArrow":
                    return Command.MoveUp;
                case "DownArrow":
                    return Command.MoveDown;
                case "Enter":
                    return Command.Execute;
                case "Escape":
                    return Command.Exit;
                default:
                    return Command.Unknown;
            }
        }

        public string Read()
        {
            var input = Console.ReadLine();
            return input;
        }
    }
}
