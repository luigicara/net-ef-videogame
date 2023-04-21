using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class Videogame
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Overview { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int SoftwareHouseId { get; set; }

        public SoftwareHouse SoftwareHouse { get; set; }

        public Videogame(string name, string overview, DateTime releaseDate, int softwareHouseId)
        {
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            SoftwareHouseId = softwareHouseId;
        }

        public static void Add(Videogame newVideogame)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try
                { 
                    db.Add(newVideogame);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    Console.WriteLine("l'id della software house non esiste!");
                }
            }
        }

        public static Videogame? SearchById(int id)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try
                {
                    Videogame risultato = db.Videogames.Where(Videogames => Videogames.Id == id).Include(Videogames => Videogames.SoftwareHouse).First();

                    return risultato;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());

                    return null;
                }
            }
        }

        public static List<Videogame> SearchByName(string name)
        {
            using (VideogameContext db = new VideogameContext())
            {
                List<Videogame> risultati = db.Videogames.Where(Videogame => Videogame.Name.Contains(name)).Include(Videogames => Videogames.SoftwareHouse).ToList();

                return risultati;
            }
        }

        //bonus
        public static List<Videogame> SearchBySoftwareHouse(int id)
        {
            using (VideogameContext db = new VideogameContext())
            {
                List<Videogame> risultati = db.Videogames.Where(Videogame => Videogame.SoftwareHouseId == id).Include(Videogames => Videogames.SoftwareHouse).ToList();

                return risultati;
            }
        }

        public static void Delete(int id)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try
                {
                    Videogame risultato = db.Videogames.Where(Videogames => Videogames.Id == id).First();
                    db.Remove(risultato);
                    db.SaveChanges();

                    Console.WriteLine($"Videogioco id numero:{id} è stato eliminato!");

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    Console.WriteLine("Operazione Fallita!");
                }
            }
        }

        public override string ToString()
        {
            return $"\r\n\tNome: {Name}\r\n\tSoftware house: {SoftwareHouse.Name}\r\n\tData di Rilascio: {ReleaseDate.ToString("dd/MM/yyyy")}\r\n\tDescrizione: {Overview}";
        }

        public static string ListToString(List<Videogame> videogamesList)
        {
            if (videogamesList.Count == 0)
                return "Non ci sono videogiochi corrispondenti!";

            string risultato = string.Empty;

            int index = 1;

            foreach (Videogame videogame in videogamesList)
            {
                risultato += $"\r\n{index}° Videogioco\r\n\t{videogame.ToString()}";
                index++;
            }

            return risultato;
        }
    }
}
