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
using System.Data.SqlClient;
using System.Data;



namespace gestion_clients
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QUDI77S\MSSQLSERVER01;Initial Catalog=gestion_clt;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();

        /*public void vider(Control f)
        {
            foreach(Control ct in f.Controls)
            {
                if (ct.GetType()==typeof(TextBox))
                {
                    ct.Text = "";
                }
                if (ct.Controls !== 0)
                {
                    vider(ct);
                }
            }
        }*/
        public MainWindow()
        {
            InitializeComponent();
        }
        Ado d = new Ado();

        

        

        private void btn_check_Click(object sender, RoutedEventArgs e)
        {
            if (id.Text==""|| nom.Text == "" || prenom.Text == "" || ville.Text == "")
            {
                MessageBox.Show("merci de remplir les champ!");
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into clients values(" + id.Text + ",'" + nom.Text + "','" + prenom.Text + "','" + adresse.Text + "','" + ville.Text + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("bien ajouter");
            }
            
        }

        private void btn_modif_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("update clients set nom='" + nom.Text + "',prenom='" + prenom.Text + "',adresse='" + adresse.Text + "',ville='" + ville.Text + "' where id="+id.Text+"", conn);
            cmd1.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("bien modifier");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("delete clients where id=" + id.Text + "", conn);
            cmd1.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("bien supprimer");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            /*if(MessageBox.Show("voulez-vous quitter?", "confirmation", MessageBoxButton.YesNo) == DialogResult.Yes)
            {
                d.deconnecter();
                this.Close();
            }*/
            MessageBox.Show("Fermer");
            d.deconnecter();
            this.Close();
        }
        //remplir data grid 
        private void btn_afficher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                string selectall = "select * from clients";
                SqlCommand cr = new SqlCommand(selectall, conn);              
                SqlDataReader reader = cr.ExecuteReader();
                reader.Close();
                SqlDataAdapter dt_adapt = new SqlDataAdapter(cr);
                DataTable dt = new DataTable("clients");
                dt_adapt.Fill(dt);
                datagr.ItemsSource = dt.DefaultView;
                dt_adapt.Update(dt);
                
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
        }
    }
}
