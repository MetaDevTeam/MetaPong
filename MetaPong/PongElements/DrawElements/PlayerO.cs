namespace MetaPong.PongElements.DrawElements
{
    using System;
    using Utilities;
    using Utilities.ScreenElements;


    public class PlayerO
    {
        private const int Thickness = 2;
        private const int Height = 8;
        private int _row = 0;

        private ScreenLayout _layout;

        public PlayerO(int row, int size, string side)
        {
            _row = row;
            _layout = Composer.GetBox(Thickness, Height, _row, GetSide(side));
        }

        private int GetSide(string side)
        {
            switch (side)
            {
                case "Right":
                    return 130 - Thickness;
                default:
                    return 0;
            }
        }

        public void Print()
        {
            _layout.Print();
        }
    }
}
