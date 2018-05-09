using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Deanery.Interfaces;

namespace Deanery.Classes
{
    public class StudentList : IMyList<Student>
    {
        private List<Student> _studentList;

        public List<Student> Value
        {
            get { return _studentList; }
        }

        public StudentList()
        {
            _studentList = new List<Student>();
        }

        public void Add(Student item)
        {
            if (Find(item) != null)
                return;

            SqlConnection connection = Service.OpenConnection();

            string request = " INSERT INTO Students " +
                " (name, surname, patronymic," +
                " studying_form, speciality, group_name," +
                " year, semester, average_mark) " +
                " VALUES ( " +
                " @name, " +
                " @surname, " +
                " @patronymic, " +
                " @studying_form, " +
                " @speciality, " +
                " @group_name, " +
                " @year, " +
                " @semester, " +
                " @average_mark) ";

            var command = new SqlCommand(request, connection);

            var parameter = new SqlParameter();
            parameter.ParameterName = "@name";
            parameter.Value = item.Name;
            parameter.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@surname";
            parameter.Value = item.Surname;
            parameter.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@patronymic";
            parameter.Value = item.Patronymic;
            parameter.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@studying_form";
            parameter.Value = item.StudyingForm;
            parameter.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@speciality";
            parameter.Value = item.Speciality;
            parameter.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@group_name";
            parameter.Value = item.Group;
            parameter.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@year";
            parameter.Value = item.Year;
            parameter.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@semester";
            parameter.Value = item.Semester;
            parameter.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@average_mark";
            parameter.Value = item.AverageMark;
            parameter.SqlDbType = SqlDbType.Float;
            command.Parameters.Add(parameter);

            if (command.ExecuteNonQuery() != 0)
                _studentList.Add(item);

            Service.CloseConnection(connection);
        }

        public bool Remove(Student item)
        {
            SqlConnection connection = Service.OpenConnection();

            if (item.StudentId == 0)
                return _studentList.Remove(item);

            string request = " DELETE FROM Students " +
                "WHERE student_id = @student_id ";

            var command = new SqlCommand(request, connection);

            var parameter = new SqlParameter();
            parameter.ParameterName = "@student_id";
            parameter.Value = item.StudentId;
            parameter.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();

            Service.CloseConnection(connection);

            return _studentList.RemoveAll(i => i.StudentId == item.StudentId) > 0;
        }

        public Student Find(Student item)
        {
            return _studentList.Find(i => i == item);
        }

        public Student Find(int studentId)
        {
            return _studentList.Find(i => i.StudentId == studentId);
        }

        public int FindIndex(Student item)
        {
            return _studentList.FindIndex(i => i == item);
        }

        public void Fill()
        {
            _studentList.Clear();
            SqlConnection connection = Service.OpenConnection();

            string request = " SELECT * FROM Students ";
            var command = new SqlCommand(request, connection);
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var newStudent = new Student();
                    newStudent.StudentId = Convert.ToInt32(dataReader["student_id"]);
                    newStudent.Name = dataReader["name"].ToString();
                    newStudent.Surname = dataReader["surname"].ToString();
                    newStudent.Patronymic = dataReader["patronymic"].ToString();
                    newStudent.StudyingForm = (Student.FormOfStudying)dataReader["studying_form"];
                    newStudent.Speciality = dataReader["speciality"].ToString();
                    newStudent.Group = dataReader["group_name"].ToString();
                    newStudent.Year = Convert.ToInt32(dataReader["year"]);
                    newStudent.Semester = Convert.ToInt32(dataReader["semester"]);
                    newStudent.AverageMark = Convert.ToSingle(dataReader["average_mark"]);

                    _studentList.Add(newStudent);
                }
            }

            Service.CloseConnection(connection);
        }

        public void Update()
        {
            SqlConnection connection = Service.OpenConnection();
            SqlTransaction transaction = connection.BeginTransaction();

            for (int i = 0; i < _studentList.Count; i++)
            {
                if (_studentList[i].StudentId != 0)
                {
                    string request = " UPDATE Students " +
                        " SET name = @name, " +
                        " surname = @surname, " +
                        " patronymic = @patronymic, " +
                        " studying_form = @studying_form, " +
                        " speciality = @speciality, " +
                        " group_name = @group_name, " +
                        " year = @year, " +
                        " semester = @semester, " +
                        " average_mark = @average_mark " +
                        " WHERE student_id = @student_id ";

                    var command = new SqlCommand
                    {
                        Connection = connection,
                        Transaction = transaction,
                        CommandText = request
                    };

                    var parameter = new SqlParameter();
                    parameter.ParameterName = "@name";
                    parameter.Value = _studentList[i].Name;
                    parameter.SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@surname";
                    parameter.Value = _studentList[i].Surname;
                    parameter.SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@patronymic";
                    parameter.Value = _studentList[i].Patronymic;
                    parameter.SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@studying_form";
                    parameter.Value = _studentList[i].StudyingForm;
                    parameter.SqlDbType = SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@speciality";
                    parameter.Value = _studentList[i].Speciality;
                    parameter.SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@group_name";
                    parameter.Value = _studentList[i].Group;
                    parameter.SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@year";
                    parameter.Value = _studentList[i].Year;
                    parameter.SqlDbType = SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@semester";
                    parameter.Value = _studentList[i].Semester;
                    parameter.SqlDbType = SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@average_mark";
                    parameter.Value = _studentList[i].AverageMark;
                    parameter.SqlDbType = SqlDbType.Float;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@student_id";
                    parameter.Value = _studentList[i].StudentId;
                    parameter.SqlDbType = SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
                }
                else
                    Add(_studentList[i]);
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

        public void Replace(int id, Student item)
        {
            int index = _studentList.FindIndex(i => i.StudentId == id);
            _studentList[index].Name = item.Name;
            _studentList[index].Surname = item.Surname;
            _studentList[index].Patronymic = item.Patronymic;
            _studentList[index].StudyingForm = item.StudyingForm;
            _studentList[index].Speciality = item.Speciality;
            _studentList[index].Year = item.Year;
            _studentList[index].Semester = item.Semester;
            _studentList[index].AverageMark = item.AverageMark;
        }
    }
}
