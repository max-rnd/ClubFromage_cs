﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Model.Business;
using Model.Data;
using WpfClubFromage.viewModel;

namespace WpfClubFromage.viewModel
{
    class viewModelFromage : viewModelBase
    {
        private daoPays vmDaoPays;
        private daoFromage vmDaoFromage;
        private Fromage selectedFromage = new Fromage();
        private Fromage activeFromage = new Fromage();
        private ObservableCollection<Pays> listPays;
        private ObservableCollection<Fromage> listFromages;
        private ICommand updateCommand;
        private ICommand deleteCommand;
        private ICommand imageFileDialogCommand;
        private ICommand createCommand;
        

        #region Constructeur
        public viewModelFromage(daoPays thedaopays, daoFromage thedaofromage)
        {
            vmDaoPays = thedaopays;
            vmDaoFromage = thedaofromage;

            listPays = new ObservableCollection<Pays>(thedaopays.SelectAll());
            listFromages = new ObservableCollection<Fromage>(thedaofromage.SelectAll());

            foreach (Fromage f in listFromages)
            {
                foreach (Pays p in listPays)
                {
                    if (f.PaysOrigine.Nom == p.Nom)
                    {
                        f.PaysOrigine = p;
                    }
                }
            }
        }
        #endregion

        #region Liaison Binding
        public ObservableCollection<Pays> ListPays { get => listPays; set => listPays = value; }
        public ObservableCollection<Fromage> ListFromages { get => listFromages; set => listFromages = value; }
        public Fromage SelectedFromage
        {
            get => selectedFromage;
            set
            {
                if (selectedFromage != value)
                {
                    selectedFromage = value;
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
                    OnPropertyChanged("Name");
                    OnPropertyChanged("Origin");
                    OnPropertyChanged("Creation");
                    OnPropertyChanged("Image");
                    OnPropertyChanged("ImageSource");
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
                    OnPropertyChanged("Name");
                }
            }
        }
        public DateTime Creation
        {
            get => activeFromage.Creation;
            set
            {
                if (activeFromage.Creation != value)
                {
                    activeFromage.Creation = value;
                    OnPropertyChanged("Creation");
                }
            }
        }
        public Pays Origin
        {
            get => activeFromage.PaysOrigine;
            set
            {
                if (activeFromage.PaysOrigine != value)
                {
                    activeFromage.PaysOrigine = value;
                    OnPropertyChanged("Origin");
                }
            }
        }
        public string Image
        {
            get => "D:\\Lab\\ClubFromage_cs\\Wpf\\img\\" + activeFromage.Image;
        }
        public string ImageSource
        {
            get => activeFromage.Image;
            set
            {
                if (activeFromage.Image != value)
                {
                    activeFromage.Image = value;
                    OnPropertyChanged("ImageSource");
                }
            }
        }
        #endregion

        #region Commande (boutons)
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
        public ICommand DeleteCommand
        {
            get
            {
                if (this.deleteCommand == null)
                {
                    this.deleteCommand = new RelayCommand(() => DeleteFromage(), () => true);
                }
                return this.deleteCommand;
            }
        }
        public ICommand ImageFileDialogCommand
        {
            get
            {
                if (this.imageFileDialogCommand == null)
                {
                    this.imageFileDialogCommand = new RelayCommand(() => UploadImage(), () => true);
                }
                return this.imageFileDialogCommand;
            }
        }
        public ICommand CreateCommand
        {
            get
            {
                if (this.createCommand == null)
                {
                    this.createCommand = new RelayCommand(() => CreateFromage(), () => true);
                }
                return this.createCommand;
            }
        }
        #endregion

        #region Action
        private void UpdateFromage()
        {
            if (IsSelected())
            {
                this.vmDaoFromage.update(this.ActiveFromage);
                MessageBox.Show("Le fromage à bien été mis à jour");
            }
        }
        private void DeleteFromage()
        {
            if (IsSelected())
            {
                MessageBox.Show("Test suppr");
                /*this.vmDaoFromage.delete(this.ActiveFromage);*/
            }
        }
        private void UploadImage()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".txt"; // Required file extension 
            fileDialog.Filter = "Text documents (.txt)|*.txt"; // Optional file extensions
            fileDialog.ShowDialog();
        }
        private void CreateFromage()
        {
            Fromage newF = new Fromage();
            newF.Nom = "Nouveau fromage";
            this.ListFromages.Add(newF);
        }
        #endregion

        #region Autre méthode
        private bool IsSelected()
        {
            if (ActiveFromage.Nom != "")
                return true;
            else
            {
                MessageBox.Show("Il faut selectionner un fromage");
                return false;
            }
        }
        #endregion
    }
}