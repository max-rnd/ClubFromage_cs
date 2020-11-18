using Model.Business;
using CsvHelper;
using CsvHelper.TypeConversion;
using CsvHelper.Configuration;

namespace Model.Data
{
    public class PaysConverter : DefaultTypeConverter
    {
        private DBAL _dbal;
        public PaysConverter()
        {
            _dbal = new DBAL("club_fromager");
        }
        public override object ConvertFromString(string t, IReaderRow row, MemberMapData memberMapData)
        {
            daoPays daoP = new daoPays(_dbal);
            return daoP.SelectByName(t);
        }

        // public string ConvertToString(Pays p, IWriterRow row, MemberMapData memberMapData)
        // {
        //     return p.Id + ";" + p.Nom;
        // }
    }
}