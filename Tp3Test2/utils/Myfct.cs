using System.Data.SqlClient;
using System.Net;
using Tp3Test2.Class;

namespace Tp3Test2.utils
{
    public class Myfct
    {
        public static bool addToFacture(string nomProduit, float superficie,float prixTotal,float longeur , float largeur)
        {
			try
			{
				string connexionString = "Data Source=LAPTOP-81OR91DR\\SQLEXPRESS01;Initial Catalog=PlancherExpert;Integrated Security=True";

				using (SqlConnection connexion = new SqlConnection(connexionString))
				{
					connexion.Open();
					string sqlQuery = "INSERT INTO facture(nomProduit,superficie,prixTotal,longeur,largeur) values(@nomProduit,@superficie,@prixTotal,@longeur,@largeur);";
					using (SqlCommand command = new SqlCommand(sqlQuery, connexion))
					{
						command.Parameters.AddWithValue("@nomProduit", nomProduit);
						command.Parameters.AddWithValue("@superficie", superficie);
						command.Parameters.AddWithValue("@prixTotal", prixTotal);
						command.Parameters.AddWithValue("@longeur", longeur);
						command.Parameters.AddWithValue("@largeur", largeur);
						command.ExecuteNonQuery();
						Console.WriteLine("facture inserted to database");
					}
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);

				return false;

			}
			return true;

	}
		public static Demande getProductByName(string name)
		{
			Demande DMD = new Demande();

			try
			{
				string connexionString = "Data Source=LAPTOP-81OR91DR\\SQLEXPRESS01;Initial Catalog=PlancherExpert;Integrated Security=True";
				using (SqlConnection connexion = new SqlConnection(connexionString))
				{
					connexion.Open();
					string sqlQuery = "SELECT * FROM couvrePLancher where type='" + name + "';";
					using (SqlCommand command = new SqlCommand(sqlQuery, connexion))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								DMD.Id = reader.GetInt32(0);
								DMD.Type = reader.GetString(1);
								DMD.MainDoeuvrePrice = (float)reader.GetSqlDouble(2);
								DMD.MaterialPrice = (float)reader.GetSqlDouble(3);

							}
						}
					}
				}

			}
			catch (Exception e)
			{

				Console.WriteLine(e.Message);
			}
			return DMD;
		}
		public static List<Demande> GetAllCvrPl() {  
            List <Demande> myList = new List<Demande>();
            try
            {
                string connexionString = "Data Source=LAPTOP-81OR91DR\\SQLEXPRESS01;Initial Catalog=PlancherExpert;Integrated Security=True";

                using (SqlConnection connexion = new SqlConnection(connexionString))
                {
                    connexion.Open();
                    string sqlQuery = "SELECT * FROM couvrePLancher;";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connexion))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Demande D = new Demande();
                                D.Id = reader.GetInt32(0);
                                D.Type = reader.GetString(1);
                                D.MainDoeuvrePrice = (float)reader.GetSqlDouble(2);
                                D.MaterialPrice = (float)reader.GetSqlDouble(3);

                                myList.Add(D);

                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return myList;

        }


    }
}

