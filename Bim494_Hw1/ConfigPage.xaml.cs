using Bim494_Hw1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bim494_Hw1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfigPage : ContentPage, INotifyPropertyChanged
	{
		public ConfigPage ()
		{
			InitializeComponent ();
		}

        private void AddWord(object sender, EventArgs e)
        {

            App.UserRepo.AddNewWord(TurkishWord.Text, EnglishWord.Text);
            DependencyService.Get<IMessage>().Message(App.UserRepo.StatusMessage);
            //await DisplayAlert("Information",App.UserRepo.StatusMessage,"OK","Cancel");
        }

        private void UpdateWord(object sender, EventArgs e)
        {
            App.UserRepo.UpdateWord(TurkishWord.Text, EnglishWord.Text);
            DependencyService.Get<IMessage>().Message(App.UserRepo.StatusMessage);
            //await DisplayAlert("Information", App.UserRepo.StatusMessage, "OK", "Cancel");
        }

        private void DeleteWord(object sender, EventArgs e)
        {
            App.UserRepo.DeleteWord(TurkishWord.Text);
            DependencyService.Get<IMessage>().Message(App.UserRepo.StatusMessage);
            //await DisplayAlert("Information", App.UserRepo.StatusMessage, "OK", "Cancel");
           
        }

        private void GetWord(object sender, EventArgs e)
        {
            
            List<Words> users = App.UserRepo.GetAllWord();
            peopleList.ItemsSource = users;
            
        }


       

    }
}