
namespace MetaPong.Data.ImportData
{
    using MetaPong.DataModels.Models;
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

        public static void ImportGame(MetaPongContext context, bool scoreWin, string username)
        {
            var dataUser = context.Users
                .Where(u => u.Username == username)
                .FirstOrDefault();

            var game = new Game
            {
                Finished = true,
                ScoreWin = scoreWin,
                UserId = dataUser.Id
            };

            context.Games.Add(game);

            context.SaveChanges();
        }
    }
}
