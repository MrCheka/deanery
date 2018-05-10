using System;
using System.Collections.Generic;

namespace Deanery.Classes
{
    public class Lesson: IEquatable<Lesson>
    {
        public enum State
        {
            None = 0,
            Visited = 1,
            Absent = 2
        }
        public struct VisitInfo
        {
            public int LsId;
            public Student VisitStudent;
            public State IsVisited;
            public VisitInfo(Student student, State isVisited)
            {
                LsId = 0;
                VisitStudent = student;
                IsVisited = isVisited;
            }
            public VisitInfo(int lsId, Student student, State isVisited)
            {
                LsId = lsId;
                VisitStudent = student;
                IsVisited = isVisited;
            }
        }

        private int _lessonId;
        private DateTime _date;
        private List<VisitInfo> _visitInfoList;

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

        public List<VisitInfo> VisitInfoList
        {
            get { return _visitInfoList; }
            set { _visitInfoList = value; }
        }

        public Lesson()
        {
            _date = DateTime.Now;
            _visitInfoList = new List<VisitInfo>();
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
