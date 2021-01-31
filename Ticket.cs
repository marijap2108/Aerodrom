using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Aerodrom
{
    class Ticket
    {
        SqlConnection connection;

        public bool SetTicket(int letId, int userId)
        {
            Konekcija kon = new Konekcija();
            connection = kon.KreirajKonekciju();
            SqlCommand command = new SqlCommand("Insert into tblKarta(KorisnikID, LetID, VremeIzdavanja) values (@userId, @letId, @dateNow)", connection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@letId", letId);
            command.Parameters.AddWithValue("@datenow", DateTime.Now);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Greška pri čuvanju karte!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return true;
        }
    }
}
