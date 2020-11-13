﻿using System;
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
        private ObservableCollection<Fromage> listFromage;
        private Fromage monFromage = new Fromage(1, new Pays(), "Rebloch", new DateTime(), "");

        //déclaration des listes...à compléter avec les fromages
        public ObservableCollection<Pays> ListPays { get => listPays; set => listPays = value; }
        public ObservableCollection<Fromage> ListFromage { get => listFromage; set => listFromage = value; }
        //déclaration des propriétés avec OnPropertyChanged("nom_propriété_bindée")
        //par exemple...
        public string Name
        {
            get => monFromage.Nom;
            set
            {
                if (monFromage.Nom != value)
                {
                    monFromage.Nom = value;
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
            listFromage = new ObservableCollection<Fromage>(thedaofromage.SelectAll());

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