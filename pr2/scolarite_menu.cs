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
    public partial class scolarite_menu : MaterialForm
    {
        public scolarite_menu()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.DeepOrange200, Primary.DeepOrange200, Primary.DeepOrange200, Accent.LightBlue200, TextShade.WHITE);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
