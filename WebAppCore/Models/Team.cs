using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCore.Models
{
    public class Team
    {
        [Key]
        public string ID { get; set; }
        [MaxLength(30)]
        public string TeamName { get; set; }

        public string City { get; set; }

        public string  Country { get; set; }


        public List<Player> Players { get; set; }

    }
}
