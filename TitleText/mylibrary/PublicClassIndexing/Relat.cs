using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mylibrary
{
    public class Relat
    {
        private string term;
        private string document;
        private int frequency;


        public string Term
        {
            get { return term; }
            set { term = value; }
        }
        public string Document
        {
            get { return document; }
            set { document = value; }
        }

        public int Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

    }
}
