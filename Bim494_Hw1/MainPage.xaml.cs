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

                TranslatedWord.Text = App.UserRepo.GetEnglishWord(EntryTxt.Text);

            }
            else if (entotr.IsToggled == true)
            {
                TranslatedWord.Text = App.UserRepo.GetTurkishWord(EntryTxt.Text);
            }
            else if(string.IsNullOrEmpty(EntryTxt.Text))
            {
                DisplayAlert("Error", "Please enter some text..!", "OK", "Cancel");
            }
        }

        private void Trtoen_Toggled(object sender, ToggledEventArgs e)
        {
        //    if(entotr.IsToggled == true)
        //    {
        //        entotr.IsToggled = false;
        //        trtoen.IsToggled = true;
        //    }
        //    else if(trtoen.IsToggled == true)
        //    {
        //        trtoen.IsToggled = true;
        //    }
        //    else
        //    {
        //        trtoen.IsToggled = true;
        //    }
            
        }

        private void Entotr_Toggled(object sender, ToggledEventArgs e)
        {
        //    if(trtoen.IsToggled == true)
        //    {
        //        trtoen.IsToggled = false;
        //        entotr.IsToggled = true;
        //    }
        //    else if (entotr.IsToggled == true)
        //    {
        //        entotr.IsToggled = true;
        //    }
        //    else
        //    {
        //        entotr.IsToggled = true;
        //    }
            
        }
    }
}