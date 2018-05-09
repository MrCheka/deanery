using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deanery.Classes
{
    public class Subject : IEquatable<Subject>
    {
        private int _subjectId;
        private string _shortName;
        private string _longName;

        public int SubjectId
        {
            get { return _subjectId; }
            set { _subjectId = value; }
        }

        public string ShortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }

        public string LongName
        {
            get { return _longName; }
            set { _longName = value; }
        }

        public Subject()
        {

        }

        public static bool operator ==(Subject left, Subject right)
        {
            if (left is null && right is null)
                return true;
            else if (left is null)
                return false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Subject left, Subject right)
        {
            return !(left == right);
        }

        public bool Equals(Subject other)
        {
            return other != null &&
                ShortName == other.ShortName &&
                LongName == other.LongName;
        }
    }
}
