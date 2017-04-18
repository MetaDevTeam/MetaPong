
namespace MetaPong.DataModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User 
    {
        public User()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        [MinLength(3), MaxLength(15), Required]
        public string Username { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
