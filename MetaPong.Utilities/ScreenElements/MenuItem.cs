namespace MetaPong.Utilities.ScreenElements
{
    using Enumeration;


    public class MenuItem: Label
    {
        public Command Command { get; set; }

        public MenuItem(int row, int column, string content, Command command) :
            base(row, column, content)
        {
            Command = command;
        }
    }
}
