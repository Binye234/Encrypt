using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace EncryptFile
{
    static public class EncryptFile
    {
        //密钥
        private static byte[] _KEY = Encoding.UTF8.GetBytes( "12345678");
        private static byte[] _IV= Encoding.UTF8.GetBytes("sdfg4563");
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="oldPath">明文文件路径</param>
        /// <param name="newPath">密文文件路径</param>
        static public void EnEncryptFile(string oldPath, string newPath)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = _KEY;
            des.IV = _IV;
            using (FileStream readFs = new FileStream(oldPath, FileMode.Open, FileAccess.Read))
            using (FileStream writeFs = new FileStream(newPath, FileMode.Create, FileAccess.Write))
            {
                using (CryptoStream cs = new CryptoStream(writeFs, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] buff = new byte[1024];
                    int count = readFs.Read(buff, 0, buff.Length);
                    while (count != 0)
                    {    
                        cs.Write(buff, 0, count);
                        count = readFs.Read(buff, 0, buff.Length);
                    }
                }
            }
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="newPath">密文路径</param>
        /// <param name="oldPath">明文路径</param>
        static public void DeEncryptFile(string newPath,string oldPath)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = _KEY;
            des.IV = _IV;
            using (FileStream readFs = new FileStream(newPath, FileMode.Open, FileAccess.Read))
            using (FileStream writeFs = new FileStream(oldPath, FileMode.Create, FileAccess.Write))
            {
                using (CryptoStream cs = new CryptoStream(readFs, des.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] buff = new byte[1024];
                    int count = cs.Read(buff, 0, buff.Length);
                    while (count != 0)
                    {
                        writeFs.Write(buff, 0, count);
                        count = cs.Read(buff, 0, buff.Length);
                    }
                }
            }
        }
    }
}
