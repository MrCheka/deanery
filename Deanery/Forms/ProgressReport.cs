using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deanery.Forms
{
    public partial class ProgressReport : Form
    {
        private List<progressDS> _progress;

        public ProgressReport(DataGridView dgvProgress, string longName)
        {
            _progress = new List<progressDS>();
            InitializeComponent();
            for (int i = 0; i < dgvProgress.Rows.Count; i++)
            {
                var newProgress = new progressDS();
                newProgress.LongName = longName;
                newProgress.Surname = dgvProgress[0, i].Value.ToString();
                newProgress.Name = dgvProgress[1, i].Value.ToString();
                newProgress.Patronymic = dgvProgress[2, i].Value.ToString();
                newProgress.semester1 = Convert.ToString(dgvProgress[3, i].Value);
                newProgress.semester2 = Convert.ToString(dgvProgress[4, i].Value);
                newProgress.semester3 = Convert.ToString(dgvProgress[5, i].Value);
                newProgress.semester4 = Convert.ToString(dgvProgress[6, i].Value);
                newProgress.semester5 = Convert.ToString(dgvProgress[7, i].Value);
                newProgress.semester6 = Convert.ToString(dgvProgress[8, i].Value);
                newProgress.semester7 = Convert.ToString(dgvProgress[9, i].Value);
                newProgress.semester8 = Convert.ToString(dgvProgress[10, i].Value);
                newProgress.semester9 = Convert.ToString(dgvProgress[11, i].Value);
                newProgress.semester10 = Convert.ToString(dgvProgress[12, i].Value);

                _progress.Add(newProgress);
            }

            var ds = new Microsoft.Reporting.WinForms.ReportDataSource("progressDS", _progress);

            reportViewer.LocalReport.DataSources.Add(ds);

            ds.Value = _progress;

            reportViewer.LocalReport.Refresh();
        }

        private void ProgressReport_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
        }
    }

    public class progressDS
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string LongName { get; set; }
        public string semester1 { get; set; }
        public string semester2 { get; set; }
        public string semester3 { get; set; }
        public string semester4 { get; set; }
        public string semester5 { get; set; }
        public string semester6 { get; set; }
        public string semester7 { get; set; }
        public string semester8 { get; set; }
        public string semester9 { get; set; }
        public string semester10 { get; set; }
    }
}
