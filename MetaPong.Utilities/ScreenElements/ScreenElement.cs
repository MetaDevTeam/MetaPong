namespace MetaPong.Utilities.ScreenElements
{
    public abstract class ScreenElement
    {
        public int Column;
        public int Row;

        protected ScreenElement(int row, int column)
        {
            Column = column;
            Row = row;
        }

        protected ScreenElement(int row)
        {
            Column = 0;
            Row = row;
        }


        public abstract void Print();
    }
}
