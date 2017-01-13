using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLoader.Processor
{

    public struct DateParser
    {
        public bool IsValid;
        public DateTime Date;
    }

    

    public class Loader
    {

        public static List<Models.Actor> GetActors()
        {
            var actors = new List<Models.Actor>();
            using (var context = new DbLoader.DAL.ActorContext())
            {
                actors = context.Actors.ToList();
            }

            return actors;
        }

        public static string[] LoadData(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);

            return lines;
        }

        public static Models.Actor CreateActor(string line)
        {
            var parts = line.Split('|');


            var d = IsValidDate(parts[0]);
            if (d.IsValid)
            {
                return new Models.Actor(d.Date, Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), parts[3], parts[4], parts[5], parts[6]);
            }

            return null;
        }

        public static int LoadActors(List<Models.Actor> actors, bool append)
        {
            int c = 0;

            if (!append)
            {
                ClearActors();
            }

            using(var context = new DbLoader.DAL.ActorContext())
            {
                foreach(var a in actors)
                {
                    if(a != null)
                    {
                        context.Actors.Add(a);
                        context.SaveChanges();
                    }
                    
                    c = context.Actors.Count();
                }
                
            }

            return c;
        }

        public static void ClearActors()
        {
            using (var context = new DbLoader.DAL.ActorContext())
            {
                var dbActors = context.Actors.ToArray();
                context.Actors.RemoveRange(dbActors);
                context.SaveChanges();
            }
        }

        public static DateParser IsValidDate(string dateStr)
        {

            int y;
            int m;
            int d;

            DateParser dp;
            dp.Date = DateTime.Now;

            try
            {
                y = Convert.ToInt32(dateStr.Substring(0, 4));
                m = Convert.ToInt32(dateStr.Substring(4, 2));
                d = Convert.ToInt32(dateStr.Substring(6, 2));

                dp.IsValid = true;
                dp.Date = new DateTime(y, m, d);

            }
            catch (Exception)
            {
                dp.IsValid = false;
            }

            return dp;
        }

    }
}
