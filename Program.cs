﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CryptFile
{
    class Program
    {
        static void ASCII_label()
        {
            // http://patorjk.com/software/taag/#p=display&f=Standard&t=CryptFile%0A%0Aby%20%0A%0ACode%2021
            Console.WriteLine("");
            Console.WriteLine("   ____                  _   _____ _ _      ");
            Console.WriteLine("  / ___|_ __ _   _ _ __ | |_|  ___(_) | ___ ");
            Console.WriteLine(" | |   | '__| | | | '_ \\| __| |_  | | |/ _ \\");
            Console.WriteLine(" | |___| |  | |_| | |_) | |_|  _| | | |  __/");
            Console.WriteLine("  \\____|_|   \\__, | .__/ \\__|_|   |_|_|\\___|");
            Console.WriteLine(" | |__  _   _|___/|_|                       ");
            Console.WriteLine(" | '_ \\| | | |                              ");
            Console.WriteLine(" | |_) | |_| |                              ");
            Console.WriteLine(" |_.__/ \\__, |                              ");
            Console.WriteLine("   ____ |___/    _        ____  _           ");
            Console.WriteLine("  / ___|___   __| | ___  |___ \\/ |          ");
            Console.WriteLine(" | |   / _ \\ / _` |/ _ \\   __) | |          ");
            Console.WriteLine(" | |__| (_) | (_| |  __/  / __/| |          ");
            Console.WriteLine("  \\____\\___/ \\__,_|\\___| |_____|_|          ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        
        
        static void help()
        {
            ASCII_label();
            Console.WriteLine("Program je urceny pro sifrovani a desifrovani souboru.");
            Console.WriteLine("Soubor, ktery chceme zasifrovat nesmi mit koncovku *.aes. Ta je urcena jen pro zasifrovane soubory. Diky tomu se software sam rozhodne, chcete-li sifrovat nebo desifrovat.");
            Console.WriteLine("");
            Console.WriteLine("Heslo si dobre zapamatujte. Pri jeho zapomenutí se jiz k puvodnim datum nedostanete.");
            Console.WriteLine("");
            Console.WriteLine("Spusteni programu:");
            Console.WriteLine("");
            Console.WriteLine("CryptFile [*.*]");
            Console.WriteLine("");
            Console.WriteLine("Vysledkem je soubor *.aes.");
            
            Console.WriteLine("");
            Console.ReadKey();
            return;
        }
        
        static void Main(string[] args)
        {
            
            string soubor = "";
            //string pripona = "";

            if (args.Length >= 1)
            {
                if ((args[0].ToString() == "help") || (args[0].ToString() == "HELP"))
                {
                    help();
                    return;
                }
            }

            ASCII_label();
            

            if (args.Length > 0) soubor = args[0].ToString();
            else
            {
                Console.WriteLine("File: ");
                soubor = Console.ReadLine();
                Console.WriteLine("");
            }

            if (!File.Exists(soubor))
            {
                Console.WriteLine("Soubor neexistuje !!!");
                Console.ReadKey();
                return;
            }
                

                // desifrovani
                if (soubor.IndexOf(".aes") != -1)
                {
                    Console.WriteLine("Decpryt file: " + soubor);
                    Console.WriteLine("");
                    Console.WriteLine("password: ");
                    string password = Console.ReadLine();
                    string souborVystup = soubor.Substring(0, soubor.Length - 4);                    
                    AES aes = new AES();
                    aes.DecryptFile(soubor, souborVystup, password);
                }
                // sifrovani
                else
                {
                    Console.WriteLine("Encpryt file: " + soubor);
                    Console.WriteLine("");
                    Console.WriteLine("password: ");
                    string password = Console.ReadLine();
                    string souborVystup = soubor + ".aes";                    
                    AES aes = new AES();
                    aes.EncryptFile(soubor, souborVystup, password);
                }
            
        }
    }
}
