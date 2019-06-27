using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bim494_Hw1.Model;
using SQLite;
using Xamarin.Forms;

namespace Bim494_Hw1
{
    public class UserRepository
    {
       
        static SQLiteConnection conn , connWords;
        public string StatusMessage { get; set; }
       

        public UserRepository(string dbPath)
        {
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Users>(); // Connection to the Users Table

            connWords = new SQLiteConnection(dbPath);
            connWords.CreateTable<Words>();  // Connection to the Words Table
        }


        ///////////////   Here for Users   /////////////////////////////////

        public void AddNewUser(string email, string password)
        {
            int result = 0;
            try
            {
                if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
                    throw new Exception("Valid name required");

                result = conn.Insert(new Users { Email = email , Password = password});

                StatusMessage = string.Format("{0} added and password combination is new! You have been registered. Enjoy!",email);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", email, ex.Message);
            }
        }


        public List<Users> GetAllPeople()
        {
            try
            {
                return conn.Table<Users>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Users>();
        }

        public bool ListHasUser(string _Email, string _Password)
        {
           
            bool control;

            var data = conn.Table<Users>(); 
            var data1 = data.Where(x => x.Email == _Email && x.Password == _Password).FirstOrDefault(); 
            if (data1 != null)
            {
                return control = true;
            }
            else
            {
                return control = false;
            }
        }


        /////////////   Here for Words  ///////////////////////////////////

        public static void AddNewWord(string Turkishword, string Englishword)
        {
            int result = 0;
            try
            {
                if (string.IsNullOrEmpty(Turkishword) && string.IsNullOrEmpty(Englishword))
                    throw new Exception("Valid word required");

                result = connWords.Insert(new Words { TurkishWord = Turkishword , EnglishWord = Englishword });

                //StatusMessage = string.Format("{0} - {1} added", Turkishword,Englishword);

            }
            catch (Exception ex)
            {
                //StatusMessage = string.Format("Failed to add {0}. Error: {1}", Turkishword, ex.Message);
            }
        }

        public bool IsTurkishWord(string Turkishword)
        {
            bool control;

            var data = connWords.Table<Words>();
            var data1 = data.Where(x => x.TurkishWord == Turkishword).FirstOrDefault();
            if (data1 != null)
            {
                return control = true;
            }
            else
            {
                return control = false;
            }

        }

        public bool IsEnglishWord(string Englishword)
        {
            bool control;

            var data = connWords.Table<Words>();
            var data1 = data.Where(x => x.EnglishWord == Englishword).FirstOrDefault();
            if (data1 != null)
            {
                return control = true;
            }
            else
            {
                return control = false;
            }

        }


        public void UpdateWord(string Turkishword, string Englishword)
        {
            string oldWord = Turkishword;
            string newWord = Englishword;
           
            if(IsTurkishWord(oldWord) == true)
            {
                var Updated = connWords.Query<Words>($"UPDATE Words SET TurkishWord = '{newWord}'  WHERE TurkishWord = '{oldWord}'");
                StatusMessage = string.Format("{0} updated", oldWord);
            }
            else if(IsEnglishWord(oldWord) == true)
            {
                var Updated = connWords.Query<Words>($"UPDATE Words SET EnglishWord = '{newWord}'  WHERE EnglishWord = '{oldWord}'");
                StatusMessage = string.Format("{0} updated", oldWord);
            }
            else
            {
                DependencyService.Get<IMessage>().Message("The word has not founded in the table!");
            }
            
        }

        public void DeleteWord(string word)
        {            
            try
            {
                if (string.IsNullOrEmpty(word.ToString()))
                    throw new Exception("Valid word required");

                //result = connWords.Delete<Words>(word);
                var deleted = connWords.Query<Words>($"DELETE FROM Words WHERE TurkishWord = '{word}' OR EnglishWord = '{word}'");
                StatusMessage = string.Format("{0} deleted", word);               

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. Error: {1}", word, ex.Message);
            }
        }


        public static void DeleteWord(bool result, string word)
        {
            if (result)
            {
                var deleted = UserRepository.connWords.Query<Words>($"DELETE FROM Words WHERE TurkishWord = '{word}' OR EnglishWord = '{word}'");
            }
            
        }

        private Task<bool> DisplayAlert(string v1, string v2, string v3, string v4)
        {
            throw new NotImplementedException();
        }

        public static List<Words> GetAllWord()
        {
            try
            {
                return connWords.Table<Words>().ToList();
            }
            catch (Exception ex)
            {
               // StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Words>();
        }

        public static string GetEnglishWord(string Word)
        {
            try
            {
                var Engdata = connWords.Query<Words>($"SELECT EnglishWord FROM Words WHERE TurkishWord='{Word}'");
                return Engdata[0].EnglishWord;
            }
            catch(Exception ex)
            {
                return "There is no this word..!";
            }
           
        }

        public static string GetTurkishWord(string Word)
        {
            try
            {
                var Turkdata = connWords.Query<Words>($"SELECT TurkishWord FROM Words WHERE EnglishWord='{Word}'");
                return Turkdata[0].TurkishWord;
            }
            catch (Exception ex)
            {
                return "There is no this word..!";
            }
        }
    }
}
