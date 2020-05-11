using System;
using GenericParsing;
using DataLayer.Model;
using System.Collections.Generic;
using System.Text;
using DataLayer;

namespace LeagueApp
{
    class Read
    {
        public void ReadCsv()
        {
            using GenericParser footballParser = new GenericParser(Config.Path + "/" + Config.FileName)
            {
                ColumnDelimiter = ';',
                FirstRowHasHeader = true,
                MaxBufferSize = 4096
            };
            while (footballParser.Read())
            {
                var spelernaam = footballParser[0] != null ? footballParser[0].Trim() : "";
                var rugnummer = footballParser[1] != null ? int.Parse(footballParser[1]) : -1;
                var clubNaam = footballParser[2] != null ? footballParser[2].Trim() : "";
                var waarde = footballParser[3] != null ? double.Parse(footballParser[3]) : -1;
                var stamnummer = footballParser[4] != null ? int.Parse(footballParser[4]) : -1;
                var trainer = footballParser[5] != null ? footballParser[5].Trim() : "";
                var bijnaam = footballParser[6] != null ? footballParser[6].Trim() : "";

              this.CreateTeam(stamnummer, clubNaam,bijnaam,trainer);
                // this.CreatePlayer(spelernaam,rugnummer,waarde,)
                
            }

        }
        public void CreateTeam(int stamnummer, string naam, string bijnaam, string trainer)
        {
            Team t = new Team(stamnummer, naam, bijnaam,trainer);
            Dbfunctions dbfunctions = new Dbfunctions();
            dbfunctions.VoegTeamToe(t);
        }


       
         
       
     /*   public void CreatePlayer(string naam, int rugnummer, double value, Team team) 
        {
            Speler player = new Speler(naam, rugnummer,value,team);
            Dbfunctions dbfunctions = new Dbfunctions();
            dbfunctions.VoegSpelerToe(player);
        }*/
    }
}
