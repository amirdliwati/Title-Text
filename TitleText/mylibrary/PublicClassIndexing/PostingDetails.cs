using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mylibrary
{
    public class PostingDetails
    {
        private int termID;
        private string document;
        private int termFreq;

        public int TermID
        {
            get { return termID; }
            set { termID = value; }
        }
        public string Document
        {
            get { return document; }
            set { document = value; }
        }
        public int TermFreq
        {
            get { return termFreq; }
            set { termFreq = value; }
        }

    }
}
