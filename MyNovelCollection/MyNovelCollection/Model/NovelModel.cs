using System.Collections.Generic;
using System.Text;

namespace MyNovelCollection.Model
{
    class NovelModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Thumb { get; set; }

        public NovelModel(string title, string description, string author, string thumb)
        {
            Title = title;
            Description = description;
            Author = author;
            Thumb = thumb;
        }
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