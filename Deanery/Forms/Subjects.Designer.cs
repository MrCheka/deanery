namespace Deanery.Forms
{
    partial class Subjects
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
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.lblShortName = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLongName = new System.Windows.Forms.Label();
            this.txtLongName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SubjectIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LongNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectIdColumn,
            this.ShortNameColumn,
            this.LongNameColumn});
            this.dgvSubjects.Location = new System.Drawing.Point(28, 75);
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.RowTemplate.Height = 24;
            this.dgvSubjects.Size = new System.Drawing.Size(464, 344);
            this.dgvSubjects.TabIndex = 0;
            // 
            // lblShortName
            // 
            this.lblShortName.AutoSize = true;
            this.lblShortName.Location = new System.Drawing.Point(28, 28);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(169, 17);
            this.lblShortName.TabIndex = 1;
            this.lblShortName.Text = "Сокращенное название:";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(204, 22);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(100, 22);
            this.txtShortName.TabIndex = 2;
            this.txtShortName.TextChanged += new System.EventHandler(this.Filter);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "subject_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ShortName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Сокращенное название";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "LongName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Полное название";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // lblLongName
            // 
            this.lblLongName.AutoSize = true;
            this.lblLongName.Location = new System.Drawing.Point(343, 27);
            this.lblLongName.Name = "lblLongName";
            this.lblLongName.Size = new System.Drawing.Size(128, 17);
            this.lblLongName.TabIndex = 3;
            this.lblLongName.Text = "Полное название:";
            // 
            // txtLongName
            // 
            this.txtLongName.Location = new System.Drawing.Point(478, 21);
            this.txtLongName.Name = "txtLongName";
            this.txtLongName.Size = new System.Drawing.Size(100, 22);
            this.txtLongName.TabIndex = 4;
            this.txtLongName.TextChanged += new System.EventHandler(this.Filter);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(515, 86);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(515, 116);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(124, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(515, 146);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(124, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // SubjectIdColumn
            // 
            this.SubjectIdColumn.DataPropertyName = "SubjectId";
            this.SubjectIdColumn.HeaderText = "subject_id";
            this.SubjectIdColumn.Name = "SubjectIdColumn";
            this.SubjectIdColumn.Visible = false;
            // 
            // ShortNameColumn
            // 
            this.ShortNameColumn.DataPropertyName = "ShortName";
            this.ShortNameColumn.HeaderText = "Сокращенное название";
            this.ShortNameColumn.Name = "ShortNameColumn";
            this.ShortNameColumn.ReadOnly = true;
            // 
            // LongNameColumn
            // 
            this.LongNameColumn.DataPropertyName = "LongName";
            this.LongNameColumn.HeaderText = "Полное название";
            this.LongNameColumn.Name = "LongNameColumn";
            this.LongNameColumn.ReadOnly = true;
            // 
            // Subjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 462);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtLongName);
            this.Controls.Add(this.lblLongName);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.lblShortName);
            this.Controls.Add(this.dgvSubjects);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Subjects";
            this.ShowIcon = false;
            this.Text = "Дисциплины";
            this.Load += new System.EventHandler(this.Subjects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSubjects;
        private System.Windows.Forms.Label lblShortName;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label lblLongName;
        private System.Windows.Forms.TextBox txtLongName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LongNameColumn;
    }
}