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

namespace pr2.PlateForme.Cycle
{
    public partial class frm_Cycle : MaterialForm
    {
        cycle_classe cycle = new cycle_classe();
        private readonly MaterialSkinManager materialSkinManager;
        public frm_Cycle()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue500, Primary.LightBlue500, Primary.Yellow300, Accent.Green400, TextShade.WHITE);
           
        }

        private void frm_Cycle_Load(object sender, EventArgs e)
        {

        }

        private void materialExpansionPanel1_SaveClick(object sender, EventArgs e)
        {
            pnl_test.Collapse = false;
            pnl_test.ExpandHeight = 311;
          
        }

        private void materialExpansionPanel1_Click(object sender, EventArgs e)
        {
           

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text == "" || materialMaskedTextBox2.Text == "" || materialMaskedTextBox3.Text == "")
            {
                MessageBox.Show("Required Field - Id no, first name and phone no:", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    int id = 31;
                    int id_user = 11;
                    int id_schole = 73;
                    string name = materialMaskedTextBox1.Text;
                    string arabic_name = materialMaskedTextBox3.Text;
                    DateTime created_at =Convert.ToDateTime( materialMaskedTextBox2.Text);
                    DateTime ede_at =Convert.ToDateTime( materialMaskedTextBox4.Text);
                    

                    Boolean insertGuest = cycle.insertCycle(id,id_schole,id_user,id_user,name,arabic_name,created_at,ede_at);
                    if (insertGuest)
                    {
                        MessageBox.Show("New guest save successfuly", "Guest Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
                        // you can clear all text after the save action
                      
                    }
                    else
                    {
                        MessageBox.Show("ERROR - guest not inserted", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
