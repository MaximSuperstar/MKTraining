using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class InitContactData : IEquatable<InitContactData>, IComparable<InitContactData>
    {
        public InitContactData(string lastname)
        {
            Lastname = lastname;           
        }

        public bool Equals(InitContactData other)
        {
            if (Object.ReferenceEquals(other, null)) { return false; }
            if (Object.ReferenceEquals(this, other)) { return true; }
            return LastNameContact == other.LastNameContact;
        }

        public int getHashCode()
        {
            return LastNameContact.GetHashCode();
        }

        public int CompareTo(InitContactData other)
        {
            return Id.CompareTo(other.Id);
        }

        public string LastNameContact { get; set; }
        
        public string Firstname { get; set; }
        
        public string Middlename { get; set; }
        
        public string Lastname { get; set; }

        public string Id { get; set; }

    }
}