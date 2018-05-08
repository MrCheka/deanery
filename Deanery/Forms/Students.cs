﻿using System;
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

        public Students()
        {
            InitializeComponent();
        }

        private void Students_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Students_Load(object sender, EventArgs e)
        {
            _studentList = new StudentList();
            _studentList.FillStudentList(Service.GetConnectionString());

            dgvStudents.DataSource = _studentList.Value;
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new Settings();
            settingsForm.ShowDialog();
        }
    }
}
