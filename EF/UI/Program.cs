using System;


namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Read reader = new Read();
            reader.ReadCsv();
            Scenarios scenarios = new Scenarios();
            scenarios.SpelerToevoegenEnAanpassenScenario();
            scenarios.TransferScenario();
            
        }
    }
}
