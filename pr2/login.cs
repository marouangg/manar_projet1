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
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;

namespace pr2
{
    using BCrypt;
    public partial class login : MaterialForm
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
        void theme()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            // Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panel1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 25, 25));
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 15, 15));
            btn_invisible.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_invisible.Width, btn_invisible.Height, 30, 30));
            btn_visible.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_visible.Width, btn_visible.Height, 30, 30));
            materialMultiLineTextBox21.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, materialMultiLineTextBox21.Width, materialMultiLineTextBox21.Height, 30, 30));
            materialMultiLineTextBox22.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, materialMultiLineTextBox22.Width, materialMultiLineTextBox22.Height, 30, 30));
        }
        public login()
        {
            InitializeComponent();
            theme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (materialMultiLineTextBox22.PasswordChar == '\0')
            {
                btn_visible.BringToFront();
                btn_invisible.SendToBack();
                materialMultiLineTextBox22.PasswordChar = '*';
            }
        }

        private void btn_visible_Click(object sender, EventArgs e)
        {
            if (materialMultiLineTextBox22.PasswordChar == '*')
            {
                btn_invisible.BringToFront();
                btn_visible.SendToBack();
                materialMultiLineTextBox22.PasswordChar = '\0';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sc = "datasource=localhost;username=root;password=;database=db_manar_demo";
            string role = "";
            string user_name = "";
            MySqlConnection cn = new MySqlConnection(sc);
            cn.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `user` WHERE `username`=@user", cn);
            com.Parameters.AddWithValue("@user", materialMultiLineTextBox21.Text);
            MySqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                if (BCrypt.Net.BCrypt.Verify(materialMultiLineTextBox22.Text, dr["password"].ToString())==true)
                {
                    role = dr["roles"].ToString();
                    user_name = dr["username"].ToString();
                    
                }
            }

            if (role != "")
            {

               // admin_menu1 mm = new admin_menu1(user_name);
               //// admin_menu2 mmm = new admin_menu2(user_name);
               // mm.Show();
               // this.Hide();


                this.Hide();
                var admin_menu1 = new admin_menu1(user_name);
                admin_menu1.Closed += (s, args) => this.Close();
                admin_menu1.Show();
            }
            else
                MessageBox.Show("login or password is incorrect", "login error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pic_ar_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("ar");
            this.RightToLeft = RightToLeft.Yes;
           // this.RightToLeftLayout = true;
            this.Controls.Clear();
            InitializeComponent();
            pictureBox2.Image = Properties.Resources.WhatsApp_Image_2022_04_07_at_23_17_03;
            materialMultiLineTextBox21.TextAlign = HorizontalAlignment.Left;
            materialMultiLineTextBox22.TextAlign = HorizontalAlignment.Left;
            theme();
        
        
        }

        private void pic_fr_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture =
            System.Globalization.CultureInfo.GetCultureInfo("fr");
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            this.Controls.Clear();
            InitializeComponent();
            theme();
        }
    }
}
