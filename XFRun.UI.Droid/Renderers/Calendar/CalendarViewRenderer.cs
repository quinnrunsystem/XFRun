﻿using System;
using System.ComponentModel;
using Android.Content;
using Android.Views;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using XFRun.UI.Forms.Renderers;
using XFRun.UI.Droid.Renderers.Calendar;
using Android.Widget;
using XFRun.UI.Droid.Renderers.Calendar.MonoDroid.TimesSquare;
using XFRun.UI.Android.Extensions;

[assembly: Xamarin.Forms.ExportRenderer(typeof(XFRun.UI.Forms.Renderers.CalendarView), typeof(CalendarViewRenderer))]

namespace XFRun.UI.Droid.Renderers.Calendar
{
    public class CalendarViewRenderer : ViewRenderer<XFRun.UI.Forms.Renderers.CalendarView, RelativeLayout>
    {
        /// <summary>
        ///     The tag
        /// </summary>
        private const string TAG = "XLabs.Forms.Controls.Calendar";

        /// <summary>
        ///     The _container view
        /// </summary>
        private View _containerView;

        /// <summary>
        ///     The _is element changing
        /// </summary>
        private bool _isElementChanging;

        /// <summary>
        ///     The _left arrow
        /// </summary>
        private XFRun.UI.Droid.Renderers.Calendar.MonoDroid.TimesSquare.CalendarArrowView _leftArrow;

        /// <summary>
        ///     The _picker
        /// </summary>
        private XFRun.UI.Droid.Renderers.Calendar.MonoDroid.TimesSquare.CalendarPickerView _picker;

        /// <summary>
        ///     The _right arrow
        /// </summary>
        private XFRun.UI.Droid.Renderers.Calendar.MonoDroid.TimesSquare.CalendarArrowView _rightArrow;

        /// <summary>
        ///     The _view
        /// </summary>
        private XFRun.UI.Forms.Renderers.CalendarView _view;

        public CalendarViewRenderer(Context context) : base(context)
        {
        }

        /// <summary>
        ///     Called when [element changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<XFRun.UI.Forms.Renderers.CalendarView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                _view = e.NewElement;
                var inflatorservice =
                    (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
                _containerView = inflatorservice.Inflate(Resource.Layout.calendar_picker, null);
                _picker = _containerView.FindViewById<MonoDroid.TimesSquare.CalendarPickerView>(Resource.Id.calendar_view);
                _picker.Init(Element.MinDate, Element.MaxDate, Element.HighlightedDaysOfWeek);
                _picker.OnDateSelected +=
                    (object sender, DateSelectedEventArgs evt) =>
                    {
                        ProtectFromEventCycle(() => { Element.NotifyDateSelected(evt.SelectedDate); });
                    };
                _picker.OnMonthChanged += (object sender, MonthChangedEventArgs mch) =>
                {
                    SetNavigationArrows();
                    ProtectFromEventCycle(() => { Element.NotifyDisplayedMonthChanged(mch.DisplayedMonth); });
                };
                SetDisplayedMonth(Element.DisplayedMonth);
                SetNavigationArrows();
                SetColors();
                SetFonts();
                SetNativeControl((RelativeLayout)_containerView);
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:ElementPropertyChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            ProtectFromEventCycle(() =>
            {
                if (e.PropertyName == XFRun.UI.Forms.Renderers.CalendarView.DisplayedMonthProperty.PropertyName)
                {
                    SetDisplayedMonth(Element.DisplayedMonth);
                }
            });
        }

        /// <summary>
        ///     Protects from event cycle.
        /// </summary>
        /// <param name="action">The action.</param>
        private void ProtectFromEventCycle(Action action)
        {
            if (_isElementChanging == false)
            {
                _isElementChanging = true;
                action.Invoke();
                _isElementChanging = false;
            }
        }

