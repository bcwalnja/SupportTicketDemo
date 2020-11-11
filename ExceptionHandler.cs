using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace SupportTicketDemo.Classes
{
    public static class ExceptionHandler
    {
        public static void Report(this Exception ex)
        {
            Print(ex);

            var message = GetShortErrorMessage(ex);
            XtraMessageBox.Show(message, "Address Book Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void Print(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            System.Diagnostics.Debug.WriteLine(ex.InnerException?.Message);
            System.Diagnostics.Debug.WriteLine(ex.InnerException?.StackTrace);
        }

        private static string GetShortErrorMessage(Exception ex)
        {
            if (ex.InnerException != null)
            {
                GetShortErrorMessage(ex.InnerException);
            }
            if (ex.Message == null)
            {
                return "An error has occurred.";
            }
            if (ex.Message?.Length > 400)
            {
                return $"An error has occurred:\n{ex.Message.Substring(0, 400)} ...";
            }
            else
            {
                return ex.Message;
            }
        }
    }
}
