using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaportsLSISoftware
{
    internal class Raport
    {
        public int RaportID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string User { get; set; }
        public string Local { get; set; }

        public Raport(int id, string name, DateTime date, string time, string user, string local)
        {
            RaportID = id;
            Name = name;
            Date = date;
            Time = time;
            User = user;
            Local = local;
        }
    }
}
