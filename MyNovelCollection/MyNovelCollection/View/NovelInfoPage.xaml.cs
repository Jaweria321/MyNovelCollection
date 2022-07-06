using MyNovelCollection.Model;
using MyNovelCollection.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyNovelCollection.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovelInfoPage : ContentPage
    {
        NovelViewModel nvm;
        NovelModel nvl;
        

        public NovelInfoPage(NovelViewModel _nvm)
        {
            InitializeComponent();

           nvm = _nvm;
           nvl = nvm.SelectedNovel;

           BindingContext = nvl;

        }
    }
}