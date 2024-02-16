﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace mylibrary
{
           
    public class RemoveStopWords
    {
        PrePost StopWords;

        public RemoveStopWords ()
        {

            StopWords = new PrePost(363);
            StopWords.AddString("في"); StopWords.AddString("على");
            StopWords.AddString("إلى"); StopWords.AddString("من");
            StopWords.AddString("عن"); StopWords.AddString("هناك");
            StopWords.AddString("أو"); StopWords.AddString("ثم");
            StopWords.AddString("نحن"); StopWords.AddString("أنا");
            StopWords.AddString("أنتم"); StopWords.AddString("أنت");
            StopWords.AddString("أنتما"); StopWords.AddString("إياه");
            StopWords.AddString("أنتن"); StopWords.AddString("إياها");
            StopWords.AddString("هو"); StopWords.AddString("إياهما");
            StopWords.AddString("هي"); StopWords.AddString("إياهم");
            StopWords.AddString("هما"); StopWords.AddString("إياهن");
            StopWords.AddString("هم"); StopWords.AddString("إياك");
            StopWords.AddString("هن"); StopWords.AddString("إياكما");
            StopWords.AddString("تلك"); StopWords.AddString("إياكم");
            StopWords.AddString("ذا"); StopWords.AddString("إياكن");
            StopWords.AddString("ذاك"); StopWords.AddString("إياي");
            StopWords.AddString("ذلك"); StopWords.AddString("إيانا");
            StopWords.AddString("ذان"); StopWords.AddString("أولاء");
            StopWords.AddString("ذانك"); StopWords.AddString("أولئك");
            StopWords.AddString("ذه"); StopWords.AddString("أولالك");
            StopWords.AddString("ذين"); StopWords.AddString("ذي");
            StopWords.AddString("ذينك"); StopWords.AddString("هؤلاء");
            StopWords.AddString("هذان"); StopWords.AddString("هاتان");
            StopWords.AddString("هذه"); StopWords.AddString("هانه");
            StopWords.AddString("هذي"); StopWords.AddString("هاتي");
            StopWords.AddString("هذين"); StopWords.AddString("هاتين");
            StopWords.AddString("هنا"); StopWords.AddString("هذا");
            StopWords.AddString("من"); StopWords.AddString("هنالك");
            StopWords.AddString("ما"); StopWords.AddString("التي");
            StopWords.AddString("أين"); StopWords.AddString("الذي");
            StopWords.AddString("أي"); StopWords.AddString("اللذين");
            StopWords.AddString("أيان"); StopWords.AddString("الذين");
            StopWords.AddString("حيثما"); StopWords.AddString("اللذان");
            StopWords.AddString("كيفما"); StopWords.AddString("اللاتي");
            StopWords.AddString("متى"); StopWords.AddString("اللتان");
            StopWords.AddString("هماكم"); StopWords.AddString("اللتيا");
            StopWords.AddString("كيف"); StopWords.AddString("اللتيا");
            StopWords.AddString("ماذا"); StopWords.AddString("اللواتي");
            StopWords.AddString("هلم"); StopWords.AddString("كأي");
            StopWords.AddString("قلما"); StopWords.AddString("كأين");
            StopWords.AddString("إن"); StopWords.AddString("إليك");
            StopWords.AddString("لا"); StopWords.AddString("إليكم");
            StopWords.AddString("لات"); StopWords.AddString("إليكما");
            StopWords.AddString("أن"); StopWords.AddString("إليكن");
            StopWords.AddString("كأن"); StopWords.AddString("عليك");
            StopWords.AddString("لعل"); StopWords.AddString("ها");
            StopWords.AddString("لكن"); StopWords.AddString("هاك");
            StopWords.AddString("أي"); StopWords.AddString("ليت");
            StopWords.AddString("أيا"); StopWords.AddString("أجل");
            StopWords.AddString("بل"); StopWords.AddString("إذما");
            StopWords.AddString("بلا"); StopWords.AddString("إذن");
            StopWords.AddString("حتى"); StopWords.AddString("إذ");
            StopWords.AddString("سوف"); StopWords.AddString("ألا");
            StopWords.AddString("عل"); StopWords.AddString("إلى");
            StopWords.AddString("في"); StopWords.AddString("أم");
            StopWords.AddString("كلا"); StopWords.AddString("أما");
            StopWords.AddString("هلا"); StopWords.AddString("كي");
            StopWords.AddString("وا"); StopWords.AddString("لم");
            StopWords.AddString("إذ"); StopWords.AddString("لن");
            StopWords.AddString("إلا"); StopWords.AddString("لو");
            StopWords.AddString("على"); StopWords.AddString("لولا");
            StopWords.AddString("عن"); StopWords.AddString("لوما");
            StopWords.AddString("قد"); StopWords.AddString("هل");
            StopWords.AddString("عدا"); StopWords.AddString("لما");
            StopWords.AddString("بعض"); StopWords.AddString("مذ");
            StopWords.AddString("سوى"); StopWords.AddString("منذ");
            StopWords.AddString("غير"); StopWords.AddString("حاشا");
            StopWords.AddString("كل"); StopWords.AddString("خلا");
            StopWords.AddString("ذات"); StopWords.AddString("لعمر");
            StopWords.AddString("عندما"); StopWords.AddString("مثل");
            StopWords.AddString("كلما"); StopWords.AddString("مع");
            StopWords.AddString("قبل"); StopWords.AddString("نحو");
            StopWords.AddString("خلف"); StopWords.AddString("حيث");
            StopWords.AddString("أمام"); StopWords.AddString("كلتا");
            StopWords.AddString("تحت"); StopWords.AddString("سيما");
            StopWords.AddString("يمين"); StopWords.AddString("أصلاً");
            StopWords.AddString("أصبح"); StopWords.AddString("بين");
            StopWords.AddString("كان"); StopWords.AddString("صار");
            StopWords.AddString("ليس"); StopWords.AddString("ظل");
            StopWords.AddString("انفك"); StopWords.AddString("عاد");
            StopWords.AddString("مادام"); StopWords.AddString("برح");
            StopWords.AddString("مازال"); StopWords.AddString("مافتئ");
            StopWords.AddString("فوق"); StopWords.AddString("و");
            StopWords.AddString("I"); StopWords.AddString("a");
            StopWords.AddString("an"); StopWords.AddString("as");
            StopWords.AddString("at"); StopWords.AddString("by");
            StopWords.AddString("he"); StopWords.AddString("his");
            StopWords.AddString("me"); StopWords.AddString("thou");
            StopWords.AddString("us"); StopWords.AddString("who");
            StopWords.AddString("against"); StopWords.AddString("amid");
            StopWords.AddString("amidst"); StopWords.AddString("among");
            StopWords.AddString("amongst"); StopWords.AddString("anybody");
            StopWords.AddString("anyone"); StopWords.AddString("because");
            StopWords.AddString("beside"); StopWords.AddString("circa");
            StopWords.AddString("despite"); StopWords.AddString("during");
            StopWords.AddString("everybody"); StopWords.AddString("everyone");
            StopWords.AddString("for"); StopWords.AddString("from");
            StopWords.AddString("her"); StopWords.AddString("hers");
            StopWords.AddString("herself"); StopWords.AddString("him");
            StopWords.AddString("himself"); StopWords.AddString("hisself");
            StopWords.AddString("idem"); StopWords.AddString("if");
            StopWords.AddString("into"); StopWords.AddString("it");
            StopWords.AddString("its"); StopWords.AddString("itself");
            StopWords.AddString("myself"); StopWords.AddString("nor");
            StopWords.AddString("of"); StopWords.AddString("oneself");
            StopWords.AddString("onto"); StopWords.AddString("our");
            StopWords.AddString("ourself"); StopWords.AddString("ourselves");
            StopWords.AddString("per"); StopWords.AddString("she");
            StopWords.AddString("since"); StopWords.AddString("than");
            StopWords.AddString("that"); StopWords.AddString("the");
            StopWords.AddString("thee"); StopWords.AddString("theirs");
            StopWords.AddString("them"); StopWords.AddString("themselves");
            StopWords.AddString("they"); StopWords.AddString("thine");
            StopWords.AddString("this"); StopWords.AddString("thyself");
            StopWords.AddString("to"); StopWords.AddString("tother");
            StopWords.AddString("toward"); StopWords.AddString("towards");
            StopWords.AddString("until"); StopWords.AddString("unless");
            StopWords.AddString("upon"); StopWords.AddString("versus");
            StopWords.AddString("via"); StopWords.AddString("we");
            StopWords.AddString("what"); StopWords.AddString("whatall");
            StopWords.AddString("whereas"); StopWords.AddString("which");
            StopWords.AddString("whichever"); StopWords.AddString("whichsoever");
            StopWords.AddString("whoever"); StopWords.AddString("whom");
            StopWords.AddString("whomever"); StopWords.AddString("whomso");
            StopWords.AddString("whomsoever"); StopWords.AddString("whosoever");
            StopWords.AddString("with"); StopWords.AddString("whose");
            StopWords.AddString("without"); StopWords.AddString("ye");
            StopWords.AddString("you"); StopWords.AddString("you-all");
            StopWords.AddString("yourselves"); StopWords.AddString("yourself");
            StopWords.AddString("about"); StopWords.AddString("aboard");
            StopWords.AddString("across"); StopWords.AddString("above");
            StopWords.AddString("after"); StopWords.AddString("all");
            StopWords.AddString("along"); StopWords.AddString("alongside");
            StopWords.AddString("although"); StopWords.AddString("another");
            StopWords.AddString("anti"); StopWords.AddString("any");
            StopWords.AddString("anything"); StopWords.AddString("around");
            StopWords.AddString("astride"); StopWords.AddString("aught");
            StopWords.AddString("bar"); StopWords.AddString("barring");
            StopWords.AddString("before"); StopWords.AddString("behind");
            StopWords.AddString("below"); StopWords.AddString("yonder");
            StopWords.AddString("besides"); StopWords.AddString("beneath");
            StopWords.AddString("beyond"); StopWords.AddString("between");
            StopWords.AddString("but"); StopWords.AddString("both");
            StopWords.AddString("considering"); StopWords.AddString("concerning");
            StopWords.AddString("down"); StopWords.AddString("each");
            StopWords.AddString("either"); StopWords.AddString("enough");
            StopWords.AddString("except"); StopWords.AddString("excepting");
            StopWords.AddString("excluding"); StopWords.AddString("few");
            StopWords.AddString("fewer"); StopWords.AddString("following");
            StopWords.AddString("ilk"); StopWords.AddString("in");
            StopWords.AddString("including"); StopWords.AddString("inside");
            StopWords.AddString("like"); StopWords.AddString("many");
            StopWords.AddString("mine"); StopWords.AddString("minus");
            StopWords.AddString("more"); StopWords.AddString("most");
            StopWords.AddString("naught"); StopWords.AddString("near");
            StopWords.AddString("neither"); StopWords.AddString("nobody");
            StopWords.AddString("none"); StopWords.AddString("nothing");
            StopWords.AddString("notwithstanding"); StopWords.AddString("off");
            StopWords.AddString("on"); StopWords.AddString("opposite");
            StopWords.AddString("other"); StopWords.AddString("otherwise");
            StopWords.AddString("outside"); StopWords.AddString("over");
            StopWords.AddString("own"); StopWords.AddString("past");
            StopWords.AddString("pending"); StopWords.AddString("plus");
            StopWords.AddString("regarding"); StopWords.AddString("round");
            StopWords.AddString("save"); StopWords.AddString("self");
            StopWords.AddString("several"); StopWords.AddString("so");
            StopWords.AddString("some"); StopWords.AddString("somebody");
            StopWords.AddString("someone"); StopWords.AddString("something");
            StopWords.AddString("somewhat"); StopWords.AddString("such");
            StopWords.AddString("suchlike"); StopWords.AddString("sundry");
            StopWords.AddString("there"); StopWords.AddString("though");
            StopWords.AddString("through"); StopWords.AddString("throughout");
            StopWords.AddString("till"); StopWords.AddString("twain");
            StopWords.AddString("under"); StopWords.AddString("underneath");
            StopWords.AddString("unlike"); StopWords.AddString("up");
            StopWords.AddString("various"); StopWords.AddString("vis-a-vis");
            StopWords.AddString("whatever"); StopWords.AddString("whatsoever");
            StopWords.AddString("when"); StopWords.AddString("wherewith");
            StopWords.AddString("wherewithal"); StopWords.AddString("within");
            StopWords.AddString("worth"); StopWords.AddString("while");
            StopWords.AddString("yet"); StopWords.AddString("yon");
            StopWords.AddString("yours");
            

        }

        public string removing (string W)
        {
            string Stem = "";
            W = W.Trim();
       
                string S = W.ToString();
                if (!StopWords.Search(S))
                {
                    Stem += S;
                }
            return Stem;
        }


    }
}
