using System.Collections.Generic;
using System.Text;

namespace MyNovelCollection.Model
{
    public class NovelModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Thumb { get; set; }

        public string Location { get; set; }

        public NovelModel(string title, string description, string author, string thumb, string location)
        {
            Title = title;
            Description = description;
            Author = author;
            Thumb = thumb;
            Location = location;
        }

        public NovelModel()
        { }
    }

   
}


//string _Title;
//string _Description;
//string _Author;
//string _thumb;

//public string Title
//{
//    get
//    {
//        return _Title;
//    }
//    set
//    {
//        _Title = value;
//    }
//}