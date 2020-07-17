using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomApp2.Models
{
    public class Notes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string RGBColor { get; set; }
        public string RGBText { get; set; }
    }
}
