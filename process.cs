using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stego_extract
{
    class process
    {
        public process()
        {

        }

        public static Int32 change(int r)
        {
            string s, c = "0";
            int result;
            s = process.conbinary(r);

            for (int i = 5; i < 8; i++)
            {
                s = s.Remove(i, 1).Insert(i, c);
            }
            result = process.convdecimal(s);
            return (result);

        }
        public static string conbinary(int r)
        {
            string result = Convert.ToString(r, 2).PadLeft(8, '0');
            return (result);
        }
        public static Int32 conascii(string s)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(s);

            int result = BitConverter.ToInt32(bytes, 0);
            return result;
        }
        public static string rotation(string r)
        {
            string result, c;
            c = r.Substring(0, 4);
            result = r.Substring(4, 4);
            result = result.Insert(4, c);
            return (result);
        }
        public static void set(string s, string[] r, int d)
        {
            string c;
            for (int i = 0; i < 8; i++)
            {
                c = s.Substring(i, 1);
                r[d] = c;
                d++;

            }
        }
        public static Int32 convdecimal(string bin)
        {
            Int32 pp;
            pp = Convert.ToInt32(bin, 2);
            return (pp);

        }

        public static string stegon(string ss, Int32 d, string[] stego, Int32 c)
        {
            int m = 8 - d;
            string v;
            int t = stego.Length;

            for (int i = m; i < 8; i++)
            {
                if (c < t)
                {
                    v = stego[c];
                    c++;
                    ss = ss.Remove(i, 1).Insert(i, v);
                }
            }

            return (ss);
        }
        public static int get(string[] s, int d)
        {
            string zz = "";
            int m;
            int l = 0;
            for (int i = d; i < d + 8; i++)
            {
                zz = zz.Insert(l, s[i]);
                l++;
            }
            m = process.convdecimal(zz);
            return (m);
        }


        public static int[] DecimalToASCII(string dec)
        {
            // create an array of strings
            string[] ascii;

            // split each group into the array
            ascii = Strings.Split(dec, ",");

            // declare numbers array that is the same size as the ascii array
            int[] numbers = new int[ascii.GetUpperBound(0) + 1];

            // convert the array of strings to an array of numbers
            for (int i = 0; i <= ascii.GetUpperBound(0) - 1; i++)
                numbers[i] = System.Convert.ToInt32(ascii[i]);

            // return an array of numbers containing each group
            return numbers;
        }



        public static string decode(string binary)
        {
            if (binary == null)
            {
                return null;
            }
            else
            {
                try
                {
                    string[] arrStrings = binary.Trim('.').Split('.');
                    string ascii = "";
                    foreach (string s in arrStrings)
                    {
                        ascii += Convert.ToChar(Convert.ToInt32(s, 2));
                    }
                    return ascii;
                }
                catch (FormatException)
                {
                    throw new FormatException("SECURITY ALERT! You cannot access a page by entering its URL.");
                }
            }
        }
    }
}


