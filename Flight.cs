using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aerodrom
{
    class Flight
    {
        SqlConnection connection;

        private Flight[] flights;

        public int Id { get; private set; }
        public string Polazak { get; set; }
        public string Dolazak { get; set; }
        public DateTime VremePolaska { get; set; }
        public DateTime VremeDolaska { get; set; }

        public Flight[] GetFlight()
        {
            Konekcija kon = new Konekcija();
            connection = kon.KreirajKonekciju();

            int size, i;

            SqlCommand count = new SqlCommand("SELECT COUNT(*) FROM tblLet", connection);
            SqlCommand command = new SqlCommand("Select * from tblLet", connection);

            try
            {
                connection.Open();

                size = (int)count.ExecuteScalar();
                flights = new Flight[size];

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    for (i = 0; dataReader.Read(); i++)
                    {
                        flights[i] = new Flight();
                        flights[i].Polazak = dataReader["NazivPolaska"].ToString();
                        flights[i].Dolazak = dataReader["NazivDestinacije"].ToString();
                        flights[i].Id = (int)dataReader["LetID"];
                        flights[i].VremePolaska = (DateTime)dataReader["VremeIDatumPolaska"];
                        flights[i].VremeDolaska = (DateTime)dataReader["VremeIDatumDolaska"];
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Greška pri učitavanju letova!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return flights;
        }

        public bool SetFlight(string nazivPolaska, string nazivDestinacije, DateTime vremePolaska, DateTime vremeDolaska, int userId, int avionId)
        {
            Konekcija kon = new Konekcija();
            connection = kon.KreirajKonekciju();
            SqlCommand command = new SqlCommand("Insert into tblLet(NazivPolaska, NazivDestinacije, VremeIDatumPolaska, VremeIDatumDolaska, AvionID, ZaposleniID) values (@nazivPolaska, @nazivDestinacije, @vremePolaska, @vremeDolaska, @userId, @avionId)", connection);
            command.Parameters.AddWithValue("@nazivPolaska", nazivPolaska);
            command.Parameters.AddWithValue("@nazivDestinacije", nazivDestinacije);
            command.Parameters.AddWithValue("@vremePolaska", vremePolaska);
            command.Parameters.AddWithValue("@vremeDolaska", vremeDolaska);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@avionId", avionId);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Greška pri čuvanju leta!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return true;
        }
    }
}
