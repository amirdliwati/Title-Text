using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office;
using Microsoft.Office.Interop.Word;



namespace mylibrary
{
   public class GetWordsFromDoc
    {

       public string GetWords(string path)
        {
            
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            object file = path;
            object objFalse = false;
            object objTrue = true;
            object missing = System.Reflection.Missing.Value;
            object emptyData = string.Empty;
            wordApp.Visible = false;
            Microsoft.Office.Interop.Word.Document aDoc = wordApp.Documents.Open(ref file, ref objFalse, ref objFalse,
                    ref objFalse, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref objTrue,
                    ref missing, ref missing, ref missing);
            aDoc.Activate();
            string fileStr = "";

            foreach (Paragraph item in aDoc.Paragraphs)
            {
                fileStr += item.Range.Text + " ";
            }

            //aDoc.Close(ref missing, ref missing, ref missing);
            wordApp.Quit(ref missing, ref missing, ref missing);


            return fileStr;
        }




    }
}
