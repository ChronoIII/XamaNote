using RandomApp2.Helpers;
using RandomApp2.Models;
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
    public partial class NoteEditorPage : ContentPage
    {
        private Notes Note;
        public NoteEditorPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            button_submit.Text = "Add note";
            button_submit.ClassId = "add";
        }

        public NoteEditorPage(Notes _note)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            Note = _note;
            button_submit.Text = "Submit changes";
            button_submit.ClassId = "edit";

            entry_title.Text = Note.Title;
            editor_content.Text = Note.Content;
        }

        private void GoBackToMain(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void SubmitNote(object sender, EventArgs e)
        {
            string ButtonMode = ((Button)sender).ClassId;
            Notes note = new Notes()
            {
                Id = Note != null ? Note.Id : 0,
                Title = entry_title.Text,
                Content = editor_content.Text,
                RGBColor = "#ffffff",
                RGBText = "#333333"
            };

            switch (ButtonMode)
            {
                case "add":
                    DatabaseHelper.Insert(ref note);
                    await DisplayAlert("Note Added", "Note was successfully added to list.", "Ok");
                    break;
                case "edit":
                    DatabaseHelper.Update(note);
                    await DisplayAlert("Note Modified", "Note was successfully modified", "Ok");
                    break;
            }
            await Navigation.PopAsync();
        }
    }
}