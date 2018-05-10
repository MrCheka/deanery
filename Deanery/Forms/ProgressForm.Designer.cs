namespace Deanery.Forms
{
    partial class ProgressForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSubject = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPatronymic = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPatronymic = new System.Windows.Forms.TextBox();
            this.dgvProgress = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurnameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatronymicColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semseter1Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semester2Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semester3Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semester4Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semester5Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semester6Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semester7Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semester8Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semester9Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semester10Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(13, 30);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(94, 17);
            this.lblSubject.TabIndex = 0;
            this.lblSubject.Text = "Дисциплина:";
            // 
            // cmbSubject
            // 
            this.cmbSubject.DisplayMember = "LongName";
            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(113, 23);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(321, 24);
            this.cmbSubject.TabIndex = 1;
            this.cmbSubject.ValueMember = "LongName";
            this.cmbSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSubject_SelectedIndexChanged);
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(13, 65);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(74, 17);
            this.lblSurname.TabIndex = 2;
            this.lblSurname.Text = "Фамилия:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(268, 65);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 17);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Имя:";
            // 
            // lblPatronymic
            // 
            this.lblPatronymic.AutoSize = true;
            this.lblPatronymic.Location = new System.Drawing.Point(458, 65);
            this.lblPatronymic.Name = "lblPatronymic";
            this.lblPatronymic.Size = new System.Drawing.Size(75, 17);
            this.lblPatronymic.TabIndex = 4;
            this.lblPatronymic.Text = "Отчество:";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(113, 59);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(121, 22);
            this.txtSurname.TabIndex = 5;
            this.txtSurname.TextChanged += new System.EventHandler(this.Filter);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(313, 59);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 22);
            this.txtName.TabIndex = 6;
            this.txtName.TextChanged += new System.EventHandler(this.Filter);
            // 
            // txtPatronymic
            // 
            this.txtPatronymic.Location = new System.Drawing.Point(539, 60);
            this.txtPatronymic.Name = "txtPatronymic";
            this.txtPatronymic.Size = new System.Drawing.Size(121, 22);
            this.txtPatronymic.TabIndex = 7;
            this.txtPatronymic.TextChanged += new System.EventHandler(this.Filter);
            // 
            // dgvProgress
            // 
            this.dgvProgress.AllowUserToAddRows = false;
            this.dgvProgress.AllowUserToDeleteRows = false;
            this.dgvProgress.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProgress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProgress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SurnameColumn,
            this.NameColumn,
            this.PatronymicColumn,
            this.semseter1Column,
            this.semester2Column,
            this.semester3Column,
            this.semester4Column,
            this.semester5Column,
            this.semester6Column,
            this.semester7Column,
            this.semester8Column,
            this.semester9Column,
            this.semester10Column,
            this.StudentIdColumn});
            this.dgvProgress.Location = new System.Drawing.Point(16, 103);
            this.dgvProgress.Name = "dgvProgress";
            this.dgvProgress.RowTemplate.Height = 24;
            this.dgvProgress.Size = new System.Drawing.Size(666, 481);
            this.dgvProgress.TabIndex = 8;
            this.dgvProgress.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProgress_CellEndEdit);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(707, 125);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(707, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(707, 184);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(118, 23);
            this.btnReport.TabIndex = 12;
            this.btnReport.Text = "Отчет";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 60F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Фамилия";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 46;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 60F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Имя";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 46;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 60F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Отчество";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 47;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 13.77597F;
            this.dataGridViewTextBoxColumn4.HeaderText = "1";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 46;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 13.77597F;
            this.dataGridViewTextBoxColumn5.HeaderText = "2";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 46;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 13.77597F;
            this.dataGridViewTextBoxColumn6.HeaderText = "3";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 46;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.FillWeight = 13.77597F;
            this.dataGridViewTextBoxColumn7.HeaderText = "4";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 47;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.FillWeight = 13.77597F;
            this.dataGridViewTextBoxColumn8.HeaderText = "5";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 46;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.FillWeight = 13.77597F;
            this.dataGridViewTextBoxColumn9.HeaderText = "6";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 46;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.FillWeight = 13.77597F;
            this.dataGridViewTextBoxColumn10.HeaderText = "7";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 46;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.FillWeight = 13.77597F;
            this.dataGridViewTextBoxColumn11.HeaderText = "8";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 47;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.FillWeight = 13.77597F;
            this.dataGridViewTextBoxColumn12.HeaderText = "9";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 46;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.FillWeight = 13.77597F;
            this.dataGridViewTextBoxColumn13.HeaderText = "10";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 46;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "StudentId";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // SurnameColumn
            // 
            this.SurnameColumn.FillWeight = 60F;
            this.SurnameColumn.HeaderText = "Фамилия";
            this.SurnameColumn.Name = "SurnameColumn";
            this.SurnameColumn.ReadOnly = true;
            // 
            // NameColumn
            // 
            this.NameColumn.FillWeight = 60F;
            this.NameColumn.HeaderText = "Имя";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // PatronymicColumn
            // 
            this.PatronymicColumn.FillWeight = 60F;
            this.PatronymicColumn.HeaderText = "Отчество";
            this.PatronymicColumn.Name = "PatronymicColumn";
            this.PatronymicColumn.ReadOnly = true;
            // 
            // semseter1Column
            // 
            this.semseter1Column.FillWeight = 13.77597F;
            this.semseter1Column.HeaderText = "1";
            this.semseter1Column.Name = "semseter1Column";
            // 
            // semester2Column
            // 
            this.semester2Column.FillWeight = 13.77597F;
            this.semester2Column.HeaderText = "2";
            this.semester2Column.Name = "semester2Column";
            // 
            // semester3Column
            // 
            this.semester3Column.FillWeight = 13.77597F;
            this.semester3Column.HeaderText = "3";
            this.semester3Column.Name = "semester3Column";
            // 
            // semester4Column
            // 
            this.semester4Column.FillWeight = 13.77597F;
            this.semester4Column.HeaderText = "4";
            this.semester4Column.Name = "semester4Column";
            // 
            // semester5Column
            // 
            this.semester5Column.FillWeight = 13.77597F;
            this.semester5Column.HeaderText = "5";
            this.semester5Column.Name = "semester5Column";
            // 
            // semester6Column
            // 
            this.semester6Column.FillWeight = 13.77597F;
            this.semester6Column.HeaderText = "6";
            this.semester6Column.Name = "semester6Column";
            // 
            // semester7Column
            // 
            this.semester7Column.FillWeight = 13.77597F;
            this.semester7Column.HeaderText = "7";
            this.semester7Column.Name = "semester7Column";
            // 
            // semester8Column
            // 
            this.semester8Column.FillWeight = 13.77597F;
            this.semester8Column.HeaderText = "8";
            this.semester8Column.Name = "semester8Column";
            // 
            // semester9Column
            // 
            this.semester9Column.FillWeight = 13.77597F;
            this.semester9Column.HeaderText = "9";
            this.semester9Column.Name = "semester9Column";
            // 
            // semester10Column
            // 
            this.semester10Column.FillWeight = 13.77597F;
            this.semester10Column.HeaderText = "10";
            this.semester10Column.Name = "semester10Column";
            // 
            // StudentIdColumn
            // 
            this.StudentIdColumn.HeaderText = "StudentId";
            this.StudentIdColumn.Name = "StudentIdColumn";
            this.StudentIdColumn.ReadOnly = true;
            this.StudentIdColumn.Visible = false;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 595);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvProgress);
            this.Controls.Add(this.txtPatronymic);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.lblPatronymic);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.lblSubject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressForm";
            this.ShowIcon = false;
            this.Text = "Успеваемость";
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPatronymic;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPatronymic;
        private System.Windows.Forms.DataGridView dgvProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurnameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatronymicColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn semseter1Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn semester2Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn semester3Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn semester4Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn semester5Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn semester6Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn semester7Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn semester8Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn semester9Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn semester10Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentIdColumn;
    }
}