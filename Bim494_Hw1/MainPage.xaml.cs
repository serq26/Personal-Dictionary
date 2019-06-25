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
        
        public MainPage()
        {
            InitializeComponent();
           
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
                TranslatedWord.Text = UserRepository.GetTurkishWord(EntryTxt.Text);      //changed        

            }
            else if(string.IsNullOrEmpty(EntryTxt.Text))
            {
                DisplayAlert("Error", "Please enter some text..!", "OK", "Cancel");
            }
        }
        
       
    }
}