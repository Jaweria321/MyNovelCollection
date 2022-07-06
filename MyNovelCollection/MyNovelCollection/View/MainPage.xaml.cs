using Acr.UserDialogs;
using MyNovelCollection.Model;
using MyNovelCollection.View;
using MyNovelCollection.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyNovelCollection
{
    public partial class MainPage : ContentPage
    {
        NovelViewModel nvm;

        public MainPage()
        {
            InitializeComponent();
            nvm = new NovelViewModel();
            nvm.CollectionName = "Jaweria's Collection";
            BindingContext = nvm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await nvm.GetNovels();
            Novellistview.ItemsSource = nvm.NovelList;
        }

        private async void Novellistview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Console.WriteLine(e.SelectedItem);
            if (e.SelectedItem != null)
            {
                nvm.SelectedNovel = (NovelModel)e.SelectedItem;
                // DisplayAlert(nvm.SelectedNovel.Title, nvm.SelectedNovel.Description,  "ok");
                await Navigation.PushModalAsync(new NovelInfoPage(nvm));


                // Issue: Same listview item not getting selected after pressing back
                //Solution: https://social.msdn.microsoft.com/Forums/en-US/cb47f2a9-0065-47b5-b0da-691ea0917c89/same-listview-item-not-getting-selected-after-pressing-back?forum=xamarinforms
                ((ListView)sender).SelectedItem = null;
            }

        }

        private async void btnName_Clicked(object sender, EventArgs e)
        {
            

            // Display a prompt https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/pop-ups

            string result = await DisplayPromptAsync("Collection Name", "Choose a Collection Name:");

            if (result != null)
            {
                nvm.CollectionName = result;
            }

        }
    }
}
