using System.Configuration;
using System.Data.SqlClient;

namespace Todo.Dao
{
    public class ConexionDB
    {
        protected SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Tarea"].ConnectionString);
    }
}