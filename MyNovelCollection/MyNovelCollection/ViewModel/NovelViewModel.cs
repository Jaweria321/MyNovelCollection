﻿using MyNovelCollection.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace MyNovelCollection.ViewModel
{
    class NovelViewModel : INotifyPropertyChanged
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
            if (NovelList == null)
            {
                NovelList = new List<NovelModel>();
                NovelModel Novel1 = new NovelModel("Pir-e-Kamil", "Pir-e-Kamil or Peer-e-Kamil is a novel written by Pakistani writer Umera Ahmad. It was first published in Urdu in 2004 and later in English in 2011. The book deals with the turning points in intervening lives of two people: a runaway girl named Imama Hashim; and a boy named Salar Sikander with an IQ of more than 150.", "Umera Ahmad", "");
                NovelList.Add(Novel1);
                // above 2 lines of code are equal to below one line
                NovelList.Add(new NovelModel("Mushaf", "A novel about a helpless orphan girl who discovers the real meaning of the holy Quran which helps her cope with the vagaries of her miserable life.", "Nemrah Ahmed", ""));
                NovelList.Add(new NovelModel("Ishq Ka Sheen", "Its a long story which goes from materialistic world love to true love with Almighty God. It took author more than 13 years to write and goes on. Six parts have been published so far and seventh is on the way.", "Aleem Ul Haq Haqqi", ""));
                NovelList.Add(new NovelModel("Mata-e-Jaan Hai Tu", "Mata-e-Jaan Hai Tu is a social romantic novel written by a female Pakistani author Farhat Ishtiaq. It is an Urdu language novel about the love story of a young couple.", "Farhat Ishtiaq", ""));
                NovelList.Add(new NovelModel("Shehr e Chara Gran", "Urdu novel", "Sadia Amal Kashif", ""));
                NovelList.Add(new NovelModel("Abdullah", "The main idea of the story is a journey of a man from Ishq-e-Majaazi to Ishq-e-Haqiqi. It is a novel that answers your questions about divinity.", "Hashim Nadeem", ""));
                
            }

            return true;
        }
        



        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop));}
        }
    }
}
