using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Deanery.Classes
{
    public class StudentList
    {
        private List<Student> _studentList;
        private DataTable _studentsDataTable;

        public List<Student> Value
        {
            get { return _studentList; }
        }

        public StudentList()
        {
            _studentList = new List<Student>();
            _studentsDataTable = new DataTable("Students");
        }

        public void AddStudent(Student student)
        {
            _studentList.Add(student);
        }

        public bool RemoveStudent(Student student)
        {
            return _studentList.Remove(student);
        }

        public Student FindStudent(Student student)
        {
            return _studentList.Find(s => s == student);
        }

        public void FillStudentList(string connectionString)
        {
            var sqlDataAdapter =
                new SqlDataAdapter("SELECT * FROM Students", connectionString);

            sqlDataAdapter.Fill(_studentsDataTable);

            for (int curRow = 0; curRow < _studentsDataTable.Rows.Count; curRow++)
            {
                var newStudent = new Student
                {
                    Name = _studentsDataTable.Rows[curRow]["name"].ToString(),
                    Surname = _studentsDataTable.Rows[curRow]["surname"].ToString(),
                    Patronymic = _studentsDataTable.Rows[curRow]["patronymic"].ToString(),
                    StudyingForm =
                    Convert.ToInt32(_studentsDataTable.Rows[curRow]["studying_form"]) == 0 ? Student.FormOfStudying.Free : Student.FormOfStudying.Pay,
                    Speciality = _studentsDataTable.Rows[curRow]["speciality"].ToString(),
                    Group = _studentsDataTable.Rows[curRow]["group_name"].ToString(),
                    Year = Convert.ToInt32(_studentsDataTable.Rows[curRow]["year"]),
                    Semester = Convert.ToInt32(_studentsDataTable.Rows[curRow]["semester"]),
                    AverageMark = Convert.ToSingle(_studentsDataTable.Rows[curRow]["average_mark"])
                };
                _studentList.Add(newStudent);
            }
        }
    }
}
