﻿using GameLauncher.App.Classes.LauncherCore.Support;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GameLauncher.App.Classes.Hash
{
    class SHATwoFiveSix
    {
        public static string Hashes(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return String.Empty;

            HashAlgorithm algorithm = SHA256.Create();
            StringBuilder sb = new StringBuilder();
            foreach (byte b in algorithm.ComputeHash(Encoding.UTF8.GetBytes(input)))
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

        public static string Files(string filename)
        {
            if (!File.Exists(Strings.Encode(filename))) return String.Empty;

            SHA256 sha256 = new SHA256CryptoServiceProvider();

            byte[] retVal = new byte[] { };

            using (var test = File.OpenRead(Strings.Encode(filename)))
            {
                retVal = sha256.ComputeHash(test);
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }

            return sb.ToString().ToUpper();
        }
    }
}
