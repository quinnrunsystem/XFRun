using System;
using Xamarin.Forms;

namespace XFRun.UI.Forms.Renderers
{
    /// <summary>
    /// Class ExtendedLabel.
    /// </summary>
    public class ExtendedLabel : Label
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedLabel"/> class.
        /// </summary>
        public ExtendedLabel()
        {
        }

        /// <summary>
        /// The is underlined property.
        /// </summary>
        public static readonly BindableProperty IsUnderlineProperty =
            BindableProperty.Create<ExtendedLabel, bool>(p => p.IsUnderline, false);

        /// <summary>
        /// Gets or sets a value indicating whether the text in the label is underlined.
        /// </summary>
        /// <value>A <see cref="bool"/> indicating if the text in the label should be underlined.</value>
        [Obsolete("Already officially support in XF 3.3")]
        public bool IsUnderline
        {
            get
            {
                return (bool)GetValue(IsUnderlineProperty);
            }
            set
            {
                SetValue(IsUnderlineProperty, value);
            }
        }

        /// <summary>
        /// The is underlined property.
        /// </summary>
        public static readonly BindableProperty IsStrikeThroughProperty =
            BindableProperty.Create<ExtendedLabel, bool>(p => p.IsStrikeThrough, false);

        /// <summary>
        /// Gets or sets a value indicating whether the text in the label is underlined.
        /// </summary>
        /// <value>A <see cref="bool"/> indicating if the text in the label should be underlined.</value>
        [Obsolete("Already officially support in XF 3.3")]
        public bool IsStrikeThrough
        {
            get
            {
                return (bool)GetValue(IsStrikeThroughProperty);
            }
            set
            {
                SetValue(IsStrikeThroughProperty, value);
            }
        }

        /// <summary>
        /// This is the drop shadow property
        /// </summary>
        public static readonly BindableProperty IsDropShadowProperty =
            BindableProperty.Create<ExtendedLabel, bool>(p => p.IsDropShadow, false);

        /// <summary>
        /// Gets or sets a value indicating whether this instance is drop shadow.
        /// </summary>
        /// <value><c>true</c> if this instance is drop shadow; otherwise, <c>false</c>.</value>
        public bool IsDropShadow
        {
            get
            {
                return (bool)GetValue(IsDropShadowProperty);
            }
            set
            {
                SetValue(IsDropShadowProperty, value);
            }
        }

        /// <summary>
        /// This is the drop shadow color property
        /// </summary>
        public static readonly BindableProperty DropShadowColorProperty =
            BindableProperty.Create<ExtendedLabel, Color>(p => p.DropShadowColor, default(Color));

        /// <summary>
        /// Gets or sets the color of the drop shadow.
        /// </summary>
        /// <value>The color of the drop shadow.</value>
        public Color DropShadowColor
        {
            get
            {
                return (Color)GetValue(DropShadowColorProperty);
            }
            set
            {
                SetValue(DropShadowColorProperty, value);
            }
        }

    }
}