        /// <summary>
        ///     Sets the displayed month.
        /// </summary>
        /// <param name="newMonth">The new month.</param>
        /// <exception cref="System.Exception">Month must be between MinDate and MaxDate</exception>
        private void SetDisplayedMonth(DateTime newMonth)
        {
            if (newMonth >= XFRun.UI.Forms.Renderers.CalendarView.FirstDayOfMonth(Element.MinDate) &&
                newMonth <= XFRun.UI.Forms.Renderers.CalendarView.LastDayOfMonth(Element.MaxDate))
            {
                var index = (newMonth.Month - Element.MinDate.Month) + 12 * (newMonth.Year - Element.MinDate.Year);
                SelectMonth(index, false);
            }
            else
            {
                throw new Exception("Month must be between MinDate and MaxDate");
            }
        }

        /// <summary>
        ///     Sets the navigation arrows.
        /// </summary>
        private void SetNavigationArrows()
        {
            if (_leftArrow == null)
            {
                _leftArrow = _containerView.FindViewById<CalendarArrowView>(Resource.Id.left_arrow);
                _leftArrow.Click += (object sender, EventArgs e) => { SelectMonth(_picker.CurrentItem - 1, true); };
            }
            if (_rightArrow == null)
            {
                _rightArrow = _containerView.FindViewById<CalendarArrowView>(Resource.Id.right_arrow);
                _rightArrow.Direction = CalendarArrowView.ArrowDirection.RIGHT;
                _rightArrow.Click += (object sender, EventArgs e) => { SelectMonth(_picker.CurrentItem + 1, true); };
            }
            _leftArrow.SetBackgroundColor(Color.Transparent);
            _rightArrow.SetBackgroundColor(Color.Transparent);
            if (Element.ShowNavigationArrows)
            {
                _rightArrow.Visibility = _picker.CurrentItem + 1 != _picker.MonthCount ? ViewStates.Visible : ViewStates.Invisible;

                _leftArrow.Visibility = _picker.CurrentItem != 0 ? ViewStates.Visible : ViewStates.Invisible;
            }
            else
            {
                _leftArrow.Visibility = ViewStates.Gone;
                _rightArrow.Visibility = ViewStates.Gone;
            }
        }

        /// <summary>
        ///     Selects the month.
        /// </summary>
        /// <param name="monthIndex">Index of the month.</param>
        /// <param name="animated">if set to <c>true</c> [animated].</param>
        private void SelectMonth(int monthIndex, bool animated)
        {
            if (monthIndex >= 0 && monthIndex < _picker.MonthCount)
            {
                _picker.ScrollToSelectedMonth(monthIndex, animated);
            }
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
        ///     unmanaged resources.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            //Console.WriteLine("Disposing calendar renderer");
        }

        /// <summary>
        ///     Sets the fonts.
        /// </summary>
        private void SetFonts()
        {
            if (Element.DateLabelFont != Xamarin.Forms.Font.Default)
            {
                _picker.StyleDescriptor.DateLabelFont = Element.DateLabelFont.ToExtendedTypeface(Context);
            }
            if (Element.MonthTitleFont != Xamarin.Forms.Font.Default)
            {
                _picker.StyleDescriptor.MonthTitleFont = Element.MonthTitleFont.ToExtendedTypeface(Context);
            }
        }

