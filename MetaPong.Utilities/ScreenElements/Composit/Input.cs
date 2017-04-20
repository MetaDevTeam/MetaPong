
namespace MetaPong.Utilities.ScreenElements.Composit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Input : Alert
    {
        private int _fildSize;

        public Input(int row, int column, string text, int fildSize) : base(row, column, text)
        {
            _fildSize = fildSize;

            Elements[0] = Composer.GetBox(
               text.Length + 6 + fildSize,
               5,
               row - 2, column - (text.Length / 2) - 3);
        }
    }
}
