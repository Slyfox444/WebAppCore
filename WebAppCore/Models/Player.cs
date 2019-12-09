using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCore.Models
{
    public class Player
    {
        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }


        public string TeamName { get; set; }
        public Team Team { get; set; }
    }
}
