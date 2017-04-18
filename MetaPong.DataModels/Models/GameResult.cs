

namespace MetaPong.DataModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class GameResult
    {
        public enum GameResultEnum
        {
            win,
            lose
        }

        public int Id { get; set; }

        public GameResultEnum Result { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
