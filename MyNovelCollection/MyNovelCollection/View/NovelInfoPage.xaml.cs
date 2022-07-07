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
        bool isNew;

        public NovelInfoPage(NovelViewModel _nvm, bool _isNew)
        {
            InitializeComponent();

            nvm = _nvm;
            isNew = _isNew;
            nvl = new NovelModel("", "", "", "", "");
            if(isNew)
            {

            }
            else
            {
                nvl.Title = nvm.SelectedNovel.Title;
                nvl.Author = nvm.SelectedNovel.Author;
                nvl.Thumb = nvm.SelectedNovel.Thumb;
                nvl.Location = nvm.SelectedNovel.Location;
                nvl.Description = nvm.SelectedNovel.Description;

            }

            BindingContext = nvl;
            
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            //Asynchronously dismisses the most recent modally presented Page.
            await Navigation.PopModalAsync();
        }

        private async void btnOk_Clicked(object sender, EventArgs e)
        {

            if (isNew)
            {
                nvm.InsertNovel(nvl);
            }
            else
            {
                nvm.UpdateNovel(nvl);
            }
            
            //Asynchronously dismisses the most recent modally presented Page.
            await Navigation.PopModalAsync();

        }
    }
}