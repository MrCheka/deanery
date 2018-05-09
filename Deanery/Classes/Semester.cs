using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deanery.Classes
{
    class Semester: IEquatable<Semester>
    {
        private int _semesterId;
        private List<Exam> _examList;
        private int _number;

        public int SemesterId
        {
            get { return _semesterId; }
            set { _semesterId = value; }
        }

        public List<Exam> ExamList
        {
            get { return _examList; }
            set { _examList = value; }
        }

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public Semester()
        {
            _examList = new List<Exam>();
        }

        public static bool operator==(Semester left, Semester right)
        {
            if (left is null && right is null)
                return true;
            else if (left is null)
                return false;
            else
                return left.Equals(right);
        }

        public static bool operator!=(Semester left, Semester right)
        {
            return !(left == right);
        }

        public bool Equals(Semester other)
        {
            return other != null &&
                SemesterId == other.SemesterId;
        }
    }
}
