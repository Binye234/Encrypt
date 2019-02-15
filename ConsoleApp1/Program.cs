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
            string oldPath = @"E:\test\test.txt";
            string newPath = @"E:\test\test1.enc";
           // EncryptFile.EncryptFile.EnEncryptFile(oldPath, newPath);

            EncryptFile.EncryptFile.DeEncryptFile(newPath, @"E:\test\test12.txt");
            Console.ReadKey();
        }
    }
}
