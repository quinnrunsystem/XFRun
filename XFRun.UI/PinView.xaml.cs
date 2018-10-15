using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XFRun.UI.Forms.Renderers;

namespace XFRun.UI.Forms
{
    public partial class PinView : RoundedCornerView
    {
        private List<Label> _labels;
        public string PinCode = String.Empty;
        public static BindableProperty CountProperty = BindableProperty.Create(nameof(CountProperty), typeof(int), typeof(PinView), 4, propertyChanged: (bindable, oldValue, newValue) =>
        {
            PinView pinView = (PinView)bindable;
            pinView.CreateListTextbox((int)newValue);
        });

        public int Count
        {
            get
            {
                return (int)GetValue(CountProperty);
            }
            set
            {
                SetValue(CountProperty, value);
            }
        }

        private void CreateListTextbox(int count)
        {
            _labels = new List<Label>();
            for (int i = 0; i < count; i++)
            {
                ExtendedFrame frame = new ExtendedFrame()
                {
                    BorderThickness = 1,
                    CornerRadius = 15,
                    BorderColor = Color.Gray,
                    HeightRequest = 50,
                    WidthRequest = 50
                };

                Label label = new Label()
                {
                    TextColor = Color.Accent,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                };
                frame.Content = label;
                _labels.Add(label);
                flexLayout.Children.Add(frame);
            }
        }

        public PinView()
        {
            InitializeComponent();
            fakeEntry.TextChanged += FakeEntry_TextChanged;
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            fakeEntry.Focus();
        }

        void FakeEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (var item in _labels)
            {
                item.Text = e.NewTextValue;
            }
        }

    }
}
