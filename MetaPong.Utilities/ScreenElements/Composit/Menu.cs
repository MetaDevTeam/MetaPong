namespace MetaPong.Utilities.ScreenElements.Composit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Menu : ScreenGroup
    {
        private new readonly List<Label> _elements;
        private int _selected;

        public void Add(int x, int y, string content)
        {
            var item = new Label(x, y, content);
            _elements.Add(item);
        }

        public void MoveUp()
        {
            if (_selected > 0)
            {
                _selected--;
            }
        }

        public void MoveDown()
        {
            if (_selected < Elements.Count - 1)
            {
                _selected++;
            }
        }

        public Label GetSelected()
        {
            return (Label)Elements[_selected];
        }

        /// <summary>
        /// Prints the setr of elements on the screen.
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                if (i==_selected)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Elements[i].Print();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Elements[i].Print();
                }
                
            }
        }
    }
}
