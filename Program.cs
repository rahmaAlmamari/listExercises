namespace listExercises
{
    internal class Program
    {
        static List<int> numbers = new List<int>();
        static List<int> numbersWithoutFrequent = new List<int>();
        static List<int> Frequent = new List<int>();

        static List<string> words = new List<string>();
        static List<string> letters = new List<string>();
        static List<string> lettersReverse = new List<string>();
        static List<bool> Palindrome = new List<bool>();
        static void Main(string[] args)
        {
            ///*
            // * 1. Top N Frequent Numbers
            //   Given a List<int> of numbers, find the top N most frequent numbers
            // */
            //int num;
            //Console.WriteLine("Enter list of int numbers (at less 5 number):");
            //char choice;
            //do
            //{
            //    Console.WriteLine($"Enter the {numbers.Count+1} number:");
            //    num = int.Parse(Console.ReadLine());
            //    numbers.Add(num);

            //    Console.WriteLine("Do you want to add anther" +
            //                                  " number? y / n");
            //    choice = Console.ReadKey().KeyChar;
            //    Console.ReadLine();//just to hold second ...
            //} while (choice == 'y' || choice == 'Y');
            ////to show your list elements ...
            //Console.WriteLine("numbers list elements:");
            //for(int i = 0; i<numbers.Count; i++)
            //{
            //    Console.WriteLine($"Number {i+1}: {numbers[i]}");
            //}
            ////to get Top N Frequent Numbers call ...
            //for(int i = 0; i < numbers.Count; i++)
            //{
            //    TopNFrequentNumbers(numbers[i]);
            //}

            //-------------------------------------------------------------------------------

            /*
             * 2. Palindrome Filter
               Given a list of strings, filter out all non-palindrome strings using 
               a function and return a new List<string> containing only palindromes.
             */
            //to insert string in your words list ...
            Console.WriteLine("Enter list of string (at less 5 number):");
            char choice1;
            do
            {
                Console.WriteLine($"Enter the {words.Count + 1} string:");
                words.Add(Console.ReadLine());

                Console.WriteLine("Do you want to add anther" +
                                              " string? y / n");
                choice1 = Console.ReadKey().KeyChar;
                Console.ReadLine();//just to hold second ...
            } while (choice1 == 'y' || choice1 == 'Y');
            //to show your words list elements ...
            Console.WriteLine("words list elements:");
            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine($"String {i + 1}: {words[i]}");
            }
            //to get Palindrome Filter ...
            for(int i = 0; i < words.Count; i++)
            {
                PalindromeFilter(words[i]);
            }
            //to print only palindromes string ...
            Console.WriteLine("The palindromes string:");
            for(int i = 0; i < words.Count; i++)
            {
                if (Palindrome[i])
                {
                    Console.WriteLine(words[i]);
                }
            }


        }

        //1. Top N Frequent Numbers ...
        public static void TopNFrequentNumbers(int num)
        {
            //to store elements in numbers list in numbersWithoutFrequent list without Frequent ...
            int count = 0;
            if(numbersWithoutFrequent.Count == 0)
            {
                numbersWithoutFrequent.Add(num);
            }
            else
            {
                for(int i = 0; i < numbersWithoutFrequent.Count; i++)
                {
                    if(num == numbersWithoutFrequent[i])
                    {
                        count++;
                    }
                }
                if(count == 0)
                {
                    numbersWithoutFrequent.Add(num);
                }
            }
            ////just to show numbersWithoutFrequent elements ...
            //Console.WriteLine("numbersWithoutFrequent list elements:");
            //for (int i = 0; i < numbersWithoutFrequent.Count; i++)
            //{
            //    Console.WriteLine($"Number {i + 1}: {numbersWithoutFrequent[i]}");
            //}
            //to get the Frequent time for each elements ...
            int countFrequent;
            for(int i = 0; i < numbersWithoutFrequent.Count; i++)
            {
                countFrequent = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbersWithoutFrequent[i] == numbers[j])
                    {
                        countFrequent++;
                    }
                }
                //store how many time numbersWithoutFrequent[i] appear in numbers list in Frequent list ...
                Frequent.Add(countFrequent);
            }
            //to sorte the Frequent list ...
            int temp;
            int elementTemp;
            int r = 0;
            for (int i = 0; i < Frequent.Count-r; i++)
            {
                for (int j = 0; j < Frequent.Count - 1; j++)
                {
                    if (Frequent[j] < Frequent[j + 1])
                    {
                        temp = Frequent[j];
                        elementTemp = numbersWithoutFrequent[j];
                
                        Frequent[j] = Frequent[j + 1];
                        numbersWithoutFrequent[j] = numbersWithoutFrequent[j + 1];
                
                        Frequent[j + 1] = temp;
                        numbersWithoutFrequent[j + 1] = elementTemp;
                    }

                }
                r++;
            }
            //to print top n frequent ...
            //int n;
            //Console.WriteLine("Enter N frequent you want to display:");
            //n = int.Parse(Console.ReadLine());
            Console.WriteLine("Element | Frequent");
            //for (int i = 0; i < n; i++)
            //{
                Console.WriteLine($"{numbersWithoutFrequent[0]} | {Frequent[0]}");
            //}


        }
        //2. Palindrome Filter ...
        public static void PalindromeFilter(string word)
        {
            //to clear the list and work in the new string we have ...
            letters.Clear();
            lettersReverse.Clear();
            //to store each letter in the word as element in letters list ...
            letters = word.Select(c => c.ToString()).ToList();
            //to store the reverse of letters list in lettersReverse ...
            for (int i = letters.Count - 1; i >= 0; i--)
            {
                lettersReverse.Add(letters[i]);
            }
            //to check if the letters and lettersReverse are same or not
            int count = 0;
            for(int i = 0; i < letters.Count; i++)
            {
                if (letters[i] == lettersReverse[i])
                {
                    count++;
                }
            }
            if(count == letters.Count)
            {
                Palindrome.Add(true);
            }
            else
            {
                Palindrome.Add(false);
            }
        }
    }
}
