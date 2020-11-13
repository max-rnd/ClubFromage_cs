using Model.Business;
using CsvHelper.Configuration;

namespace Model.Data
{
    public class FromageMap : ClassMap<Fromage> 
    {
        public FromageMap()
        {
            Map(m => m.Id);
            Map(m => m.Nom);
            Map(m => m.PaysOrigine).TypeConverter<PaysConverter>();
            Map(m => m.Creation);
            Map(m => m.Image);
        }
    }
}