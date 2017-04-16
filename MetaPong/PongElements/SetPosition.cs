
namespace MetaPong.PongElements
{
    using MetaPong.PongElements.DrawElements;
    using System;

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
