using System;
using System.Collections.Generic;
using System.Text;
using lab_5_province_city.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace lab_5_province_city.Data
{
    public class SampleData {
        public static void Initialize(IApplicationBuilder app) { 
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            // Look for any teams.
            if (context.Provinces.Any()) {
                return;   // DB has already been seeded
            }

            var provinces = GetProvinces().ToArray();
            context.Provinces.AddRange(provinces);
            context.SaveChanges();

            var cities = GetCities(context).ToArray();
            context.Cities.AddRange(cities);
            context.SaveChanges();
            }
        }

        public static List<Province> GetProvinces() {
            List<Province> provinces = new List<Province>() {
                new Province() {
                    ProvinceCode="AB",
                    ProvinceName="Alberta",
                },
                new Province() {
                    ProvinceCode="BC",
                    ProvinceName="British Columbia",
                },
                new Province() {
                    ProvinceCode="ON",
                    ProvinceName="Ontario",
                },
 
            };

            return provinces;
        }

        public static List<City> GetCities(ApplicationDbContext context) {
            List<City> cities = new List<City>() {
                new City {
                CityName = "Richmond",
                Population = 100000,
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode
            },
            new City {
                CityName = "Vancouver",
                Population = 300000,
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode
            },new City {
                CityName = "Burnaby",
                Population = 400000,
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode
            },new City {
                CityName = "Calgary",
                Population = 20000,
                ProvinceCode = context.Provinces.Find("AB").ProvinceCode
            },new City {
                CityName = "Edmonton",
                Population = 3000,
                ProvinceCode = context.Provinces.Find("AB").ProvinceCode
            },new City {
                CityName = "Red Deer",
                Population = 4000,
                ProvinceCode = context.Provinces.Find("AB").ProvinceCode
            },new City {
                CityName = "Toronto",
                Population = 500000,
                ProvinceCode = context.Provinces.Find("ON").ProvinceCode
            },new City {
                CityName = "Ottawa",
                Population = 400000,
                ProvinceCode = context.Provinces.Find("ON").ProvinceCode
            },new City {
                CityName = "London",  
                Population = 350000,
                ProvinceCode = context.Provinces.Find("ON").ProvinceCode
            },
            };

            return cities;
        }
    }
}