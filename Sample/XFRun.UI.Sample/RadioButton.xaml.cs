using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XFRun.UI.Sample
{
    public partial class RadioButton : ContentPage
    {
        public RadioButton()
        {
            InitializeComponent();
            ansPicker.ItemsSource = new[]
           {
                "Red",
                "Blue",
                "Green",
                "Yellow",
                "Orange"
            };
            //ansPicker.CheckedChanged += ansPicker_CheckedChanged;
            ansPicker.SelectedIndex = 2;
        }
        private void ansPicker_CheckedChanged(object sender, int e)
        {
            var radio = sender as CustomRadioButton;

            if (radio == null || radio.Id == -1)
            {
                return;
            }

            DisplayAlert("Info", radio.Text, "OK");
        }

        void Handle_CheckedChanged(object sender, XFRun.UI.Forms.Helpers.EventArgs<bool> e)
        {
        }
    }
}
