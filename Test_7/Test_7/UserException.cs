using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_7
{
    internal class UserException : Exception
    {
        public User Nome { get; set; }
        public UserException()
        {

        }
        public UserException(string message) : base(String.Format("User non trovato: {0}", message))
        {

        }
    }
}
