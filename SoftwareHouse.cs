using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace net_ef_videogame
{
    public class SoftwareHouse
    {
        public int SoftwareHouseId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string TaxId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string City { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Country { get; set; }

        public List<Videogame> Videogames { get; set; }

        public SoftwareHouse(string name, string taxId, string city, string country)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(taxId) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(country))
                throw new ArgumentException("I campi non possono essere nulli!");
            Name = name;
            TaxId = taxId;
            City = city;
            Country = country;
        }

        public static void Add(SoftwareHouse softwareHouse)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try
                { 
                    db.Add(softwareHouse);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    Console.WriteLine("Errore!");
                }
            }
        }

    }
}
