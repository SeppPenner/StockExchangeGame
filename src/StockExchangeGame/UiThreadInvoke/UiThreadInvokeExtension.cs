namespace StockExchangeGame.UiThreadInvoke
{
    using System;
    using System.Windows.Forms;

    public static class UiThreadInvokeExtension
    {
        public static void UiThread(this Control control, Action code)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(code);
                return;
            }

            code.Invoke();
        }

        public static void UiThreadInvoke(this Control control, Action code)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(code);
                return;
            }

            code.Invoke();
        }
    }
}