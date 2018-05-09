using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Deanery.Classes
{
    public class Attendance
    {
        private List<Lesson> _lessonList;
        private List<Student> _studentList;
        private Subject _subject;
        private string _group;
        private string _fio;
        private int _year;
        private int _semester;

        public List<Lesson> LessonList
        {
            get { return _lessonList; }
            set { _lessonList = value; }
        }

        public List<Student> ListOfStudents
        {
            get { return _studentList; }
            set { _studentList = value; }
        }

        public Subject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Group
        {
            get { return _group; }
            set { _group = value; }
        }

        public string Fio
        {
            get { return _fio; }
            set { _fio = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public int Semester
        {
            get { return _semester; }
            set { _semester = value; }
        }

        public Attendance()
        {
            _lessonList = new List<Lesson>();
            _studentList = new List<Student>();
            _subject = new Subject();
            _group = "";
            _fio = "";
            _year = 0;
            _semester = 0;
        }

        public void Fill()
        {
            if (_subject != null && _subject.SubjectId == 0)
                return;
            _lessonList.Clear();
            _studentList.Clear();

            SqlConnection connection = Service.OpenConnection();

            string request = " SELECT les.lesson_id as lesson_id, " +
                " stu.*, " +
                " ls.is_visited as is_visited, " +
                " les.lesson_date as lesson_date " +
                " FROM Attendance AS att " +
                " JOIN Subjects AS sub ON sub.subject_id = att.subject_id " +
                " JOIN Lessons AS les ON les.attendance_id = att.attendance_id " +
                " JOIN LessonStudents AS ls ON ls.lesson_id = les.lesson_id " +
                " JOIN Students AS stu ON stu.student_id = ls.student_id " +
                " WHERE att.subject_id = @subject_id ";

            var command = new SqlCommand(request, connection);

            var parameter = new SqlParameter();
            parameter.ParameterName = "@subject_id";
            parameter.Value = _subject.SubjectId;
            parameter.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(parameter);

            if (_group != "")
            {
                request += " AND att.group_name = @group_name ";
                parameter = new SqlParameter();
                parameter.ParameterName = "@group_name";
                parameter.Value = _group;
                parameter.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(parameter);
            }
            if (_fio != "")
            {
                request += " AND att.fio = @fio ";
                parameter = new SqlParameter();
                parameter.Value = _fio;
                parameter.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(parameter);
            }
            if (_year != 0)
            {
                request += " AND att.year = @year ";
                parameter = new SqlParameter();
                parameter.Value = _year;
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                command.Parameters.Add(parameter);
            }
            if (_semester != 0)
            {
                request += " AND att.semester = @semester ";
                parameter = new SqlParameter();
                parameter.Value = _semester;
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                command.Parameters.Add(parameter);
            }

            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    int lessonId = Convert.ToInt32(dataReader["lesson_id"]);
                    if (_lessonList.Count == 0 || !_lessonList.Exists(i => i.LessonId == lessonId))
                        _lessonList.Add(new Lesson());
                    Lesson lesson = _lessonList.Last();
                    DateTime date = Convert.ToDateTime(dataReader["lesson_date"]);
                    lesson.LessonId = lessonId;
                    lesson.Date = date;
                    var student = new Student();
                    student.StudentId = Convert.ToInt32(dataReader["student_id"]);
                    student.Surname = dataReader["surname"].ToString();
                    student.Name = dataReader["name"].ToString();
                    student.Patronymic = dataReader["patronymic"].ToString();
                    student.StudyingForm = (Student.FormOfStudying)dataReader["studying_form"];
                    student.Speciality = dataReader["speciality"].ToString();
                    student.Group = dataReader["group_name"].ToString();
                    student.Year = Convert.ToInt32(dataReader["year"]);
                    student.Semester = Convert.ToInt32(dataReader["semester"]);
                    student.AverageMark = Convert.ToSingle(dataReader["average_mark"]);
                    if (!_studentList.Contains(student))
                    {
                        _studentList.Add(student);
                        lesson.VisitInfo.Add((Lesson.VisitState)dataReader["is_visited"]);
                    }
                    else
                        lesson.VisitInfo[_studentList.IndexOf(student)] = (Lesson.VisitState)dataReader["is_visited"];

                    _lessonList.Add(lesson);
                }
            }
        }
    }
}
