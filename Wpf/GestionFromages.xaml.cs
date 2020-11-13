using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ModelLayer.Business;
using ModelLayer.Data;

namespace WpfClubFromage
{
    /// <summary>
    /// Interaction logic for GestionFromages.xaml
    /// </summary>
    public partial class GestionFromages : Window
    {
        
        public GestionFromages(DaoPays thedaopays, DaoFromage thedaofromage)
        {
            InitializeComponent();
            mainGrid.DataContext = new viewModel.viewModelFromage(thedaopays, thedaofromage);            
            
        }
    }
}
