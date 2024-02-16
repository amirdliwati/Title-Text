using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using mylibrary;
using System.Web;
using System.IO;

namespace mylibrary
{
    public class Index
    {
        public string path;
        private string connectionString1;
        public Index()
        {
            connectionString1 = Class1.x;

        }


        public bool DeleteIndexes()
        {
            bool status = false;
            SqlConnection con = new SqlConnection(connectionString1);
            SqlCommand cmd = new SqlCommand("DeleteIndexes", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException err)
            {

                throw new ApplicationException("Data error." + err);
            }
            finally
            {
                con.Close();
                status = true;
            }
            return status;
        }

        public bool EnglishIndexes()
        {
            bool status = false;

            try
            {

                ArrayList termsArr = new ArrayList();
                for (int i = 1; i <= 1; i++)
                {
                    GetWordsFromDoc getword = new GetWordsFromDoc();
                    string MyTerms = getword.GetWords(path);
                    CheckWord check = new CheckWord();
                    RemoveStopWords RSW = new RemoveStopWords();
                    string S = ""; string Temp = "";
                    Temp = MyTerms;
                    for (int l = 0; l < Temp.Length; l++)
                        if (char.IsLetter(Temp, l))
                            S += Temp[l].ToString();
                        else
                            S += " ";
                    S = S.Trim();
                    string[] R = S.ToLower().Split(' ');
                    for (int j = 0; j < R.Length; j++)
                    {
                        string Stem;
                        Stem = check.checkword(R[j]);
                        if (Stem == "1")

                            Stem = RSW.removing(R[j]);
                        if (Stem != "")
                        {
                            Comparison comp = new Comparison();
                            comp.Doc = Convert.ToString(i);
                            comp.Term = Stem;
                            termsArr.Add(comp);
                        }
                    }
                    PorterStemmer StemmerPorterStemmer = new PorterStemmer();
                    for (int k = 0; k < termsArr.Count; k++)
                    {
                        string Stem = StemmerPorterStemmer.StemWord(((Comparison)(termsArr[k])).Term);
                        ((Comparison)(termsArr[k])).Term = Stem;
                    }
                }
                termsArr.Sort(new TermsComparer());
                ArrayList termsArr2 = new ArrayList();
                if (termsArr.Count != 0)
                {
                    Relat r = new Relat();
                    r.Document = ((Comparison)termsArr[0]).Doc;
                    r.Term = ((Comparison)termsArr[0]).Term;
                    r.Frequency = 1;
                    termsArr2.Add(r);
                    for (int i = 1; i < termsArr.Count; i++)
                    {
                        Comparison f1 = (Comparison)termsArr[i];
                        Comparison f2 = (Comparison)termsArr[i - 1];
                        if (f1.CompareTo(f2) == 0)
                        {
                            ((Relat)termsArr2[termsArr2.Count - 1]).Frequency += 1;
                        }
                        else
                        {
                            r = new Relat();
                            r.Document = f1.Doc;
                            r.Term = f1.Term;
                            r.Frequency = 1;
                            termsArr2.Add(r);
                        }
                    }
                }
                AddTermsFreqEnglish(termsArr2);
            }
            catch (SqlException err)
            {

                throw new ApplicationException("Data error." + err);
            }
            finally
            {

                status = true;
            }
            return status;
        }

