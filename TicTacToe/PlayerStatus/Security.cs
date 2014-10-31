using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoodle
{
    class Security
    {
        public static string Encrypt(string password)
        {

            if (password.Length > 0)
            {
                char[] code = new char[password.Length + 1];
                int key = (int)password[0];
                int i = 0;
                for (i = 0; i < password.Length; i++)
                {
                    int current = (int)password[i];

                    code[i] = (char)(current + key);
                }
                code[i] = (char)(key + 28);
                return new string(code);
            }
            return "";
        }


        public static string Decrypt(string code)
        {

            if (code.Length > 0)
            {
                char[] password = new char[code.Length - 1];
                int key = (((int)code[code.Length - 1]) - 28);
                for (int i = 0; i < password.Length; i++)
                {

                    int current = (int)code[i];

                    password[i] = (char)(current - key);
                }



                return new string(password);
            }
            return "";
        }
    }
}
