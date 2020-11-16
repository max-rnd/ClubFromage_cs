using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model.Business;
using Model.Data;
using WpfClubFromage.viewModel;

namespace WpfClubFromage.viewModel
{
    class viewModelFromage : viewModelBase
    {
        //déclaration des attributs ...à compléter
        private daoPays vmDaoPays;
        private daoFromage vmDaoFromage;
        private ICommand updateCommand;
        private ObservableCollection<Pays> listPays;
        private ObservableCollection<Fromage> listFromages;
        private Fromage selectedFromage = new Fromage();
        private Fromage activeFromage = new Fromage();

        //déclaration des listes...à compléter avec les fromages
        public ObservableCollection<Pays> ListPays { get => listPays; set => listPays = value; }
        public ObservableCollection<Fromage> ListFromages { get => listFromages; set => listFromages = value; }
        //public Fromage SelectedFromage { get => selectedFromage; set => selectedFromage = value; }
        //déclaration des propriétés avec OnPropertyChanged("nom_propriété_bindée")
        //par exemple...
        public Fromage SelectedFromage
        {
            get => selectedFromage;
            set
            {
                if (selectedFromage != value)
                {
                    selectedFromage = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("SelectedFromage");
                    if (selectedFromage != null)
                    {
                        ActiveFromage = selectedFromage;
                    }
                }
            }
        }
        public Fromage ActiveFromage
        {
            get => activeFromage;
            set
            {
                if (activeFromage != value)
                {
                    activeFromage = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Name
        {
            get => activeFromage.Nom;
            set
            {
                if (activeFromage.Nom != value)
                {
                    activeFromage.Nom = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Name");
                }
            }
        }


        //déclaration du contructeur de viewModelFromage
        public viewModelFromage(daoPays thedaopays, daoFromage thedaofromage)
        {
            vmDaoPays = thedaopays;
            vmDaoFromage = thedaofromage;

            listPays = new ObservableCollection<Pays>(thedaopays.SelectAll());
            listFromages = new ObservableCollection<Fromage>(thedaofromage.SelectAll());

        }

        //Méthode appelée au click du bouton UpdateCommand
        public ICommand UpdateCommand
        {
            get
            {
                if (this.updateCommand == null)
                {
                    this.updateCommand = new RelayCommand(() => UpdateFromage(), () => true);
                }
                return this.updateCommand;

            }

        }

        private void UpdateFromage()
        {
            //code du bouton - à coder

        }
    }
}