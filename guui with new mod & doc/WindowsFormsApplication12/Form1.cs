using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// returns whether the first string is smaller in value than the second or not 
        /// </summary>
        /// <param name="str1">the first string that carries the first number value in string format</param>
        /// <param name="str2">the second string that carries the second number value in string format</param>
        /// <returns>boolean denoting  str1 is smaller than str2 or not</returns>
        ///O(N) = N
        public static bool firstIsSameller(string str1, string str2)
        {
            int n1 = str1.Length, n2 = str2.Length;                         //1+1(assignment)
            if (n1 < n2)                                                    //1 (condition)
                return true;                                                //1 (return value)
            if (n2 < n1)                                                    //1
                return false;                                               //1
            for (int i = 0; i < n1; i++)                        //1 (initialize) + n1+1 (condition) + n1 (increment)=>  O(N)
            {
                if (str1[i] < str2[i])                                      //1 
                    return true;                                            //1
                else if (str2[i] < str1[i])                                 //1 + (2 * 1) (indexing)
                    return false;                                           //1
            }
            return false;                                                   //1
        }


        /// <summary>
        /// calculates the addition of integer value of str1 and str2
        /// </summary>
        /// <param name="str1">the first string that carries the first number value in string format</param>
        /// <param name="str2">the second string that carries the second number value in string format</param>
        /// <returns>Addition result</returns>
        /// n1 is str1 length , n2 is str2 length
        /// O(N) = N
        public static string Add(string str1, string str2)
        {
            if (str1.Length > str2.Length)                                  //1(condition) 
            {
                string t = str1;                                            //O(N)
                str1 = str2;                                                //O(N)
                str2 = t;                                                   //O(N)
            }

            int n1 = str1.Length, n2 = str2.Length;                         //O(1)

            char[] ch = str1.ToCharArray();                                 //n1 + n1  O(N)
            Array.Reverse(ch);                                              //n1       O(N)
            str1 = new string(ch);                                          //n1(copying array to string) + n1   O(N)
            char[] ch1 = str2.ToCharArray();                                //n + n                              O(N)
            Array.Reverse(ch1);                                             //n1                                 O(N)
            str2 = new string(ch1);                                         //n + n                              O(N)

            int carry = 0;                                                  //1                                  O(1)
            //result string
                                                            
            StringBuilder sb = new StringBuilder();                               //O(1)
            for (int i = 0; i < n1; i++)                                          //O(N)
            {
                int sum = (str1[i] - '0') + (str2[i] - '0') + carry;                     //O(1)
                sb.Append((char)(sum % 10 + '0'));                                       //O(1)
                carry = sum / 10;                                                        //O(1)
            }



            for (int i = n1; i < n2; i++)                                          //O(N)
            {
                int sum = (str2[i] - '0') + carry;                                 //O(1)
                sb.Append((char)(sum % 10 + '0'));                                 //O(1)
                carry = sum / 10;                                                  //O(1)
            }

            if (carry > 0)                                                         //1
                sb.Append((char)(carry + '0'));                                    //1
            char[] ch2 = new char[sb.Length];
            sb.CopyTo(0, ch2, 0, sb.Length);                                       //O(N)
            Array.Reverse(ch2);                                                    //n2          O(N)
            return string.Join("", ch2);                                           //n2          O(N)

        }

        /// <summary>
        /// calaculates the subtraction of integer value of str1 and str2
        /// </summary>
        /// <param name="str1">the first string that carries the first number value in string format</param>
        /// <param name="str2">the second string that carries the second number value in string format</param>
        /// <returns>Subtraction result</returns>
        /// n1 is str1 length , n2 is str2 length
        /// O(N) = N
        public static string Subtract(string num1, string num2) 
        {
            // StringBuilder ch = new StringBuilder();
            int remainder;                                                 //O(1)
            string ch;                                                     //O(1)

            int borrow = 0;                                                //1    //O(1)
            int diff;                                                      //O(1)

            int res;                                                       //O(1)

            bool b = false;                                                //O(1)  
            string string_of_difflenof_two_strings;                        //O(1)
            int min_len;                                                   //O(1)
            int max_len;                                                   //O(1)
                 
            string result;                                                 //O(1)

            if (firstIsSameller(num1, num2))                               //O(N)  
            {
                string temp = num1;                                        //O(N)
                num1 = num2;                                               //O(N)
                num2 = temp;                                               //O(N)
            }

            if (num1.Length <= num2.Length)                                //O(1)
            {
                min_len = num1.Length;                                     //O(1)
                max_len = num2.Length;                                     //O(1)
                ch = ("s2rem");                                            //O(1)

            }
            else
            {
                min_len = num2.Length;                                     //O(1)
                max_len = num1.Length;                                     //O(1)
                ch = ("s1rem");                                            //O(1)
            }

            remainder = (max_len) - min_len;                               //O(1)
            char[] numa1 = new char[remainder];                            //O(1)
            int[] arr3 = new int[max_len];                                 //O(1)


            for (int i = 0; i < remainder; i++)                            //O(N)
            {
                numa1[i] = '0';                                            //O(1)
            }

            if (ch == "s1rem")                                             //1
            {
                string_of_difflenof_two_strings = string.Join("", numa1);  //O(N)
                string_of_difflenof_two_strings = string_of_difflenof_two_strings + num2;      //O(N)  
                num2 = string_of_difflenof_two_strings;                                        //O(N)
            }

            else
            {
                string_of_difflenof_two_strings = string.Join("", numa1);    //1 + remainder (join fn order)  O(N)
                string_of_difflenof_two_strings = string_of_difflenof_two_strings + num1;     //O(N)
                num1 = string_of_difflenof_two_strings;                         //O(N)
            }

            int l1 = num1.Length - 1;                                        //O(1)
            int l2 = num2.Length - 1;                                        //O(1)


            for (int i = max_len - 1; i >= 0; i--)                           //O(N)    
            {
                diff = (num1[l1] - '0') - borrow - (num2[l2] - '0');         //O(1)

                if (diff < 0)                                                //O(1) 
                {
                    b = true;                                                //O(1)
                    res = (num1[l1] - '0') - borrow + 10;                    //O(1)
                    arr3[i] = res - (num2[l2] - '0');                        //O(1)
                    borrow = 1;                                              //O(1)
                }
                else
                {
                    b = false;                                               //O(1)
                    arr3[i] = diff;                                          //O(1)
                    borrow = 0;                                              //O(1)
                }
                l1--;                                                        //O(1)
                l2--;                                                        //O(1)
            }
            result = string.Join("", arr3);                                  //O(N)

            RemoveZeroes(ref result);                                        //O(N)
            return result;                                                   //O(1)
        }
        
        /// <summary>
        /// Multiplies num1 by num2 by using Karatsuba multiplication algorithm
        /// </summary>
        /// <param name="X">first number</param>
        /// <param name="Y">second number</param>
        /// <returns>multiplication result</returns>
        /// recurrence => T(N) = 3 T(N/2) + n + c ,O(1) = n
        /// Θ(N) = N^1.58
        public static string Multiply(string X, string Y)
        {
            int n = Equalize(ref X, ref Y);                                  //O(N)

            if (n < 10)                                                      //O(1)
            {
                long xLong = long.Parse(X);                                  //n(less than 10) + 1    O(1)
                long yLong = long.Parse(Y);                                  //n + 1    O(1)
                return (xLong * yLong).ToString();                           //2 + n    O(1)
            }

            int firstHalf = n / 2;                                          //O(1)
           
            int secHalf = (n - firstHalf);                                  //O(1)

            string a = X.Substring(0, firstHalf);                           //O(N/2)
            string b = X.Substring(firstHalf, secHalf);                     //O(N/2)

            string c = Y.Substring(0, firstHalf);                           //O(N/2)
            string d = Y.Substring(firstHalf, secHalf);                     //O(N/2)

            string ac = Multiply(a, c);                                     //O(N) string copying
            string bd = Multiply(b, d);                                     //O(N) string copying
            string addMul = Multiply(Add(a, b), Add(c, d));                 //n+n+n => O(N) string copying and add fn

            int pow1 = (2 * (n - n / 2));                                   //O(1)
            int pow2 = (n - (n / 2));                                       //O(1)
            string z = Subtract(addMul, Add(ac, bd));                       //n+n+n =>O(N) 
            
            string mulResult = Add(Add(ShiftLeft(ac, pow1), bd), ShiftLeft(z, pow2));  //O(N)
            
            RemoveZeroes(ref mulResult);                                     //O(N)
            return mulResult;                                                //O(1)
        }


        /// <summary>
        /// Shifts the input string with n zeroes
        /// </summary>
        /// <param name="str">Integer value to be shifted to left in string format</param>
        /// <param name="n">number of times to shift the number to left</param>
        /// <returns>the same number shifted to left</returns>
        /// O(N) = N 
        public static string ShiftLeft(string str, int n)
        {
            StringBuilder sb = new StringBuilder(str);                       //O(str.Length) =>O(N) 
            for (int i = 0; i < n; i++)                                      //O(N)
                sb.Append('0');                                              //O(1)
            return sb.ToString();                                            //O(sb.length) => O(N)
        }


        /// <summary>
        /// Equalizes the length of string1 and string2 by adding zeroes on the right side so both have same length 
        /// </summary>
        /// <param name="str1">the first number in string format</param>
        /// <param name="str2">the second number in string format</param>
        /// <returns>the length of both strings after equalization</returns>
        /// O(N) = N
        public static int Equalize(ref string str1, ref string str2)
        {
            StringBuilder sb1 = new StringBuilder();                          
            StringBuilder sb2 = new StringBuilder();
            int len1 = str1.Length;                                            //O(1)
            int len2 = str2.Length;                                            //O(1)

            if (len1 < len2)                                                   //O(1)
            { 
                for (int i = 0; i < len2 - len1; i++)                          //O(N)
                    sb1.Append(0);                                             //O(1)

                sb1.Append(str1);                                              //O(1)
                str1 = sb1.ToString();                                         //O(N)

                return len2;                                                   //O(1)
            }

            else if (len1 > len2)                                              //O(1)
            {
                for (int i = 0; i < len1 - len2; i++)                          //O(N)
                    sb2.Append(0);                                             //O(1)

                sb2.Append(str2);                                              //O(1)
                str2 = sb2.ToString();                                         //O(N)
            }
            return len1;                                                       //O(1)
        }


        /// <summary>
        /// Removes zeroes from the left side of input string
        /// </summary>
        /// <param name="x">Integer number in string format</param>
        /// O(N) = N
        public static void RemoveZeroes(ref string x)
        {
            bool allZero = true;                                             //O(1)
            int zeroCount = 0;                                               //O(1)
           
            for (int i = 0; i < x.Length; i++)                               //O(N)
            {
                if (x[i] == '0')                                             //O(1)
                    zeroCount++;                                             //O(1)
                else
                {
                    allZero = false;                                         //O(1)
                    break;                                                   //O(1)
                }
            }
            string tmp = "";                                                 //O(1)
            if (zeroCount > 0)                                               //O(1)
            {
                if (!allZero)                                                //O(1)
                    tmp = x.Remove(0, zeroCount);                            //O(N)

                else
                    tmp = "0";                                               //O(1)
                x = tmp;                                                     //O(1)
            }
        }


        /// <summary>
        /// stack stores divide fn result ,quotient pushed first then remainder
        /// </summary>
        static Stack<string> ResultDiv = new Stack<string>();
        static string q = "";                                                //O(1)
        static string r = "";                                                //O(1)
        /// <summary>
        /// Calculates the division of a over b 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>stack with division results but only top two string are final remainder then quotient</returns>
        public static Stack<string> divid(string a, string b)
        {
            if (firstIsSameller(a, b))                                       //O(N)  
            {
                q = "0";                                                     //O(1)
                r = a;                                                       //O(N)

                ResultDiv.Push(q);                                           //O(1)
                ResultDiv.Push(r);                                           //O(1)

                return ResultDiv;                                            //O(1)
            }
            else
            {
                ResultDiv = (divid(a, Add(b, b)));                           /***********/
                q = Add(q, q);                                               //O(N)

                if (firstIsSameller(r, b))                                   //O(N)
                {
                    ResultDiv.Push(q);                                       //O(1)
                    ResultDiv.Push(r);                                       //O(1)

                    return ResultDiv;                                        //O(1)
                }
                else
                {
                    q = (Add(q, "1"));                                       //O(N)

                    r = (Subtract(r, b));                                    //O(N)

                    ResultDiv.Push(q);                                       //O(1)
                    ResultDiv.Push(r);                                       //O(1)
                    return ResultDiv;                                        //O(1)
                }
            }
        }


        /// <summary>
        /// calculates the mod of powered number 
        /// </summary>
        /// <param name="msg">message to be encrypted or decrypted</param>
        /// <param name="pow">the exponent</param>
        /// <param name="mod">n</param>
        /// <returns>the mod of power in string format</returns>
        static string modpower(string msg, string pow, string mod)
        {
            string remPow;                                                 //1
            Stack<string> powBy2;                                          //1
            string cMsg = "1";                                             //1
             
            while (pow != "0")                                             //1(condition)
            {
                powBy2 = divid(pow, "2");                                  //1 + n 
                remPow = powBy2.Pop();                                     //n
                pow = powBy2.Pop();                                        //n
                if (remPow == "1")                                         //1
                {
                    cMsg = Multiply(cMsg, msg);                            //n^1.58
                    cMsg = divid(cMsg, mod).Pop();                         //1 + n + 1
                }


                msg = Multiply(msg, msg);                                   //n^1.58
                msg = divid(msg, mod).Pop();                                //n
            }

            return cMsg;                                                    //1
        }


        /// <summary>
        /// Encrypts the msg using public key 
        /// </summary>
        /// <param name="msg">the message to be encrypted</param>
        /// <param name="key">public key</param>
        /// <param name="n">the modulous of the public key</param>
        /// <returns>encrypted string</returns>
        /// O(N^1.58 log p =>digits number of key
       public static string incrypt(string msg, string key, string n)
        {
            return modpower(msg, key, n);
        }


        /// <summary>
        /// Decrypts the msg using private key 
        /// </summary>
        /// <param name="msg">the message to be decrypted</param>
        /// <param name="key">private key</param>
        /// <param name="n">the modulous of the private key</param>
        /// <returns>decrypted string</returns>
        /// O(N^1.58 log p) =>digits number of key
       public static string decrypt(string msg, string key, string n)
        {
            return modpower(msg, key, n);      
        }


        /// <summary>
        /// Enctypts plain Text
        /// </summary>
        /// <param name="plainText">msg to be encrypted</param>
        /// <param name="key">public key</param>
        /// <param name="n">modulous</param>
        /// <returns>Encrypted text</returns>
       public static string PlainTextEnc(string plainText, string key, string n)
       {
           byte[] strBytes = ASCIIEncoding.UTF8.GetBytes(plainText);             
           if (strBytes.Length >= n.Length)                                      
           {
               MessageBox.Show("Msg can't be larger than N");
               return "";            
           }

           return incrypt(string.Join("", strBytes), key, n);                    
        
       }

       public static string PlainTextDec(string encPlainText, string key, string n)
       {
           string decRes = decrypt(encPlainText, key, n);
           byte[] decResBytes = new byte[decRes.Length / 3];

           for (int i = 0; i < decRes.Length / 3; i++)
               decResBytes[i] = byte.Parse(decRes.Substring(i * 3, 3));

           return ASCIIEncoding.UTF8.GetString(decResBytes);
       }





       public static string phi = "";
       public static string n = "";
       public static string e = "";
       public static string enc_mess = "";

       public static string gcd(string a, string h)
       {
           string temp;
           while (true)
           {
               var div = divid(a, h);

               temp = div.Pop();
               if (temp == "0")
                   return h;
               a = h;
               h = temp;
           }
       }

       public static void eve()
       {


           var l = GetAllPrimes("1000");
           e = l[_random.Next(l.Count)];

           var l2 = pandq();
           phi = l2[l2.Count - 2];
           n = l2[l2.Count - 1];

           while (firstIsSameller(e, phi))
           {


               if (gcd(e, phi) == "1")
               {
                   break;

               }

               else
                   e = Add(e, "1");
           }

       }

       public static List<string> _primes;
       public static Random _random = new Random();

       public static bool IsPrime(string n)
       {
     
           string i = "3";

           while (firstIsSameller(i, n) || i.Equals(n))
           {
               var div = divid(i,n);
               string rem = div.Pop();
               if (rem == "0")
               {
                   return false;
               }
               i = Add(i, "2");
           }
           return true;
       }

       public static List<string> GetAllPrimes(string n)
       {
           var result = new List<string> { "2" };
       
           string i = "3";
           while (firstIsSameller(i, n)||i.Equals(n))
           {
               if (IsPrime(i))
               {
                   result.Add(i.ToString());
               }
               i = Add(i, "2");
           }
           return result;
       }


       public static List<string> pandq()
       {
           List<string> l = new List<string>();
           _primes = GetAllPrimes("1000");
           string p = _primes[_random.Next(_primes.Count)];
           string q = _primes[_random.Next(_primes.Count)];
           string np = Subtract(q, "1");
           string nq = Subtract(p, "1");
           phi = Multiply(np, nq);
           l.Add(phi);
           n = Multiply(p, q);
           l.Add(n);

           return l;

       }
       public static string Enc(string message)
       {
           eve();
           enc_mess = modpower(message, e, n);
           return enc_mess;
       }

        public static string Dec()
        {
            string c = enc_mess;
            var div = divid("1", e);
            div.Pop();
            string rev = div.Pop();
            string message = modpower(c, rev, n);
            return message;
        }

   
        

        private void button2_Click(object sender, EventArgs e)
        {
            msg_rich.Text = decrypt(cipher_rich.Text,textBox1.Text,textBox4.Text);
            //if (checkBox1.Checked)
            //    textBox4.Text = PlainTextDec(textBox1.Text, textBox2.Text, textBox3.Text);
            //else
            //    textBox4.Text = decrypt(textBox1.Text, textBox2.Text, textBox3.Text);

            ////textBox4.Text = dec();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cipher_rich.Text = incrypt(msg_rich.Text,textBox1.Text,textBox4.Text);
            //if (checkBox1.Checked)
            //    textBox4.Text = PlainTextEnc(textBox1.Text, textBox2.Text, textBox3.Text);
            //else
            //    textBox4.Text = incrypt(textBox1.Text, textBox2.Text, textBox3.Text);
            //textBox4.Text = Enc(textBox1.Text);
        }

        public static void writeOutFile(string testChoice, string outFileName, string resultString, long exTime)
        {
            FileStream fso = new FileStream(outFileName, FileMode.Append);
            StreamWriter sw = new StreamWriter(fso);
            if (testChoice == "1")
            {
                sw.WriteLine(resultString);
                //sw.WriteLine(exTime);
            }
            else if (testChoice == "2")
            {
                sw.WriteLine(resultString);
                sw.WriteLine(exTime);
                sw.WriteLine(exTime/1000);
            }

            sw.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string choice = "1";
            string inputFileName = "", outFileName = "";
            inputFileName = "SampleRSA.txt";
            outFileName = "SampleRSAOutput.txt";
            FileStream fs = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(fs);

            string num = "", key = "", msg = "", enc = "";
            int cases = int.Parse(SR.ReadLine());
            string resultString = "";
            int exTime = 0;


            for (int i = 0; i < cases; i++)
            {
                string tmpStr = SR.ReadLine();
                if (!string.IsNullOrEmpty(tmpStr))
                    num = tmpStr;

                tmpStr = SR.ReadLine();
                if (!string.IsNullOrEmpty(tmpStr))
                    key = tmpStr;

                tmpStr = SR.ReadLine();
                if (!string.IsNullOrEmpty(tmpStr))
                    msg = tmpStr;

                tmpStr = SR.ReadLine();
                if (!string.IsNullOrEmpty(tmpStr))
                    enc = tmpStr;

                int timeBefore = 0, timeAfter = 0;
                if (enc == "0")
                {
                    timeBefore = System.Environment.TickCount;
                    resultString = incrypt(msg, key, num);
                    timeAfter = System.Environment.TickCount;

                }

                else if (enc == "1")
                {
                    timeBefore = System.Environment.TickCount;
                    resultString = decrypt(msg, key, num);
                    timeAfter = System.Environment.TickCount;
                }
                exTime = timeAfter - timeBefore;
                writeOutFile(choice, outFileName, resultString, exTime);
            }

            SR.Close();
            fs.Close();
            MessageBox.Show("Sample Cases Success");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string choice = "2";
            string inputFileName = "", outFileName = "";
            inputFileName = "TestRSA.txt";
            outFileName = "TestRSAOutput.txt";
            FileStream fs = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(fs);

            string num = "", key = "", msg = "", enc = "";
            int cases = int.Parse(SR.ReadLine());
            string resultString = "";
            int exTime = 0;


            for (int i = 0; i < cases; i++)
            {
                string tmpStr = SR.ReadLine();
                if (!string.IsNullOrEmpty(tmpStr))
                    num = tmpStr;

                tmpStr = SR.ReadLine();
                if (!string.IsNullOrEmpty(tmpStr))
                    key = tmpStr;

                tmpStr = SR.ReadLine();
                if (!string.IsNullOrEmpty(tmpStr))
                    msg = tmpStr;

                tmpStr = SR.ReadLine();
                if (!string.IsNullOrEmpty(tmpStr))
                    enc = tmpStr;

                int timeBefore = 0, timeAfter = 0;
                if (enc == "0")
                {
                    timeBefore = System.Environment.TickCount;
                    resultString = incrypt(msg, key, num);
                    timeAfter = System.Environment.TickCount;

                }

                else if (enc == "1")
                {
                    timeBefore = System.Environment.TickCount;
                    resultString = decrypt(msg, key, num);
                    timeAfter = System.Environment.TickCount;
                }
                exTime = timeAfter - timeBefore;
                writeOutFile(choice, outFileName, resultString, exTime);
            }
            SR.Close();
            fs.Close();

            MessageBox.Show("Complete Cases Success");
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
