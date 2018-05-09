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
            this.SubjectIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LongNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblShortName = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectIdColumn,
            this.ShortNameColumn,
            this.LongNameColumn});
            this.dgvSubjects.Location = new System.Drawing.Point(28, 75);
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.RowTemplate.Height = 24;
            this.dgvSubjects.Size = new System.Drawing.Size(420, 267);
            this.dgvSubjects.TabIndex = 0;
            // 
            // SubjectIdColumn
            // 
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
            this.txtShortName.TextChanged += new System.EventHandler(this.txtShortName_TextChanged);
            // 
            // Subjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 462);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.lblShortName);
            this.Controls.Add(this.dgvSubjects);
            this.Name = "Subjects";
            this.Text = "Subjects";
            this.Load += new System.EventHandler(this.Subjects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSubjects;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LongNameColumn;
        private System.Windows.Forms.Label lblShortName;
        private System.Windows.Forms.TextBox txtShortName;
    }
}