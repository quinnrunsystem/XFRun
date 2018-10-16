using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XFRun.UI.Forms.Renderers;

namespace XFRun.UI.Forms
{
    public partial class PinView : RoundedCornerView
    {
        private List<Label> _labels;
        private List<ExtendedFrame> _frames;
        public string PinCode = String.Empty;

        public Color FocusColor { get; set; } = Color.Green;
        public Color BorderItemColor { get; set; } = Color.Gray;

        public static BindableProperty CountProperty = BindableProperty.Create(nameof(CountProperty), typeof(int), typeof(PinView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            PinView pinView = (PinView)bindable;
            if (newValue != null)
            {
                pinView?.CreateListTextbox((int)newValue);
            }
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
            _frames = new List<ExtendedFrame>();

            for (int i = 0; i < count; i++)
            {
                ExtendedFrame frame = new ExtendedFrame()
                {
                    BorderThickness = 1,
                    CornerRadius = 15,
                    BorderColor = BorderItemColor,
                    HeightRequest = 50,
                    WidthRequest = 50,
                    HasShadow = false
                };

                Label label = new Label()
                {
                    TextColor = Color.Accent,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                };
                label.GestureRecognizers.Add(new TapGestureRecognizer()
                {
                    Command = new Command(HandleAction),
                    CommandParameter = label
                });
                frame.Content = label;

                _labels.Add(label);
                _frames.Add(frame);

                flexLayout.Children.Add(frame);
            }
        }

        void HandleAction(object obj)
        {
            FocusEntry(_labels.IndexOf((Label)obj));
        }

        public PinView()
        {
            InitializeComponent();
            fakeEntry.TextChanged += FakeEntry_TextChanged;
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            FocusEntry(0);
        }

        private int _focusPosition = 0;
        private void FocusEntry(int position)
        {
            // Reset Color
            for (int i = 0; i < _frames.Count; i++)
            {
                _frames[i].BorderColor = BorderItemColor;
            }

            if (position < _labels.Count)
            {
                _focusPosition = position;
                _frames[position].BorderColor = FocusColor;
                fakeEntry.Text =  _labels[position].Text;
                fakeEntry.Focus();
            }
            else
            {
                fakeEntry.Unfocus();
            }
        }

        void FakeEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue)
                && int.TryParse(e.NewTextValue, out int newValue))
            {
                _labels[_focusPosition].Text = e.NewTextValue;

                //Reset content
                //fakeEntry.Text = string.Empty;

                //Focus next item 
                FocusEntry(_focusPosition + 1);
            }
            else
            {
                _labels[_focusPosition].Text = string.Empty;
            }
        }

    }
}
