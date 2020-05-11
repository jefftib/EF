using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Model
{
   public class Speler
    {
        public int SpelerId {get; set;}
        public string naam {get;set;}
        public int rugnummer {get;set;}
        public double value {get;set;}
        public Team Team {get;set;}


    }
}
