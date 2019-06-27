using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bim494_Hw1.Model
{
    [Table("Words")]
    public class Words
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string TurkishWord { get; set; }

        [MaxLength(250), Unique]
        public string EnglishWord { get; set; }

        public override string ToString()
        {
            return TurkishWord;
        }
                  
    }
}
