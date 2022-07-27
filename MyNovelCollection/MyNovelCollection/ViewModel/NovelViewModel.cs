using MyNovelCollection.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace MyNovelCollection.ViewModel
{
    public class NovelViewModel : INotifyPropertyChanged
    {
        private string _CollectionName;

        public string CollectionName
        {
            get 
            { 
                return _CollectionName;
            }
            set 
            { 
                _CollectionName = value;
                // it's going to notify the user interface that
                // there has been a change to the data and specifically a change to CollectionName
                RaisePropertyChanged("CollectionName");
            }
        }

        public List<NovelModel> NovelList;
        public NovelModel SelectedNovel;

        public async Task<bool> GetNovels()
        {
            NovelList = new List<NovelModel>();
            // Total number of entries available in table name NovelModel
            int rows = (int)await App.Database.Count();


            // here it is not storing this data to database it is only displaying it to list view
            // if (NovelList == null || NovelList.Count == 0)
            //{

            //NovelList.Add(new NovelModel("Pir-e-Kamil", "Pir-e-Kamil or Peer-e-Kamil is a novel written by Pakistani writer Umera Ahmad. It was first published in Urdu in 2004 and later in English in 2011. The book deals with the turning points in intervening lives of two people: a runaway girl named Imama Hashim; and a boy named Salar Sikander with an IQ of more than 150.", "Umera Ahmad", "Pir_e_Kamil.jpg", "Box1"));
            //NovelList.Add(new NovelModel("Mushaf", "A novel about a helpless orphan girl who discovers the real meaning of the holy Quran which helps her cope with the vagaries of her miserable life.", "Nemrah Ahmed", "Mushaf.jpg","Box 3"));
            //NovelList.Add(new NovelModel("Ishq Ka Sheen", "Its a long story which goes from materialistic world love to true love with Almighty God. It took author more than 13 years to write and goes on. Six parts have been published so far and seventh is on the way.", "Aleem Ul Haq Haqqi", "Ishq_Ka_Sheen.jpg", "Box 3"));
            //NovelList.Add(new NovelModel("Mata-e-Jaan Hai Tu", "Mata-e-Jaan Hai Tu is a social romantic novel written by a female Pakistani author Farhat Ishtiaq. It is an Urdu language novel about the love story of a young couple.", "Farhat Ishtiaq", "Mata_e_Jaan_Hai_Tu.jpg","Box2"));
            //NovelList.Add(new NovelModel("Shehr e Chara Gran", "Urdu novel", "Sadia Amal Kashif", "Shehr_e_Chara_Gran.jpg", "Box 1"));
            //NovelList.Add(new NovelModel("Abdullah", "The main idea of the story is a journey of a man from Ishq-e-Majaazi to Ishq-e-Haqiqi. It is a novel that answers your questions about divinity.", "Hashim Nadeem", "Abdullah.jpg","Box 2"));
             // }


             // When there is no data in the app following data will be populated whenever all data is removed it will be repopulated with this data
             // ----------- Need to solve this Problem-------

            // ---------- Try to put it in the constructor ------------
            if (rows == 0)
             {
                await InsertNovel(new NovelModel("Pir-e-Kamil", "Pir-e-Kamil or Peer-e-Kamil is a novel written by Pakistani writer Umera Ahmad. It was first published in Urdu in 2004 and later in English in 2011. The book deals with the turning points in intervening lives of two people: a runaway girl named Imama Hashim; and a boy named Salar Sikander with an IQ of more than 150.", "Umera Ahmad", "Pir_e_Kamil.jpg", "Box1"));
                await InsertNovel(new NovelModel("Mushaf", "A novel about a helpless orphan girl who discovers the real meaning of the holy Quran which helps her cope with the vagaries of her miserable life.", "Nemrah Ahmed", "Mushaf.jpg","Box 3"));
                await InsertNovel(new NovelModel("Ishq Ka Sheen", "Its a long story which goes from materialistic world love to true love with Almighty God. It took author more than 13 years to write and goes on. Six parts have been published so far and seventh is on the way.", "Aleem Ul Haq Haqqi", "Ishq_Ka_Sheen.jpg", "Box 3"));
                await InsertNovel(new NovelModel("Mata-e-Jaan Hai Tu", "Mata-e-Jaan Hai Tu is a social romantic novel written by a female Pakistani author Farhat Ishtiaq. It is an Urdu language novel about the love story of a young couple.", "Farhat Ishtiaq", "Mata_e_Jaan_Hai_Tu.jpg","Box2"));
                await InsertNovel(new NovelModel("Shehr e Chara Gran", "Urdu novel", "Sadia Amal Kashif", "Shehr_e_Chara_Gran.jpg", "Box 1"));
                await InsertNovel(new NovelModel("Abdullah", "The main idea of the story is a journey of a man from Ishq-e-Majaazi to Ishq-e-Haqiqi. It is a novel that answers your questions about divinity.", "Hashim Nadeem", "Abdullah.jpg", "Box 2"));
            }


            NovelList = await App.Database.GetNovelsAsync();

            return true;
        }
        

        public async Task<bool> UpdateNovel(NovelModel nvl)
        {

            // SelectedNovel.Title = nvl.Title;
            //SelectedNovel.Author = nvl.Author;
            //SelectedNovel.Thumb = nvl.Thumb;
            //SelectedNovel.Location = nvl.Location;
            //SelectedNovel.Description = nvl.Description;

            await App.Database.UpdateNovel(nvl);
            return true;
        }

        public async Task<bool> InsertNovel(NovelModel nvl)
        {
           // NovelList.Add(nvl);
            await App.Database.InsertNovel(nvl);
            return true;
        }

        public async Task<bool> DeleteNovel(NovelModel nvl)
        {
           // NovelList.Remove(nvl);
            await App.Database.DeleteNovel(nvl);
            return true;
        }

        public async Task<bool> clearNovel()
        {
            // NovelList.Clear();
            await App.Database.ClearNovels();
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop));}
        }
    }
}
