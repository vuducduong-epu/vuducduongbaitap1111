
using Microsoft.Data.SqlClient;

namespace QuanLyBanHang
{
    public class Database
    {
        private static string connectionString =
            @"Data Source=.;Initial Catalog=BanHangDB;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
