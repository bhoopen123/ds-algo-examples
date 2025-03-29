using System;

namespace _001_ModularArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 2147483647;
            int num2 = 2;

            Console.WriteLine(num1 + num2);
            Console.WriteLine((num1 + num2) % 5); // output = -2

            // Why the modulo of (2147483647 + 2) is -2
            // because the maximum value an integer can store is 2147483647, if we add any number in it
            // it goes back to the minimum value i.e. -2147483648 and then adds the value in it.
            // for example, (2147483647 + 1) = -2147483648 (aka Overflow condition).
            // so, (2147483647 + 2) % 5 = -2147483647 % 5 = -2 

            // Solving such problems using Modular Arithmetic
            // (a + b) % c = (a % c + b % c) % c
            // (a - b) % c = (a % c - b % c) % c
            // (a * b) % c = ((a % c) * (b % c)) % c

            // the above formula is not true for division
            // Modulo of two numbers after division is also known as 'Inverse Modulo'.


            // mod of negative numbers
            Console.WriteLine($"Mod of (-8)%5 = {(-8) % 5}");   // -3

            Console.WriteLine("Hello World!");
        }
    }
}

