namespace task4;
/*
 * Використовуючи Visual Studio, створіть проект за шаблоном Console Application.
 * Напишіть програму, в якій метод викликатиметься рекурсивно.
 * Кожен новий виклик методу виконується окремому потоці.
 */
class Program
{
    public static void MyMetod(int col)
    {
        Thread thread = new Thread(()=>MyMetod(col));
        if (col>0)
        {
            Console.WriteLine($"Потік {thread.GetHashCode()}");
            col--;
            thread.Start();
        }
    }

    static void Main(string[] args)
    {
           MyMetod(5); 
    }
}