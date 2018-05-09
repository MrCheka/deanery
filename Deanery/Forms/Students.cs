using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Deanery.Classes;

namespace Deanery.Forms
{
    public partial class Students : Form
    {
        private StudentList _studentList;
        private bool isExit;

        public Students()
        {
            InitializeComponent();
            dgvStudents.AutoGenerateColumns = false;
            StudyingFormColumn.CellTemplate = new StudyingFormDGVTextBoxCell();
            cmbStudyingForm.SelectedIndex = 0;
            isExit = false;
        }

        private void Students_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isExit)
                Application.Exit();
        }

        private void Students_Load(object sender, EventArgs e)
        {
            if (Service.CurrentUser.Role == User.UserRole.Student)
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnEdit.Visible = false;
            }
            _studentList = new StudentList();
            _studentList.Fill();

            dgvStudents.DataSource = _studentList.Value;
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new Settings();
            settingsForm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newStudent = new Student();
            var addForm = new OneStudentForm(OneStudentForm.WorkMode.AddStudent, newStudent);
            newStudent = addForm.ShowDialog();
            if (newStudent != new Student())
                _studentList.Add(newStudent);
            _studentList.Fill();

            dgvStudents.DataSource = typeof(List<Student>);
            dgvStudents.DataSource = _studentList.Value;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
                return;
            var selectedRow = dgvStudents.SelectedRows[0];
            Student selectedStudent = _studentList.Find(Convert.ToInt32(selectedRow.Cells[0].Value));
            var editForm = new OneStudentForm(OneStudentForm.WorkMode.EditStudent, selectedStudent);
            Student newStudent = editForm.ShowDialog();
            _studentList.Replace(selectedStudent.StudentId, newStudent);
            _studentList.Update();

            dgvStudents.DataSource = typeof(List<Student>);
            dgvStudents.DataSource = _studentList.Value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
                return;
            var selectedRow = dgvStudents.SelectedRows[0];
            var selectedStudent = new Student();
            selectedStudent.StudentId = Convert.ToInt32(selectedRow.Cells[0].Value);
            if (!_studentList.Remove(selectedStudent))
                MessageBox.Show("Произошла ошибка при удалении!", "Ошибка!");

            dgvStudents.DataSource = typeof(List<Student>);
            dgvStudents.DataSource = _studentList.Value;
        }

        private void Filter(object sender, EventArgs e)
        {
            if (_studentList is null)
                return;
            List<Student> filtered = new List<Student>(_studentList.Value);
            if (txtSurname.Text != "")
                filtered = filtered.Where(i => i.Surname.Contains(txtSurname.Text)).ToList();
            if (txtName.Text != "")
                filtered = filtered.Where(i => i.Name.Contains(txtName.Text)).ToList();
            if (txtPatronymic.Text != "")
                filtered = filtered.Where(i => i.Patronymic.Contains(txtPatronymic.Text)).ToList();
            if (txtSpeciality.Text != "")
                filtered = filtered.Where(i => i.Speciality.Contains(txtSpeciality.Text)).ToList();
            if (txtGroup.Text != "")
                filtered = filtered.Where(i => i.Group.Contains(txtGroup.Text)).ToList();
            if (txtYear.Text != "")
                filtered = filtered.Where(i => i.Year == Convert.ToInt32(txtYear.Text)).ToList();
            if (txtSemester.Text != "")
                filtered = filtered.Where(i => i.Semester == Convert.ToInt32(txtSemester.Text)).ToList();
            if (txtAverageMark.Text != "")
                filtered = filtered.Where(i => i.AverageMark == Convert.ToSingle(txtAverageMark.Text)).ToList();
            if (cmbStudyingForm.SelectedIndex != 0)
                filtered = filtered.Where(i => i.StudyingForm == (Student.FormOfStudying)cmbStudyingForm.SelectedIndex - 1).ToList();

            dgvStudents.DataSource = filtered;
        }

        private void tsmiSubjects_Click(object sender, EventArgs e)
        {
            var subjectsForm = new Subjects();
            subjectsForm.ShowDialog();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            isExit = true;
            OwnedForms[0].Show();
            RemoveOwnedForm(OwnedForms[0]);
            Close();
        }

        private void tsmiAttendance_Click(object sender, EventArgs e)
        {
            var attendanceForm = new AttendanceForm();
            attendanceForm.ShowDialog();
        }
    }

    public class StudyingFormDGVTextBoxCell : DataGridViewTextBoxCell
    {
        protected override object GetFormattedValue(object value,
            int rowIndex,
            ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter,
            DataGridViewDataErrorContexts context)
        {
            Student.FormOfStudying studyingForm = (Student.FormOfStudying)value;
            switch (studyingForm)
            {
                case Student.FormOfStudying.Free: return "Бюджет";
                case Student.FormOfStudying.Pay: return "Платное";
                default: throw new NotImplementedException();
            };
        }
    }
}
