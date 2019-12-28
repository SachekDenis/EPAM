using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Class TestData.
    /// Implements the <see cref="System.IComparable" />
    /// </summary>
    /// <seealso cref="System.IComparable" />
    [DataContract]
    public class TestData : IComparable
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the name of the test.
        /// </summary>
        /// <value>The name of the test.</value>
        [DataMember]
        public string TestName { get; set; }
        /// <summary>
        /// Gets or sets the test mark.
        /// </summary>
        /// <value>The test mark.</value>
        [DataMember]
        public int TestMark { get; set; }
        /// <summary>
        /// Gets or sets the test time.
        /// </summary>
        /// <value>The test time.</value>
        [DataMember]
        public DateTime TestTime { get; set; }
        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order.</returns>
        public int CompareTo(object obj)
        {
            return TestMark.CompareTo((obj as TestData).TestMark);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return obj is TestData data &&
                   Name == data.Name &&
                   TestName == data.TestName &&
                   TestMark == data.TestMark &&
                   TestTime == data.TestTime;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            var hashCode = -1226589120;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TestName);
            hashCode = hashCode * -1521134295 + TestMark.GetHashCode();
            hashCode = hashCode * -1521134295 + TestTime.GetHashCode();
            return hashCode;
        }
    }
}
