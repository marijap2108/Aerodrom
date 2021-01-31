using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aerodrom
{
    public class User
    {
        SqlConnection connection;

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Id { get; private set; }
        public string Ime { get; internal set; }
        public string Prezime { get; internal set; }
        public string Kontakt { get; internal set; }
        public string Jmbg { get; internal set; }
        public bool isOWner { get; internal set; }

        public string GetUser(string email, string password, bool isOWner)
        {
            Konekcija kon = new Konekcija();
            User user = new User();
            connection = kon.KreirajKonekciju();
            SqlCommand command;
            if (isOWner)
            {
                command = new SqlCommand("Select ImeZap as Ime, PrezimeZap as Prezime, JMBGZap as JMBG, KontaktZap as Kontakt, EmailZap as Email, ZaposleniID as Id, Password from tblZaposleni where EmailZap=@email", connection);
            } 
            else
            {
                command = new SqlCommand("Select Ime, Prezime, JMBG, Kontakt, Email, KorisnikPass as Password, KorisnikID as Id from tblKorisnik where Email=@email", connection);
            }
            command.Parameters.AddWithValue("@email", email);

            try
            {
                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        user.Ime = dataReader["Ime"].ToString();
                        user.Prezime = dataReader["Prezime"].ToString();
                        user.Email = dataReader["Email"].ToString();
                        user.Kontakt = dataReader["Kontakt"].ToString();
                        user.Jmbg = dataReader["JMBG"].ToString();
                        user.Password = dataReader["Password"].ToString();
                        user.Id = (int)dataReader["Id"];
                        user.isOWner = isOWner;
                    }

                }

                if (user.Email == null)
                {
                    return "Email_Error";
                }

                if (!VerifyHash(password, user.Password))
                {
                    return "Password_Error";

                }

                ((MainWindow)Application.Current.MainWindow).SetCurrentUser(user);
            }
            catch (SqlException)
            {
                MessageBox.Show("Greška pri učitavanju podataka!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return "OK";
        }

        public void GetUserByID(int id, bool isOwner)
        {
            Konekcija kon = new Konekcija();
            User user = new User();
            connection = kon.KreirajKonekciju();
            SqlCommand command;
            if (isOwner)
            {
                command = new SqlCommand("Select ImeZap as Ime, PrezimeZap as Prezime, JMBGZap as JMBG, KontaktZap as Kontakt, EmailZap as Email, ZaposleniID as Id, Password from tblZaposleni where ZaposleniID = @id", connection);
            }
            else
            {
                command = new SqlCommand("Select Ime, Prezime, JMBG, Kontakt, Email, KorisnikPass as Password, KorisnikID as Id from tblKorisnik where KorisnikID = @id", connection);

            }
            command.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        user.Ime = dataReader["Ime"].ToString();
                        user.Prezime = dataReader["Prezime"].ToString();
                        user.Email = dataReader["Email"].ToString();
                        user.Kontakt = dataReader["Kontakt"].ToString();
                        user.Jmbg = dataReader["JMBG"].ToString();
                        user.Password = dataReader["Password"].ToString();
                        user.Id = (int)dataReader["Id"];
                    }
                }

                ((MainWindow)Application.Current.MainWindow).SetCurrentUser(user);
            }
            catch (SqlException)
            {
                MessageBox.Show("Greška pri učitavanju podataka!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool SetUser(string ime, string prezime, string jmbg, string kontakt, string email, string password, bool isOwner)
        {
            Konekcija kon = new Konekcija();
            User user = new User();
            connection = kon.KreirajKonekciju();
            SqlCommand command;
            if (isOwner)
            {
                command = new SqlCommand("Select * from tblZaposleni where EmailZap=@email", connection);
            }
            else
            {
                command = new SqlCommand("Select * from tblKorisnik where Email=@email", connection);
            }
            command.Parameters.AddWithValue("@email", email);

            SqlCommand command2;
            if (isOwner)
            {
                command2 = new SqlCommand("Insert into tblZaposleni(ImeZap, PrezimeZap, JMBGZap, KontaktZap, EmailZap, Password, Username, PozicijaID) values (@ime, @prezime, @jmbg, @kontakt, @email, @password, @email, (Select Top 1 PozicijaID from tblPozicija))", connection);

            }
            else
            {
                command2 = new SqlCommand("Insert into tblKorisnik(Ime, Prezime, JMBG, Kontakt, Email, KorisnikPass) values (@ime, @prezime, @jmbg, @kontakt, @email, @password)", connection);

            }
            command2.Parameters.AddWithValue("@ime", ime);
            command2.Parameters.AddWithValue("@prezime", prezime);
            command2.Parameters.AddWithValue("@jmbg", jmbg);
            command2.Parameters.AddWithValue("@kontakt", kontakt);
            command2.Parameters.AddWithValue("@email", email);
            command2.Parameters.AddWithValue("@password", Hash(password, null));


                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        user.Email = dataReader["email"].ToString();
                    }

                }

                if (user.Email != null)
                {
                    return false;
                }

                command2.ExecuteNonQuery();
                command2.Dispose();



            return true;
        }

        public bool UpdateUser (string ime, string prezime, string jmbg, string kontakt, string email, string password, string id, bool isOwner) 
        {
            Konekcija kon = new Konekcija();
            connection = kon.KreirajKonekciju();
            string com = "UPDATE";
            if (isOwner)
            {
                com += " tblZaposleni SET ImeZap ='" + ime + "', PrezimeZap ='" + prezime + "', JMBGZap ='" + jmbg + "'";

                if (kontakt.Length > 0)
                {
                    com += ", KontaktZap ='" + kontakt + "'";
                }
                if (email.Length > 0)
                {
                    com += ", EmailZap ='" + email + "'";
                }

                if (password.Length > 0)
                {
                    com += ", Password = '" + Hash(password, null) + "'";
                }

                com += " WHERE ZaposleniID =" + id;

            }
            else
            {
                com += " tblKorisnik SET Ime ='" + ime + "', Prezime ='" + prezime + "', JMBG ='" + jmbg + "'";

                if (kontakt.Length > 0)
                {
                    com += ", Kontakt ='" + kontakt + "'";
                }
                if (email.Length > 0)
                {
                    com += ", Email ='" + email + "'";
                }

                if (password.Length > 0)
                {
                    com += ", KorisnikPass = '" + Hash(password, null) + "'";
                }

                com += " WHERE KorisnikID =" + id;
            }

            SqlCommand command = new SqlCommand(com, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Greška pri izmeni podataka!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }


            return true;
        }

        public static string Hash(string plainText, byte[] saltBytes)
        {
            // Salt size
            saltBytes = new byte[8];

            // Convert Text to Array
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Create Array
            byte[] plainTextSaltBytes =
                    new byte[plainTextBytes.Length + saltBytes.Length];

            // Copy Text into Array
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextSaltBytes[i] = plainTextBytes[i];

            // Append Salt
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

            // Algorithm
            HashAlgorithm hash;

            hash = new SHA256Managed();

            byte[] hashBytes = hash.ComputeHash(plainTextSaltBytes);

            byte[] hashSaltBytes = new byte[hashBytes.Length +
                                                saltBytes.Length];

            // Hash to Array
            for (int i = 0; i < hashBytes.Length; i++)
                hashSaltBytes[i] = hashBytes[i];

            // Append Salt
            for (int i = 0; i < saltBytes.Length; i++)
                hashSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashSaltBytes);

            // Return Result
            return hashValue;
        }

        public static bool VerifyHash(string plainText, string hashValue)
        {
            // Base64-encoded hash
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

            // Hash without Salt
            int hashSizeInBits, hashSizeInBytes;

            hashSizeInBits = 256;

            // Convert to bytes.
            hashSizeInBytes = hashSizeInBits / 8;

            // Verify Hash Length
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return false;

            // Array to hold Salt
            byte[] saltBytes = new byte[hashWithSaltBytes.Length -
                                        hashSizeInBytes];

            // Salt to New Array
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

            string expectedHashString = Hash(plainText, saltBytes);

            return (hashValue == expectedHashString);
        }
    }
}
