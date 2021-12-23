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

    // Complete the encryption function below.
    static string encryption(string s) {
        string[] arr = s.Split(' ');
        string msg = String.Join("", arr);
        string res = string.Empty;
        double msgLen = Math.Sqrt(msg.Length);
        int column = (int)Math.Ceiling(msgLen);
        int row = msgLen - Math.Floor(msgLen) > 0.5 ? (int)Math.Ceiling(msgLen) : (int)Math.Floor(msgLen);
        int index = 0;
        int runIndex = 1;
        int count = msg.Length;
        int c = count;
        int lastCol = count % row == 0 ? row : count % row;


        while (count > 0)
        {
            while (index < msg.Length && lastCol >= 0)
            {
                res += msg[index];
                index += column;
                count--;
            }
            if (lastCol > 0)
            {
                res += " ";
            }
            if (lastCol <= 0)
            {
                while (index < msg.Length - (c % row))
                {
                    res += msg[index];
                    index += column;
                    count--;
                }
                res += " ";
            }
            index = runIndex++;
            lastCol--;
        }
        return res;
}

    

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

