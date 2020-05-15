using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Model;

namespace UI
{
    class Scenarios
    {
        Dbfunctions dbfunctions = new Dbfunctions();

        //Speler Toevoegen en aanpassen
        public void SpelerToevoegenEnAanpassenScenario() 
        {
            var testspeler = new Speler("nieuwe testspeler", 111, 314, 99);
            dbfunctions.VoegSpelerToe(testspeler);
            testspeler.Naam = "Jeff";
            dbfunctions.UpdateSpeler(testspeler);
           
        }


        //Transfer scenario
        public void TransferScenario() 
        {
            var testspeler = new Speler("transferspeler", 666, 314, 99);
            dbfunctions.VoegSpelerToe(testspeler);
            var testteam = new Team(95, "testteam", "testteam2", "Jeff");
            dbfunctions.VoegTeamToe(testteam);
            Transfer transfer = new Transfer(testspeler.Id, testteam.Stamnummer, 7, 6000);
            dbfunctions.VoegTransferToe(transfer);
           
        }


        
    }
}
