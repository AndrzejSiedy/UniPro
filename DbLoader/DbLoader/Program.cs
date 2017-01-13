using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLoader
{
    class Program
    {
        static void Main(string[] args)
        {

            var fileLocation = System.Configuration.ConfigurationManager.AppSettings["BatchFile"];

            Console.WriteLine(fileLocation);

            if (!System.IO.File.Exists(fileLocation))
            {
                Console.WriteLine($"cannot find file {fileLocation}");
            }
            else
            {
                if (args.Length == 0 || args[0] == "-a")
                {
                    // load data from file by append
                    List<Models.Actor> actors = new List<Models.Actor>();
                    var lines = DbLoader.Processor.Loader.LoadData(fileLocation);
                    foreach (var l in lines)
                    {
                        var actor = DbLoader.Processor.Loader.CreateActor(l);
                        actors.Add(actor);
                    }

                    var count = DbLoader.Processor.Loader.LoadActors(actors, true);
                    Console.WriteLine($"rows {actors.Count}");
                }
                else if(args[0] == "-d")
                {
                    DbLoader.Processor.Loader.ClearActors();
                }
                

                
                
            }

            Console.ReadLine();
            
        }
    }
}
