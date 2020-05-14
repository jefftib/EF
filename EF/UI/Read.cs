using System;
using DAL.Model;
using System.Collections.Generic;
using System.Text;
using GenericParsing;
using DataLayer;

namespace UI
{
    class Read
    {
        Dbfunctions dbfunctions = new Dbfunctions();
        public void ReadCsv()
        {
            Dictionary<int, Team> teams = new Dictionary<int, Team>();
            using GenericParser footballParser = new GenericParser(Config.Path + "/" + Config.FileName)
            {
                ColumnDelimiter = ',',
                FirstRowHasHeader = true,
                MaxBufferSize = 4096
            };
           
            while (footballParser.Read())
            {
                var spelernaam = footballParser[0] != null ? footballParser[0].Trim() : "";
                var rugnummer = footballParser[1] != null ? int.Parse(footballParser[1]) : -1;
                var clubNaam = footballParser[2] != null ? footballParser[2].Trim() : "";
               var waarde = footballParser[3] != null ? int.Parse(footballParser[3].Replace(" ", "")) : -1;
                var stamnummer = footballParser[4] != null ? int.Parse(footballParser[4]) : -1;
                var trainer = footballParser[5] != null ? footballParser[5].Trim() : "";
                var bijnaam = footballParser[6] != null ? footballParser[6].Trim() : "";

                var player = new Speler(spelernaam, rugnummer, waarde,stamnummer); ;
                if (teams.ContainsKey(stamnummer)) 
                {
                    teams[stamnummer].Spelers.Add(player);
                }
                else
                {
                    var team = new Team(stamnummer, clubNaam,bijnaam,trainer);
                    team.Spelers.Add(player);
                    teams.TryAdd(team.Stamnummer, team);
                }

            }
            foreach (var t in teams.Values)
            {
                dbfunctions.VoegTeamToe(t);
                foreach (var s in t.Spelers)
                {
                  
                    dbfunctions.VoegSpelerToe(s);
                }
            }
            var appel = new Speler("test", 666, 314, 99);
           
            dbfunctions.VoegSpelerToe(appel);
             appel.Naam = "Jeff";
           
            dbfunctions.UpdateSpeler(appel);
       //     Transfer transfer = new Transfer(1, 7, 35,6000) ;
       //     dbfunctions.VoegTransferToe(transfer);
            var bosbes = new Team(95, "bosbes", "kokosnoot", "Jeff");
            dbfunctions.VoegTeamToe(bosbes);
            bosbes.Naam = "mango";
            dbfunctions.UpdateTeam(bosbes);
           
        }

    }
}
