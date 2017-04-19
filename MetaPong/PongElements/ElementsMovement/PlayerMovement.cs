
namespace MetaPong.PongElements.ElementsMovement
{
    using System;
    using DrawElements;

    class PlayerMovement
    {
        private static Random _random = new Random();
        private static Player _bot;

        public PlayerMovement(Player bot)
        {
            _bot = bot;
        }

        //public static void MoveFirstPlayerDown()
        //{
        //    if (Player.firstPlayerPosition < Console.WindowHeight - Player.firstPlayerPadSize)
        //    {
        //        Player.firstPlayerPosition++;
        //    }
        //}

        //public static void MoveFirstPlayerUp()
        //{
        //    if (Player.firstPlayerPosition > 0)
        //    {
        //        Player.firstPlayerPosition--;
        //    }
        //}

        //public static void MoveSecondPlayerDown()
        //{
        //    if (Player.secondPlayerPosition < Console.WindowHeight - Player.secondPlayerPadSize)
        //    {
        //        Player.secondPlayerPosition++;
        //    }
        //}

        //public static void MoveSecondPlayerUp()
        //{
        //    if (Player.secondPlayerPosition > 0)
        //    {
        //        Player.secondPlayerPosition--;
        //    }
        //}

        public static void MoveSecondPlayerBot()
        {
            int randomNum = _random.Next(1, 101);

            if (randomNum <= 60)
            {
                if (BallMovement.ballDirectionUp == true)
                {
                    _bot.MoveUp();
                }

                else
                {
                    _bot.MoveDown();
                }
            }
        }
    }
}
