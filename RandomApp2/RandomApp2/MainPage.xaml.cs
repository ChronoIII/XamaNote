using RandomApp2.Helpers;
using RandomApp2.Models;
using RandomApp2.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RandomApp2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private String ColorID;
        private String ColorHex;
        public MainPage()
        {
            InitializeComponent();
            AddBoxView();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void OpenNote(object sender, EventArgs e)
        {
            var selectedNote = (Notes)((ViewCell)sender).BindingContext;
            Navigation.PushAsync(new NoteEditorPage(selectedNote));
        }

        private void AddNote(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NoteEditorPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((NoteListViewModel)BindingContext).RefreshList();
        }

        private void DeleteAll(object sender, EventArgs e)
        {
            DatabaseHelper.DeleteAll();
        }

        private void EditColor(object sender, EventArgs e)
        {
            ((NoteListViewModel)BindingContext).ShowModal = true;
            ColorID = ((Image)sender).ClassId;
        }

        private void AddBoxView()
        {
            // Black
            var newBoxBlack = new BoxView()
            {
                BackgroundColor = Color.FromRgb(0, 0, 0),
                WidthRequest = 40,
                HeightRequest = 40,
                CornerRadius = 10,
                ClassId = "#000000/#dddddd"
            };

            var tapBlack = new TapGestureRecognizer();
            tapBlack.Tapped += ChangeColor;
            newBoxBlack.GestureRecognizers.Add(tapBlack);

            flex_container.Children.Add(newBoxBlack);

            // White
            var newBoxWhite = new BoxView()
            {
                BackgroundColor = Color.FromRgb(255, 255, 255),
                WidthRequest = 40,
                HeightRequest = 40,
                CornerRadius = 10,
                ClassId = "#ffffff/#333333"
            };

            var tapWhite = new TapGestureRecognizer();
            tapWhite.Tapped += ChangeColor;
            newBoxWhite.GestureRecognizers.Add(tapWhite);

            flex_container.Children.Add(newBoxWhite);
        }

        private void ChangeColor(object sender, EventArgs e)
        {
            ColorHex = ((BoxView)sender).ClassId;
            String[] ColorValues = ColorHex.Split('/');

            Notes editNote = DatabaseHelper.Get(Int32.Parse(ColorID));
            editNote.RGBColor = ColorValues[0];
            editNote.RGBText = ColorValues[1];

            DatabaseHelper.Update(editNote);
            ((NoteListViewModel)BindingContext).ShowModal = false;
            ((NoteListViewModel)BindingContext).RefreshList();
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();

            if (((NoteListViewModel)BindingContext).ShowModal)
            {
                ((NoteListViewModel)BindingContext).ShowModal = false;
                return true;
            }
            return false;
        }

        private void CloseModal(object sender, EventArgs e)
        {
            ((NoteListViewModel)BindingContext).ShowModal = false;
        }
    }
}
