
namespace MetaPong.Data.ImportData
{
    using MetaPong.DataModels.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Import
    {
        public static void ImportUser(MetaPongContext context, string username)
        {
            //var dataUser = context.Users
            //    .Where(u => u.Username == username)
            //    .FirstOrDefault();

            if (!context.Users.Any(u => u.Username == username))
            {
                var users = new User
                {
                    Username = username
                };

                context.Users.Add(users);

                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine($"{username} already exists!");
            }
        }

        public static List<string> GetUser(MetaPongContext context, string user)
        {
            //var dataUser = context.Users
            //    .Where(u => u.Username == username)
            //    .FirstOrDefault();
            List<string> result = new List<string>();
            string mesege = "";

            if (context.Users.Any(u => u.Username == user))
            {
                mesege = $"{user} Loaded!";

                result.Add(mesege);

                result.Add(user);
            }
            else
            {
                mesege = $"{user} doesn't exist. Please, create one!";

                result.Add(mesege);
            }

            return result;
        }

        public static void ImportGame(MetaPongContext context, bool scoreWin, string username, int scoreDiference)
        {
            var dataUser = context.Users
                .Where(u => u.Username == username)
                .FirstOrDefault();

            var game = new Game
            {
                Finished = true,
                ScoreWin = scoreWin,
                Difference = scoreDiference,
                Date = DateTime.Now,
                UserId = dataUser.Id
            };

            context.Games.Add(game);

            context.SaveChanges();
        }
    }
}
