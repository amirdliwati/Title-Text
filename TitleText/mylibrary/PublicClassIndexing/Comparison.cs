using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace mylibrary
{
    public class Comparison : System.IComparable
    {
        private string term;
        private string doc;

        public string Term
        {
            get { return term; }
            set { term = value; }
        }
        public string Doc
        {
            get { return doc; }
            set { doc = value; }
        }

        public int CompareTo(object obj)
        {
            Comparison comp = (Comparison)obj;
            if (this.Term == comp.Term)
            {
                return this.doc.CompareTo(comp.doc);
            }
            else
            {
                return this.term.CompareTo(comp.term);
            }
        }
    }
    public class TermsComparer : IComparer
    {
        public TermsComparer() { }
        public int Compare(object x, object y)
        {
            Comparison term1 = (Comparison)x;
            Comparison term2 = (Comparison)y;
            if (term1.Term == term2.Term)
            {
                return term1.Doc.CompareTo(term2.Doc);
            }
            else
            {
                return term1.Term.CompareTo(term2.Term);
            }
        }
    }
}
