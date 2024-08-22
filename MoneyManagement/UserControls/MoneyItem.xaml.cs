using FontAwesome.WPF;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MoneyManagement.UserControls
{
    /// <summary>
    /// Interaction logic for MoneyItem.xaml
    /// </summary>
    public partial class MoneyItem : UserControl
    {
        public MoneyItem()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(MoneyItem));

        public string Time
        {
            get { return (string)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register("Time", typeof(string), typeof(MoneyItem));

        public SolidColorBrush Color
        {
            get { return (SolidColorBrush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(SolidColorBrush), typeof(MoneyItem));

        public SolidColorBrush MoneyColor
        {
            get { return (SolidColorBrush)GetValue(MoneyColorProperty); }
            set { SetValue(MoneyColorProperty, value); }
        }

        public static readonly DependencyProperty MoneyColorProperty = DependencyProperty.Register("MoneyColor", typeof(SolidColorBrush), typeof(MoneyItem));

        public decimal Money
        {
            get { return (decimal)GetValue(MoneyProperty); }
            set { SetValue(MoneyProperty, value); }
        }

        public static readonly DependencyProperty MoneyProperty = DependencyProperty.Register("Money", typeof(decimal), typeof(MoneyItem));

        public bool IsAdd
        {
            get { return (bool)GetValue(IsAddProperty); }
            set { SetValue(IsAddProperty, value); }
        }

        public static readonly DependencyProperty IsAddProperty = DependencyProperty.Register("IsAdd", typeof(bool), typeof(MoneyItem));

        public FontAwesomeIcon Icon
        {
            get { return (FontAwesomeIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(FontAwesomeIcon), typeof(MoneyItem));
    }
}
