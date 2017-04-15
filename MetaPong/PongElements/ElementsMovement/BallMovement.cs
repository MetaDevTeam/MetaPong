
namespace MetaPong.PongElements.ElementsMovement
{
    using MetaPong.PongElements.DrawElements;
    using System;

    public class BallMovement
    {
        public static bool ballDirectionUp = true;
        public static bool ballDirectionRight = true;

        public static void MoveBall()
        {
            UpAndDownBorder();
            RightBorder();
            LeftBorder();
            HitFirstPlayerPad();
            HitSecondPlayerPad();
            BallDirectionUpAndDown();
            BallDirectionRightAndLeft();
        }

        private static void BallDirectionRightAndLeft()
        {
            if (ballDirectionRight)
            {
                Ball.ballPositionX++;
            }

            else
            {
                Ball.ballPositionX--;
            }
        }

        private static void BallDirectionUpAndDown()
        {
            if (ballDirectionUp)
            {
                Ball.ballPositionY--;
            }

            else
            {
                Ball.ballPositionY++;
            }
        }

        private static void HitSecondPlayerPad()
        {
            if (Ball.ballPositionX >= Console.WindowWidth - 4)
            {
                if (Ball.ballPositionY >= Player.secondPlayerPosition
                    && Ball.ballPositionY <= Player.secondPlayerPosition + Player.secondPlayerPadSize)
                {
                    ballDirectionRight = false;
                }
            }
        }

        private static void HitFirstPlayerPad()
        {
            if (Ball.ballPositionX < 3)
            {
                if (Ball.ballPositionY >= Player.firstPlayerPosition
                    && Ball.ballPositionY <= Player.firstPlayerPosition + Player.firstPlayerPadSize)
                {
                    ballDirectionRight = true;
                }
            }
        }

        private static void LeftBorder()
        {
            if (Ball.ballPositionX == 0)
            {
                Ball.SetBallOnStartPosition();
                ballDirectionRight = true;
                ballDirectionUp = true;
                PrintResults.secondPlayerResults++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("Second Player Wins!");
                Console.ReadKey();
            }
        }

        private static void RightBorder()
        {
            if (Ball.ballPositionX == Console.WindowWidth - 1)
            {
                Ball.SetBallOnStartPosition();
                ballDirectionRight = false;
                ballDirectionUp = true;
                PrintResults.firstPlayerResults++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("First Player Wins!");
                Console.ReadKey();
            }
        }

        private static void UpAndDownBorder()
        {
            if (Ball.ballPositionY == 0)
            {
                ballDirectionUp = false;
            }

            if (Ball.ballPositionY == Console.WindowHeight - 1)
            {
                ballDirectionUp = true;
            }
        }
    }
}
