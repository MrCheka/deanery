using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deanery.Classes
{
    public class Exam: IEquatable<Exam>
    {
        private int _examId;
        private Subject _subject;
        private int _mark;

        public int ExamId
        {
            get { return _examId; }
            set { _examId = value; }
        }

        public Subject SubjectExam
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public int Mark
        {
            get { return _mark; }
            set { _mark = value; }
        }

        public Exam()
        {
            _subject = new Subject();
        }

        public static bool operator==(Exam left, Exam right)
        {
            if (left is null && right is null)
                return true;
            else if (left is null)
                return false;
            else
                return left.Equals(right);
        }

        public static bool operator!=(Exam left, Exam right)
        {
            return !(left == right);
        }

        public bool Equals(Exam other)
        {
            return other != null &&
                ExamId == other.ExamId;
        }
    }
}
