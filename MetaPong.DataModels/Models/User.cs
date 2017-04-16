namespace MetaPong.DataModels.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.GameResults = new HashSet<GameResult>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        //TODO: have to count results for win
        public int? WinCount { get; set; }

        //TODO: have to count results for lose
        public int? LoseCount { get; set; }

        public virtual ICollection<GameResult> GameResults { get; set; }
    }
}
