using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    public class Workshop

    {
        Workshop() { }

        public Workshop(int wkID, string wkName, string wkStoreName, string Date, string Time, int avaPlace)
        {
            this.wkID = wkID;
            this.wkStoreName = wkStoreName;
            this.wkName = wkName;
            this.Date = Date;
            this.Time = Time;
            this.avaPlace = avaPlace;
           
            List<Workshop> workshop = new List<Workshop> { new Workshop() { } };
        }

        public int wkID { get; set; }
        public string wkName { get; set; }
        public string wkStoreName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int avaPlace { get; set; }
       
    }
}
