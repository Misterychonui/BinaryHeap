using System;

namespace BinaryHeap
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double[] weights = new double[n];
            Random r = new Random();
            for(int i=0; i<n; i++)
                weights[i] = r.NextDouble();
            Binaryheap<double> heap = new Binaryheap<double>();
            double containers = CalculateContainers(heap,weights);
            Console.WriteLine("Размер кучи: {0}",containers);
            Console.WriteLine("&&&&&&&&&&&&");
            Console.WriteLine("Начальные значения");
            foreach(var t in weights)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("&&&&&&&&&&&&");
            Console.WriteLine("Куча");
            for(int i=0;i<heap.Count();i++)
            {
                Console.WriteLine(heap.FindNextElement(i));
            }
        }

        private static double CalculateContainers(Binaryheap<double> heap,double[] weights)
        {        
            int containers = 0;
            double x = 1;
            for (int i=0;i<weights.Length;i++)
            {
                x = 1;
                if (weights[i] == 1)
                {
                    containers++;
                }
                else
                {
                    if (heap.Count() == 0)
                    {
                        heap.Insert(weights[i]);
                    }
                    else
                    {
                        if(x > heap.FindMax()+weights[i])
                        {
                            x = heap.FindMax() + weights[i];
                            heap.DeleteElement();
                            heap.Insert(x);
                        }
                        else 
                        {
                            heap.Insert(weights[i]);
                        } 
                    }
                }
            }
            int g = heap.Count();
            return containers + g;
        }
    }
}
