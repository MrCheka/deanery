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
    public partial class OneSubjectForm : Form
    {
        public enum WorkMode
        {
            AddSubject = 0,
            EditSubject = 1
        }

        private Subject _selectedSubject;
        private WorkMode _workMode;

        public OneSubjectForm(WorkMode workMode, Subject selectedSubject)
        {
            _workMode = workMode;
            _selectedSubject = selectedSubject;
            InitializeComponent();
            if (workMode == WorkMode.AddSubject)
                Text = "Добавление дисциплины";
            else if (workMode == WorkMode.EditSubject)
                Text = "Редактирование дисциплины";
        }

        public Subject ShowDialog()
        {
            base.ShowDialog();
            return _selectedSubject;
        }

        private void OneSubjectForm_Load(object sender, EventArgs e)
        {
            if (_selectedSubject.SubjectId != 0)
            {
                txtLongName.Text = _selectedSubject.LongName;
                txtShortName.Text = _selectedSubject.ShortName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtLongName.Text == "" ||
                txtShortName.Text == "")
                MessageBox.Show("Заполните все поля!", "Ошибка!");
            else
            {
                if (_selectedSubject is null)
                    _selectedSubject = new Subject();

                _selectedSubject.ShortName = txtShortName.Text;
                _selectedSubject.LongName = txtLongName.Text;

                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
