using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using MaterialSkin;
using MaterialSkin.Controls;


namespace pr2
{
    public partial class Form1 : MaterialForm
    {
          private readonly MaterialSkinManager materialSkinManager;
        //MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        public Form1()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
           materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            //  materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            // materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue500, Primary.LightBlue500, Primary.Yellow100, Accent.Green100, TextShade.BLACK);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue500, Primary.LightBlue500, Primary.Yellow300, Accent.Green400, TextShade.WHITE);
        }
        MaterialCard m = new MaterialCard();
        private void Form1_Load(object sender, EventArgs e)
        {
            //// materialSkinManager.AddFormToManage();
            // materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            // // Configure color schema
            // materialSkinManager.ColorScheme = new ColorScheme(
            //     Primary.Green400, Primary.Green500,
            //     Primary.Green500, Accent.LightGreen200,
            //     TextShade.WHITE
            // );
            mc_theme.BackColor = Color.Black;
            mc_theme.Visible = false;

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSkinManager.Theme == MaterialSkinManager.Themes.DARK)
            { materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
               // InitializeComponent();
            }


            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                mc_theme.BackColor = Color.Black;
              //  InitializeComponent();
            }
               
        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            mc_theme.Visible = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            mc_theme.Visible = true;
        }

        private void mc_theme_MouseClick(object sender, MouseEventArgs e)
        {
            mc_theme.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            plateforme_menu f = new plateforme_menu();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            scolarite_menu f = new scolarite_menu();
            f.Show();
        }
    }
}