using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProdApi.Models;

namespace ProdApi.Controllers
{
    public static class Helpers
    {
        
    }

    public class DailySummary
    {
        private float _carb = 0;
        private float _fat = 0;
        private float _protein = 0;
        private float _callories = 0;

        public float Carb { get { return _carb; } }
        public float Fat { get { return _fat; } }
        public float Protein { get { return _protein; } }
        public float Callories { get { return _callories; } }

        public DailySummary(Product product)
        {
            
        }
    }    
}