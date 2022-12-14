using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mobileFoodAPI.Models
{
    public class CuisineModel
    {
        public CuisineModel(NationalCuisine nationalCuisine)
        {
            Code_NationalCuisine = nationalCuisine.Code_NationalCuisine;
            Name_NationalCuisine = nationalCuisine.Name_NationalCuisine;
        }

        public int Code_NationalCuisine { get; set; }
        public string Name_NationalCuisine { get; set; }

    }
}