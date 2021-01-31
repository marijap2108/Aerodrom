using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Aerodrom
{
    class Runway
    {
        private Runway[] runways;
        SqlConnection connection;

        public int Id { get; internal set; }
        public string Naziv { get; set; }
        public int Cena { get; set; }

        public Runway[] GetHangars()
        {
            Konekcija kon = new Konekcija();
            connection = kon.KreirajKonekciju();

            int size, i;

            SqlCommand count = new SqlCommand("SELECT COUNT(*) FROM tblPista", connection);
            SqlCommand command = new SqlCommand("Select * from tblPista", connection);

            try
            {
                connection.Open();
                size = (int)count.ExecuteScalar();
                runways = new Runway[size];

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    for (i = 0; dataReader.Read(); i++)
                    {
                        runways[i] = new Runway();
                        runways[i].Id = (int)dataReader["PistaID"];
                        runways[i].Naziv = dataReader["NazivPiste"].ToString();
                        runways[i].Cena = Int32.Parse(dataReader["CenaPiste"].ToString());
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Greška pri učitavanju piste!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return runways;
        }
    }
}
