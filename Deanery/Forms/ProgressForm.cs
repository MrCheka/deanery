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
    public partial class ProgressForm : Form
    {
        private ExamList _examList;
        private SubjectList _subjectList;

        public ProgressForm()
        {
            _examList = new ExamList();
            _subjectList = new SubjectList();
            InitializeComponent();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            _examList.Fill();
            _subjectList.Fill();
            cmbSubject.DataSource = _subjectList.Value;
        }

        private void FillDataGridView()
        {
            dgvProgress.Rows.Clear();
            StudentList studentList = new StudentList();
            studentList.Fill();
            foreach (var item in studentList.Value)
            {
                var row = new string[dgvProgress.ColumnCount];
                row[0] = item.Surname;
                row[1] = item.Name;
                row[2] = item.Patronymic;
                row[dgvProgress.ColumnCount - 1] = item.StudentId.ToString();
                foreach (var exam in _examList.Value)
                {
                    if (exam.StudentExam == item &&
                        exam.SubjectExam == _subjectList.Value[cmbSubject.SelectedIndex])
                        row[exam.Number + 2] = exam.Mark.ToString();
                }

                dgvProgress.Rows.Add(row);
            }
        }

        private void Filter(object sender, EventArgs e)
        {
            FillDataGridView();
            for (int i = 0; i < dgvProgress.Rows.Count; i++)
            {
                if (txtSurname.Text != "" &&
                    !dgvProgress[0, i].Value.ToString().Contains(txtSurname.Text))
                {
                    dgvProgress.Rows.RemoveAt(i);
                    i--;
                }
                else if (txtName.Text != "" &&
                    !dgvProgress[1, i].Value.ToString().Contains(txtName.Text))
                {
                    dgvProgress.Rows.RemoveAt(i);
                    i--;
                }
                else if (txtPatronymic.Text != "" &&
                    !dgvProgress[2, i].Value.ToString().Contains(txtPatronymic.Text))
                {
                    dgvProgress.Rows.RemoveAt(i);
                    i--;
                }
            }
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void dgvProgress_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var newExam = new Exam();
            newExam.Mark = Convert.ToInt32(dgvProgress[e.ColumnIndex, e.RowIndex].Value);
            newExam.Number = e.ColumnIndex - 2;
            newExam.StudentExam.StudentId = Convert.ToInt32(dgvProgress[dgvProgress.ColumnCount - 1, e.RowIndex].Value);
            newExam.SubjectExam = _subjectList.Value[cmbSubject.SelectedIndex];
            _examList.Value.Add(newExam);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _examList.Update();
            _examList.Fill();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _examList.Fill();
            FillDataGridView();
        }
    }
}
