using System;
using Model.Business;
using Model.Data;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DBAL dbal = new DBAL("localhost", "club_fromage", "root", "root");


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
