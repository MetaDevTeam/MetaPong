namespace MetaPong.Utilities.ScreenElements
{
    using System;

    public class Label: ScreenElement
    {
        private readonly string _content;

        public Label(int row, int column, string content) 
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
