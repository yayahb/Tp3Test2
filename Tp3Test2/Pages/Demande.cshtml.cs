using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using Tp3Test2.Pages;
using Tp3Test2.Pages.CouvrePlancher;
using Tp3Test2.Class;
using Tp3Test2.utils;

namespace PlancherExpert.Pages
{
    public class NewDemandeModel : PageModel
    {
        
        public Demande dmdd = new Demande();
		public string messageErreur = "";
		public List<Demande> dmd = new List<Demande>();
		public double Longueur { get; set; } = 0;
        public double Largeur { get; set; } = 0;
        public double TauxMat { get; set; } = 0;
        public double TauxMO { get; set; } = 0;
        public double Sup { get; set; } = 0;
        public double CoutMat { get; set; } = 0;
        public double CoutMO { get; set; } = 0;
        public double Total { get; set; } = 0;
        public String typeRev { get; set; } = "";

        public bool HasData { get; set; } = false;
       public List<Demande> dmdList = new List<Demande>();


        public void OnGet()
		{
            dmdList = Myfct.GetAllCvrPl();


		}
		public void OnPost()
        {
           

          

		}
    }
   
}