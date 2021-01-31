using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aerodrom
{
    public class PackageSize
    {
        private PackageSize[] packageSizes;
        SqlConnection connection;

        public string Naziv { get; set; }
        public int Zapremina { get; set; }
        public int Tezina { get; set; }
        public int Id { get; set; }
        public string VrednostVelicine { get; set; }
        public bool Lomljivost { get; internal set; }

        public PackageSize[] GetPackageSize()
        {
            Konekcija kon = new Konekcija();
            connection = kon.KreirajKonekciju();

            int size, i;

            SqlCommand count = new SqlCommand("SELECT COUNT(*) FROM tblVelicinaPaketa", connection);
            SqlCommand command = new SqlCommand("Select * from tblVelicinaPaketa", connection);

            try
            {
                connection.Open();
                size = (int)count.ExecuteScalar();
                packageSizes = new PackageSize[size];

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    for (i = 0; dataReader.Read(); i++)
                    {
                        packageSizes[i] = new PackageSize();
                        packageSizes[i].Naziv = dataReader["NazivVelicine"].ToString();
                        packageSizes[i].Zapremina = (int)dataReader["MaxZapremina"];
                        packageSizes[i].Tezina = (int)dataReader["MaxTezina"];
                        packageSizes[i].VrednostVelicine = dataReader["VrednostVelicine"].ToString();
                        packageSizes[i].Lomljivost = (bool)dataReader["Lomljivo"];
                        packageSizes[i].Id = (int)dataReader["VelicinaPaketaID"];
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Greška pri učitavanju veličine paketa!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return packageSizes;
        }

    }
}
