namespace Deanery.Forms
{
    partial class Students
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiSubjects = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProgress = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.SurnameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatronymicColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudyingFormColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecialityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SemesterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageMarkColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formOfStudyingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formOfStudyingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSubjects,
            this.tsmiAttendance,
            this.tsmiProgress,
            this.tsmiSettings,
            this.tsmiExit});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(909, 28);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // tsmiSubjects
            // 
            this.tsmiSubjects.Name = "tsmiSubjects";
            this.tsmiSubjects.Size = new System.Drawing.Size(111, 24);
            this.tsmiSubjects.Text = "Дисциплины";
            // 
            // tsmiAttendance
            // 
            this.tsmiAttendance.Name = "tsmiAttendance";
            this.tsmiAttendance.Size = new System.Drawing.Size(125, 24);
            this.tsmiAttendance.Text = "Посещаемость";
            // 
            // tsmiProgress
            // 
            this.tsmiProgress.Name = "tsmiProgress";
            this.tsmiProgress.Size = new System.Drawing.Size(119, 24);
            this.tsmiProgress.Text = "Успеваемость";
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(96, 24);
            this.tsmiSettings.Text = "Настройки";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(65, 24);
            this.tsmiExit.Text = "Выход";
            // 
            // dgvStudents
            // 
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SurnameColumn,
            this.NameColumn,
            this.PatronymicColumn,
            this.StudyingFormColumn,
            this.SpecialityColumn,
            this.GroupColumn,
            this.YearColumn,
            this.SemesterColumn,
            this.AverageMarkColumn});
            this.dgvStudents.Location = new System.Drawing.Point(25, 123);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowTemplate.Height = 24;
            this.dgvStudents.Size = new System.Drawing.Size(617, 357);
            this.dgvStudents.TabIndex = 1;
            // 
            // SurnameColumn
            // 
            this.SurnameColumn.DataPropertyName = "Surname";
            this.SurnameColumn.HeaderText = "Фамилия";
            this.SurnameColumn.Name = "SurnameColumn";
            this.SurnameColumn.ReadOnly = true;
            // 
            // NameColumn
            // 
            this.NameColumn.DataPropertyName = "Name";
            this.NameColumn.HeaderText = "Имя";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // PatronymicColumn
            // 
            this.PatronymicColumn.DataPropertyName = "Patronymic";
            this.PatronymicColumn.HeaderText = "Отчество";
            this.PatronymicColumn.Name = "PatronymicColumn";
            this.PatronymicColumn.ReadOnly = true;
            // 
            // StudyingFormColumn
            // 
            this.StudyingFormColumn.DataPropertyName = "StudyingForm";
            this.StudyingFormColumn.HeaderText = "Форма обучения";
            this.StudyingFormColumn.Name = "StudyingFormColumn";
            this.StudyingFormColumn.ReadOnly = true;
            // 
            // SpecialityColumn
            // 
            this.SpecialityColumn.DataPropertyName = "Speciality";
            this.SpecialityColumn.HeaderText = "Специальность";
            this.SpecialityColumn.Name = "SpecialityColumn";
            this.SpecialityColumn.ReadOnly = true;
            // 
            // GroupColumn
            // 
            this.GroupColumn.DataPropertyName = "Group";
            this.GroupColumn.HeaderText = "Группа";
            this.GroupColumn.Name = "GroupColumn";
            this.GroupColumn.ReadOnly = true;
            // 
            // YearColumn
            // 
            this.YearColumn.DataPropertyName = "Year";
            this.YearColumn.HeaderText = "Курс";
            this.YearColumn.Name = "YearColumn";
            this.YearColumn.ReadOnly = true;
            // 
            // SemesterColumn
            // 
            this.SemesterColumn.DataPropertyName = "Semester";
            this.SemesterColumn.HeaderText = "Семестер";
            this.SemesterColumn.Name = "SemesterColumn";
            this.SemesterColumn.ReadOnly = true;
            // 
            // AverageMarkColumn
            // 
            this.AverageMarkColumn.DataPropertyName = "AverageMark";
            this.AverageMarkColumn.HeaderText = "Средний балл";
            this.AverageMarkColumn.Name = "AverageMarkColumn";
            this.AverageMarkColumn.ReadOnly = true;
            // 
            // formOfStudyingBindingSource
            // 
            this.formOfStudyingBindingSource.DataSource = typeof(Deanery.Classes.Student.FormOfStudying);
            // 
            // Students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 517);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "Students";
            this.Text = "Студенты";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Students_FormClosed);
            this.Load += new System.EventHandler(this.Students_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formOfStudyingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiSubjects;
        private System.Windows.Forms.ToolStripMenuItem tsmiAttendance;
        private System.Windows.Forms.ToolStripMenuItem tsmiProgress;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.BindingSource formOfStudyingBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurnameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatronymicColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudyingFormColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecialityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SemesterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageMarkColumn;
    }
}

