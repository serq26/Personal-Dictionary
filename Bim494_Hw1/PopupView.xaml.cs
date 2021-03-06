﻿using Rg.Plugins.Popup.Pages;
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
	public partial class PopupView : PopupPage
	{
		public PopupView ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            UserRepository.AddNewWord(trWord.Text, engWord.Text);
            trWord.Text = "";
            engWord.Text = "";
            MyWords.GetWord();
        }

        private void CloseTheInfo_Tapped(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(true);
        }
    }
}