using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.SqlClient;
using System.Data.SqlClient;
using Tp3Test2.Class;
using Tp3Test2.utils;

namespace Tp3Test2.Pages.CouvrePlancher
{
    public class Index1Model : PageModel
    {
        public List<Demande> CvrPl = new List<Demande>();
        public void OnGet()
        {
            CvrPl = Myfct.GetAllCvrPl();        }
    }

   

}

   

