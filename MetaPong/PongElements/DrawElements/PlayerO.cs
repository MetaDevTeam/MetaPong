namespace MetaPong.PongElements.DrawElements
{
    using Utilities;
    using Utilities.ScreenElements;


    public class PlayerO: ScreenLayout
    {
        private const int Thickness = 2;
        private const int Height = 8;
        private bool _changed;
        
        //TODO organize it OOP way in an object
        private const int ScreenHeight = 40;

        public PlayerO(int row, int column) : base(row, column)
        {
            _layout = Composer.Compose(Composer.MakeBoxLayout(Thickness, Height));
            _changed = true;
        }

        public PlayerO(int row, string side) : base(row)
        {
            _column = GetSide(side);
            _destinationColumn = _column;
            _layout = Composer.Compose(Composer.MakeBoxLayout(Thickness,Height));
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
            if (Row > 0)
            {
                _destinationRow = Row - 1;
                _changed = true;
            }
        }

        public void MoveDown()
        {
            if (Row < ScreenHeight - Height)
            {
                _destinationRow = Row + 1;
                _changed = true;
            }
        }

        public override void Print()
        {
            if (_changed)
            {
                base.Print();
                _changed = false;
            }
            
        }
    }
}