        private void AddTermsFreqEnglish(ArrayList arrlst)
        {
            ArrayList terms = new ArrayList();
            ArrayList freq = new ArrayList();

            if (arrlst.Count != 0)
            {
                int ID = 1;
                DictionaryDetails dic = new DictionaryDetails();
                dic.Term = ((Relat)arrlst[0]).Term;
                dic.Ndoc = 1;
                dic.CollFreq = 1;
                dic.TermID = ID;
                terms.Add(dic);

                PostingDetails post = new PostingDetails();
                post.Document = ((Relat)arrlst[0]).Document;
                post.TermFreq = ((Relat)arrlst[0]).Frequency;
                post.TermID = ID;
                freq.Add(post);



                for (int i = 1; i < arrlst.Count; i++)
                {
                    Relat r1 = (Relat)arrlst[i];
                    Relat r2 = (Relat)arrlst[i - 1];
                    if (r1.Term == r2.Term)
                    {
                        ((DictionaryDetails)terms[terms.Count - 1]).Ndoc += 1;
                        ((DictionaryDetails)terms[terms.Count - 1]).CollFreq += r1.Frequency;
                    }
                    else
                    {
                        dic = new DictionaryDetails();
                        dic.Term = r1.Term;
                        dic.Ndoc = 1;
                        dic.CollFreq = r1.Frequency;
                        dic.TermID = ++ID;
                        terms.Add(dic);
                    }
                    post = new PostingDetails();
                    post.Document = r1.Document;
                    post.TermFreq = r1.Frequency;
                    post.TermID = ID;
                    freq.Add(post);




                }

                SqlConnection con = new SqlConnection(connectionString1);
                SqlCommand cmd = new SqlCommand("AddDictionary", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@TermID", SqlDbType.Int, 4));
                cmd.Parameters.Add(new SqlParameter("@Term", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@Ndoc", SqlDbType.Int, 4));
                cmd.Parameters.Add(new SqlParameter("@CollFreq", SqlDbType.Int, 4));

                try
                {
                    con.Open();
                    foreach (DictionaryDetails dictionary in terms)
                    {
                        cmd.Parameters["@TermID"].Value = dictionary.TermID;
                        cmd.Parameters["@Term"].Value = dictionary.Term;
                        cmd.Parameters["@Ndoc"].Value = dictionary.Ndoc;
                        cmd.Parameters["@CollFreq"].Value = dictionary.CollFreq;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException err)
                {
                    throw new ApplicationException("Data error." + err);
                }
                finally
                {
                    con.Close();
                }

                SqlCommand cmd1 = new SqlCommand("AddPosting", con);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add(new SqlParameter("@TermID", SqlDbType.Int, 4));
                cmd1.Parameters.Add(new SqlParameter("@DocID", SqlDbType.Int, 4));
                cmd1.Parameters.Add(new SqlParameter("@TermFreq", SqlDbType.Int, 4));

                try
                {
                    con.Open();
                    foreach (PostingDetails posting in freq)
                    {
                        cmd1.Parameters["@TermID"].Value = posting.TermID;
                        cmd1.Parameters["@DocID"].Value = posting.Document;
                        cmd1.Parameters["@TermFreq"].Value = posting.TermFreq;
                        cmd1.ExecuteNonQuery();
                    }
                }
                catch (SqlException err)
                {
                    throw new ApplicationException("Data error." + err);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public bool ArabicIndexes()
        {
            bool status = false;

            try
            {

                ArrayList termsArr = new ArrayList();
           
                    GetWordsFromDoc getword = new GetWordsFromDoc();
                    string MyTerms = getword.GetWords(path);
                    RemoveStopWords RSW = new RemoveStopWords();
                    CheckWord check = new CheckWord();
                    string S = ""; string Temp = "";
                    Temp = MyTerms;
                    for (int l = 0; l < Temp.Length; l++)
                        if (char.IsLetter(Temp, l))
                            S += Temp[l].ToString();
                        else
                            S += " ";
                    S = S.Trim();
                    string[] R = S.Split(' ');
                    for (int j = 0; j < R.Length; j++)
                    {
                        string Stem;
                        Stem = check.checkword(R[j]);
                        if (Stem == "0")
                            Stem = RSW.removing(R[j]);
                        if (Stem != "")
                        {
                            Comparison comp = new Comparison();
                            comp.Doc = Convert.ToString(path);
                            comp.Term = Stem;
                            termsArr.Add(comp);
                        }
                    }
                    ISRI StemmerISRI = new ISRI();
                    for (int k = 0; k < termsArr.Count; k++)
                    {
                        string Stem = StemmerISRI.Stemming(((Comparison)(termsArr[k])).Term);
                        ((Comparison)(termsArr[k])).Term = Stem;
                    }
                
                termsArr.Sort(new TermsComparer());
                ArrayList termsArr2 = new ArrayList();
                if (termsArr.Count != 0)
                {
                    Relat r = new Relat();
                    r.Document = ((Comparison)termsArr[0]).Doc;
                    r.Term = ((Comparison)termsArr[0]).Term;
                    r.Frequency = 1;
                    termsArr2.Add(r);
                    for (int i = 1; i < termsArr.Count; i++)
                    {
                        Comparison f1 = (Comparison)termsArr[i];
                        Comparison f2 = (Comparison)termsArr[i - 1];
                        if (f1.CompareTo(f2) == 0)
                        {
                            ((Relat)termsArr2[termsArr2.Count - 1]).Frequency += 1;
                        }
                        else
                        {
                            r = new Relat();
                            r.Document = f1.Doc;
                            r.Term = f1.Term;
                            r.Frequency = 1;
                            termsArr2.Add(r);
                        }
                    }
                }
                AddTermsFreqArabic(termsArr2);
            }
            catch (SqlException err)
            {
                throw new ApplicationException("Data error." + err);
            }
            finally
            {

                status = true;
            }
            return status;
        }

        private void AddTermsFreqArabic(ArrayList arrlst)
        {
            ArrayList terms = new ArrayList();
            ArrayList freq = new ArrayList();
            if (arrlst.Count != 0)
            {
                int ID = 1;
                DictionaryDetails dic = new DictionaryDetails();
                dic.Term = ((Relat)arrlst[0]).Term;
                dic.Ndoc = 1;
                dic.CollFreq = 1;
                dic.TermID = ID;
                terms.Add(dic);

                PostingDetails post = new PostingDetails();
                post.Document = ((Relat)arrlst[0]).Document;
                post.TermFreq = ((Relat)arrlst[0]).Frequency;
                post.TermID = ID;
                freq.Add(post);

                for (int i = 1; i < arrlst.Count; i++)
                {
                    Relat r1 = (Relat)arrlst[i];
                    Relat r2 = (Relat)arrlst[i - 1];
                    if (r1.Term == r2.Term)
                    {
                        ((DictionaryDetails)terms[terms.Count - 1]).Ndoc += 1;
                        ((DictionaryDetails)terms[terms.Count - 1]).CollFreq += r1.Frequency;
                    }
                    else
                    {
                        dic = new DictionaryDetails();
                        dic.Term = r1.Term;
                        dic.Ndoc = 1;
                        dic.CollFreq = r1.Frequency;
                        dic.TermID = ++ID;
                        terms.Add(dic);
                    }
                    post = new PostingDetails();
                    post.Document = r1.Document;
                    post.TermFreq = r1.Frequency;
                    post.TermID = ID;
                    freq.Add(post);
                }

                SqlConnection con = new SqlConnection(connectionString1);
                SqlCommand cmd = new SqlCommand("AddDictionary", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@TermID", SqlDbType.Int, 4));
                cmd.Parameters.Add(new SqlParameter("@Term", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@Ndoc", SqlDbType.Int, 4));
                cmd.Parameters.Add(new SqlParameter("@CollFreq", SqlDbType.Int, 4));

                try
                {
                    con.Open();
                    foreach (DictionaryDetails dictionary in terms)
                    {
                        cmd.Parameters["@TermID"].Value = dictionary.TermID;
                        cmd.Parameters["@Term"].Value = dictionary.Term;
                        cmd.Parameters["@Ndoc"].Value = dictionary.Ndoc;
                        cmd.Parameters["@CollFreq"].Value = dictionary.CollFreq;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException err)
                {
                    throw new ApplicationException("Data error." + err);
                }
                finally
                {
                    con.Close();
                }

                SqlCommand cmd1 = new SqlCommand("AddPosting", con);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add(new SqlParameter("@TermID", SqlDbType.Int, 4));
                cmd1.Parameters.Add(new SqlParameter("@DocID", SqlDbType.VarChar));
                cmd1.Parameters.Add(new SqlParameter("@TermFreq", SqlDbType.Int, 4));

                try
                {
                    con.Open();
                    foreach (PostingDetails posting in freq)
                    {
                        cmd1.Parameters["@TermID"].Value = posting.TermID;
                        cmd1.Parameters["@DocID"].Value = posting.Document;
                        cmd1.Parameters["@TermFreq"].Value = posting.TermFreq;
                        cmd1.ExecuteNonQuery();
                    }
                }
                catch (SqlException err)
                {
                    throw new ApplicationException("Data error." + err);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
