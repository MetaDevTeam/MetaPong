using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaPong.PongElements
{
    public class SetPosition
    {
        public static void SetInitialPosition()
        {
            Player.firstPlayerPosition = Console.WindowHeight / 2 - Player.firstPlayerPadSize / 2;
            Player.secondPlayerPosition = Console.WindowHeight / 2 - Player.secondPlayerPadSize / 2;
            Ball.SetBallOnStartPosition();
        }
    }
}