        /// <summary>
        ///     Sets the colors.
        /// </summary>
        private void SetColors()
        {
            if (Element.BackgroundColor != Xamarin.Forms.Color.Default)
            {
                var andColor = Element.BackgroundColor.ToAndroid();
                _containerView.SetBackgroundColor(andColor);
                _picker.SetBackgroundColor(andColor);
                _picker.StyleDescriptor.BackgroundColor = andColor;
            }

            //Month title
            if (Element.ActualMonthTitleBackgroundColor != Xamarin.Forms.Color.Default)
                _picker.StyleDescriptor.TitleBackgroundColor = Element.ActualMonthTitleBackgroundColor.ToAndroid();
            if (Element.ActualMonthTitleForegroundColor != Xamarin.Forms.Color.Default)
                _picker.StyleDescriptor.TitleForegroundColor = Element.ActualMonthTitleForegroundColor.ToAndroid();

            //Navigation color arrows
            if (Element.ActualNavigationArrowsColor != Xamarin.Forms.Color.Default)
            {
                _leftArrow.Color = Element.ActualNavigationArrowsColor.ToAndroid();
                _rightArrow.Color = Element.ActualNavigationArrowsColor.ToAndroid();
            }
            else
            {
                _leftArrow.Color = _picker.StyleDescriptor.TitleForegroundColor;
                _rightArrow.Color = _picker.StyleDescriptor.TitleForegroundColor;
            }

            //Day of week label
            if (Element.ActualDayOfWeekLabelBackroundColor != Xamarin.Forms.Color.Default)
            {
                var andColor = Element.ActualDayOfWeekLabelBackroundColor.ToAndroid();
                _picker.StyleDescriptor.DayOfWeekLabelBackgroundColor = andColor;
            }
            if (Element.ActualDayOfWeekLabelForegroundColor != Xamarin.Forms.Color.Default)
            {
                var andColor = Element.ActualDayOfWeekLabelForegroundColor.ToAndroid();
                _picker.StyleDescriptor.DayOfWeekLabelForegroundColor = andColor;
            }

            _picker.StyleDescriptor.ShouldHighlightDaysOfWeekLabel = Element.ShouldHighlightDaysOfWeekLabels;

            //Default date color
            if (Element.ActualDateBackgroundColor != Xamarin.Forms.Color.Default)
            {
                var andColor = Element.ActualDateBackgroundColor.ToAndroid();
                _picker.StyleDescriptor.DateBackgroundColor = andColor;
            }
            if (Element.ActualDateForegroundColor != Xamarin.Forms.Color.Default)
            {
                var andColor = Element.ActualDateForegroundColor.ToAndroid();
                _picker.StyleDescriptor.DateForegroundColor = andColor;
            }

            //Inactive Default date color
            if (Element.ActualInactiveDateBackgroundColor != Xamarin.Forms.Color.Default)
            {
                var andColor = Element.ActualInactiveDateBackgroundColor.ToAndroid();
                _picker.StyleDescriptor.InactiveDateBackgroundColor = andColor;
            }
            if (Element.ActualInactiveDateForegroundColor != Xamarin.Forms.Color.Default)
            {
                var andColor = Element.ActualInactiveDateForegroundColor.ToAndroid();
                _picker.StyleDescriptor.InactiveDateForegroundColor = andColor;
            }

            //Today date color
            if (Element.ActualTodayDateBackgroundColor != Xamarin.Forms.Color.Default)
            {
                var andColor = Element.ActualTodayDateBackgroundColor.ToAndroid();
                _picker.StyleDescriptor.TodayBackgroundColor = andColor;
            }
            if (Element.ActualTodayDateForegroundColor != Xamarin.Forms.Color.Default)
            {
                var andColor = Element.ActualTodayDateForegroundColor.ToAndroid();
                _picker.StyleDescriptor.TodayForegroundColor = andColor;
            }

            //Highlighted date color
            if (Element.ActualHighlightedDateBackgroundColor != Xamarin.Forms.Color.Default)
            {
                var andColor = Element.ActualHighlightedDateBackgroundColor.ToAndroid();
                _picker.StyleDescriptor.HighlightedDateBackgroundColor = andColor;
            }
            if (Element.ActualHighlightedDateForegroundColor != Xamarin.Forms.Color.Default)
            {
                var andColor = Element.ActualHighlightedDateForegroundColor.ToAndroid();
                _picker.StyleDescriptor.HighlightedDateForegroundColor = andColor;
            }


            //Selected date
            if (Element.ActualSelectedDateBackgroundColor != Xamarin.Forms.Color.Default)
                _picker.StyleDescriptor.SelectedDateBackgroundColor = Element.ActualSelectedDateBackgroundColor.ToAndroid();
            if (Element.ActualSelectedDateForegroundColor != Xamarin.Forms.Color.Default)
                _picker.StyleDescriptor.SelectedDateForegroundColor = Element.ActualSelectedDateForegroundColor.ToAndroid();

            //Divider
            if (Element.DateSeparatorColor != Xamarin.Forms.Color.Default)
                _picker.StyleDescriptor.DateSeparatorColor = Element.DateSeparatorColor.ToAndroid();
        }
    }
}
