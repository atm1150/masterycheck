using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class VehicleDetailsItem
    {
        public int VehicleID { get; set; }
        public int VehicleYear { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public string Vin { get; set; }
        public decimal MSRP { get; set; }
        public string VehicleDescription { get; set; }
        public string ImageFileName { get; set; }
        public string BodyDescription { get; set; }
        public string TransStyle { get; set; }
        public string BodyColorName { get; set; }
        public string InteriorColorName { get; set; }
        public bool IsAvailable { get; set; }
    }
}