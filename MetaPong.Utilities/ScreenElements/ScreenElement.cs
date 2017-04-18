namespace MetaPong.Utilities.ScreenElements
{
    public abstract class ScreenElement
    {
        protected int _column;
        protected int _row;

        protected ScreenElement(int row, int column)
        {
            _column = column;
            _row = row;
        }

        protected ScreenElement(int row)
        {
            _column = 0;
            _row = row;
        }

        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }

        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }

        public abstract void Print();
    }
}
