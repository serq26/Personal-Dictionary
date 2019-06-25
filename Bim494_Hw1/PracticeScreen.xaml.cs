
using Bim494_Hw1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamanimation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bim494_Hw1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PracticeScreen : ContentPage
	{
        List<Words> MyWords = new List<Words>();

        int i = 0;

        public PracticeScreen()
        {
            InitializeComponent();

            MyWords = UserRepository.GetAllWord();

            EnglishWord.Text = MyWords[i].EnglishWord;
        }

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    Card.Animate(new FlipAnimation
                    {
                        Direction = FlipAnimation.FlipDirection.Left,
                        Duration = "500",
                        Easing = EasingType.SpringIn

                    });
                    TurkishWord.Text = UserRepository.GetTurkishWord(EnglishWord.Text);                    
                    break;
                case SwipeDirection.Right:
                    Card.Animate(new FlipAnimation
                    {
                        Direction = FlipAnimation.FlipDirection.Right,
                        Duration = "500",
                        Easing = EasingType.Linear
                    });
                    TurkishWord.Text = UserRepository.GetTurkishWord(EnglishWord.Text);
                    break;             
            }
        }

        private void Next_Button_Clicked(object sender, EventArgs e)
        {
            i++;          

            if (i == MyWords.Count)
            {
                EnglishWord.Text = "Finish!";
                TurkishWord.Text = "";
                i = 0;
            }
            else
            {
                EnglishWord.Text = MyWords[i].EnglishWord;
                TurkishWord.Text = "";
            }
        }
    }
}