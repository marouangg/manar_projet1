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
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
namespace pr2
{
    public partial class Form2 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
     (
         int nLeftRect,     // x-coordinate of upper-left corner
         int nTopRect,      // y-coordinate of upper-left corner
         int nRightRect,    // x-coordinate of lower-right corner
         int nBottomRect,   // y-coordinate of lower-right corner
         int nWidthEllipse, // height of ellipse
         int nHeightEllipse // width of ellipse
     );
        private readonly MaterialSkinManager materialSkinManager;
        public Form2()
        {
            InitializeComponent();
            
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 15, 15));
            materialMultiLineTextBox21.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, materialMultiLineTextBox21.Width, materialMultiLineTextBox21.Height, 30, 30));
            materialMultiLineTextBox22.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, materialMultiLineTextBox22.Width, materialMultiLineTextBox22.Height, 30, 30));
        }
        static public string hash512(string chaine)
        {
            byte[] textAsByte = Encoding.Default.GetBytes(chaine);

            SHA512 sha512 = SHA512.Create();

            byte[] hash = sha512.ComputeHash(textAsByte);

            return Convert.ToBase64String(hash);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sc = "datasource=localhost;username=root;password=;database=db_menu9_";
            string role = "";
            MySqlConnection cn = new MySqlConnection(sc);
            cn.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `user` WHERE `username`=@user", cn);
            com.Parameters.AddWithValue("@user", materialMultiLineTextBox21.Text);
            MySqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                if (dr["password"].ToString() == hash512(materialMultiLineTextBox22.Text))
                {
                    role = dr["roles"].ToString();

                }
            }

            if (role != "")
            {
                admin_menu1 f = new admin_menu1();
                f.Show();
                this.Hide();
            }
            else
                MessageBox.Show("login or password is incorrect", "login error", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
