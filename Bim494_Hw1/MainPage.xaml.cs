using Bim494_Hw1.Model;
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
    public partial class MainPage : ContentPage
    {
        List<Words> findingWords = new List<Words>();
        
        public MainPage()
        {
            InitializeComponent();

            findListview.IsVisible = false;

            findListview_2.IsVisible = false;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConfigPage());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (trtoen.IsToggled == true)
            {

                TranslatedWord.Text = UserRepository.GetEnglishWord(EntryTxt.Text);

            }
            else if (entotr.IsToggled == true)
            {
                TranslatedWord.Text = UserRepository.GetTurkishWord(EntryTxt.Text);        

            }
            else if(string.IsNullOrEmpty(EntryTxt.Text))
            {
                DisplayAlert("Error", "Please enter some text..!", "OK", "Cancel");
            }
        }

        private void EntryTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EntryTxt.Text == "")
            {
                findListview.IsVisible = false;

                findListview_2.IsVisible = false;

                TranslatedWord.Text = "";
            }

            else if (trtoen.IsToggled == true)
            {
                findListview.IsVisible = true;

                findListview_2.IsVisible = false;

                findingWords = UserRepository.FindTurkishWord(EntryTxt.Text);

                findListview.ItemsSource = findingWords;
            }
            else if (entotr.IsToggled == true)
            {
                findListview.IsVisible = false;

                findListview_2.IsVisible = true;

                findingWords = UserRepository.FindEnglishWord(EntryTxt.Text);

                findListview_2.ItemsSource = findingWords;
            }  
          
        }

        private void FindListview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            findListview.IsVisible = false;
            var selected = (Words)e.SelectedItem;
            TranslatedWord.Text = UserRepository.GetEnglishWord(selected.TurkishWord);
           
        }

        private void FindListview_ItemSelected_2(object sender, SelectedItemChangedEventArgs e)
        {
            findListview_2.IsVisible = false;
            var selected = (Words)e.SelectedItem;
            TranslatedWord.Text = UserRepository.GetTurkishWord(selected.EnglishWord);

        }
    }
}