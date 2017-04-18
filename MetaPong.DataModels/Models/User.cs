
namespace MetaPong.DataModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User 
    {
        public User()
        {
            this.GameResilts = new HashSet<GameResult>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Win { get; set; }

        public int Lose { get; set; }

        public virtual ICollection<GameResult> GameResilts  { get; set; }
    }
}
