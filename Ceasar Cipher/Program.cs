using System;
using System.Collections;

namespace ceasarCipher
{
    /**
     * This is a simple script for encrypting or decrypting
     * messages with a known key (aka Ceasar Cipher).
     * 
     * @author Nicholas Hess
     * @version 2023.05.02
     */
    class Program
    {
        /** This is the string used to build the encrypted or
         * decrypted message */
        private static String message = "";
        
        /** This is the key */
        private static int key = 0;

        /** An array of characters for the alphabet */
        private static Char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g',
        'h', 'i','j','k','l','m','n','o','p','q','r','s','t','u','v',
        'w','x','y','z'};

        /** An array of characters for the uppercase alphabet */
        private static Char[] uppercaseAlphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 
            'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 
            'U', 'V', 'W', 'X', 'Y', 'Z' };

        /** An array of special characters */
        private static Char[] specialChars = { '!', '@', '#', '$', '%', '^', '&', 
            '*', '(', ')', '-', '+', '=', '.', '?'};
        
        /**
         * The main class where the program is run
         */
        static void Main(string[] args)
        {
            dialogue();
        }

        /**
         * Main method that reads the message input and key input
         * and will print out the corresponding encrypted/decrypted
         * message
         */
        static void readInput()
        {
            // First prompt
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("|  Would you like to encrypt or decrypt a message?  |");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Enter 'e' for encrypt or 'd' for decrypt or " +
                "'i' for instructions");
            Console.WriteLine("");
            String choice = Console.ReadLine();

            // Begin encryption
            if (choice == "e")
            {
                Console.WriteLine("-----------------------------------" +
                    "-----------------");
                Console.WriteLine("Enter the message you would like " +
                    "to encrypt:");
                Console.WriteLine("----------------------------------" +
                    "------------------");

                message += Console.ReadLine();

                Console.WriteLine("---------------------------------" +
                    "-------------------");
                Console.WriteLine("Enter the key you would like " +
                    "to use:");
                Console.WriteLine("---------------------------------" +
                    "-------------------");

                String keyString = Console.ReadLine();

                key = Convert.ToInt32(keyString);

                // Use the encrypt method to encrypt the message with the key
                message = encryptInput(message, key);

                // Display the encrypted message
                Console.WriteLine("---------------------------------" +
                    "-------------------");
                Console.WriteLine("Here is your encrypted message: " + message);
                Console.WriteLine("The key is: " + key);
                Console.WriteLine("---------------------------------" +
                    "-------------------");


            }
            // Begin decryption
            else if (choice == "d")
            {
                Console.WriteLine("-----------------------------------" +
                    "-----------------");
                Console.WriteLine("Enter the message you would like " +
                    "to decrypt:");
                Console.WriteLine("----------------------------------" +
                    "------------------");

                message += Console.ReadLine();

                Console.WriteLine("---------------------------------" +
                    "-------------------");
                Console.WriteLine("Enter the key you would like " +
                    "to use:");
                Console.WriteLine("---------------------------------" +
                    "-------------------");

                String keyString = Console.ReadLine();

                key = Convert.ToInt32(keyString);

                // Use the decrypt method to encrypt the message with the key
                message = decryptInput(message, key);

                // Display the decrypted message
                Console.WriteLine("---------------------------------" +
                    "------------------");
                Console.WriteLine("Here is your decrypted message: " + message);
                Console.WriteLine("The key is: " + key);
                Console.WriteLine("---------------------------------" +
                    "------------------");
            }
            // Display instructions
            if (choice == "i")
            {
                writeInstructions();
            }
        }

        /**
         * This method will take a message string and a int key
         * and will move 'key' many places forward through the alphabet
         * for each character in the message to replace it with
         * the letter 'key' amount ahead of its current letter.
         * 
         * Ex: (abc def, 1) -> [bcd efg]
         * 
         * @param input
         *             the message that will be encrypted
         * @param thisKey
         *             the number of letters the current letters
         *             will be moved by
         */
        static String encryptInput(String input, int thisKey)
        {
            String encrypt = "";

            input.ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                // This keeps spaces
                if (input[i] == ' ')
                {
                    encrypt += ' ';
                }
                // This keeps special characters
                if (specialChars.Contains(input[i]))
                {
                    encrypt += input[i];
                }
                // This checks case of current letter
                if (char.IsUpper(input[i]))
                {
                    // If uppercase, use uppcaseAlphabet
                    for (int j = 0; j < uppercaseAlphabet.Length; j++)
                    {

                        if (input[i] == uppercaseAlphabet[j] && thisKey + j < uppercaseAlphabet.Length)
                        {
                            encrypt += uppercaseAlphabet[j + thisKey];
                        }
                        else if (input[i] == uppercaseAlphabet[j] && thisKey + j >= uppercaseAlphabet.Length)
                        {
                            int startIndex = Array.IndexOf(alphabet, input[i]);
                            encrypt += uppercaseAlphabet[(startIndex + thisKey) % uppercaseAlphabet.Length];


                        }
                    }
                }
                // If lowercase, use alphabet
                else
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {

                        if (input[i] == alphabet[j] && thisKey + j < alphabet.Length)
                        {
                            encrypt += alphabet[j + thisKey];
                        }
                        else if (input[i] == alphabet[j] && thisKey + j >= alphabet.Length)
                        {
                            int startIndex = Array.IndexOf(alphabet, input[i]);
                            encrypt += alphabet[(startIndex + thisKey) % alphabet.Length];


                        }
                    }
                }
                

            }
            return encrypt;

        }

        /**
         * This method will take a message string and a int key
         * and will move 'key' many places backward through the alphabet
         * for each character in the message to replace it with
         * the letter 'key' amount behind its current letter.
         * 
         * Ex: (bcd efg, 1) -> [abc def]
         * 
         * @param input
         *             the message that will be encrypted
         * @param thisKey
         *             the number of letters the current letters
         *             will be moved by
         */
        static String decryptInput(String input, int thisKey) {
            String decrypt = "";

            input.ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                // This will keep spaces
                if (input[i] == ' ')
                {
                    decrypt += ' ';
                }
                // This will keep special characters
                if (specialChars.Contains(input[i]))
                {
                    decrypt += input[i];
                }
                // This will check for capital letters
                if (char.IsUpper(input[i]))
                {
                    // If uppercase, use uppercaseAlphabet
                    for (int j = 0; j < uppercaseAlphabet.Length; j++)
                    {

                        if (input[i] == uppercaseAlphabet[j])
                        {
                            int startIndex = Array.IndexOf(uppercaseAlphabet, input[i]);
                            decrypt += uppercaseAlphabet[(startIndex + uppercaseAlphabet.Length - thisKey) % uppercaseAlphabet.Length];
                        }
                    }
                }
                // If lowercase, use alphabet
                else
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {

                        if (input[i] == alphabet[j])
                        {
                            int startIndex = Array.IndexOf(alphabet, input[i]);
                            decrypt += alphabet[(startIndex + alphabet.Length - thisKey) % alphabet.Length];
                        }
                    }
                }
                

            }
            return decrypt;
        }

        /**
         * Opening dialogue, then calls the rest of the methods
         */
        static void dialogue()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("|    Welcome   |");
            Console.WriteLine("----------------");
            Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine("Have you used this program before?");
            Console.WriteLine("Y/N: ");

            String answer = Console.ReadLine();

            if (answer == "y")
            {
                readInput();
            }
            else if (answer == "n")
            {
                writeInstructions();
            }
            
        }

        /**
         * Displays directions for how to use the program, then
         * calls read input method
         */
        static void writeInstructions()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("|    Instructions   |");
            Console.WriteLine("--------------------");
            Console.WriteLine("");
            Console.WriteLine("Use this to either encrypt or " +
                "decrypt messages using a key.");
            Console.WriteLine("");
            Thread.Sleep(5000);

            Console.WriteLine("");
            Console.WriteLine("Well, that is all the " +
                "instructions you get...");
            Console.WriteLine("");
            Thread.Sleep(2000);

            Console.WriteLine("");
            Console.WriteLine("I'm fairly easy to use :)");
            Console.WriteLine("");
            Thread.Sleep(2000);

            Console.WriteLine("");
            Console.WriteLine("Have fun!");
            Console.WriteLine("");
            Thread.Sleep(1000);

            Console.WriteLine("");
            Console.WriteLine("When you are ready to continue enter 'c'...");
            Console.WriteLine("");
            String answer = Console.ReadLine();
            if (answer == "c")
            {
                readInput();
            }
            
        }
    }
}



