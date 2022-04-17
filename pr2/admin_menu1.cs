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
namespace pr2
{
    public partial class admin_menu1 : MaterialForm
    {
       
        private readonly MaterialSkinManager materialSkinManager;
        //
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
        //

        //
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(MaterialCard))
                {
                    MaterialCard btn = (MaterialCard)btns;
                    btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 30, 30));
                }
            }
            panel2.Region= Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 10, 10));
           // pictureBox13.Region= Region.FromHrgn(CreateRoundRectRgn(0, 0, pictureBox13.Width, pictureBox13.Height, 60, 60));
        }
        //
        string user_name = "";
        //
        public admin_menu1(string user_name)
        {
            InitializeComponent();
            this.user_name = user_name;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;

            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            //  materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue500, Primary.LightBlue500, Primary.Yellow300, Accent.Green400, TextShade.WHITE);
            // m.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, m.Width, m.Height, 30, 30));
            LoadTheme();
            //materialButton1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, materialButton1.Width, materialButton1.Height, 60, 60));

            //materialScrollBar1.Value = panel1.VerticalScroll.Value;
            //materialScrollBar1.Minimum=panel1.VerticalScroll.Minimum;
            //materialScrollBar1.Maximum = panel1.VerticalScroll.Maximum;
   
        }

        void affiche_luang()
        {
            if (System.Threading.Thread.CurrentThread.CurrentUICulture == System.Globalization.CultureInfo.GetCultureInfo("ar"))
            {
                pic_ar.Visible = false;
            }
            else if (System.Threading.Thread.CurrentThread.CurrentUICulture == System.Globalization.CultureInfo.GetCultureInfo("en"))
            {
                pic_en.Visible = false;
            }
            else 
            {
                pic_fr.Visible = false;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            mc_theme.Visible = false;

            affiche_luang();
           // label41.Text = user_name;
            materialLabel17.Text = label41.Text = user_name;
        }

        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSkinManager.Theme == MaterialSkinManager.Themes.DARK)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                // InitializeComponent();
             
            }


            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                // materialCard1.BackColor = Color.Black;
                // InitializeComponent();
               

            }

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void materialScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //materialScrollBar1.Minimum = panel1.VerticalScroll.Minimum;     
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {

            label5.Font = new Font(label5.Font, FontStyle.Underline);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {

            label5.Font = new Font(label5.Font, 0);
        }
        //
       

        private void label6_MouseHover(object sender, EventArgs e)
        {
            label6.Font = new Font(label6.Font, FontStyle.Underline);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.Font = new Font(label6.Font, 0);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            mc_theme.Visible = true;
        }

        private void mc_theme_MouseClick(object sender, MouseEventArgs e)
        {
            mc_theme.Visible = false;
        }

        private void materialFloatingActionButton2_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            var plateforme_menu = new plateforme_menu(user_name);
            plateforme_menu.Closed += (s, args) => this.Close();
            plateforme_menu.Show();

        }

        private void panel1_ControlRemoved(object sender, ControlEventArgs e)
        {
           
        }

        private void materialScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
           
        }
         int colorSchemeIndex;
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            colorSchemeIndex++;
            if (colorSchemeIndex > 1) colorSchemeIndex = 0;

            //These are just example color schemes
            switch (colorSchemeIndex)
            {
                case 0:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue500, Primary.LightBlue500, Primary.Yellow300, Accent.Green400, TextShade.WHITE);
                    break;
                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
                    break;
                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //colorSchemeIndex++;
            //if (colorSchemeIndex > 2) colorSchemeIndex = 0;

            ////These are just example color schemes
            //switch (colorSchemeIndex)
            //{
            //    case 0:
            //        materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue500, Primary.LightBlue500, Primary.Yellow300, Accent.Green400, TextShade.WHITE);
            //        InitializeComponent();
            //        break;
            //    case 1:
            //        materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
            //        InitializeComponent();
            //        break;
            //    case 2:
            //        materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);
            //        InitializeComponent();
            //        break;
            //}
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("ar");
            this.RightToLeft = RightToLeft.Yes;
           // this.RightToLeftLayout = true;
            
            this.Controls.Clear();
            InitializeComponent();
            affiche_luang();
        }

        private void pic_en_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture =
              System.Globalization.CultureInfo.GetCultureInfo("en");
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            this.Controls.Clear();
            InitializeComponent();
            affiche_luang();
        }

        private void pic_fr_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture =
            System.Globalization.CultureInfo.GetCultureInfo("fr");
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            this.Controls.Clear();
            InitializeComponent();
            affiche_luang();
        }

        private void materialFloatingActionButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            scolarite_menu f = new scolarite_menu();
            f.Show();
        }

        private void materialSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();
            var admin_menu2 = new admin_menu2(user_name);
            admin_menu2.Closed += (s, args) => this.Close();
            admin_menu2.Show();
        }
        //
    }
}
