using System;

namespace SupportTicketDemo.BLL.Events
{
    public class ImportEventArgs : EventArgs
    {
        public int Current { get; }
        public int Total { get; }

        public ImportEventArgs(int current, int total)
        {
            this.Current = current;
            this.Total = total;
        }
    }
}
