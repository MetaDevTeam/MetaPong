
namespace MetaPong.DataModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GameResult
    {
        public enum GameResults
        {
            Win,
            Lose
        }

        public int Id { get; set; }

        
        public GameResults Result { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
