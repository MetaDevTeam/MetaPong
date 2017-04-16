
namespace MetaPong.PongElements.ElementsMovement
{
    using System;

    class PlayerMovement
    {
        static Random random = new Random();

        public static void MoveFirstPlayerDown()
        {
            if (Player.firstPlayerPosition < Console.WindowHeight - Player.firstPlayerPadSize)
            {
                Player.firstPlayerPosition++;
            }
        }

        public static void MoveFirstPlayerUp()
        {
            if (Player.firstPlayerPosition > 0)
            {
                Player.firstPlayerPosition--;
            }
        }

        public static void MoveSecondPlayerDown()
        {
            if (Player.secondPlayerPosition < Console.WindowHeight - Player.secondPlayerPadSize)
            {
                Player.secondPlayerPosition++;
            }
        }

        public static void MoveSecondPlayerUp()
        {
            if (Player.secondPlayerPosition > 0)
            {
                Player.secondPlayerPosition--;
            }
        }

        public static void MoveSecondPlayerBot()
        {
            int randomNum = random.Next(1, 101);

            if (randomNum <= 60)
            {
                if (BallMovement.ballDirectionUp == true)
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
