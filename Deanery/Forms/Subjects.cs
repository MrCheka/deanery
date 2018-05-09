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
    public partial class Subjects : Form
    {
        private SubjectList _subjectList;
        private BindingSource _bindingSource;

        public Subjects()
        {
            _subjectList = new SubjectList();
            InitializeComponent();
            dgvSubjects.AutoGenerateColumns = false;
        }

        private void Subjects_Load(object sender, EventArgs e)
        {
            _subjectList.Fill();
            dgvSubjects.DataSource = _bindingSource;
        }

        private void txtShortName_TextChanged(object sender, EventArgs e)
        {
            _bindingSource.Filter =
                string.Format("ShortName = 'ЛОИС'", txtShortName.Text);
            dgvSubjects.DataSource = _bindingSource;
        }
    }
}
