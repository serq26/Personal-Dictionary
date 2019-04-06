using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;
namespace Bim494_Hw1.Model
{
    [Table("Users")]
    public class Users : INotifyPropertyChanged
    {
        private string validateError;
        public string ValidateError
        {
            get
            {
                return validateError;
            }
            set
            {
                validateError = value;
                //OnPropertyChanged("ValidateError");
            }
        }



        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Password { get; set; }

        //private string _password;
        //[MaxLength(200)]
        //public string Password
        //{
        //    get
        //    {
        //        return _password;
        //    }
        //    set
        //    {
        //        _password = value;

        //        if (value.Length < 4)
        //        {
        //            validateError = "This password is too short";
        //            OnPropertyChanged("ValidateError");
        //        }

        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
