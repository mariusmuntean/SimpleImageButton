using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleImageButton.Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void NormalButton_OnClicked(object sender, EventArgs e)
        {
            Console.WriteLine((sender as Button).TextColor);
        }
    }
}