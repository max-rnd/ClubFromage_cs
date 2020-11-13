using System.IO;
using Model.Business;
using CsvHelper;
using System.Globalization;
using System.Collections.Generic;
using System.Data;

namespace Model.Data
{
    public class daoPays
    {
        private DBAL _dbal;
        public daoPays(DBAL dbal)
        {
            _dbal = dbal;
        }
        
        public void insert(Pays p)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val["id"] = p.Id.ToString();
            val["nom"] = "'" + p.Nom.Replace("'", "\\'") + "'";
            _dbal.Insert("pays", val);
        }
        
        public void update(Pays p)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val["Nom"] = "'"+p.Nom.Replace("'", "\\'") +"'";
            _dbal.Update("pays", val, "Id = " + p.Id);
        }
        public void delete(Pays p)
        {
            _dbal.Delete("pays", "Id = " + p.Id);
        }
        public void insertCsvFile(string pathFile, string delimiter)
        {
            using (var reader = new StreamReader(pathFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = delimiter;
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();

                var record = new Pays();
                var records = csv.EnumerateRecords(record);
                foreach (Pays r in records)
                {
                    this.insert(r);
                }
            }
        }
        public List<Pays> SelectAll()
        {
            List<Pays> l = new List<Pays>();
            foreach (DataRow r in _dbal.SelectAll("pays").Rows)
            {
                l.Add(new Pays((int)r["id"], (string)r["nom"]));
            }
            return l;
        }
        public Pays SelectByName(string nom)
        {
            DataRow r = _dbal.SelectByField("pays", "nom like '" + nom + "'").Rows[0];
            return new Pays((int)r["id"], (string)r["nom"]);
        }
        public Pays SelectById(int id)
        {
            DataRow r = _dbal.DataRowSelectById("pays", id);
            return new Pays((int)r["id"], (string)r["nom"]);
        }
    }
}
