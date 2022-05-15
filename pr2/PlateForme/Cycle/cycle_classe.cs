using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace pr2.PlateForme.Cycle
{
     class cycle_classe
    {
        dbConnection connect = new dbConnection();


        // create a function to insert a new guest
        public bool insertCycle(int id,int id_schol,int createdBy_id,int edited_by_id, string name, string arabic_name, DateTime created_at, DateTime edited_at)
        {
            string insertQuerry = "INSERT INTO `cycle` (`id`, `school_id`, `created_by_id`, `edited_by_id`, `name`, `arabic_name`, `created_at`, `edited_at`) VALUES(@id,@school_id,@created_by_id,@edited_by_id,@n,@arabic_n,@created_at,@edited_at)";
            MySqlCommand command = new MySqlCommand(insertQuerry, connect.GetConnection());
            //@id,@fname,@lname,@ph,@ct
           
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@school_id", id_schol);
            command.Parameters.AddWithValue("@edited_at", edited_at);
            command.Parameters.AddWithValue("@created_at", created_at);
            command.Parameters.AddWithValue("@arabic_n", arabic_name);
            command.Parameters.AddWithValue("@n", name);
            command.Parameters.AddWithValue("@edited_by_id", edited_by_id);
            command.Parameters.AddWithValue("@created_by_id", createdBy_id);
            
            connect.OpenCon();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.CloseCon();
                return true;
            }
            else
            {
                connect.CloseCon();
                return false;
            }

        }
    }
}
