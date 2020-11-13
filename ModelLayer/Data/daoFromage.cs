using System;
using System.IO;
using Model.Business;
using CsvHelper;
using System.Globalization;
using System.Collections.Generic;
using System.Data;

namespace Model.Data
{
    public class daoFromage
    {
        private DBAL _dbal;
        private daoPays _daoPays;
        public daoFromage(DBAL dbal)
        {
            _dbal = dbal;
            _daoPays = new daoPays(dbal);
        }
        public void insert(Fromage f)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val["id"] = f.Id.ToString();
            val["pays_origine_id"] = f.PaysOrigine.Id.ToString();
            val["nom"] = "'" + f.Nom.Replace("'", "\\'") + "'";
            val["creation"] = "'" + f.Creation.ToString("yyyy'-'MM'-'dd") + "'";
            val["image"] = "'" + f.Image.Replace("'", "\\'") + "'";
            _dbal.Insert("fromage", val);
        }
        public void update(Fromage f)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val["pays_origine_id"] = f.PaysOrigine.Id.ToString();
            val["nom"] = "'"+f.Nom.Replace("'", "\\'") +"'";
            val["creation"] = "'"+f.Creation.ToString("yyyy'-'MM'-'dd")+"'";
            val["image"] = "'"+f.Image.Replace("'", "\\'") +"'";
            _dbal.Update("fromage", val, "id = " + f.Id);
        }
        public void delete(Fromage f)
        {
            _dbal.Delete("fromage", "id = " + f.Id);
        }
        public void insertCsvFile(string pathFile, string delimiter)
        {
            using (var reader = new StreamReader(pathFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = delimiter;
                csv.Configuration.RegisterClassMap<FromageMap>();
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();

                Fromage record = new Fromage();
                var records = csv.EnumerateRecords(record);
                foreach (Fromage f in records)
                {
                    this.insert(f);
                }
            }
        }
        public List<Fromage> SelectAll()
        {
            List<Fromage> l = new List<Fromage>();
            DataTable tabP = _dbal.SelectAll("Pays");
            DataTable tabF = _dbal.SelectAll("Fromage");
            foreach (DataRow r in tabF.Rows)
            {
                l.Add(new Fromage(
                    (int)r["id"],
                    _daoPays.SelectById((int)r["pays_origine_id"]),
                    (string)r["nom"],
                    (DateTime)r["creation"],
                    (string)r["image"]
                ));
            }
            return l;
        }
        public Fromage SelectById(int id)
        {
            DataRow r = _dbal.DataRowSelectById("Fromage", id);
            return new Fromage(
                (int)r["id"],
                _daoPays.SelectById((int)r["pays_origine_id"]),
                (string)r["nom"],
                (DateTime)r["creation"],
                (string)r["image"]
            );
        }
        public Fromage SelectByName(string nom)
        {
            DataRow r = _dbal.SelectByField("Fromage", "nom = '" + nom + "'").Rows[0];
            return new Fromage(
                (int)r["id"],
                _daoPays.SelectById((int)r["pays_origine_id"]),
                (string)r["nom"],
                (DateTime)r["creation"],
                (string)r["image"]
            );
        }
    }
}
