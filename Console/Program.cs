using System;
using Model.Business;
using Model.Data;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DBAL dbal = new DBAL("club_fromager");

            // Insertion des pays
            daoPays daoP = new daoPays(dbal);
            daoP.insertCsvFile("D:\\Lab\\ClubFromage_cs\\pays.csv", ";");

            // Insertion des fromages
            daoFromage daoF = new daoFromage(dbal);
            daoF.insertCsvFile("D:\\Lab\\ClubFromage_cs\\fromages.csv", ";");

            System.Console.WriteLine("  ---- Fin ----");
        }
    }
}
