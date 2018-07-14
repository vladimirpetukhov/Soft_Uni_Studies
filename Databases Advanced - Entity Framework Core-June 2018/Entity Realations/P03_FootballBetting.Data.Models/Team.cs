using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            Players  =new HashSet<Player>();
            HomeGames=new HashSet<Game>();
            AwayGames = new HashSet<Game>(); 
        }

        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Url]
        [Required]
        public string LogoUrl { get; set; }

        [StringLength(3)]
        [Required]
        public string Initials { get; set; }
        
        public decimal Budget { get; set; }

        [ForeignKey("PrimaryKitColor")]
        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }

        [ForeignKey("SecondaryKitColor")]
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }

        [ForeignKey("Town")]
        public int TownId { get; set; }
        public Town Town { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<Game> HomeGames { get; set; }

        public ICollection<Game> AwayGames { get; set; }
    }
}
