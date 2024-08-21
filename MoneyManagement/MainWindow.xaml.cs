using Syncfusion.Windows.Shared;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;

namespace MoneyManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handling event
        /// </summary>
        #region event handler


        //Window loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblMsgSum.Text = "Tổng thu chi trong Tháng " + DateTime.Now.Month + " : ";
            lblSum.Text = "1.000.000 VND";
            lblSum.Foreground = Brushes.Green;

            lbDate.Text = DateTime.Now.Day.ToString("D2");
            var DoW = DateTime.Now.DayOfWeek;
            lbMonth.Text = "Tháng " + DateTime.Now.Month.ToString();

            string[] daysOfWeek = { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };

            lbDay.Text = daysOfWeek[(int)DoW];

            List<DateTime> specificDates = new List<DateTime>
            {
                new DateTime(2024, 8, 1),
                new DateTime(2024, 8, 15),
                new DateTime(2024, 8, 10),
                new DateTime(2024, 8, 5)
            };

            ApplyCustomStyle(calendar, specificDates);
        }

        //Border move drag
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        //private void lblNote_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    txtNote.Focus();
        //}

        //private void txtNote_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtNote.Text) && txtNote.Text.Length > 0)
        //    {
        //        lblNote.Visibility = Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        lblNote.Visibility = Visibility.Visible;
        //    }
        //}

        //private void txtTime_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    txtTime.Focus();
        //}

        //private void lblTime_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtTime.Text) && txtTime.Text.Length > 0)
        //    {
        //        lblTime.Visibility = Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        lblTime.Visibility = Visibility.Visible;
        //    }
        //}

        //Close button
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Minimize Button
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //Selected Date Changed
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (calendar.SelectedDate != null)
            {
                lbDate.Text = calendar.SelectedDate?.Day.ToString("D2");
                var DoW = calendar.SelectedDate?.DayOfWeek;
                lbMonth.Text = "Tháng " + calendar.SelectedDate?.Month.ToString();

                string[] daysOfWeek = { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };

                lbDay.Text = daysOfWeek[(int)DoW];
            }

        }

        //Previous Button
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (calendar.SelectedDate == null)
            {
                calendar.SelectedDate = DateTime.Now;
            }
            calendar.SelectedDate = calendar.SelectedDate?.AddDays(-1);

            calendar.DisplayDate = calendar.SelectedDate.Value;

            if (calendar.DisplayMode != CalendarMode.Month)
            {
                calendar.DisplayMode = CalendarMode.Month;
            }
        }

        //Next Button
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (calendar.SelectedDate == null)
            {
                calendar.SelectedDate = DateTime.Now;
            }
            calendar.SelectedDate = calendar.SelectedDate?.AddDays(1);

            calendar.DisplayDate = calendar.SelectedDate!.Value;

            if (calendar.DisplayMode != CalendarMode.Month)
            {
                calendar.DisplayMode = CalendarMode.Month;
            }
        }

        //Display Date Changed
        private void calendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            List<DateTime> specificDates = new List<DateTime>
            {
                new DateTime(2024, 8, 8),
                new DateTime(2024, 8, 15),
                new DateTime(2024, 8, 10),
                new DateTime(2024, 8, 5)
            };

            ApplyCustomStyle(calendar, specificDates);

            lblMsgSum.Text = "Tổng thu chi trong Tháng " + calendar.DisplayDate.Month + " : ";
            lblSum.Text = "-1.000.000 VND";
            lblSum.Foreground = Brushes.Red;
        }
        #endregion

        private void ApplyCustomStyle(Calendar calendar, List<DateTime> datesToHighlight, bool isAdd = false)
        {
            var buttons = FindVisualChildren<CalendarDayButton>(calendar);
            DateTime currentMonth = calendar.DisplayDate;

            foreach (var button in buttons)
            {
                if (button.DataContext is DateTime date)
                {
                    bool isHighlighted = datesToHighlight.Contains(date);

                    // Set the background only if the date is highlighted
                    button.Background = isHighlighted ? (isAdd ? Brushes.LightGreen : Brushes.Red) : null;
                }
            }
        }


        // Helper method to find all CalendarDayButton controls
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private static T FindVisualChild<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T tChild)
                    {
                        return tChild;
                    }

                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }

    }
}