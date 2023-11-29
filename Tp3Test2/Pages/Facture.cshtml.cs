using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tp3Test2.Class;
using Tp3Test2.utils;

namespace Tp3Test2.Pages
{
    public class FactureModel : PageModel
     {
        public string nomProduit = "";
        public float superficie; 
        public float prixTotal;
        public float longeur;
        public float largeur;
        public int tax = 15;
        public bool valid = false;



        public void OnPost()
        {
            valid = true;
            nomProduit = Request.Form["nomProduit"];
            longeur = float.Parse(Request.Form["longueur"]);
            largeur = float.Parse(Request.Form["largeur"]);
            superficie = longeur * largeur;
            Demande Dmdd = Myfct.getProductByName(nomProduit);
            prixTotal = superficie * (Dmdd.MaterialPrice + Dmdd.MainDoeuvrePrice) - (superficie * (Dmdd.MaterialPrice + Dmdd.MainDoeuvrePrice)) * tax / 100;
            Myfct.addToFacture(nomProduit, superficie, prixTotal, longeur, largeur);
        }
		public void OnGet()
        {
                   

		}
    }
}
