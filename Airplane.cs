using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Aerodrom
{
    class Airplane
    {
        private Airplane[] airplanes;

        SqlConnection connection;

        public int Id { get; internal set; }
        public int BrojMesta { get; set; }
        public int PaketMesto { get; set; }

        public Airplane[] GetAirplanes()
        {
            Konekcija kon = new Konekcija();
            connection = kon.KreirajKonekciju();

            int size, i;

            try
            {
                SqlCommand count = new SqlCommand("SELECT COUNT(*) FROM tblAvion", connection);
                SqlCommand command = new SqlCommand("Select * from tblAvion", connection);

                connection.Open();

                size = (int)count.ExecuteScalar();
                airplanes = new Airplane[size];

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    for (i = 0; dataReader.Read(); i++)
                    {
                        airplanes[i] = new Airplane
                        {
                            Id = (int)dataReader["AvionID"],
                            BrojMesta = (int)dataReader["BrojMesta"],
                            PaketMesto = (int)dataReader["PaketMesto"]
                        };
                    }
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("Greška pri učitavanju aviona!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return airplanes;
        }
    }
}
