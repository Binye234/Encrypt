using System;
using System.Collections.Generic;
using System.Text;
using EncryptFile;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\hlder\Desktop\河北区总工会.dat";
            var flag = EncryptFile.EncryptFile.IsExcel(path);
            Console.WriteLine(flag);
            Console.ReadKey();
        }
    }
}
