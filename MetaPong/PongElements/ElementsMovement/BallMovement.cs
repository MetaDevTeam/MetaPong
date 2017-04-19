
namespace MetaPong.PongElements.ElementsMovement
{
    using DrawElements;
    using System;
    using PrintElements;

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
                BallOld.ballPositionX++;
            }

            else
            {
                BallOld.ballPositionX--;
            }
        }

        private static void BallDirectionUpAndDown()
        {
            if (ballDirectionUp)
            {
                BallOld.ballPositionY--;
            }

            else
            {
                BallOld.ballPositionY++;
            }
        }

        private static void HitSecondPlayerPad()
        {
            if (BallOld.ballPositionX >= Console.WindowWidth - 4)
            {
                if (BallOld.ballPositionY >= PlayerOld.secondPlayerPosition
                    && BallOld.ballPositionY <= PlayerOld.secondPlayerPosition + PlayerOld.secondPlayerPadSize)
                {
                    ballDirectionRight = false;
                }
            }
        }

        private static void HitFirstPlayerPad()
        {
            if (BallOld.ballPositionX < 3)
            {
                if (BallOld.ballPositionY >= PlayerOld.firstPlayerPosition
                    && BallOld.ballPositionY <= PlayerOld.firstPlayerPosition + PlayerOld.firstPlayerPadSize)
                {
                    ballDirectionRight = true;
                }
            }
        }

        private static void LeftBorder()
        {
            if (BallOld.ballPositionX == 0)
            {
                BallOld.SetBallOnStartPosition();
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
            if (BallOld.ballPositionX == Console.WindowWidth - 1)
            {
                BallOld.SetBallOnStartPosition();
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
            if (BallOld.ballPositionY == 0)
            {
                ballDirectionUp = false;
            }

            if (BallOld.ballPositionY == Console.WindowHeight - 1)
            {
                ballDirectionUp = true;
            }
        }
    }
}
