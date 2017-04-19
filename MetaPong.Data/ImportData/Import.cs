
namespace MetaPong.Data.ImportData
{
    using MetaPong.DataModels.Models;
    using System.Linq;

    public class Import
    {
        public static void ImportUser(MetaPongContext context, string user)
        {
            var users = new User
            {
                Username = user
            };

            context.Users.Add(users);

            context.SaveChanges();
        }

        public static void ImportGame(MetaPongContext context, bool scoreWin, string user)
        {
            var dataUser = context.Users
                .Where(u => u.Username == user)
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
