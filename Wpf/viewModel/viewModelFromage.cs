using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Model.Business;
using Model.Data;
using WpfClubFromage.viewModel;

namespace WpfClubFromage.viewModel
{
    class viewModelFromage : viewModelBase
    {
        private daoPays vmDaoPays;
        private daoFromage vmDaoFromage;
        private ICommand updateCommand;
        private ObservableCollection<Pays> listPays;
        private ObservableCollection<Fromage> listFromages;
        private Fromage selectedFromage = new Fromage();
        private Fromage activeFromage = new Fromage();

        // Liaison Binding
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
        private void ImageFileDialog()
        {
            MessageBox.Show("Test");
            /*OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                ActiveFromage.Image = openFileDialog.FileName;*/
        }
        private void UpdateFromage()
        {
            this.vmDaoFromage.update(this.ActiveFromage);
            MessageBox.Show("Le fromage à bien été mis à jour");
        }
    }
}