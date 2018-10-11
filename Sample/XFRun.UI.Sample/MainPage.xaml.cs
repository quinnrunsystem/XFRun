using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFRun.UI.Forms.Renderers.RadioButton;

namespace XFRun.UI.Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
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
            ansPicker.CheckedChanged += ansPicker_CheckedChanged;
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
    }
}
