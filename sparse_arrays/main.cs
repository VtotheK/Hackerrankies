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

class Solution {

    // Complete the matchingStrings function below.
    static int[] matchingStrings(string[] strings, string[] queries) {
        int[]res = new int[queries.Length];
        Stack matches = new Stack();
        for(int i = 0; i<queries.Length; i++)
        {
            for(int j = 0; j<strings.Length; j++)
            {
                if(strings[j][0] == queries[i][0] && strings[j].Length == queries[i].Length)
                {
                    if(strings[j].Length > 1)
                    {
                        for(int d = 0; d<=strings[j].Length; d++)
                        {
                            if(d==strings[j].Length)
                            {
                                res[i]++;
                                break;
                            }
                            if(strings[j][d] != queries[i][d])
                            {
                                break;
                            }

                        }
                    }
                    else
                    {
                        res[i]++;        
                    }
                }
            }
        }
        return res;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int stringsCount = Convert.ToInt32(Console.ReadLine());

        string[] strings = new string [stringsCount];

        for (int i = 0; i < stringsCount; i++) {
            string stringsItem = Console.ReadLine();
            strings[i] = stringsItem;
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine());

        string[] queries = new string [queriesCount];

        for (int i = 0; i < queriesCount; i++) {
            string queriesItem = Console.ReadLine();
            queries[i] = queriesItem;
        }

        int[] res = matchingStrings(strings, queries);

        textWriter.WriteLine(string.Join("\n", res));

        textWriter.Flush();
        textWriter.Close();
    }
}

