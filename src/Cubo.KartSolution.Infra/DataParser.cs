using Cubo.KartSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace Cubo.KartSolution.Infra
{
    public class DataParser
    {
        public static List<Race> Parse()
        {
            var fileContents = File.ReadAllText(HostingEnvironment.MapPath(@"~/App_Data/logRace.txt"));
            var rows = fileContents.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            
            List<Race> data = new List<Race>();
            Race r = null;

            if (rows.Length > 1)
            {
                foreach (var item in rows.Skip(1))
                {
                    string[] parts = item.Replace(" ", "").Split('\t').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    
                    DateTime datetimeLap = DateTime.ParseExact(parts[0], "HH:mm:ss.fff", CultureInfo.CurrentCulture);
                    int pilotCode = Convert.ToInt32(parts[1].Substring(0, 3));
                    string pilotName = parts[1].Substring(4);
                    int lapNumber = Convert.ToInt32(parts[2]);
                    TimeSpan timeLap = DateTime.ParseExact(parts[3], "m:ss.fff", CultureInfo.CurrentCulture).TimeOfDay;
                    double averageLapSpeed = Convert.ToDouble(parts[4]);
                    r = new Race(datetimeLap, pilotCode, pilotName, lapNumber, timeLap, averageLapSpeed);
                    data.Add(r);
                }
                return data;
            }
            return null;
        }
    }
}
