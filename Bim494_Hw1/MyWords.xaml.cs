using Bim494_Hw1.Model;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bim494_Hw1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyWords : ContentPage
	{
        public static ListView eng;
       // public static ListView tr;

        public MyWords ()
		{
			InitializeComponent ();
            eng = englishword;
            //tr = turkishword;
            GetWord();
		}

        public static void GetWord()
        {
            List<Words> words = UserRepository.GetAllWord();
            
            eng.ItemsSource = words;
           // tr.ItemsSource = words;
        }       


        private async void Englishword_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            bool result = await DisplayAlert("Delete", "Would you like to delete the word ?", "Yes", "No");

            UserRepository.DeleteWord(result, englishword.SelectedItem.ToString());

            GetWord();
        }

        private async void Turkishword_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            bool result = await DisplayAlert("Delete", "Would you like to delete the word ?", "Yes", "No");            

            UserRepository.DeleteWord(result, englishword.SelectedItem.ToString());

            GetWord();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new PopupView());
        }
    }
}