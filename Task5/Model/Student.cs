using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student:IComparable
    {
        public string Name{get;set;}
        public string TestName {get;set;}
        public int TestMark {get;set;}
        public DateTime TestTime {get;set;}

        public int CompareTo(object obj)
        {
            return TestMark.CompareTo(obj);
        }
    }
}
