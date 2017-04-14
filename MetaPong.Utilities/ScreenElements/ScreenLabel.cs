namespace MetaPong.Utilities.ScreenElements
{
    using System;

    /// <summary>
    /// A class for printing text labels in the console.
    /// It can be used for the TUI buttons, points and tex elements
    /// </summary>
    /// <seealso cref="MetaPong.Utilities.ScreenElements.ScreenElement" />
    public class ScreenLabel: ScreenElement
    {
        private readonly string _content;

        public ScreenLabel(int row, int column, string content) 
            : base(row, column)
        {
            _content = content;
        }

        public override void Print()
        {
            Console.SetCursorPosition(Column,Row);
            Console.Write(_content);
        }
    }
}
