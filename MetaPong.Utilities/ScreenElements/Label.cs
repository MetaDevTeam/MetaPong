namespace MetaPong.Utilities.ScreenElements
{
    using System;

    public class Label: ScreenElement
    {
        private string _content;

        public Label(int row, int column, string content) 
            : base(row, column)
        {
            _content = content;
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public override void Print()
        {
            Console.SetCursorPosition(Column,Row);
            Console.Write(_content);
        }
    }
}
