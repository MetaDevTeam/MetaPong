namespace MetaPong.Utilities.ScreenElements
{
    using System;

    public abstract class ScreenElement
    {
        protected int _x;
        protected int _y;

        public ScreenElement(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public abstract void Print();
    }
}
