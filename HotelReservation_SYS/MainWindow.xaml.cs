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
using System.Data;
using System.Data.SqlClient;
using HotelReservation_SYS.CustomersDataSetTableAdapters;

namespace HotelReservation_SYS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HotelEntities hotelEntities = new HotelEntities();

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

           

            
            hotelEntities.SP_ADMINLOGINCHECK(txtUsername.Text, txtPassword.Password.ToString(), existingUsername, existingPassword, failedAttempts, blockTime);
            
            if (txtPassword.Password.ToString() == (string)existingPassword.Value)
            {

                MessageBox.Show("Welcome " + txtUsername.Text);
                loginBorder.Visibility = Visibility.Hidden;
                //existingCustBtn.Visibility = Visibility.Hidden;
                
            }

           
        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ObjectParameter custId = new ObjectParameter("o_cust_id", typeof(Int32));
            ObjectParameter forename = new ObjectParameter("o_FORENAME", typeof(string));
            ObjectParameter surname = new ObjectParameter("o_SURNAME", typeof(string));
            ObjectParameter dob = new ObjectParameter("o_DOB", typeof(DateTime));
            ObjectParameter email = new ObjectParameter("o_EMAIL", typeof(string));
            ObjectParameter mobileNo = new ObjectParameter("o_MOBILE_NO", typeof(string));
            ObjectParameter loyalty = new ObjectParameter("o_LOYALTY", typeof(string));


            //CustomersTable

            //hotelEntities.SP_SEARCHEXISTINGCUST(txtExistingCust.Text, custId, forename, surname, dob, email, mobileNo, loyalty);

          

            
           
            
            //MessageBox.Show(txtsearchCustomerName.Text);
            // MessageBox.Show((string)custId.Value);

            


            


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            HotelReservation_SYS.CustomersDataSet customersDataSet = ((HotelReservation_SYS.CustomersDataSet)(this.FindResource("customersDataSet")));
            // Load data into the table CUSTOMERS. You can modify this code as needed.
            HotelReservation_SYS.CustomersDataSetTableAdapters.CUSTOMERSTableAdapter customersDataSetCUSTOMERSTableAdapter = new HotelReservation_SYS.CustomersDataSetTableAdapters.CUSTOMERSTableAdapter();
            customersDataSetCUSTOMERSTableAdapter.Fill(customersDataSet.CUSTOMERS);
            System.Windows.Data.CollectionViewSource cUSTOMERSViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cUSTOMERSViewSource")));
            cUSTOMERSViewSource.View.MoveCurrentToFirst();
            HotelReservation_SYS.adminsTable adminsTable = ((HotelReservation_SYS.adminsTable)(this.FindResource("adminsTable")));
            // Load data into the table ADMINS. You can modify this code as needed.
            HotelReservation_SYS.adminsTableTableAdapters.ADMINSTableAdapter adminsTableADMINSTableAdapter = new HotelReservation_SYS.adminsTableTableAdapters.ADMINSTableAdapter();
            adminsTableADMINSTableAdapter.Fill(adminsTable.ADMINS);
            System.Windows.Data.CollectionViewSource aDMINSViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("aDMINSViewSource")));
            aDMINSViewSource.View.MoveCurrentToFirst();
        }

        private void existingCustGrd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void newCustBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
