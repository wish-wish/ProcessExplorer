using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessExplorer
{
    class ProcessInfo
    {
        public Process Process { get; set; }

        public string Name { get; set; }
        public string Id { get; set; }
        public string Priority { get; set; }
        public string Threads { get; set; }
        public string Modules { get; set; }
        public string StartTime { get; set; }

        private ProcessInfo()
        {
            this.Name = "N/A";
            this.Id = "N/A";
            this.Priority = "N/A";
            this.Threads = "N/A";
            this.Modules = "N/A";
            this.StartTime = "N/A";
        }

        public ProcessInfo(Process process)
            : this()
        {
            this.Process = process;
            try { this.Name = process.ProcessName; }
            catch { }
            try { this.Id = process.Id.ToString(); }
            catch { }
            try { this.Priority = process.PriorityClass.ToString(); }
            catch { }
            try { this.Threads = process.Threads.Count.ToString(); }
            catch { }
            try { this.Modules = process.Modules.Count.ToString(); }
            catch { }
            try { this.StartTime = process.StartTime.ToLongDateString() + " " + process.StartTime.ToLongTimeString(); }
            catch { }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }

            ProcessInfo pi = obj as ProcessInfo;

            if (pi == null) { return false; }

            if (this.Name == pi.Name && this.Id == pi.Id)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Id.GetHashCode() ^ Priority.GetHashCode() ^ Threads.GetHashCode() ^ Modules.GetHashCode() ^ StartTime.GetHashCode();
        }
    }
}
