using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Common
{
    public static class StringHelper
    {
        private static char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static string GenerateRandomNumber(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(10);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(10)]);
            }
            return newRandom.ToString();
        }

        public static List<string> GetChildCollections(string strTemp)
        {
            List<string> lstTemp = strTemp.Split(',').ToList();
            var subsets = from m in Enumerable.Range(0, 1 << lstTemp.Count)
                          select (from i in Enumerable.Range(0, lstTemp.Count)
                                  where (m & (1 << i)) != 0
                                  select lstTemp[i]).ToArray();
            return subsets.Select(x => string.Join(",", x)).ToList();
        }

        public static string[] BianLi(List<string[]> al)
        {
            if (al.Count == 0)
                return null;
            int size = 1;
            for (int i = 0; i < al.Count; i++)
            {
                size = size * al[i].Length;
            }
            string[] str = new string[size];
            for (int j = 0; j < size; j++)
            {
                for (int m = 0; m < al.Count; m++)
                {
                    str[j] = str[j] + al[m][(j * jisuan(al, m) / size) % al[m].Length] + " ";
                }
                str[j] = str[j].Trim(' ');
            }
            return str;
        }

        private static int jisuan(List<string[]> al, int m)
        {
            int result = 1;
            for (int i = 0; i < al.Count; i++)
            {
                if (i <= m)
                {
                    result = result * al[i].Length;
                }
                else
                {
                    break;
                }
            }
            return result;
        }
    }
}
