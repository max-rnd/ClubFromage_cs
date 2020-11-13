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

            daoFromage daoF = new daoFromage(dbal);
            foreach (Fromage f in daoF.SelectAll())
            {
                System.Console.WriteLine(f.Nom);
            }

            System.Console.WriteLine("  ---- Fin ----");
        }
    }
}
