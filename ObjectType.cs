using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aerodrom
{
    public class ObjectType
    {
        private ObjectType[] objectTypes;
        SqlConnection connection;

        public int Id { get; internal set; }
        public string Naziv { get; set; }

        public ObjectType[] GetObjectType()
        {
            Konekcija kon = new Konekcija();
            connection = kon.KreirajKonekciju();

            int size, i;

            SqlCommand count = new SqlCommand("SELECT COUNT(*) FROM tblTipObjekta", connection);
            SqlCommand command = new SqlCommand("Select * from tblTipObjekta", connection);

            try
            {
                connection.Open();
                size = (int)count.ExecuteScalar();
                objectTypes = new ObjectType[size];

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    for (i = 0; dataReader.Read(); i++)
                    {
                        objectTypes[i] = new ObjectType();
                        objectTypes[i].Naziv = dataReader["NazivObjekta"].ToString();
                        objectTypes[i].Id = (int)dataReader["TipObjektaID"];
                    }
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("Greška pri učitavanju tipa objekta!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return objectTypes;
        }

    }
}
