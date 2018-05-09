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
    public partial class OneStudentForm : Form
    {
        public enum WorkMode
        {
            AddStudent = 0,
            EditStudent = 1
        }

        private Student _selectedStudent;
        private WorkMode _workMode;

        public OneStudentForm(WorkMode workMode, Student selectedStudent)
        {
            _workMode = workMode;
            _selectedStudent = selectedStudent;
            InitializeComponent();
            cmbStudyingForm.SelectedIndex = 0;
            if (workMode == WorkMode.AddStudent)
                Text = "Добавление студента";
            else if (workMode == WorkMode.EditStudent)
                Text = "Редактирование студента";
        }

        public Student ShowDialog()
        {
            base.ShowDialog();
            return _selectedStudent;
        }

        private void OneStudentForm_Load(object sender, EventArgs e)
        {
            if (_selectedStudent.StudentId != 0)
            {
                txtSurname.Text = _selectedStudent.Surname;
                txtName.Text = _selectedStudent.Name;
                txtPatronymic.Text = _selectedStudent.Patronymic;
                cmbStudyingForm.SelectedIndex = (int)_selectedStudent.StudyingForm;
                txtSpeciality.Text = _selectedStudent.Speciality;
                txtGroup.Text = _selectedStudent.Group;
                txtYear.Text = _selectedStudent.Year.ToString();
                txtSemester.Text = _selectedStudent.Semester.ToString();
                txtAverageMark.Text = _selectedStudent.AverageMark.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtSurname.Text == "" ||
                txtName.Text == "" ||
                txtPatronymic.Text == "" ||
                txtSemester.Text == "" ||
                txtSpeciality.Text == "" ||
                txtGroup.Text == "" ||
                txtYear.Text == "" ||
                txtAverageMark.Text == "")
                MessageBox.Show("Заполните все поля!", "Ошибка!");
            else
            {
                if (_selectedStudent is null)
                    _selectedStudent = new Student();

                _selectedStudent.Name = txtName.Text;
                _selectedStudent.Surname = txtSurname.Text;
                _selectedStudent.Patronymic = txtPatronymic.Text;
                _selectedStudent.StudyingForm = (Student.FormOfStudying)cmbStudyingForm.SelectedIndex;
                _selectedStudent.Speciality = txtSpeciality.Text;
                _selectedStudent.Group = txtGroup.Text;
                _selectedStudent.Year = Convert.ToInt32(txtYear.Text);
                _selectedStudent.Semester = Convert.ToInt32(txtSemester.Text);
                _selectedStudent.AverageMark = Convert.ToSingle(txtAverageMark.Text);

                Close();
            }
        }
    }
}
