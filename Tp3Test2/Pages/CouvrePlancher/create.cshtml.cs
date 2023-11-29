using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Tp3Test2.Class;

namespace Tp3Test2.Pages.CouvrePlancher
{
    public class createModel : PageModel
    {
        
        public Demande Pl = new Demande();
        public string messageErreur = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Pl.Id = Convert.ToInt32(Request.Form["id"]);
            Pl.Type = Request.Form["type"];
            Pl.MaterialPrice = Convert.ToInt32(Request.Form["MaterialPrice"]);
            Pl.MainDoeuvrePrice = Convert.ToInt32(Request.Form["MainDoeuvrePrice"]);


            if (Pl.Type == "" || Pl.Id == 0)
            {
                messageErreur = "Veuillez saisir le nom et le prix du produit";
                return;
            }

            //Sauvegarder les donn�es dans la base de donn�es
            try

            {
                string connectionString = "Data Source=LAPTOP-81OR91DR\\SQLEXPRESS01;Initial Catalog=PlancherExpert;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString)) //Cr�ation de la connection
                {
                    connection.Open();//Ouvrir La connection
                    String sql = "INSERT INTO couvrePlancher(Id,type,materialPrice,mainDoeuvrePrice)" +
                        "values(@Id,@type,@materialPrice,@mainDoeuvrePrice);";//D�claration de la requ�te
                    using (SqlCommand cmd = new SqlCommand(sql, connection)) //pr�parer la requ�te
                    {
                        cmd.Parameters.AddWithValue("@Id", Convert.ToString(Pl.Id));
                        cmd.Parameters.AddWithValue("@type", Pl.Type);
                        cmd.Parameters.AddWithValue("@materialPrice", Convert.ToString(Pl.MaterialPrice));
                        cmd.Parameters.AddWithValue("@mainDoeuvrePrice", Convert.ToString(Pl.MainDoeuvrePrice));

                        cmd.ExecuteNonQuery(); //Ex�cuter la requ�te
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            //Reinitialiser les donn�es
            
            Pl.Id = 0;
            Pl.Type = "";
            Pl.MaterialPrice = 0;
            Pl.MainDoeuvrePrice = 0;

            Response.Redirect("/Index");
        }
       
    }
}
