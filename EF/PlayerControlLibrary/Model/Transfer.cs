using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Model
{
   public class Transfer
    {
        public int TransferId { get; set; }
        public Speler Speler  {get;set;}
        public double Prijs   {get;set;}
        public Team OudeClub  {get;set;}
        public Team NieuweClub{get;set;}
    }
}
