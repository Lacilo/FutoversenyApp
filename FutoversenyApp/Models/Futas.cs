using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace FutoversenyApp.Models
{
    internal class Futas
    {
        private DateTime datum;
        private int tavolsag;
        private string idotartam;
        private int maxpulzus;

        public Futas(DateTime datum, int tavolsag, string idotartam, int maxpulzus)
        {
            Datum = datum;
            Tavolsag = tavolsag;
            Idotartam = idotartam;
            Maxpulzus = maxpulzus;
        }

        public Futas(string[] futas)
        {
            Datum = DateTime.Parse(futas[0]);
            Tavolsag = int.Parse(futas[1]);
            Idotartam = futas[2];
            Maxpulzus = int.Parse(futas[3]);
        }

        public Futas()
        {

        }

        public DateTime Datum { get => datum; set => datum = value; }
        public int Tavolsag { get => tavolsag; set => tavolsag = value; }
        public string Idotartam { get => idotartam; set => idotartam = value; }
        public int Maxpulzus { get => maxpulzus; set => maxpulzus = value; }

        public override string ToString()
        {
            return $"Dátum: {Datum}, Távolság: {Tavolsag}, Időtartam: {Idotartam}, Maximális pulzus: {Maxpulzus}";
        }

        /// <summary>
        /// Beolvassa a futások .json fájlját
        /// </summary>
        /// <param name="filename">A fájl amit beolvas</param>
        /// <returns>Egy listát ami a futásokból készített objektumokat tartalmaz</returns>
        public static List<Futas> RunsJsonReader(string filename)
        {
            string json = File.ReadAllText(filename);
            List<Futas> futasok = JsonSerializer.Deserialize<List<Futas>>(json);
            return futasok;
        }

        /// <summary>
        /// Kiír egy .json fájlt ami tartalmazza a felhasználó futásait
        /// </summary>
        /// <param name="futas">Egy lista ami tartalmazza felhasználó futásait</param>
        public static void JsonWriter(List<Futas> futas)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
            };
            string json = JsonSerializer.Serialize(futas, options);
            File.WriteAllText("Runs.json", json);
        }
    }
}
