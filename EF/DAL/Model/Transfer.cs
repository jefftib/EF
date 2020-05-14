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

      /*  public Transfer(int SpelerId, int OudeClub, int nieuweClub, int bedrag)
        {
            this.SpelerId = SpelerId;
            this.OudeClubId = OudeClub;
            this.NieuweClubId = nieuweClub;
            this.Prijs = bedrag;
        }*/
       
    }
}
