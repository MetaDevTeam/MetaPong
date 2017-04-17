namespace MetaPong.PongElements.DrawElements
{
    using System;
    using Utilities;
    using Utilities.ScreenElements;


    public class PlayerO: ScreenElement
    {
        private const int Thickness = 2;
        private const int Height = 8;
        private bool _changed;
        
        //TODO organize it OOP way in an object
        private const int ScreenHeight = 40;

        private ScreenLayout _layout;

        public PlayerO(int row, int column, string side) : base(row, column)
        {
            _layout = Composer.GetBox(Thickness, Height, row, GetSide(side));
            _changed = true;
        }

        public PlayerO(int row, string side) : base(row)
        {
            _layout = Composer.GetBox(Thickness, Height, row, GetSide(side));
            _changed = true;
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

        public void MoveUp()
        {
            if (_layout.Row > 0)
            {
                _layout.Row -= 1;
                _changed = true;
            }
        }

        public void MoveDown()
        {
            if (_layout.Row < ScreenHeight - Height)
            {
                _layout.Row += 1;
                _changed = true;
            }
        }

        public override void Print()
        {
            if (_changed)
            {
                _layout.Print();
                _changed = false;
            }
            
        }
    }
}
