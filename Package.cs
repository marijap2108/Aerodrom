using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aerodrom
{
    public class Package
    {
        private Package[] packages;
        SqlConnection connection;

        public int Id { get; internal set; }
        public string Naziv { get; set; }
        public int KorisikId { get; set; }
        public int VelicinaId { get; set; }


        public Package[] GetPackage()
        {
            Konekcija kon = new Konekcija();
            connection = kon.KreirajKonekciju();

            int size, i;

            SqlCommand count = new SqlCommand("SELECT COUNT(*) FROM tblPaket", connection);
            SqlCommand command = new SqlCommand("Select * from tblPaket", connection);

            try
            {
                connection.Open();
                size = (int)count.ExecuteScalar();
                packages = new Package[size];

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    for (i = 0; dataReader.Read(); i++)
                    {
                        packages[i] = new Package();
                        packages[i].Naziv = dataReader["NazivPaketa"].ToString();
                        packages[i].VelicinaId = (int)dataReader["VelicinaPaketaID"];
                        packages[i].KorisikId = (int)dataReader["KorisnikID"];
                    }
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("Greška pri učitavanju paketa!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return packages;
        }

        public bool SetPackage(string name, int userId, int packageSizeId, int letId)
        {
            Konekcija kon = new Konekcija();
            connection = kon.KreirajKonekciju();
            SqlCommand command = new SqlCommand("Insert into tblPaket(NazivPaketa, KorisnikID, VelicinaPaketaID, LetId) values (@name, @userId, @packageSizeId, @letId)", connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@packageSizeId", packageSizeId);
            command.Parameters.AddWithValue("@letId", letId);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch(SqlException)
            {
                MessageBox.Show("Greška pri čuvanju paketa!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return true;
        }

    }
}
