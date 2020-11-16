using System;

namespace Model.Business
{
    public class Fromage
    {
        private int _id;
        private Pays _pays_origine;
        private string _nom;
        private DateTime _creation;
        private string _image;

        public Fromage(int id, Pays pays_origine, string nom, DateTime creation, string image)
        {
            _id = id;
            _pays_origine = pays_origine;
            _nom = nom;
            _creation = creation;
            _image = image;
        }
        public Fromage()
        {
            
        }
        public int Id { get => _id; set => _id = value; }
        public Pays PaysOrigine { get => _pays_origine; set => _pays_origine = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public DateTime Creation { get => _creation; set => _creation = value; }
        public string Image { get => _image; set => _image = value; }

        public override string ToString()
        {
            return this._nom + " => " + this._pays_origine.Nom;
        }
    }
}
