using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_7
{
    internal class ManagerDB
    {
        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NomeSbagliato;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //Ho inserito il nome del database sbagliato: "Catalog=NomeSbagliato"
        public bool EsistenzaUtente(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from Utente where Username=@user";
                    command.Parameters.AddWithValue("@user", username);
                    SqlDataReader reader = command.ExecuteReader();

                    bool esiste = false;

                    int i = 0;
                    while (reader.Read())
                    {
                        i++;
                    }
                    if (i != 0)
                    {
                        esiste = true;
                        Console.WriteLine("User trovato con successo");
                    }
                    else
                    {
                        esiste = false;
                        Console.WriteLine("User non trovato!");

                    }
                    connection.Close();
                    return esiste;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore col db {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore {ex.Message}");
                return false;
            }
        }
    }
}
