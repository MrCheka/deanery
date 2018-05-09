using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deanery.Classes
{
    public class Lesson: IEquatable<Lesson>
    {
        public enum VisitState
        {
            None = 0,
            Attended = 1,
            Missed = 2
        }
        private int _lessonId;
        private DateTime _date;
        private List<VisitState> _visitInfo;

        public int LessonId
        {
            get { return _lessonId; }
            set { _lessonId = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public List<VisitState> VisitInfo
        {
            get { return _visitInfo; }
            set { _visitInfo = value; }
        }

        public Lesson()
        {
            _date = DateTime.Now;
            _visitInfo = new List<VisitState>();
        }

        public static bool operator==(Lesson left, Lesson right)
        {
            if (left is null && right is null)
                return true;
            else if (left is null)
                return false;
            else
                return left.Equals(right);
        }

        public static bool operator!=(Lesson left, Lesson right)
        {
            return !(left == right);
        }

        public bool Equals(Lesson other)
        {
            return other != null &&
                LessonId == other.LessonId;
        }
    }
}
