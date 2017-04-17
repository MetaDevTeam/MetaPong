﻿
using System.ComponentModel.DataAnnotations;

namespace MetaPong.DataModels.Models
{
    public class GameResult
    {
        public enum GameResults
        {
            Win,
            Lose
        }

        public int Id { get; set; }
        
        [Required]
        public GameResults Result { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
