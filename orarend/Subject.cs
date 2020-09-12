using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orarend
{
    public class Subject
    {
        public string name;
        public int length;
        List<Occasion> o;
        int i;

        public Subject(string name, int length, List<Occasion> o)
        {
            if (name == "" || length <= 0 || length >= 5) throw new ArgumentException();
            foreach(Occasion oc in o)
            {
                if (oc.time <= 0 || oc.time >= 24) throw new ArgumentException();
            }
            this.name = name;
            this.length = length;
            this.o = o;
        }
        public void first()
        {
            i = 0;
        }
        public void next() { ++i; }
        public bool end() { return i >= o.Count; }

        public Occasion current() { return o[i]; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(name + ": " + length + " óra ||");
            foreach(Occasion o in o)
            {
                sb.Append(" " + o);
            }
            return sb.ToString();
        }
    }

    public class Occasion
    {
        public DayOfWeek day;
        public int time;

        public Occasion(DayOfWeek day,int time)
        {
            this.day = day;
            this.time = time;
        }

        public override string ToString()
        {
            switch(day)
            {
                case DayOfWeek.Monday:
                    return "Hétfő " + time + ":00";
                case DayOfWeek.Tuesday:
                    return "Kedd " + time + ":00";
                case DayOfWeek.Wednesday:
                    return "Szerda " + time + ":00";
                case DayOfWeek.Thursday:
                    return "Csütörtök " + time + ":00";
                case DayOfWeek.Friday:
                    return "Péntek " + time + ":00";
            }
            return "";
        }
    }
}
