using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aerodrom
{
    public class Rent
    {
        SqlConnection connection;

        public int Id { get; internal set; }
        public int ObjectId { get; set; }
        public int ObjectTypeId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }

        public bool SetRent(int objectId, int userId, int objectTypeId, DateTime startDate, DateTime dueDate)
        {
            Konekcija kon = new Konekcija();
            connection = kon.KreirajKonekciju();
            SqlCommand command = new SqlCommand("Insert into tblZakup(ObjekatID, KorisnikID, PocetakZakupa, KrajZakupa, TipObjektaID) values (@objectId, @userId, @startDate, @dueDate, @objectTypeId)", connection);
            command.Parameters.AddWithValue("@objectId", objectId);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@startDate", startDate);
            command.Parameters.AddWithValue("@dueDate", dueDate);
            command.Parameters.AddWithValue("@objectTypeId", objectTypeId);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Greška pri čuvanju zakupa!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return true;
        }

    }
}
