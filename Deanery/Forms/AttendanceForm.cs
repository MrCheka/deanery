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
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            _attendance.Subject = _subjectList.Value[cmbSubject.SelectedIndex];
            _attendance.Fill();
            for (int i = 0; i < _attendance.LessonList.Count; i++)
            {
                dgvAttendance.Columns.Add($"{_attendance.LessonList[i].LessonId}",
                    $"{_attendance.LessonList[0].Date.ToShortDateString()}");
            }
            for (int i = 0; i < _attendance.ListOfStudents.Count; i++)
            {
                string[] row = new string[dgvAttendance.ColumnCount];
                row[0] = _attendance.ListOfStudents[i].Surname;
                row[1] = _attendance.ListOfStudents[i].Name;
                row[2] = _attendance.ListOfStudents[i].Patronymic;
                for (int j = 0; j < _attendance.LessonList.Count; j++)
                    row[3 + j] = _attendance.LessonList[j].VisitInfo[i].ToString();
            }
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            _subjectList.Fill();
            cmbSubject.DataSource = _subjectList.Value;
        }
    }
}
