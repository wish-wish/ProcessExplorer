using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessExplorer
{
    class ProcessComparerByName : IComparer
    {
        public int Compare(object x, object y)
        {
            ProcessInfo p1 = ((ListViewItem)x).Tag as ProcessInfo;
            ProcessInfo p2 = ((ListViewItem)y).Tag as ProcessInfo;

            if (p1 == null || p2 == null) { return 0; }

            return String.Compare(p1.Name, p2.Name);
        }
    }
}