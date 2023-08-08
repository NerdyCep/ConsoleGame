using System;

namespace ConsoleGame
{
    
    class Program
    {
        static void Main()
        {
            Grafics grafics = new Grafics(80,50, 2f);
            Circle circle = new Circle(new Vector2(0, 0), 1.0f, new char[] { '-', ':', 'a', '@' });
            grafics.Begin();
            grafics.Draw(circle);
            grafics.End();
            Console.ReadKey();
           
        }
    }










} 