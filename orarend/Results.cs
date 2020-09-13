using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orarend
{
    public class Result
    {
        List<ResultSubject> r;

        public Result() { r = new List<ResultSubject>(); }
        public Result(Result r)
        {
            this.r = new List<ResultSubject>();
            foreach(ResultSubject rs in r.r)
            {
                this.r.Add(new ResultSubject(rs));
            }
        }

        public bool add(ResultSubject rs)
        {
            foreach(ResultSubject subject in r)
            {
                if (ResultSubject.between(rs, subject)) return false;
            }
            r.Add(rs);
            return true;
        }

        public void add_anyway(ResultSubject rs)
        {
            r.Add(rs);
        }
        public int count() { return r.Count; }
        public void removelast()
        {
            r.RemoveAt(r.Count-1);
        }
        public List<ResultSubject> GetSubjects() { return r; }
    }

    public class ResultSubject
    {
        public string name;
        public int length;
        public Occasion time;

        public ResultSubject(string name, int length, Occasion time)
        {
            this.name = name;
            this.length = length;
            this.time = time;
        }

        public ResultSubject(ResultSubject rs)
        {
            name = rs.name;
            length = rs.length;
            time = rs.time;
        }

        public static bool between(ResultSubject r1, ResultSubject r2)
        {
            if (r1.time.day != r2.time.day) return false;
            if (r1.time.time >= r2.time.time && r1.time.time < r2.time.time + r2.length) return true;
            if (r1.time.time + r1.length > r2.time.time && r1.time.time + r1.length <= r2.time.time + r2.length) return true;
            if (r1.time.time <= r2.time.time && r1.time.time + r1.length >= r2.time.time + r2.length) return true;
            return false;
        }

        public override string ToString()
        {
            return name + ": " + time + " - " + (time.time + length) + ":00";
        }
    }
}
