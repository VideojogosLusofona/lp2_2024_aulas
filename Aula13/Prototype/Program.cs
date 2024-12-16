using System;

namespace Prototype
{
    public class Program
    {
        private static void Main()
        {
            Level original;
            Level shallow;
            Level deep;

            original = new Level('A', new int[] {10, 20, 30 ,40});
            shallow = original.ShallowCopy();
            shallow.Category = 'C';
            deep = original.DeepCopy();

            original.IncScores();

            Console.WriteLine($"Original:\n\t{original}");
            Console.WriteLine($"Shallow:\n\t{shallow}");
            Console.WriteLine($"Deep:\n\t{deep}");
        }
    }
}
