using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aerodrom
{
    public class Hangar
    {
        private Hangar[] hangars;
        SqlConnection connection;

        public int Id { get; internal set; }
        public string Naziv { get; set; }
        public int Cena { get; set; }
        public int Povrsina { get; set; }

        public Hangar[] GetHangars()
        {
            Konekcija kon = new Konekcija();
            connection = kon.KreirajKonekciju();

            int size, i;

            SqlCommand count = new SqlCommand("SELECT COUNT(*) FROM tblHangar", connection);
            SqlCommand command = new SqlCommand("Select * from tblHangar", connection);

            try
            {
                connection.Open();
                size = (int)count.ExecuteScalar();
                hangars = new Hangar[size];

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    for (i = 0; dataReader.Read(); i++)
                    {
                        hangars[i] = new Hangar();
                        hangars[i].Id = (int)dataReader["HangarID"];
                        hangars[i].Naziv = dataReader["NazivHangara"].ToString();
                        hangars[i].Cena = Int32.Parse(dataReader["CenaHangara"].ToString());
                        hangars[i].Povrsina = Int32.Parse(dataReader["PovrsinaHangara"].ToString());
                    }
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("Greška pri učitavanju hangara!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return hangars;
        }

    }
}
