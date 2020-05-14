using DAL;
using DAL.Model;
using System.Linq;

namespace DataLayer
{
    public class Dbfunctions
    {
        public void VoegSpelerToe(Speler speler)
        {
            using var context = new MyDBContext();
            context.Spelers.Add(speler);
            context.SaveChanges();
        }

        public void VoegTeamToe(Team team)
        {
            using (var context = new MyDBContext())
            {
                context.Teams.Add(team);
                context.SaveChanges();

            }
        }

        public void VoegTransferToe(Transfer transfer)
        {
            using (var context = new MyDBContext())
            {
                this.VerwijderSpelerVanTeam(transfer.SpelerId, transfer.OudeClubId); 
                this.VoegSpelerAanTeamToe(transfer.SpelerId,transfer.NieuweClubId); 
                context.Transfers.Add(transfer);
                context.SaveChanges();
            }
        }
        
        public void UpdateSpeler(Speler speler)
                {
                    using (var context = new MyDBContext())
                    {
                    var original = context.Spelers.Find(speler.Id);
                        original.Id = speler.Id;
                        original.Naam = speler.Naam;
                        original.Rugnummer = speler.Rugnummer;
                        original.TeamId = speler.TeamId;
                        context.SaveChanges();
                    }
           
                }

        public void UpdateTeam(Team team)
                {
                    using (var context = new MyDBContext()) 
                    {
                        var original = context.Teams.Find(team.Stamnummer);

                        original.Stamnummer = team.Stamnummer;
                        original.Naam = team.Naam;
                        original.Bijnaam = team.Bijnaam;
                        original.Trainer = team.Trainer;
                        original.Spelers = team.Spelers;
                        context.SaveChanges();

                    }
                }

        public void VoegSpelerAanTeamToe(int spelerId, int stamnummer)
        {
            using (var context = new MyDBContext())
            {
                var player = context.Spelers.ToList().Where(x => x.Id == spelerId).FirstOrDefault();
                var team = context.Teams.ToList().Where(x => x.Stamnummer == stamnummer).FirstOrDefault();
                team.Spelers.Add(player);
                player.TeamId = team.Stamnummer;

            }
        }

        public void VerwijderSpelerVanTeam(int spelerId, int stamnummer)
        {
            using (var context = new MyDBContext())
            {
                var player = context.Spelers.ToList().Where(x => x.Id == spelerId).FirstOrDefault();
                var team  = context.Teams.ToList().Where(x => x.Stamnummer == stamnummer).FirstOrDefault();
                team.Spelers.Remove(player);
                player.TeamId = 0;

            }
        }

        public Speler SelecteerSpeler(int spelerID)
        {
            Speler speler = null;
            using (var context = new MyDBContext())
            {

                speler = context.Spelers.ToList().Where(x => x.Id == spelerID).FirstOrDefault();

            }
            return speler;
        }

        public Team SelecteerTeam(int stamnummer)
        {
            Team team = null;
            using (var context = new MyDBContext())
            {

                team = context.Teams.ToList().Where(x => x.Stamnummer == stamnummer).FirstOrDefault();

            }
            return team;
        }


        public Transfer SelecteerTransfer(int transferID)
        {
            Transfer transfer = null;
            using (var context = new MyDBContext())
            {

                transfer = context.Transfers.ToList().Where(x => x.Id == transferID).FirstOrDefault();

            }
            return transfer;

        }


    }
}