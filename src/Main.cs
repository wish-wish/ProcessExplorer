using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace ProcessExplorer
{
    public partial class Main : Form
    {
        private delegate void UpdateListView();
        private Thread updateThread;
        private List<ProcessInfo> processesParams = new List<ProcessInfo>();

        public Main()
        {
            InitializeComponent();

            this.Load += Form1_Load;

            ColumnHeader ch = new ColumnHeader();
            ch.Text = "Name";
            ch.Width = 100;
            this.lvProcesses.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "Id";
            ch.Width = 100;
            this.lvProcesses.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "Priority";
            ch.Width = 100;
            this.lvProcesses.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "Threads";
            ch.Width = 100;
            this.lvProcesses.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "Modules";
            ch.Width = 100;
            this.lvProcesses.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "Start Time";
            ch.Width = 100;
            this.lvProcesses.Columns.Add(ch);

            for (int i = 0; i < this.lvProcesses.Columns.Count; i++)
            {
                this.lvProcesses.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
            }

        }

        #region EVENTS
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.lvProcesses.ListViewItemSorter = new ProcessComparerByName();
            this.GetProcess();
            this.ShowProcess();

            updateThread = new Thread(UpdateAll);
            updateThread.IsBackground = true;
            updateThread.Start();
        }
        
        private void details_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem menu = sender as ToolStripMenuItem;
                if (menu == null) { return; }

                if (this.lvProcesses.SelectedIndices.Count != 1) { return; }

                ProcessInfo pi = this.lvProcesses.SelectedItems[0].Tag as ProcessInfo;
                if (pi == null) { return; }

                Process proc = pi.Process;

                Details detailsForm = null;
                switch (menu.Name)
                {
                    case "cmnThreads":
                        detailsForm = new Details(proc.Threads);
                        break;
                    case "cmnModules":
                        detailsForm = new Details(proc.Modules);
                        break;
                    default:
                        throw new ApplicationException("Не известный пункт меню");
                }
                if (detailsForm != null)
                {
                    detailsForm.Show();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Не удалось получить информацию", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmnKill_Click(object sender, EventArgs e)
        {
            if (this.lvProcesses.SelectedIndices.Count != 1) { return; }

            ProcessInfo pi = this.lvProcesses.SelectedItems[0].Tag as ProcessInfo;
            if (pi == null) { return; }

            Process proc = pi.Process;
            try
            {
                proc.Kill();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Не удалось убить процесс",  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmnRun_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Исполняемые|*.exe";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Process.Start(ofd.FileName);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Не удалось убить процесс", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmnPriority_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                if (this.lvProcesses.SelectedIndices.Count != 1) { return; }

                ProcessInfo pi = this.lvProcesses.SelectedItems[0].Tag as ProcessInfo;
                if (pi == null) { return; }

                Process proc = pi.Process;

                foreach (ToolStripMenuItem item in this.cmnPriority.DropDownItems)
                {
                    if (item.Checked == true) { item.Checked = false; }
                }

                switch (proc.PriorityClass)
                {
                    case ProcessPriorityClass.AboveNormal:
                        this.cmnAboveNormal.Checked = true;
                        break;
                    case ProcessPriorityClass.BelowNormal:
                        this.cmnBelowNormal.Checked = true;
                        break;
                    case ProcessPriorityClass.High:
                        this.cmnHigh.Checked = true;
                        break;
                    case ProcessPriorityClass.Idle:
                        this.cmnIdle.Checked = true;
                        break;
                    case ProcessPriorityClass.Normal:
                        this.cmnNormal.Checked = true;
                        break;
                    case ProcessPriorityClass.RealTime:
                        this.cmnReal.Checked = true;
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        private void cmnPriority_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lvProcesses.SelectedIndices.Count != 1) { return; }

                ProcessInfo pi = this.lvProcesses.SelectedItems[0].Tag as ProcessInfo;
                if (pi == null) { return; }

                Process proc = pi.Process;

                foreach (ToolStripMenuItem item in this.cmnPriority.DropDownItems)
	            {
                    if (item.Checked == true) { item.Checked = false; }
	            }

                ProcessPriorityClass priority = ProcessPriorityClass.Normal; 
                ToolStripMenuItem menu = sender as ToolStripMenuItem;
                switch (menu.Name)
                {
                    case "cmnIdle":
                        priority = ProcessPriorityClass.Idle;
                        break;
                    case "cmnBelowNormal":
                        priority = ProcessPriorityClass.BelowNormal;
                        break;
                    case "cmnNormal":
                        priority = ProcessPriorityClass.Normal;
                        break;
                    case "cmnAboveNormal":
                        priority = ProcessPriorityClass.AboveNormal;
                        break;
                    case "cmnHigh":
                        priority = ProcessPriorityClass.High;
                        break;
                    case "cmnReal":
                        priority = ProcessPriorityClass.RealTime;
                        break;
                    default:
                        break;
                }
                proc.PriorityClass = priority;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Не удалось изменить приоритет процеасса", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region HELPERS

        private void GetProcess()
        {
            this.processesParams.Clear();
            Process[] currentProcesses = (from p in Process.GetProcesses() orderby p.ProcessName select p).ToArray<Process>();
            foreach (Process proc in currentProcesses)
            {
                this.processesParams.Add(new ProcessInfo(proc));
            }
        }

        private void ShowProcess()
        {
            ListViewItem lvi = null;
            foreach (ProcessInfo pi in this.processesParams)
            {
                lvi = new ListViewItem(pi.Name);
                lvi.SubItems.Add(pi.Id);
                lvi.SubItems.Add(pi.Priority);
                lvi.SubItems.Add(pi.Threads);
                lvi.SubItems.Add(pi.Modules);
                lvi.SubItems.Add(pi.StartTime);
                lvi.Tag = pi;
                this.lvProcesses.Items.Add(lvi);
            }
            foreach (ColumnHeader item in this.lvProcesses.Columns)
            {
                this.lvProcesses.AutoResizeColumn(item.Index, ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            this.Text = "Processes: " + this.lvProcesses.Items.Count.ToString();
        }

        private void UpdateList()
        {
            DateTime dt = DateTime.Now;

            ListViewItem selectedItem = null;
            if (this.lvProcesses.SelectedIndices.Count == 1)
            {
                selectedItem = this.lvProcesses.SelectedItems[0];
            }

            foreach (ListViewItem item in this.lvProcesses.Items)
            {
                ProcessInfo piInLv = item.Tag as ProcessInfo;
               
                //Удаление
                if (!this.processesParams.Contains(piInLv))
                {
                    this.lvProcesses.Items.Remove(item);
                }
                //Обновление
                else
                {
                    //int pIndex = this.processesParams.IndexOf(piInLv);
                    ProcessInfo piInList = this.processesParams.Find((match) => match.Equals(piInLv));

                    if (piInList.Priority != item.SubItems[2].Text)
                    {
                        item.SubItems[2].Text = piInList.Priority;
                    }

                    if (piInList.Threads != item.SubItems[3].Text)
                    {
                        item.SubItems[3].Text = piInList.Threads;
                    }

                    if (piInList.Modules != item.SubItems[4].Text)
                    {
                        item.SubItems[4].Text = piInList.Modules;
                    }
                }
            }

            //Добавление

            foreach (ProcessInfo item in this.processesParams)
            {
                if (this.IsProcessInListView(item) == false)
                {
                    ListViewItem lvi = new ListViewItem(item.Name);
                    lvi.SubItems.Add(item.Id);
                    lvi.SubItems.Add(item.Priority);
                    lvi.SubItems.Add(item.Threads);
                    lvi.SubItems.Add(item.Modules);
                    lvi.SubItems.Add(item.StartTime);
                    lvi.Tag = item;
                    this.lvProcesses.Items.Add(lvi);
                }
            }

            if (selectedItem != null && this.lvProcesses.Items.Contains(selectedItem))
            {
                this.lvProcesses.Select();
                selectedItem.Selected = true;
            }

            TimeSpan ts = DateTime.Now - dt;
            this.Text = String.Format("Процессов: {0} Обновление: {1}", this.lvProcesses.Items.Count, ts.TotalMilliseconds);
        }

        private void UpdateAll()
        {
            while (true)
            {
                Thread.Sleep(1000);
                this.GetProcess();
                this.lvProcesses.Invoke(new UpdateListView(this.UpdateList));
            }
        }

        private bool IsProcessInListView(ProcessInfo pi)
        {
            foreach (ListViewItem item in this.lvProcesses.Items)
            {
                ProcessInfo currentPi = item.Tag as ProcessInfo;
                if (pi.Equals(currentPi))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}