using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace mylibrary
{
    public class A_Composer
    {
        ArrayList R3, R4;
        public A_Composer()
        {
            R3 = new ArrayList(38);
            /*            R3.Add("فاعل");   R3.Add("فعول");
                        R3.Add("فعال");   R3.Add("فعيل");
                        R3.Add("مفعل");   R3.Add("فعلة");
                        R3.Add("تفاعل");  R3.Add("افتعل");
                        R3.Add("افعال");  R3.Add("افاعل");
                        R3.Add("فعالة");  R3.Add("فعلان");
                        R3.Add("فعولة");  R3.Add("تفعلة");
                        R3.Add("تفعيل");  R3.Add("مفعلة");
                        R3.Add("مفعول");  R3.Add("فاعول");
                        R3.Add("فواعل");  R3.Add("مفعال");
                        R3.Add("مفعيل");  R3.Add("افعلة");
                        R3.Add("فعائل");  R3.Add("منفعل");
                        R3.Add("مفتعل");  R3.Add("فاعلة");
                        R3.Add("مفاعل");  R3.Add("فملاع");
                        R3.Add("يفتعل");  R3.Add("تفتعل");
                        R3.Add("انفعل");  R3.Add("فعالي");
                        R3.Add("استفعل"); R3.Add("مفعالة");
                        R3.Add("افتعال"); R3.Add("انفعلل");
                        R3.Add("افعوعل"); R3.Add("مستفعل");
            */
            R3.Add("1ا23"); R3.Add("12و3");
            R3.Add("12ا3"); R3.Add("12ي3");
            R3.Add("م123"); R3.Add("123ة");
            R3.Add("ت1ا23"); R3.Add("ا1ت23");
            R3.Add("ا12ا3"); R3.Add("ا1ا23");
            R3.Add("12ا3ة"); R3.Add("123ان");
            R3.Add("12و3ة"); R3.Add("ت123ة");
            R3.Add("ت12ي3"); R3.Add("م123ة");
            R3.Add("م12و3"); R3.Add("1ا2و3");
            R3.Add("1وا23"); R3.Add("م12ا3");
            R3.Add("م12ي3"); R3.Add("ا123ة");
            R3.Add("12ائ3"); R3.Add("من123");
            R3.Add("م1ت23"); R3.Add("1ا23ة");
            R3.Add("م1ا23"); R3.Add("1م3ا2");
            R3.Add("ي1ت23"); R3.Add("ت1ت23");
            R3.Add("ان123"); R3.Add("12ا3ي");
            R3.Add("است123"); R3.Add("م12ا3ة");
            R3.Add("ا1ت2ا3"); R3.Add("ان1233");
            R3.Add("ا12و23"); R3.Add("مست123");



            R4 = new ArrayList(9);
            /*            R4.Add("تفعلظ"); R4.Add("افعلظ");
                        R4.Add("فعلاظ");  R4.Add("فعالظ");
                        R4.Add("مفعلظ"); R4.Add("فعلظة");
                        R4.Add("افعلاظ"); R4.Add("متفعلظ");
                        R4.Add("افتعلظ");
            */
            R4.Add("ت1234"); R4.Add("ا1234");
            R4.Add("123ا4"); R4.Add("12ا34");
            R4.Add("م1234"); R4.Add("1234ة");
            R4.Add("ا123ا4"); R4.Add("مت1234");
            R4.Add("ا1ت234");



        }

        public ArrayList Compose(string W)
        {
            //            string Stem = " ";
            ArrayList AStem = new ArrayList(38);

            if (W.Length >= 4)
            {
                for (int r = 0; r < 9; r++)
                {
                    string tempo2 = R4[r].ToString();
                    //                           int num = tempo2.LastIndexOf("ل");
                    //                            tempo2 = tempo2.Replace(tempo2[num], W[3]);
                    //                            tempo2 = tempo2.Replace(tempo2[tempo2.Length - 1], W[3]);
                    tempo2 = tempo2.Replace('4', W[3]);
                    tempo2 = tempo2.Replace('3', W[2]);
                    tempo2 = tempo2.Replace('2', W[1]);
                    tempo2 = tempo2.Replace('1', W[0]);
                    AStem.Add(tempo2);
                }
            }

            else if (W.Length >= 3)
            {
                for (int i = 0; i < 38; i++)
                {
                    string tempo = R3[i].ToString();
                    tempo = tempo.Replace('3', W[2]);
                    tempo = tempo.Replace('2', W[1]);
                    tempo = tempo.Replace('1', W[0]);
                    AStem.Add(tempo);
                }
            }
            return AStem;

        }
    }
}
