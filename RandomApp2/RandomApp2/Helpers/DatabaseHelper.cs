using RandomApp2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomApp2.Helpers
{
    public class DatabaseHelper
    {
        public static bool Insert<T>(ref T data)
        {
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<T>();
                if (conn.Insert(data) != 0) return true;
            }
            return false;
        }

        public static List<Notes> Read()
        {
            List<Notes> list = new List<Notes>();
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Notes>();
                list = conn.Table<Notes>().ToList();
            }
            return list;
        }

        public static Notes Get(int Id)
        {
            Notes selectedNote = new Notes();
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                selectedNote = conn.Table<Notes>().Where(x => x.Id == Id).First();
            }
            return selectedNote;
        }

        public static bool Update(Notes note)
        {
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.Update(note);
            }
            return false;
        }

        public static bool Delete(int Id)
        {
            return true;
        }

        public static void DeleteAll()
        {
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.DeleteAll<Notes>();
            }
        }
    }
}
