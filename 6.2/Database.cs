
using Microsoft.Data.SqlClient;

namespace QuanLyNhanSu.DAL
{
    public class Database
    {
        private static readonly string connectionString =
            @"Data Source=.;Initial Catalog=HRMDB;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
