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
        private Subject _subjectExam;
        private Student _studentExam;
        private int _number;
        private int _mark;

        public int ExamId
        {
            get { return _examId; }
            set { _examId = value; }
        }

        public Subject SubjectExam
        {
            get { return _subjectExam; }
            set { _subjectExam = value; }
        }

        public Student StudentExam
        {
            get { return _studentExam; }
            set { _studentExam = value; }
        }

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public int Mark
        {
            get { return _mark; }
            set { _mark = value; }
        }

        public Exam()
        {
            _subjectExam = new Subject();
            _studentExam = new Student();
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
