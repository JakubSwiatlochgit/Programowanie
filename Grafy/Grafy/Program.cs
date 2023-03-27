
namespace Grafy
{
    public class Program
    {
        public static int[,] CreateRandomMatrix(int n, double p)
        {
            // tworzymy macierz
            int[,] matrix = new int[n, n];

            // zerujemy macierz
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            // ustawiamy zerowe wartosci na przekatnej
            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = 0;
            }

            // wypelniamy macierz randomowymi jedynek
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (rand.NextDouble() <= p)
                    {
                        matrix[i, j] = 1;
                        matrix[j, i] = matrix[i, j];
                    }
                }
            }
            Console.WriteLine("n = " + n + ", p = " + p);

            
            // zwracamy macierz
            return matrix;
        }
        public static void Main(string[] args)
        {
            int[,] matrix = CreateRandomMatrix(10, 0.25);
            int[] degArray = new int[matrix.GetLength(0)];

            int sum = 0;
            int sumDeg = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("[" + matrix[i, j] + "]");
                    if (matrix[i, j] == 1)
                    {
                        sum++;
                        sumDeg++;
                    }
                }
                Console.Write("\tdeg: ");
                Console.WriteLine(sum);
                degArray[i] = sumDeg;
                sumDeg = 0;
                sum = 0;
            }


            Array.Sort(degArray);
            Array.Reverse(degArray);
            Console.Write("degSum: ");
            foreach (int num in degArray)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

    }
}