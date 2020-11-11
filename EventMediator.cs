using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportTicketDemo.BLL.Events
{
    public class EventMediator
    {
        private static readonly EventMediator _Instance = new EventMediator();

        private EventMediator() { }

        public static EventMediator GetInstance()
        {
            return _Instance;
        }


        public event EventHandler<ImportEventArgs> ImportProgressUpdated;

        public void OnImportProgressUpdated(int current, int total)
        {
            ImportProgressUpdated?.Invoke(this, new ImportEventArgs(current, total));
        }

        public event EventHandler<EventArgs> ImportStarted;

        public void OnImportStarted()
        {
            ImportStarted?.Invoke(this, new EventArgs());
        }

        public event EventHandler<EventArgs> ImportComplete;

        public void OnImportComplete()
        {
            ImportComplete?.Invoke(this, new EventArgs());
        }
    }
}
