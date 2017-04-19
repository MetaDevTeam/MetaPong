
namespace MetaPong.PongElements.DrawElements
{
    using System;

    public class BallOld
    {
        public static int ballPositionX = 5;
        public static int ballPositionY = 5;

        public static void DrawBall()
        {
            PrintPosition.PrintAtPosition(ballPositionX, ballPositionY, 'O');
        }
        public static void SetBallOnStartPosition()
        {
            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = Console.WindowHeight / 2;
        }
    }
}
