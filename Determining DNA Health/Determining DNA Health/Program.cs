using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Solution
{
    public static void Main(string[] args)
    {
        int n = 6;

        //Tạo ra list để lưu các genes tương ứng với giá trị a b c aa d b
        List<string> genes = new List<string>() { "a", "b", "c", "aa", "d", "b" };

        //Tạo ra list để lưu các health tương ứng với giá trị 1 2 3 4 5 6
        List<int> health = new List<int>() { 1, 2, 3, 4, 5, 6 };
        int s = 3;

        // Tạo ra tập dictionary để lưu các giá trị health tương ứng với từng genes lần lượt theo thứ tự
        Dictionary<int, Dictionary<string, int>> geneHealth = new Dictionary<int, Dictionary<string, int>>();
        // Duyệt qua từng phần tử trong genes để lưu giá trị health tương ứng với từng genes và thêm thứ tự vào key cho geneHealth
        for (int i = 0; i < genes.Count; i++)
        {
            geneHealth.Add(i, new Dictionary<string, int>
            {
                { genes[i], health[i] }
            });

        }


        // Tạo một list để lưu các giá trị health
        List<int> values = new List<int>();
        int min = 0;
        int max = 0;
        List<string[]> firstMultipleInput = new List<string[]>() { new string[] { "1", "5", "caaab" }, 
                                                                   new string[] { "0", "4", "xyz" }, 
                                                                   new string[] { "2", "4", "bcdybc" } };

        for (int sItr = 0; sItr < s; sItr++)
        {
            int first = Convert.ToInt32(firstMultipleInput[sItr][0]);

            int last = Convert.ToInt32(firstMultipleInput[sItr][1]);

            string d = firstMultipleInput[sItr][2];

            values.Clear(); // Clear the list for each iteration

            // Duyệt qua từng phần tử trong geneHealth theo key (gọi là key cha) trong khoảng từ first đến last
            // và kiểm tra nếu d có chứa key (gọi là key con) trong value (gọi là value cha) của phần tử thì thêm value con
            // vào list values
            for (int i = first; i <= last; i++)
            {
                foreach (var item in geneHealth[i])
                {
                    if (d.Contains(item.Key))
                    {
                        int count = 1;
                        int duplicate = 0;
                        for (int j = 0; j <= d.Length - item.Key.Length; j++)
                        {
                            if (d.Substring(j, item.Key.Length) == item.Key)
                            {
                                duplicate++;
                            }
                        }
                        values.Add(item.Value * (duplicate == 0 ? count : duplicate));
                    }
                }
            }
            //Kiểm tra tổng list values mà lớn hơn max
            // thì lưu vào max ngược lại thì lưu vào min 
            if (values.Sum() > max)
            {
                max = values.Sum();
            }
            if (values.Sum() < min) 
            {
                min = values.Sum();
            }
                     
        }
        // In ra giá trị min và max ngăn cách nhau bởi khoảng trắng
        Console.WriteLine(min + " " + max);
    }
}
