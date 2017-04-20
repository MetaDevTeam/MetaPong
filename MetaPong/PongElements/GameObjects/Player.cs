namespace MetaPong.PongElements.GameObjects
{
    using Utilities;
    using Utilities.ScreenElements;


    public class Player: MovingElement
    {
        public int Width = 2;
        public int Height = 8;
        private bool _changed;
        internal int _score;

        //TODO organize it OOP way in an object
        private const int ScreenHeight = 40;
        private string _username;

        public Player(int row, int column, string username = "") : base(row, column)
        {
            _layout = Composer.Compose(Composer.MakeBoxLayout(Width, Height));
            _changed = true;
            _score = 0;
            Username = username;
        }

        public Player(int row, string side, string username = "") : base(row)
        {
            _column = GetSide(side);
            ColumnDestination = _column;
            _layout = Composer.Compose(Composer.MakeBoxLayout(Width,Height));
            _changed = true;
            _score = 0;
            Username = username;
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private int GetSide(string side)
        {
            switch (side)
            {
                case "Right":
                    return 130 - Width;
                default:
                    return 0;
            }
        }

        public void MoveUp()
        {
            if (Row > 0)
            {
                RowDestination = Row - 1;
                _changed = true;
            }
        }

        public void MoveDown()
        {
            if (Row < ScreenHeight - Height)
            {
                RowDestination = Row + 1;
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

        public virtual void Tick()
        {
            _visible = true;
        }
    }
}
