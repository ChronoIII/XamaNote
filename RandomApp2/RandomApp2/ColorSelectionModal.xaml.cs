using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RandomApp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorSelectionModal : ContentPage
    {
        public ColorSelectionModal()
        {
            InitializeComponent();
            AddBoxView();
        }

        private void AddBoxView()
        {
            flex_container.Children.Add(new BoxView()
            {
                BackgroundColor = Color.FromRgb(0,0,0),
                WidthRequest = 40,
                HeightRequest = 40,
                CornerRadius = 10
            });
        }
    }
}