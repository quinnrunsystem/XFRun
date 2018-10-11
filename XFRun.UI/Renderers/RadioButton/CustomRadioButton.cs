using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XFRun.UI.Forms.Helpers;

namespace XFRun.UI.Forms.Renderers.RadioButton
{
    /// <summary>
    /// Class CustomRadioButton.
    /// </summary>
    public class CustomRadioButton : View
    {
        /// <summary>
        /// The checked property
        /// </summary>
        //public static readonly BindableProperty CheckedProperty =
        //BindableProperty.Create<CustomRadioButton, bool>(
        //p => p.Checked, false);
        public static readonly BindableProperty CheckedProperty = 
            BindableProperty.Create("Checked", typeof(bool), typeof(CustomRadioButton), false);

        /// <summary>
        ///     The default text property.
        /// </summary>
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create<CustomRadioButton, string>(
                p => p.Text, string.Empty);

        /// <summary>
        ///     The default text property.
        /// </summary>
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create<CustomRadioButton, Color>(
                p => p.TextColor, Color.Default);

        /// <summary>
        /// The font size property
        /// </summary>
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create<CheckBox, double>(
                p => p.FontSize, -1);

        /// <summary>
        /// The font name property.
        /// </summary>
        public static readonly BindableProperty FontNameProperty =
            BindableProperty.Create<CheckBox, string>(
                p => p.FontName, string.Empty);

        /// <summary>
        ///     The checked changed event.
        /// </summary>
        public event EventHandler<EventArgs<bool>> CheckedChanged;

        /// <summary>
        ///     Gets or sets a value indicating whether the control is checked.
        /// </summary>
        /// <value>The checked state.</value>
        public bool Checked
        {
            get { return (bool)this.GetValue(CheckedProperty); }

            set
            {
                var eventHandler = CheckedChanged;

                if (eventHandler != null && (bool)this.GetValue(CheckedProperty) != value)
                {
                    eventHandler.Invoke(this, new EventArgs<bool>(value));
                }
                SetValue(CheckedProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }

            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        public Color TextColor
        {
            get { return (Color)this.GetValue(TextColorProperty); }

            set { SetValue(TextColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the size of the font.
        /// </summary>
        /// <value>The size of the font.</value>
        public double FontSize
        {
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the name of the font.
        /// </summary>
        /// <value>The name of the font.</value>
        public string FontName
        {
            get
            {
                return (string)GetValue(FontNameProperty);
            }
            set
            {
                SetValue(FontNameProperty, value);
            }
        }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    }
}
