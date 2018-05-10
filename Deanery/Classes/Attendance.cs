using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Deanery.Classes
{
    public class Attendance
    {
        private int _attendanceId;
        private List<Lesson> _lessonList;
        private Subject _subject;
        private string _group;
        private string _fio;
        private int _year;
        private int _semester;

        public int AttendanceId
        {
            get { return _attendanceId; }
            set { _attendanceId = value; }
        }

        public List<Lesson> LessonList
        {
            get { return _lessonList; }
            set { _lessonList = value; }
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

            SqlConnection connection = Service.OpenConnection();

            string request = " SELECT att.attendance_id, " +
                " les.lesson_id as lesson_id, " +
                " stu.*, ls_id, " +
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
                    _attendanceId = Convert.ToInt32(dataReader["attendance_id"]);
                    int lessonId = Convert.ToInt32(dataReader["lesson_id"]);
                    Lesson lesson = new Lesson();
                    if (!_lessonList.Exists(i => i.LessonId == lessonId))
                        _lessonList.Add(lesson);
                    else
                        lesson = _lessonList.Find(i => i.LessonId == lessonId);
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
                    Lesson.State isVisited = (Lesson.State)dataReader["is_visited"];
                    int lsId = Convert.ToInt32(dataReader["ls_id"]);
                    lesson.VisitInfoList.Add(new Lesson.VisitInfo(lsId, student, isVisited));
                }
            }

            Service.CloseConnection(connection);
        }

        public void Update()
        {
            SqlConnection connection = Service.OpenConnection();
            SqlTransaction transaction = connection.BeginTransaction();

            if (_attendanceId != 0)
            {
                string request = " UPDATE Attendance " +
                    " SET subject_id = @subject_id, " +
                    " group_name = @group_name, " +
                    " fio = @fio, " +
                    " year = @year, " +
                    " semester = @semester " +
                    " WHERE attendance_id = @attendance_id; ";

                var command = new SqlCommand
                {
                    Connection = connection,
                    Transaction = transaction,
                    CommandText = request
                };

                var parameter = new SqlParameter();
                parameter.ParameterName = "@subject_id";
                parameter.Value = _subject.SubjectId;
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@group_name";
                parameter.Value = _group;
                parameter.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@fio";
                parameter.Value = _fio;
                parameter.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@year";
                parameter.Value = _year;
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@semester";
                parameter.Value = _semester;
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@attendance_id";
                parameter.Value = _attendanceId;
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
            else
            {
                string request = " INSERT INTO Attendance " +
                    " (subject_id, group_name, fio, year, semester) " +
                    " VALUES (@subject_id, @group_name, @fio, @year, @semester) ";

                var command = new SqlCommand
                {
                    Connection = connection,
                    Transaction = transaction,
                    CommandText = request
                };

                var parameter = new SqlParameter();
                parameter.ParameterName = "@subject_id";
                parameter.Value = _subject.SubjectId;
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@group_name";
                parameter.Value = _group;
                parameter.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@fio";
                parameter.Value = _fio;
                parameter.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@year";
                parameter.Value = _year;
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@semester";
                parameter.Value = _semester;
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }

            for (int i = 0; i < _lessonList.Count; i++)
            {
                if (_lessonList[i].LessonId != 0)
                {
                    string request = " UPDATE Lessons " +
                        " SET attendance_id = @attendance_id, " +
                        " lesson_date = @lesson_date" +
                        " WHERE lesson_id = @lesson_id ";

                    var command = new SqlCommand
                    {
                        Connection = connection,
                        Transaction = transaction,
                        CommandText = request
                    };

                    var parameter = new SqlParameter();
                    parameter.ParameterName = "@attendance_id";
                    parameter.Value = _attendanceId;
                    parameter.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@lesson_date";
                    parameter.Value = _lessonList[i].Date;
                    parameter.SqlDbType = System.Data.SqlDbType.DateTime;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@lesson_id";
                    parameter.Value = _lessonList[i].LessonId;
                    parameter.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
                }
                else
                {
                    string request = " INSERT INTO Lessons " +
                        " (attendance_id, lesson_date) " +
                        " VALUES (@attendance_id, @lesson_date) ";

                    var command = new SqlCommand
                    {
                        Connection = connection,
                        Transaction = transaction,
                        CommandText = request
                    };

                    var parameter = new SqlParameter();
                    parameter.ParameterName = "@attendance_id";
                    parameter.Value = _attendanceId;
                    parameter.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@lesson_date";
                    parameter.Value = _lessonList[i].Date;
                    parameter.SqlDbType = System.Data.SqlDbType.DateTime;
                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
                }

                for (int j = 0; j < _lessonList[i].VisitInfoList.Count; j++)
                {
                    if (_lessonList[i].VisitInfoList[j].LsId != 0)
                    {
                        string request = " UPDATE LessonStudents " +
                        " SET student_id = @student_id, " +
                        " is_visited = @is_visited," +
                        " lesson_id = @lesson_id " +
                        " WHERE ls_id = @ls_id ";

                        var command = new SqlCommand
                        {
                            Connection = connection,
                            Transaction = transaction,
                            CommandText = request
                        };

                        var parameter = new SqlParameter();
                        parameter.ParameterName = "@student_id";
                        parameter.Value = _lessonList[i].VisitInfoList[j].VisitStudent.StudentId;
                        parameter.SqlDbType = System.Data.SqlDbType.Int;
                        command.Parameters.Add(parameter);

                        parameter = new SqlParameter();
                        parameter.ParameterName = "@is_visited";
                        parameter.Value = _lessonList[i].VisitInfoList[j].IsVisited;
                        parameter.SqlDbType = System.Data.SqlDbType.Int;
                        command.Parameters.Add(parameter);

                        parameter = new SqlParameter();
                        parameter.ParameterName = "@lesson_id";
                        parameter.Value = _lessonList[i].LessonId;
                        parameter.SqlDbType = System.Data.SqlDbType.Int;
                        command.Parameters.Add(parameter);

                        parameter = new SqlParameter();
                        parameter.ParameterName = "@ls_id";
                        parameter.Value = _lessonList[i].VisitInfoList[j].LsId;
                        parameter.SqlDbType = System.Data.SqlDbType.Int;
                        command.Parameters.Add(parameter);

                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        string request = " INSERT INTO LessonStudents " +
                            " (student_id, lesson_id, is_visited) " +
                            " VALUES (@student_Id, @lesson_id, @is_visited) ";

                        var command = new SqlCommand
                        {
                            Connection = connection,
                            Transaction = transaction,
                            CommandText = request
                        };

                        var parameter = new SqlParameter();
                        parameter.ParameterName = "@student_id";
                        parameter.Value = _lessonList[i].VisitInfoList[j].VisitStudent.StudentId;
                        parameter.SqlDbType = System.Data.SqlDbType.Int;
                        command.Parameters.Add(parameter);

                        parameter = new SqlParameter();
                        parameter.ParameterName = "@is_visited";
                        parameter.Value = _lessonList[i].VisitInfoList[j].IsVisited;
                        parameter.SqlDbType = System.Data.SqlDbType.Int;
                        command.Parameters.Add(parameter);

                        parameter = new SqlParameter();
                        parameter.ParameterName = "@lesson_id";
                        parameter.Value = _lessonList[i].LessonId;
                        parameter.SqlDbType = System.Data.SqlDbType.Int;
                        command.Parameters.Add(parameter);

                        parameter = new SqlParameter();
                        parameter.ParameterName = "@ls_id";
                        parameter.Value = _lessonList[i].VisitInfoList[j].LsId;
                        parameter.SqlDbType = System.Data.SqlDbType.Int;
                        command.Parameters.Add(parameter);

                        command.ExecuteNonQuery();
                    }
                }
            }


            try
            {
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
                transaction.Rollback();
            }

            Service.CloseConnection(connection);
        }
    }
}
