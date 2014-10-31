using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    class User
    {
        private string _userName;
        private string _passWord;
        public string EMail { get; set; }

        public User(string uName, string pWord)
        {
            _userName = uName;
            _passWord = pWord;
        }

        public User(string uName, string pWord, string eMail)
        {
            _userName = uName;
            _passWord = pWord;
            EMail = eMail;
        }
    }
}
