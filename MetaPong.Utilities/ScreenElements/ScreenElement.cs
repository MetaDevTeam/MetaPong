namespace MetaPong.Utilities.ScreenElements
{
    public abstract class ScreenElement
    {
        protected readonly int Column;
        protected readonly int Row;

        protected ScreenElement(int row, int column)
        {
            Column = column;
            Row = row;
        }

        public abstract void Print();
    }
}
