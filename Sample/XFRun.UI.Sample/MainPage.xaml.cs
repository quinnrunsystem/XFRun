using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFRun.UI.Forms.Renderers;
using XFRun.UI.Forms.Renderers.RadioButton;

namespace XFRun.UI.Sample
{
    public partial class MainPage : ContentPage
    {
     
        public MainPage()
        {
            InitializeComponent();
            calendar.MinDate = CalendarView.FirstDayOfMonth(DateTime.Now);
            calendar.MaxDate = CalendarView.LastDayOfMonth(DateTime.Now.AddMonths(3));
            calendar.HighlightedDateBackgroundColor = Color.FromRgb(227,227,227);
            calendar.ShouldHighlightDaysOfWeekLabels = false;
            calendar.SelectionBackgroundStyle = CalendarView.BackgroundStyle.CircleFill;
            calendar.TodayBackgroundStyle = CalendarView.BackgroundStyle.CircleOutline;
            calendar.HighlightedDaysOfWeek = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            calendar.ShowNavigationArrows = true;
            calendar.MonthTitleFont = Font.OfSize("Open 24 Display St", NamedSize.Medium);
            calendar.TextColor = Color.Blue;
            calendar.DateForegroundColor = Color.Cyan;
            calendar.DayOfWeekLabelForegroundColor = Color.Black;
            calendar.DateBackgroundColor = Color.Red;
            calendar.InactiveDateBackgroundColor = Color.DarkMagenta;
        }

    }
}
