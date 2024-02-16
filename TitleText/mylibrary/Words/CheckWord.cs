using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mylibrary
{
    class CheckWord
    {
        public string checkword(string word)
        {

            string result = "";
            int y = 0;
            if (word != "" & word.Length != 1)
            {
                string x = word.Substring(0, 1);
                byte[] ASCIIValues = Encoding.ASCII.GetBytes(x);
                foreach (byte b in ASCIIValues)
                {
                    y = b;
                }


                if (y >= 65 & y <= 122)
                   result = "1";
                else
                    result = "0";    
            }
                
            else
              result = "";

            return result;
        }

    }

}
