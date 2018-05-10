using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Deanery.Classes;

namespace Deanery.Forms
{
    public partial class Subjects : Form
    {
        private SubjectList _subjectList;

        public Subjects()
        {
            _subjectList = new SubjectList();
            InitializeComponent();
            dgvSubjects.AutoGenerateColumns = false;
        }

        private void Subjects_Load(object sender, EventArgs e)
        {
            if (Service.CurrentUser.Role == User.UserRole.Student)
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnEdit.Visible = false;
            }
            _subjectList.Fill();
            dgvSubjects.DataSource = _subjectList.Value;
        }

        private void Filter(object sender, EventArgs e)
        {
            if (_subjectList is null)
                return;
            List<Subject> filtered = new List<Subject>(_subjectList.Value);
            if (txtShortName.Text != "")
                filtered = filtered.Where(i => i.ShortName.Contains(txtShortName.Text)).ToList();
            if (txtLongName.Text != "")
                filtered = filtered.Where(i => i.LongName.Contains(txtLongName.Text)).ToList();

            dgvSubjects.DataSource = filtered;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newSubject = new Subject();
            var addForm = new OneSubjectForm(OneSubjectForm.WorkMode.AddSubject, newSubject);
            newSubject = addForm.ShowDialog();
            if (newSubject != new Subject())
                _subjectList.Add(newSubject);
            _subjectList.Fill();

            dgvSubjects.DataSource = typeof(List<Subject>);
            dgvSubjects.DataSource = _subjectList.Value;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSubjects.SelectedRows.Count == 0)
                return;
            var selectedRow = dgvSubjects.SelectedRows[0];
            Subject selectedSubject = _subjectList.Find(Convert.ToInt32(selectedRow.Cells[0].Value));
            var editForm = new OneSubjectForm(OneSubjectForm.WorkMode.EditSubject, selectedSubject);
            Subject newSubject = editForm.ShowDialog();
            _subjectList.Replace(selectedSubject.SubjectId, newSubject);
            _subjectList.Update();

            dgvSubjects.DataSource = typeof(List<Subject>);
            dgvSubjects.DataSource = _subjectList.Value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSubjects.SelectedRows.Count == 0)
                return;
            var selectedRow = dgvSubjects.SelectedRows[0];
            var selectedSubject = new Subject();
            selectedSubject.SubjectId = Convert.ToInt32(selectedRow.Cells[0].Value);
            if (!_subjectList.Remove(selectedSubject))
                MessageBox.Show("Произошла ошибка при удалении!", "Ошибка!");

            dgvSubjects.DataSource = typeof(List<Subject>);
            dgvSubjects.DataSource = _subjectList.Value;
        }
    }
}
