using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bim494_Hw1.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MeesageAndroid))]
namespace Bim494_Hw1.Droid
{
    public class MeesageAndroid : IMessage
    {
        public void Message(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}