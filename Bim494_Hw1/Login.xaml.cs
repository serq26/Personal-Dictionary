using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using System.IO;
using Bim494_Hw1.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bim494_Hw1
{
    public partial class Login : ContentPage 
    {
        Users U1 = new Users();

        public Login()
        {
            InitializeComponent();
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            bool cnt1 = App.UserRepo.ListHasUser(_email.Text, _password.Text);

            if (cnt1 == true)
            {
                await Navigation.PushAsync(new MainPage());
                Navigation.RemovePage(this);

            }
            else
            {
                App.UserRepo.AddNewUser(_email.Text, _password.Text);
                
                DependencyService.Get<IMessage>().Message(App.UserRepo.StatusMessage);

                await Navigation.PushAsync(new MainPage());
                Navigation.RemovePage(this);
            }
            
        }

        //private void GetAllClicked(object sender, EventArgs e)
        //{
        //    statusMessage.Text = "";

        //    List<Users> users = App.UserRepo.GetAllPeople();
        //    peopleList.ItemsSource = users;

        //}

        private void _email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(_email.Text.Contains("@") == false)
            {
                statusMessage.Text = "This email adress is invalid!";
            }
            else
            {
                statusMessage.Text = "";
            }
            
        }

        private void _password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(_password.Text.Length <= 5)
            {
                statusMessage.Text = "This password is too short";
            }
            else
            {
                statusMessage.Text = "";
            }
        }

       
    }
}
