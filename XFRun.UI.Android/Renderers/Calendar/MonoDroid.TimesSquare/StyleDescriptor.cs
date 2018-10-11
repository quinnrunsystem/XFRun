// ***********************************************************************
// Assembly         : XLabs.Forms.Droid
// Author           : XLabs Team
// Created          : 12-27-2015
// 
// Last Modified By : XLabs Team
// Last Modified On : 01-04-2016
// ***********************************************************************
// <copyright file="StyleDescriptor.cs" company="XLabs Team">
//     Copyright (c) XLabs Team. All rights reserved.
// </copyright>
// <summary>
//       This project is licensed under the Apache 2.0 license
//       https://github.com/XLabs/Xamarin-Forms-Labs/blob/master/LICENSE
//       
//       XLabs is a open source project that aims to provide a powerfull and cross 
//       platform set of controls tailored to work with Xamarin Forms.
// </summary>
// ***********************************************************************
// 

//using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
namespace XFRun.UI.Android.Renderers.Calendar.MonoDroid.TimesSquare
{
    /// <summary>
    /// Class StyleDescriptor.
    /// </summary>
    public class StyleDescriptor
	{
		/// <summary>
		/// The background color
		/// </summary>
        public Color BackgroundColor = Xamarin.Forms.Color.FromHex("#ffffffff").ToAndroid();
		/// <summary>
		/// The date foreground color
		/// </summary>
		public Color DateForegroundColor = Xamarin.Forms.Color.FromHex("#ff778088").ToAndroid();
		/// <summary>
		/// The date background color
		/// </summary>
		public Color DateBackgroundColor = Xamarin.Forms.Color.FromHex("#fff5f7f9").ToAndroid();
		/// <summary>
		/// The inactive date foreground color
		/// </summary>
		public Color InactiveDateForegroundColor = Xamarin.Forms.Color.FromHex("#40778088").ToAndroid();
		/// <summary>
		/// The inactive date background color
		/// </summary>
		public Color InactiveDateBackgroundColor = Xamarin.Forms.Color.FromHex("#fff5f7f9").ToAndroid();
		/// <summary>
		/// The selected date foreground color
		/// </summary>
		public Color SelectedDateForegroundColor = Xamarin.Forms.Color.FromHex("#ffffffff").ToAndroid();
		/// <summary>
		/// The selected date background color
		/// </summary>
		public Color SelectedDateBackgroundColor = Xamarin.Forms.Color.FromHex("#ff379bff").ToAndroid();
		/// <summary>
		/// The title foreground color
		/// </summary>
		public Color TitleForegroundColor = Xamarin.Forms.Color.FromHex("#ff778088").ToAndroid();
		/// <summary>
		/// The title background color
		/// </summary>
		public Color TitleBackgroundColor = Xamarin.Forms.Color.FromHex("#ffffffff").ToAndroid();
		/// <summary>
		/// The today foreground color
		/// </summary>
		public Color TodayForegroundColor = Xamarin.Forms.Color.FromHex("#ff778088").ToAndroid();
		/// <summary>
		/// The today background color
		/// </summary>
		public Color TodayBackgroundColor = Xamarin.Forms.Color.FromHex("#ccffcc").ToAndroid();
		/// <summary>
		/// The day of week label foreground color
		/// </summary>
		public Color DayOfWeekLabelForegroundColor = Xamarin.Forms.Color.FromHex("#ff778088").ToAndroid();
		/// <summary>
		/// The day of week label background color
		/// </summary>
		public Color DayOfWeekLabelBackgroundColor = Xamarin.Forms.Color.FromHex("#ffffffff").ToAndroid();
		/// <summary>
		/// The highlighted date foreground color
		/// </summary>
		public Color HighlightedDateForegroundColor = Xamarin.Forms.Color.FromHex("#ff778088").ToAndroid();
		/// <summary>
		/// The highlighted date background color
		/// </summary>
		public Color HighlightedDateBackgroundColor = Xamarin.Forms.Color.FromHex("#ccffcc").ToAndroid();
		/// <summary>
		/// The date separator color
		/// </summary>
		public Color DateSeparatorColor = Xamarin.Forms.Color.FromHex("#ffbababa").ToAndroid();
		/// <summary>
		/// The month title font
		/// </summary>
		public Typeface MonthTitleFont = null;
		/// <summary>
		/// The date label font
		/// </summary>
		public Typeface DateLabelFont = null;
		/// <summary>
		/// The should highlight days of week label
		/// </summary>
		public bool 	ShouldHighlightDaysOfWeekLabel = false;

	}



}

