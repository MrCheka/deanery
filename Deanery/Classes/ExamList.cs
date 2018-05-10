using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;
using Deanery.Interfaces;

namespace Deanery.Classes
{
    public class ExamList : IMyList<Exam>
    {
        private List<Exam> _examList;

        public List<Exam> Value
        {
            get { return _examList; }
        }

        public ExamList()
        {
            _examList = new List<Exam>();
        }

        public void Add(Exam item)
        {
            SqlConnection connection = Service.OpenConnection();

            string request = " INSERT INTO Exams " +
                " (subject_id, student_id, semester_number, mark) " +
                " VALUES (@subject_id, @student_id, @number, @mark) ";

            var command = new SqlCommand(request, connection);

            var parameter = new SqlParameter();
            parameter.ParameterName = "@subject_id";
            parameter.Value = item.SubjectExam.SubjectId;
            parameter.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@student_id";
            parameter.Value = item.StudentExam.StudentId;
            parameter.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@number";
            parameter.Value = item.Number;
            parameter.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@mark";
            parameter.Value = item.Mark;
            parameter.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(parameter);

            if (command.ExecuteNonQuery() != 0 && !_examList.Contains(item))
                _examList.Add(item);

            Service.CloseConnection(connection);
        }

        public void Fill()
        {
            _examList.Clear();
            SqlConnection connection = Service.OpenConnection();

            string request = " SELECT * FROM Exams AS ex " +
                " JOIN Subjects AS sub ON sub.subject_id = ex.subject_id " +
                " JOIN Students AS stu ON stu.student_id = ex.student_id ";

            var command = new SqlCommand(request, connection);
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var newExam = new Exam();
                    newExam.ExamId = Convert.ToInt32(dataReader["exam_id"]);
                    newExam.SubjectExam.SubjectId = Convert.ToInt32(dataReader["subject_id"]);
                    newExam.SubjectExam.ShortName = dataReader["short_name"].ToString();
                    newExam.SubjectExam.LongName = dataReader["long_name"].ToString();
                    newExam.StudentExam.StudentId = Convert.ToInt32(dataReader["student_id"]);
                    newExam.StudentExam.Surname = dataReader["surname"].ToString();
                    newExam.StudentExam.Name = dataReader["name"].ToString();
                    newExam.StudentExam.Patronymic = dataReader["patronymic"].ToString();
                    newExam.StudentExam.StudyingForm = (Student.FormOfStudying)dataReader["studying_form"];
                    newExam.StudentExam.Speciality = dataReader["speciality"].ToString();
                    newExam.StudentExam.Group = dataReader["group_name"].ToString();
                    newExam.StudentExam.Year = Convert.ToInt32(dataReader["year"]);
                    newExam.StudentExam.Semester = Convert.ToInt32(dataReader["semester"]);
                    newExam.StudentExam.AverageMark = Convert.ToSingle(dataReader["average_mark"]);
                    newExam.Number = Convert.ToInt32(dataReader["semester_number"]);
                    newExam.Mark = Convert.ToInt32(dataReader["mark"]);

                    _examList.Add(newExam);
                }
            }

            Service.CloseConnection(connection);
        }

        public Exam Find(Exam item)
        {
            return _examList.Find(i => i == item);
        }

        public int FindIndex(Exam item)
        {
            return _examList.IndexOf(item);
        }

        public bool Remove(Exam item)
        {
            SqlConnection connection = Service.OpenConnection();

            string request = " DELETE FROM Exams " +
                " WHERE exam_id = @exam_id ";

            var command = new SqlCommand(request, connection);

            var parameter = new SqlParameter();
            parameter.ParameterName = "@exam_id";
            parameter.Value = item.ExamId;
            parameter.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();

            Service.CloseConnection(connection);

            return _examList.RemoveAll(i => i.ExamId == item.ExamId) > 0;
        }

        public void Replace(int id, Exam item)
        {
            Exam exam = _examList.Find(i => i.ExamId == id);
            exam.SubjectExam = item.SubjectExam;
            exam.StudentExam = item.StudentExam;
            exam.Mark = item.Mark;
            exam.Number = item.Number;
        }

        public void Update()
        {
            SqlConnection connection = Service.OpenConnection();
            SqlTransaction transaction = connection.BeginTransaction();

            for (int i = 0; i < _examList.Count; i++)
            {
                if (_examList[i].ExamId != 0)
                {
                    string request = " UPDATE Exams " +
                        " SET subject_id = @subject_id, " +
                        " student_id = @student_id, " +
                        " semester_number = @number, " +
                        " mark = @mark " +
                        " WHERE exam_id = @exam_id ";

                    var command = new SqlCommand();
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandText = request;

                    var parameter = new SqlParameter();
                    parameter.ParameterName = "@subject_id";
                    parameter.Value = _examList[i].SubjectExam.SubjectId;
                    parameter.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@student_id";
                    parameter.Value = _examList[i].StudentExam.StudentId;
                    parameter.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@number";
                    parameter.Value = _examList[i].Number;
                    parameter.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@mark";
                    parameter.Value = _examList[i].Mark;
                    parameter.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@exam_id";
                    parameter.Value = _examList[i].ExamId;
                    parameter.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
                }
                else
                    Add(_examList[i]);
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
