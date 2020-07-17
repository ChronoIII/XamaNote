using RandomApp2.Helpers;
using RandomApp2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RandomApp2.ViewModels
{
    public class NoteListViewModel : INotifyPropertyChanged
    {
        private List<Notes> noteList;
        private bool showModal = false;
        public List<Notes> NoteList
        {
            get
            {
                return noteList;
            }
            set
            {
                noteList = value;
                OnPropertyChanged();
            }
        }
        public bool ShowModal
        {
            get
            {
                return showModal;
            }
            set
            {
                showModal = value;
                OnPropertyChanged();
            }
        }

        public NoteListViewModel()
        {
            NoteList = new List<Notes>();
            RefreshList();
        }

        public void RefreshList()
        {
            NoteList = DatabaseHelper.Read();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
