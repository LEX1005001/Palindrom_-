using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppL
{
    internal class Program
    {   
        class Palindrom
        {
            int number;
            int numberDigitsNum;
            

            public int Number { get => number; set => number = value; }
            public int NumberDigitsNum { get => numberDigitsNum; set => numberDigitsNum = value; }

            public Palindrom(int number,int numberDigitsNum)
            {
                this.number = number;
                this.numberDigitsNum = numberDigitsNum;
            }
        }

        private static bool isPalindrome(int Num)
        {
            string number = Convert.ToString(Math.Abs(Num));

            if (number.Length == 0) 
            {
                return false;

            }

            for(int i =0;i<number.Length;i++)
            {
                if (number[i] != number[number.Length-i-1]) 
                {
                    return false;

                }

                if (i > number.Length - 1)
                {
                    return true;
                }
            }
            return true;

        }

        private static int PalendromoDigitsMult(int Num)
        {
            int mult = 1;
            string number = Convert.ToString(Math.Abs(Num));

            for(int i=0;i<number.Length;i++)
            {
                if(i> number.Length -i - 1)
                {
                    break;
                }
                if (number[i] != '0')
                {
                    // Если ошибка то + convert to string
                    mult *= int.Parse(Convert.ToString(number[i]*number[i]));
                }
            }

            return mult;
        }

        private static Dictionary<int, int> GroupByValues(List<int>numbers)
        {
            Dictionary<int,int> keyValuePairs= new Dictionary<int,int>();
            foreach(int number in numbers)
            {
                if (!keyValuePairs.ContainsKey(number))
                {
                    keyValuePairs.Add(number, 1);
                }
                else continue;


                foreach(int num in numbers)
                {
                    if (number == num)
                    {
                        keyValuePairs[number]++;
                    }
                }
            }
            return keyValuePairs;
        }

        static void Main()
        {
            List<Palindrom> palendroms = new List<Palindrom>();
            List<int> multOfPalendroms = new List<int>();
            for(int i=100;i<1000000000;i++)
            {
                if (isPalindrome(i))
                {
                    palendroms.Add(new Palindrom(i,PalendromoDigitsMult(i)));
                    multOfPalendroms.Add((PalendromoDigitsMult(i)));
                }

                PalendromoDigitsMult(i);


            }
            
        }
    }
}
