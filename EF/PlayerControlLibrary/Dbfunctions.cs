using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataLayer
{
    public class Dbfunctions
    {
        //TODO: implement all functions
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
                context.Transfers.Add(transfer);
                context.SaveChanges();
            }
        }

        public void UpdateSpeler(Speler speler)
        { }

        public void UpdateTeam(Team team)
        {
        }


        /*  public Speler SelecteerSpeler(int spelerID) 
            {

            }*/

        public Team SelecteerTeam(int stamnummer)
        {
            Team team = null;
            using (var context = new MyDBContext())
            {

               var  teams = context.Teams.ToList().Where(x => x.Stamnummer == stamnummer);

            }
            return team;
        }
    }

    /*  public Transfer SelecteerTransfer(int transferID) 
       {

       }*/


}




