namespace pr2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
          // Application.Run(new admin_menu2());

         //  Application.Run(new login());
         Application.Run(new PlateForme.Cycle.frm_Cycle());

            // admin_menu2 f = new admin_menu2();


            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            ////Application.Run(new Menu());
            ////splash s = new splash();
            ////s.Show();
            ////Application.Run();

            ////frm_Animated s = new frm_Animated();
            ////s.Show();
            ////Application.Run();

            //Form1 s = new Form1();
            //s.Show();
            //Application.Run();
            //admin_menu1 admin_Menu1 = new admin_menu1();
            //admin_Menu1.Show();
            //Application.Run();
        }
    }
}