using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Actor
    {
        public Actor()
        {
           
        }


        public Actor(DateTime dateStr, int startTime, int endTime, string actor1, string actor2, string actor3, string actor4)
        {
            Date = dateStr;
            StartTime = startTime;
            EndTime = endTime;
            Actor1 = actor1;
            Actor2 = actor2;
            Actor3 = actor3;
            Actor4 = actor4;
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int  StartTime { get; set; }
        public int EndTime { get; set; }
        public string Actor1 { get; set; }
        public string Actor2 { get; set; }
        public string Actor3 { get; set; }
        public string Actor4 { get; set; }

    }

    
}
