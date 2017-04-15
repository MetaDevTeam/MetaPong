using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaPong.PongElements
{
    public class Player
    {
        public static int firstPlayerPadSize = 7;
        public static int secondPlayerPadSize = 7;
        public static int firstPlayerPosition = 5;
        public static int secondPlayerPosition = 5;
        public static int firstPlayerResults = 0;
        public static int secondPlayerResults = 0;
        static Random random = new Random();

        public static void DrawFirstPlayer()
        {
            for (int y = firstPlayerPosition; y < firstPlayerPosition + firstPlayerPadSize; y++)
            {
                PrintElements.PrintAtPosition(0, y, '[');
                PrintElements.PrintAtPosition(1, y, ']');
            }
        }

        public static void DrawSecondPlayer()
        {
            for (int y = secondPlayerPosition; y < secondPlayerPosition + secondPlayerPadSize; y++)
            {
                PrintElements.PrintAtPosition(Console.WindowWidth - 1, y, ']');
                PrintElements.PrintAtPosition(Console.WindowWidth - 2, y, '[');
            }
        }

        public static void MoveFirstPlayerDown()
        {
            if (firstPlayerPosition < Console.WindowHeight - firstPlayerPadSize)
            {
                firstPlayerPosition++;
            }
        }

        public static void MoveFirstPlayerUp()
        {
            if (firstPlayerPosition > 0)
            {
                firstPlayerPosition--;
            }
        }

        public static void MoveSecondPlayerDown()
        {
            if (secondPlayerPosition < Console.WindowHeight - secondPlayerPadSize)
            {
                secondPlayerPosition++;
            }
        }

        public static void MoveSecondPlayerUp()
        {
            if (secondPlayerPosition > 0)
            {
                secondPlayerPosition--;
            }
        }

        public static void MoveSecondPlayerBot()
        {
            int randomNum = random.Next(1, 101);

            if (randomNum <= 60)
            {
                if (Ball.ballDirectionUp == true)
                {
                    MoveSecondPlayerUp();
                }

                else
                {
                    MoveSecondPlayerDown();
                }
            }
        }
    }
}
