using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_system
{
    class clssetting
    {
        static string path = Path.GetFullPath(Environment.CurrentDirectory);
        static string databaseName = "school.mdf";
        public static SqlConnection cn = new SqlConnection(@"Data Source=(localdb)\school;AttachDbFilename=" + path + @"\" + databaseName + ";Integrated Security=True");

    }
}
