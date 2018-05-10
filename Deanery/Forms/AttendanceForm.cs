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
    public partial class AttendanceForm : Form
    {
        private Attendance _attendance;
        private SubjectList _subjectList;

        public AttendanceForm()
        {
            _subjectList = new SubjectList();
            _attendance = new Attendance();
            InitializeComponent();
            dgvAttendance.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            _attendance.Subject = _subjectList.Value[cmbSubject.SelectedIndex];
            _attendance.Fill();
            FillDataGridView();
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            _subjectList.Fill();
            cmbSubject.DataSource = _subjectList.Value;
        }

        private void FillDataGridView()
        {
            dgvAttendance.Rows.Clear();
            dgvAttendance.Columns.Clear();
            StudentList studentList = new StudentList();
            studentList.Fill();
            var dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.Name = "StudentIdColumn";
            dgvColumn.Visible = false;
            dgvColumn.HeaderText = "StudentId";
            dgvColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvAttendance.Columns.Add(dgvColumn);
            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.HeaderText = "Фамилия";
            dgvColumn.Name = "SurnameColumn";
            dgvColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvColumn.ReadOnly = true;
            dgvAttendance.Columns.Add(dgvColumn);
            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.HeaderText = "Имя";
            dgvColumn.Name = "NameColumn";
            dgvColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvColumn.ReadOnly = true;
            dgvAttendance.Columns.Add(dgvColumn);
            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.HeaderText = "Отчество";
            dgvColumn.Name = "PatronymicColumn";
            dgvColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvColumn.ReadOnly = true;
            dgvAttendance.Columns.Add(dgvColumn);
            for (int i = 0; i < _attendance.LessonList.Count; i++)
            {
                var column = new DataGridViewComboBoxColumn();
                column.DataSource = new[] { "", "+", "-" };
                column.HeaderText = _attendance.LessonList[i].Date.ToShortDateString();
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvAttendance.Columns.Add(column);
            }
            for (int i = 0; i < studentList.Value.Count; i++)
            {
                int studentId = studentList.Value[i].StudentId;
                var row = new string[dgvAttendance.Columns.Count];
                row[0] = studentId.ToString();
                row[1] = studentList.Value[i].Surname;
                row[2] = studentList.Value[i].Name;
                row[3] = studentList.Value[i].Patronymic;
                for (int j = 0; j < _attendance.LessonList.Count; j++)
                {
                    if (_attendance.LessonList[j].VisitInfoList.Find(s => s.VisitStudent.StudentId == studentId).IsVisited == Lesson.State.Visited)
                        row[j + 4] = "+";
                    else if (_attendance.LessonList[j].VisitInfoList.Find(s => s.VisitStudent.StudentId == studentId).IsVisited == Lesson.State.Absent)
                        row[j + 4] = "-";
                    else
                        row[j + 4] = "";
                }

                dgvAttendance.Rows.Add(row);
            }
        }

        private void Filter(object sender, EventArgs e)
        {
            FillDataGridView();
            for (int i = 0; i < dgvAttendance.Rows.Count; i++)
            {
                if (txtSurname.Text != "" &&
                    !dgvAttendance[1, i].Value.ToString().Contains(txtSurname.Text))
                {
                    dgvAttendance.Rows.RemoveAt(i);
                    i--;
                }
                else if (txtName.Text != "" &&
                    !dgvAttendance[2, i].Value.ToString().Contains(txtName.Text))
                {
                    dgvAttendance.Rows.RemoveAt(i);
                    i--;
                }
                else if (txtPatronymic.Text != "" &&
                    !dgvAttendance[3, i].Value.ToString().Contains(txtPatronymic.Text))
                {
                    dgvAttendance.Rows.RemoveAt(i);
                    i--;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _attendance.LessonList.Add(new Lesson() { Date = DateTime.Now });
            FillDataGridView();
            _attendance.Update();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var column = dgvAttendance.SelectedColumns[0];
            if (column.Index <= 3)
                return;
            _attendance.LessonList.RemoveAt(column.Index - 4);
            FillDataGridView();
        }

        private void dgvAttendance_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
