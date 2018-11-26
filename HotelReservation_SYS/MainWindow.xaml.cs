using System;
using System.Collections.Generic;
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
using System.Data.Entity.Core.Objects;

namespace HotelReservation_SYS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObjectParameter existingUsername = new ObjectParameter("GET_EXISTING_USERNAME", typeof(string));
            ObjectParameter existingPassword = new ObjectParameter("GET_EXISTING_PASSWORD", typeof(string));
            ObjectParameter failedAttempts = new ObjectParameter("GET_FAILED_ATTEMPTS", typeof(Int16));
            ObjectParameter blockTime = new ObjectParameter("GET_BLOCKTIME", typeof(DateTime));

            HotelEntities hotelEntities = new HotelEntities();
            hotelEntities.SP_ADMINLOGINCHECK(txtUsername.Text, txtPassword.Password.ToString(), existingUsername, existingPassword, failedAttempts, blockTime);
        }
    }
}
