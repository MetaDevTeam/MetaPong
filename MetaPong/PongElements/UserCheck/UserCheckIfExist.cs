
namespace MetaPong.PongElements.UserCheck
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserCheckIfExist
    {
        public static void UserCheck(MetaPongContext context, string user)
        {
            if (!context.Users.Any(u => u.Username == user))
            {
                Console.WriteLine($"{user} doesn't Exist.");
            }
            else
            {
                //TODO: .......................
            }
        }
    }
}
