using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;

namespace pr2
{
    public partial class plateforme_menu : MaterialForm
    {
        string user_name = "";
        public plateforme_menu(string user_name)
        {
            InitializeComponent();
            this.user_name = user_name;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        string sc = "datasource=localhost;username=root;password=;database=db_menu9_";
        private void Form4_Load(object sender, EventArgs e)
        {
           // MySqlConnection cn = new MySqlConnection(sc);
           // cn.Open();
           // MySqlCommand com = new MySqlCommand("SELECT  `fisrt_name`, `last_name`, `birth_date`, `adresse`, `phone` FROM `student` ", cn);
           // MySqlDataReader dr = com.ExecuteReader();
           // DataTable table = new DataTable();
           // table.Load(dr);

           //// dataGridView1.DataSource = table;

           // dr.Close();
           // cn.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void materialFloatingActionButton1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //admin_menu1 m = new admin_menu1();
            //m.Show();

            this.Hide();
            var admin_menu1 = new admin_menu1(user_name);
            admin_menu1.Closed += (s, args) => this.Close();
            admin_menu1.Show();
        }
    }
}
