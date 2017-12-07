using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProdApi.Models;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net;

namespace ProdApi.Controllers
{
    public static class Helpers
    {
        
    }

    public class Summary
    {
        public float Carb;
        public float Fat;
        public float Protein;
        public float Callories;
        public IQueryable<FoodDiaryLines> Lines;

        public Summary(IQueryable<FoodDiaryLines> lines)
        {
            Lines = lines;
            foreach (var item in Lines)
            {
                Carb += item.Carbohydrates;
                Fat += item.Fat;
                Protein += item.Protein;
                Callories += item.Calories;
            }
        }
    }

    
}