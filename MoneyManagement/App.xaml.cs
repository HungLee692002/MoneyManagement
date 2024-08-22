using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace MoneyManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Handle exceptions in the UI thread
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

            // Handle exceptions in non-UI threads
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Log the exception to a text file
            LogException(e.Exception);

            // Optionally, prevent the application from crashing
            e.Handled = true;

            // Show a message box (optional)
            MessageBox.Show("An unexpected error occurred. The application will continue to run.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Log the exception to a text file
            LogException(e.ExceptionObject as Exception);

            // Optionally, shut down the application
            MessageBox.Show("A critical error occurred. The application will shut down.", "Critical Error", MessageBoxButton.OK, MessageBoxImage.Error);
            Environment.Exit(1);
        }

        private void LogException(Exception ex)
        {
            try
            {
                // Define the path to the log file
                string logFilePath = Path.Combine(Environment.CurrentDirectory, "error_log.txt");

                // Log the exception details
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine("Message : " + ex.Message);
                    writer.WriteLine("InnerException : " + ex.InnerException?.Message);
                    writer.WriteLine(new string('-', 80));
                }
            }
            catch { }
        }
    }

}
