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

namespace ProcessExplorer
{
    public partial class Details : Form
    {
        private ICollection collection;

        private Details()
        {
            InitializeComponent();
            this.Load += Details_Load;
        }

        public Details(ICollection c)
            : this()
        {
            this.collection = c;
        }

        private void Details_Load(object sender, EventArgs e)
        {
            ListViewItem lvi = null;
            if (collection is ProcessThreadCollection)
            {
                this.Text = "Threads";
                this.AddColumnForThreads();
                foreach (ProcessThread thread in this.collection)
                {
                    lvi = new ListViewItem(this.GetValue(thread, "Id"));
                    lvi.SubItems.Add(this.GetValue(thread, "PriorityLevel"));
                    lvi.SubItems.Add(this.GetValue(thread, "BasePriority"));
                    lvi.SubItems.Add(this.GetValue(thread, "CurrentPriority"));
                    lvi.SubItems.Add(this.GetValue(thread, "StartTime"));
                    lvi.SubItems.Add(this.GetValue(thread, "ThreadState"));
                    this.lvDetails.Items.Add(lvi);
                }
            }
            else if (collection is ProcessModuleCollection)
            {
                this.Text = "Modules";
                this.AddColumnForModeles();
                foreach (ProcessModule module in this.collection)
                {
                    lvi = new ListViewItem(this.GetValue(module, "ModuleName"));
                    lvi.SubItems.Add(this.GetValue(module, "BaseAddress"));
                    lvi.SubItems.Add(this.GetValue(module, "ModuleMemorySize"));
                    lvi.SubItems.Add(this.GetValue(module, "FileName"));
                    this.lvDetails.Items.Add(lvi);
                }
            }

            foreach (ColumnHeader item in this.lvDetails.Columns)
            {
                this.lvDetails.AutoResizeColumn(item.Index, ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void AddColumnForThreads()
        {
            this.lvDetails.Columns.Clear();

            ColumnHeader ch = new ColumnHeader();
            ch.Text = "Id";
            this.lvDetails.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "Priority Level";
            this.lvDetails.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "Base Priority";
            this.lvDetails.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "Current Priority";
            this.lvDetails.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "Start Time";
            this.lvDetails.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "Thread State";
            this.lvDetails.Columns.Add(ch);
        }

        private void AddColumnForModeles()
        {
            this.lvDetails.Columns.Clear();

            ColumnHeader ch = new ColumnHeader();
            ch.Text = "Module Name";
            this.lvDetails.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "Base Address";
            this.lvDetails.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "Memory Size";
            this.lvDetails.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "File Name";
            this.lvDetails.Columns.Add(ch);
        }

        private string GetValue(object proc, string propertyName)
        {
            if (proc == null) { return "N/A"; }

            try
            {
                Type type = proc.GetType();
                PropertyInfo pi = type.GetProperty(propertyName);
                return pi.GetValue(proc).ToString();
            }
            catch
            {
                return "N/A";
            }
        }
    }
}