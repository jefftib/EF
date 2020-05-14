using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model
{
   public class Team
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Stamnummer { get; set; }
        public string Naam { get; set; }
        public string Bijnaam { get; set; }
        public string Trainer { get; set; }
        public List<Speler> Spelers = new List<Speler>();

        public Team(int stamnummer, string naam, string bijnaam, string Trainer) 
        {
            this.Stamnummer = stamnummer;
            this.Naam = naam;
            this.Bijnaam = bijnaam;
            this.Trainer = Trainer;
        }
    }
}
