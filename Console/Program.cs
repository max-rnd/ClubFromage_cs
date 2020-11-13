using System;
using Model.Business;
using Model.Data;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DBAL dbal = new DBAL("club_fromage");

            //dbal.RQuery("select * from pays where nom like 'France'");

            // Insertion des pays
            daoPays daoP = new daoPays(dbal);
            daoP.insertCsvFile("C:\\Users\\Max\\source\\repos\\ClubFromage\\pays.csv",";");

            // Insertion des fromages
            daoFromage daoF = new daoFromage(dbal);
            daoF.insertCsvFile("C:\\Users\\Max\\source\\repos\\ClubFromage\\fromages.csv", ";");

            System.Console.WriteLine("  ---- Fin ----");
        }
    }
}
