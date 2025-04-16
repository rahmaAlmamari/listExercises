namespace listExercises
{
    internal class Program
    {
        static List<int> numbers = new List<int>();
        static List<int> numbersWithoutFrequent = new List<int>();
        static List<int> Frequent = new List<int>();
        static void Main(string[] args)
        {
            /*
             * 1. Top N Frequent Numbers
               Given a List<int> of numbers, find the top N most frequent numbers
             */
            int num;
            Console.WriteLine("Enter list of int numbers (at less 5 number):");
            char choice;
            do
            {
                Console.WriteLine($"Enter the {numbers.Count+1} number:");
                num = int.Parse(Console.ReadLine());
                numbers.Add(num);

                Console.WriteLine("Do you want to add anther" +
                                              " number? y / n");
                choice = Console.ReadKey().KeyChar;
                Console.ReadLine();//just to hold second ...
            } while (choice == 'y' || choice == 'Y');
            //to show your list elements ...
            Console.WriteLine("numbers list elements:");
            for(int i = 0; i<numbers.Count; i++)
            {
                Console.WriteLine($"Number {i+1}: {numbers[i]}");
            }
            //to get Top N Frequent Numbers call ...
            for(int i = 0; i < numbers.Count; i++)
            {
                TopNFrequentNumbers(numbers[i]);
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
    }
}
