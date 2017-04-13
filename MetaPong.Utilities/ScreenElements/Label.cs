namespace MetaPong.Utilities.ScreenElements
{
    using System;

    /// <summary>
    /// A class for printing text lables in the console.
    /// It can be used for the TUI buttons, points and tex elements
    /// </summary>
    /// <seealso cref="MetaPong.Utilities.ScreenElements.ScreenElement" />
    public class Label: ScreenElement
    {
        private readonly string _content;

        public Label(int x, int y, string content) 
            : base(x, y)
        {
            _content = content;
        }

        public override void Print()
        {
            Console.SetCursorPosition(_x,_y);
            Console.Write(_content);
        }
    }
}
