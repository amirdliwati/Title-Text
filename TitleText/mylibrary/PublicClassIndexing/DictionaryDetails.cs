using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mylibrary
{
    public class DictionaryDetails
    {
        private int termID;
        private string term;
        private int ndoc;
        private int collFreq;

        public int TermID
        {
            get { return termID; }
            set { termID = value; }
        }
        public string Term
        {
            get { return term; }
            set { term = value; }
        }
        public int Ndoc
        {
            get { return ndoc; }
            set { ndoc = value; }
        }
        public int CollFreq
        {
            get { return collFreq; }
            set { collFreq = value; }
        }

        public DictionaryDetails() { }
        public DictionaryDetails(int termID, string term, int ndoc, int collFreq)
        {
            this.termID = termID;
            this.term = term;
            this.ndoc = ndoc;
            this.collFreq = collFreq;
        }
    }
}
