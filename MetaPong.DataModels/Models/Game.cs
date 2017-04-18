
namespace MetaPong.DataModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Game
    {
        public int Id { get; set; }

        [Required]
        public bool Finished { get; set; }

        public bool ScoreWin { get; set; }

        public int Difference { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
