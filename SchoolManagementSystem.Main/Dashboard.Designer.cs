namespace SchoolManagementSystem.Main
{
    partial class Dashboard
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
            this.mnuAdmin = new System.Windows.Forms.MenuStrip();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teachersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allTeachersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer = new MetroFramework.Controls.MetroPanel();
            this.mnuTeacher = new System.Windows.Forms.MenuStrip();
            this.dashboardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noticesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStudent = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdmin.SuspendLayout();
            this.mnuTeacher.SuspendLayout();
            this.mnuStudent.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuAdmin
            // 
            this.mnuAdmin.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.studentsToolStripMenuItem,
            this.teachersToolStripMenuItem,
            this.notificationsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.mnuAdmin.Location = new System.Drawing.Point(0, 28);
            this.mnuAdmin.Name = "mnuAdmin";
            this.mnuAdmin.Size = new System.Drawing.Size(1061, 28);
            this.mnuAdmin.TabIndex = 0;
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allStudentsToolStripMenuItem,
            this.classesToolStripMenuItem});
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.studentsToolStripMenuItem.Text = "Students";
            // 
            // allStudentsToolStripMenuItem
            // 
            this.allStudentsToolStripMenuItem.Name = "allStudentsToolStripMenuItem";
            this.allStudentsToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.allStudentsToolStripMenuItem.Text = "All Students";
            this.allStudentsToolStripMenuItem.Click += new System.EventHandler(this.allStudentsToolStripMenuItem_Click);
            // 
            // classesToolStripMenuItem
            // 
            this.classesToolStripMenuItem.Name = "classesToolStripMenuItem";
            this.classesToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.classesToolStripMenuItem.Text = "Classes";
            this.classesToolStripMenuItem.Click += new System.EventHandler(this.classesToolStripMenuItem_Click);
            // 
            // teachersToolStripMenuItem
            // 
            this.teachersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allTeachersToolStripMenuItem,
            this.subjectsToolStripMenuItem});
            this.teachersToolStripMenuItem.Name = "teachersToolStripMenuItem";
            this.teachersToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.teachersToolStripMenuItem.Text = "Teachers";
            // 
            // allTeachersToolStripMenuItem
            // 
            this.allTeachersToolStripMenuItem.Name = "allTeachersToolStripMenuItem";
            this.allTeachersToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.allTeachersToolStripMenuItem.Text = "All Teachers";
            this.allTeachersToolStripMenuItem.Click += new System.EventHandler(this.allTeachersToolStripMenuItem_Click);
            // 
            // subjectsToolStripMenuItem
            // 
            this.subjectsToolStripMenuItem.Name = "subjectsToolStripMenuItem";
            this.subjectsToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.subjectsToolStripMenuItem.Text = "Subjects";
            this.subjectsToolStripMenuItem.Click += new System.EventHandler(this.subjectsToolStripMenuItem_Click);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.notificationsToolStripMenuItem.Text = "Notices";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.HorizontalScrollbarBarColor = true;
            this.pnlContainer.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlContainer.HorizontalScrollbarSize = 10;
            this.pnlContainer.Location = new System.Drawing.Point(0, 56);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1061, 673);
            this.pnlContainer.TabIndex = 1;
            this.pnlContainer.VerticalScrollbarBarColor = true;
            this.pnlContainer.VerticalScrollbarHighlightOnWheel = false;
            this.pnlContainer.VerticalScrollbarSize = 10;
            // 
            // mnuTeacher
            // 
            this.mnuTeacher.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuTeacher.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem1,
            this.logoutToolStripMenuItem1,
            this.uploadResultToolStripMenuItem,
            this.noticesToolStripMenuItem});
            this.mnuTeacher.Location = new System.Drawing.Point(0, 0);
            this.mnuTeacher.Name = "mnuTeacher";
            this.mnuTeacher.Size = new System.Drawing.Size(1061, 28);
            this.mnuTeacher.TabIndex = 2;
            this.mnuTeacher.Text = "menuStrip1";
            // 
            // dashboardToolStripMenuItem1
            // 
            this.dashboardToolStripMenuItem1.Name = "dashboardToolStripMenuItem1";
            this.dashboardToolStripMenuItem1.Size = new System.Drawing.Size(94, 24);
            this.dashboardToolStripMenuItem1.Text = "Dashboard";
            // 
            // logoutToolStripMenuItem1
            // 
            this.logoutToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logoutToolStripMenuItem1.Name = "logoutToolStripMenuItem1";
            this.logoutToolStripMenuItem1.Size = new System.Drawing.Size(68, 24);
            this.logoutToolStripMenuItem1.Text = "Logout";
            this.logoutToolStripMenuItem1.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // uploadResultToolStripMenuItem
            // 
            this.uploadResultToolStripMenuItem.Name = "uploadResultToolStripMenuItem";
            this.uploadResultToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.uploadResultToolStripMenuItem.Text = "Upload Result";
            this.uploadResultToolStripMenuItem.Click += new System.EventHandler(this.uploadResultToolStripMenuItem_Click);
            // 
            // noticesToolStripMenuItem
            // 
            this.noticesToolStripMenuItem.Name = "noticesToolStripMenuItem";
            this.noticesToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.noticesToolStripMenuItem.Text = "Notices";
            this.noticesToolStripMenuItem.Click += new System.EventHandler(this.noticesToolStripMenuItem_Click);
            // 
            // mnuStudent
            // 
            this.mnuStudent.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuStudent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.mnuStudent.Location = new System.Drawing.Point(0, 56);
            this.mnuStudent.Name = "mnuStudent";
            this.mnuStudent.Size = new System.Drawing.Size(1061, 28);
            this.mnuStudent.TabIndex = 3;
            this.mnuStudent.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(94, 24);
            this.toolStripMenuItem1.Text = "Dashboard";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(68, 24);
            this.toolStripMenuItem2.Text = "Logout";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(67, 24);
            this.toolStripMenuItem3.Text = "Results";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(71, 24);
            this.toolStripMenuItem4.Text = "Notices";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 729);
            this.Controls.Add(this.mnuStudent);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.mnuAdmin);
            this.Controls.Add(this.mnuTeacher);
            this.MainMenuStrip = this.mnuAdmin;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.mnuAdmin.ResumeLayout(false);
            this.mnuAdmin.PerformLayout();
            this.mnuTeacher.ResumeLayout(false);
            this.mnuTeacher.PerformLayout();
            this.mnuStudent.ResumeLayout(false);
            this.mnuStudent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuAdmin;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teachersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private MetroFramework.Controls.MetroPanel pnlContainer;
        private System.Windows.Forms.MenuStrip mnuTeacher;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allTeachersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noticesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mnuStudent;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
    }
}