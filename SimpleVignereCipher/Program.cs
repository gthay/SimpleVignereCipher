using System;
using System.Linq;

namespace SimpleVignereCipher
{
    class Program
    {
        


        static void Main(string[] args)
        {
            
            string text;
            string password;
            string menu;
            
            //Textinput
            Console.WriteLine("Give me some letters:\n");
            text = Console.ReadLine();
            Console.WriteLine("\nGive me some Password:\n");
            password = Console.ReadLine();

            //Validation
            if (password.All(Char.IsLetter))
            {
                Console.WriteLine("Do you want:\n1. Encrypt\n2.Decrypt?: ");
                menu = Console.ReadLine();

                if (menu == "1")
                {
                    Console.WriteLine("\n Crypted Text: " + Encrypt(text, password));
                }
                else if (menu == "2")
                {
                    Console.WriteLine("\n Encrypted Text: " + Decrypt(text, password));
                }
            
              
            }
            else
            {
                Console.WriteLine("\nPlease just use Letters for your password");
            }                     
        }

        public static string Encrypt(string clearText, string password)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string alphabetLower = "abcdefghijklmnopqrstuvwxyz";
            string cryptedText = "";
            int i = 0;

            clearText = clearText.ToUpper();

            foreach (var char_ in clearText)
            {
                if (alphabet.Contains(char_))
                {
                    int passwordLoc;

                    int clearLoc = alphabet.IndexOf(char_);
                    

                    if (alphabet.Contains(password.Substring(i % password.Length, 1)))
                        passwordLoc = alphabet.IndexOf(password.Substring(i % password.Length, 1));
                    else
                        passwordLoc = alphabetLower.IndexOf(password.Substring(i % password.Length, 1));
                    
                    int compinedLoc = (clearLoc + passwordLoc) % alphabet.Length;
                    cryptedText += alphabet.Substring(compinedLoc, 1);

                    i++;
                }
                else
                {
                    cryptedText += char_;
                }
                
            }


            return cryptedText;
        }

        public static string Decrypt(string cryptedText, string password)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string clearText = "";
            int i = 0;


            foreach (var char_ in cryptedText)
            {
                if (alphabet.Contains(char_))
                {
                    int passwordLoc;

                    int clearLoc = alphabet.IndexOf(char_);


                    if (alphabet.Contains(password.Substring(i % password.Length, 1)))
                        passwordLoc = alphabet.IndexOf(password.Substring(i % password.Length, 1));
                    else
                        passwordLoc = alphabet.ToLower().IndexOf(password.Substring(i % password.Length, 1));

                    int compinedLoc = (clearLoc - passwordLoc) % alphabet.Length;
                    clearText += alphabet.Substring(compinedLoc, 1);

                    i++;
                }
                else
                {
                    clearText += char_;
                }

            }


            return clearText;
        }

    }
}
