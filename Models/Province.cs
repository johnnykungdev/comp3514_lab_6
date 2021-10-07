using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace lab_5_province_city.Models
{
    public class Province
    {
        [Key]
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public List<City> Cities { get; set; }
    }
}