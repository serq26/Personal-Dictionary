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
	public partial class MyWords : ContentPage
	{
		public MyWords ()
		{
			InitializeComponent ();
            
            GetWord();           
		}

        private void GetWord()
        {
            List<Words> words = UserRepository.GetAllWord();
            englishword.ItemsSource = words;
            turkishword.ItemsSource = words;
        }
    }
}