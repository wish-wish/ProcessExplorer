namespace ProcessExplorer
{
    partial class Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvProcesses = new System.Windows.Forms.ListView();
            this.cmProcesses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnPriority = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnIdle = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnBelowNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnAboveNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnHigh = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnReal = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnKill = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnThreads = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnModules = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnRun = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmProcesses.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvProcesses
            // 
            this.lvProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProcesses.ContextMenuStrip = this.cmProcesses;
            this.lvProcesses.FullRowSelect = true;
            this.lvProcesses.GridLines = true;
            this.lvProcesses.Location = new System.Drawing.Point(13, 12);
            this.lvProcesses.MultiSelect = false;
            this.lvProcesses.Name = "lvProcesses";
            this.lvProcesses.Size = new System.Drawing.Size(639, 613);
            this.lvProcesses.TabIndex = 0;
            this.lvProcesses.UseCompatibleStateImageBehavior = false;
            this.lvProcesses.View = System.Windows.Forms.View.Details;
            // 
            // cmProcesses
            // 
            this.cmProcesses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnPriority,
            this.cmnKill,
            this.cmnThreads,
            this.cmnModules,
            this.toolStripSeparator1,
            this.cmnRun,
            this.toolStripSeparator2});
            this.cmProcesses.Name = "contextMenuStrip1";
            this.cmProcesses.Size = new System.Drawing.Size(153, 148);
            // 
            // cmnPriority
            // 
            this.cmnPriority.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnIdle,
            this.cmnBelowNormal,
            this.cmnNormal,
            this.cmnAboveNormal,
            this.cmnHigh,
            this.cmnReal});
            this.cmnPriority.Name = "cmnPriority";
            this.cmnPriority.Size = new System.Drawing.Size(152, 22);
            this.cmnPriority.Text = "Priority";
            this.cmnPriority.DropDownOpened += new System.EventHandler(this.cmnPriority_DropDownOpened);
            // 
            // cmnIdle
            // 
            this.cmnIdle.Name = "cmnIdle";
            this.cmnIdle.Size = new System.Drawing.Size(152, 22);
            this.cmnIdle.Text = "Idle";
            this.cmnIdle.Click += new System.EventHandler(this.cmnPriority_Click);
            // 
            // cmnBelowNormal
            // 
            this.cmnBelowNormal.Name = "cmnBelowNormal";
            this.cmnBelowNormal.Size = new System.Drawing.Size(152, 22);
            this.cmnBelowNormal.Text = "Below Normal";
            this.cmnBelowNormal.Click += new System.EventHandler(this.cmnPriority_Click);
            // 
            // cmnNormal
            // 
            this.cmnNormal.Name = "cmnNormal";
            this.cmnNormal.Size = new System.Drawing.Size(152, 22);
            this.cmnNormal.Text = "Normal";
            this.cmnNormal.Click += new System.EventHandler(this.cmnPriority_Click);
            // 
            // cmnAboveNormal
            // 
            this.cmnAboveNormal.Name = "cmnAboveNormal";
            this.cmnAboveNormal.Size = new System.Drawing.Size(152, 22);
            this.cmnAboveNormal.Text = "Above Normal";
            this.cmnAboveNormal.Click += new System.EventHandler(this.cmnPriority_Click);
            // 
            // cmnHigh
            // 
            this.cmnHigh.Name = "cmnHigh";
            this.cmnHigh.Size = new System.Drawing.Size(152, 22);
            this.cmnHigh.Text = "High";
            this.cmnHigh.Click += new System.EventHandler(this.cmnPriority_Click);
            // 
            // cmnReal
            // 
            this.cmnReal.Name = "cmnReal";
            this.cmnReal.Size = new System.Drawing.Size(152, 22);
            this.cmnReal.Text = "RealTime";
            this.cmnReal.Click += new System.EventHandler(this.cmnPriority_Click);
            // 
            // cmnKill
            // 
            this.cmnKill.Name = "cmnKill";
            this.cmnKill.Size = new System.Drawing.Size(152, 22);
            this.cmnKill.Text = "Kill";
            this.cmnKill.Click += new System.EventHandler(this.cmnKill_Click);
            // 
            // cmnThreads
            // 
            this.cmnThreads.Name = "cmnThreads";
            this.cmnThreads.Size = new System.Drawing.Size(152, 22);
            this.cmnThreads.Text = "Threads...";
            this.cmnThreads.Click += new System.EventHandler(this.details_Click);
            // 
            // cmnModules
            // 
            this.cmnModules.Name = "cmnModules";
            this.cmnModules.Size = new System.Drawing.Size(152, 22);
            this.cmnModules.Text = "Modules...";
            this.cmnModules.Click += new System.EventHandler(this.details_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // cmnRun
            // 
            this.cmnRun.Name = "cmnRun";
            this.cmnRun.Size = new System.Drawing.Size(152, 22);
            this.cmnRun.Text = "Run...";
            this.cmnRun.Click += new System.EventHandler(this.cmnRun_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 637);
            this.Controls.Add(this.lvProcesses);
            this.Name = "Main";
            this.Text = "Processes";
            this.cmProcesses.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvProcesses;
        private System.Windows.Forms.ContextMenuStrip cmProcesses;
        private System.Windows.Forms.ToolStripMenuItem cmnPriority;
        private System.Windows.Forms.ToolStripMenuItem cmnKill;
        private System.Windows.Forms.ToolStripMenuItem cmnModules;
        private System.Windows.Forms.ToolStripMenuItem cmnThreads;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmnRun;
        private System.Windows.Forms.ToolStripMenuItem cmnIdle;
        private System.Windows.Forms.ToolStripMenuItem cmnBelowNormal;
        private System.Windows.Forms.ToolStripMenuItem cmnNormal;
        private System.Windows.Forms.ToolStripMenuItem cmnAboveNormal;
        private System.Windows.Forms.ToolStripMenuItem cmnHigh;
        private System.Windows.Forms.ToolStripMenuItem cmnReal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

