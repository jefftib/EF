using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Transfer
    {
        public int Id { get; set; }
        public int SpelerId { get; set; }
        public int OudeClubId { get; set; }
        public int NieuweClubId { get; set; }
        public int Prijs { get; set; }

        public Transfer(int SpelerId, int OudeClubId,int NieuweClubId, int Prijs) 
        {
            this.SpelerId = SpelerId;
            this.OudeClubId = OudeClubId;
            this.NieuweClubId = NieuweClubId;
            this.Prijs = Prijs;
        }
       
    }
}
