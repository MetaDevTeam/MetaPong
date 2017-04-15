using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaPong.PongElements
{
    public class Ball
    {
        public static int ballPositionX = 5;
        public static int ballPositionY = 5;
        public static bool ballDirectionUp = true;
        public static bool ballDirectionRight = true;

        public static void DrawBall()
        {
            PrintElements.PrintAtPosition(ballPositionX, ballPositionY, 'O');
        }
        public static void SetBallOnStartPosition()
        {
            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = Console.WindowHeight / 2;
        }

        public static void MoveBall()
        {
            if (ballPositionY == 0)
            {
                ballDirectionUp = false;
            }

            if (ballPositionY == Console.WindowHeight - 1)
            {
                ballDirectionUp = true;
            }

            if (ballPositionX == Console.WindowWidth - 1)
            {
                SetBallOnStartPosition();
                ballDirectionRight = false;
                ballDirectionUp = true;
                Player.firstPlayerResults++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("First Player Wins!");
                Console.ReadKey();
            }

            if (ballPositionX == 0)
            {
                SetBallOnStartPosition();
                ballDirectionRight = true;
                ballDirectionUp = true;
                Player.secondPlayerResults++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("Second Player Wins!");
                Console.ReadKey();
            }

            if (ballPositionX < 3)
            {
                if (ballPositionY >= Player.firstPlayerPosition
                    && ballPositionY <= Player.firstPlayerPosition + Player.firstPlayerPadSize)
                {
                    ballDirectionRight = true;
                }
            }

            if (ballPositionX >= Console.WindowWidth - 4)
            {
                if (ballPositionY >= Player.secondPlayerPosition
                    && ballPositionY <= Player.secondPlayerPosition + Player.secondPlayerPadSize)
                {
                    ballDirectionRight = false;
                }
            }

            if (ballDirectionUp)
            {
                ballPositionY--;
            }

            else
            {
                ballPositionY++;
            }

            if (ballDirectionRight)
            {
                ballPositionX++;
            }

            else
            {
                ballPositionX--;
            }
        }
    }
}
