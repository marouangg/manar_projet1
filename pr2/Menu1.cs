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
    public partial class Menu1 : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
       
        /// <summary>
        /// this functio for border radius
        /// </summary>
        /// <param name="nLeftRect"></param>
        /// <param name="nTopRect"></param>
        /// <param name="nRightRect"></param>
        /// <param name="nBottomRect"></param>
        /// <param name="nWidthEllipse"></param>
        /// <param name="nHeightEllipse"></param>
        /// <returns></returns>
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
        //border radius for all panel
         void panel_border_radius()
        {
            //foreach (Control btns in this.Controls)
            //{
            //    if (btns.GetType() == typeof(MaterialCard))
            //    {
            //        MaterialCard btn = (MaterialCard)btns;
            //        btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 30, 30));
            //    }
            //}
           // panel6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel6.Width, panel6.Height, 30, 30));
        }

        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>



        ///<summary>
        ///this for menu slide 
        ///i write all slide menu methode on this summary
        private const int widthSlide = 170;
        private const int widthSlideIcon = 45;
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        
        public void InitializeSetting()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            HideSubMenus();
        }

        private void HideSubMenus()
        {
            PanelSubMenuCatalogo.Visible = false;
            panelSlidMenuParametre.Visible = false;
        }
        private void MoveWindowsMouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenus();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void iconBar_Click(object sender, EventArgs e)
        {
            if (PanelSlideMenu.Width != widthSlideIcon)
            {
                PanelSlideMenu.Width = widthSlideIcon;
                HideSubMenus();
                PanelSlideMenuImage.Visible = false;
            }
            else
            {
                PanelSlideMenu.Width = widthSlide;
                PanelSlideMenuImage.Visible = true;
            }
        }
        private void iconProfile_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelSubMenuCatalogo);
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>




        public Menu1()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue500, Primary.LightBlue500, Primary.Red300, Accent.Cyan700, TextShade.BLACK);

            //this function for panel border radius
            panel_border_radius();

            //this function for the menu slice
            InitializeSetting();

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

        private void iconSettings_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSlidMenuParametre);
        }

        private void materialSwitch1_CheckedChanged_1(object sender, EventArgs e)
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
    }
}
