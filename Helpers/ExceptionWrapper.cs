using System;
using System.Windows.Forms;

namespace FireWork.Helpers
{
    public static class ExceptionWrapper
    {
        public static void Wrap(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                   "Error Information",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
            }
        }
    }
}
