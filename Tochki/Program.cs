using System;

class Program
{
    static void Main(string[] args)
    {
        MnogPoints A = new MnogPoints();

        foreach (Point element in A.points)
        {
            Console.Write($"точка № {element.coord.num}: ");
            Console.Write($"x={element.coord.x} ");
            Console.Write($"y={element.coord.y} \n\n");
        }

        Point P = new Point();
        Console.WriteLine($"введите абсциссу (х)");
        P.coord.x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"введите ординату (у)");
        P.coord.y = Convert.ToInt32(Console.ReadLine());

        //точка наиболее приближенная к Р
        double range = 0; ;
        int tochka = 0;
        near_point(P, tochka, A, range);

        //точка наиболее удаленная от Р
        far_point(P, tochka, A, range);

        same_line(A, tochka);
    }

    public static void near_point(Point P, int tochka, MnogPoints A, double range)
    {
        double ab;
        range = double.MaxValue;
        int x1 = P.coord.x, y1 = P.coord.y, x2, y2, a, b, c;
        foreach (Point element in A.points)
        {
            x2 = element.coord.x;
            y2 = element.coord.y;

            a = (x2 - x1) * (x2 - x1);
            b = (y2 - y1) * (y2 - y1);
            c = a + b;
            ab = Math.Sqrt(c);

            if (range > ab)
            {
                range = ab;
                tochka = element.coord.num;
            }
        }
        Console.WriteLine($"наиболее приближенная точка это {tochka}-ая");

    }
    public static void far_point(Point P, int tochka, MnogPoints A, double range)
    {
        double ab;
        int x1 = P.coord.x, y1 = P.coord.y, x2, y2, a, b, c;
        range = double.MinValue;
        foreach (Point element in A.points)
        {
            x2 = element.coord.x;
            y2 = element.coord.y;

            a = (x2 - x1) * (x2 - x1);
            b = (y2 - y1) * (y2 - y1);
            c = a + b;
            ab = Math.Sqrt(c);

            if (range < ab)
            {
                range = ab;
                tochka = element.coord.num;
            }
        }
        Console.WriteLine($"наиболее удаленная точка это {tochka}-ая");
    }
    public static void same_line(MnogPoints A, int tochka) //точки из множества которые лежат на одной прямой с заданной прямой
    {

        // A x +B y + C = 0
        Double I, J, K;
        Console.WriteLine($"введите I");
        I = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"введите J");
        J = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"введите K");
        K = Convert.ToDouble(Console.ReadLine());


        foreach (Point element in A.points)
        {
            if (I * element.coord.x + J * element.coord.y + K == 0)
            {
                tochka = element.coord.num;
                Console.WriteLine($"точка {tochka}-ая лежит на заданной линии");
            }
        }
    }
}

public struct Point
{
    public (int num, int x, int y) coord;
}

class MnogPoints
{
    public Point[] points = new Point[5];



    public MnogPoints()
    {
        var rnd = new Random();
        for (int i = 0; i < 5; i++)
        {
            points[i].coord.num = i;
            points[i].coord.x = rnd.Next(-40, 40);
            points[i].coord.y = rnd.Next(-40, 40);
        }
    }
}
