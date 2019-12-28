using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class TestData : IComparable
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string TestName { get; set; }
        [DataMember]
        public int TestMark { get; set; }
        [DataMember]
        public DateTime TestTime { get; set; }
        public int CompareTo(object obj)
        {
            return TestMark.CompareTo((obj as TestData).TestMark);
        }

        public override bool Equals(object obj)
        {
            return obj is TestData data &&
                   Name == data.Name &&
                   TestName == data.TestName &&
                   TestMark == data.TestMark &&
                   TestTime == data.TestTime;
        }
    }
}
