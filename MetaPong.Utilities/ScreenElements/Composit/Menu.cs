namespace MetaPong.Utilities.ScreenElements.Composit
{
    using System;
    using System.Collections.Generic;
    using Enumeration;


    public class Menu : ScreenGroup
    {
        private int _selected;

        public void Add(int x, int y, string content, Command command)
        {
            var item = new MenuItem(x, y, content, command);
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

        public MenuItem GetSelected()
        {
            return (MenuItem)Elements[_selected];
        }

        /// <summary>
        /// Prints the setr of elements on the screen.
        /// </summary>
        public override void Print()
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
