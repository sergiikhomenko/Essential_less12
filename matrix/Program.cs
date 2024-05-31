namespace matrix;

/*
 * Використовуючи Visual Studio, створіть проект за шаблоном Console Application.
 * Створіть програму, яка виводитиме на екран ланцюжки падаючих символів.
 * Довжина кожного ланцюжка визначається випадково.
 * Перший символ ланцюжка – білий, другий символ – світло-зелений,
 * решта символів темно-зелені. Під час падіння ланцюжка на кожному
 * кроці всі символи змінюють своє значення. Дійшовши до кінця,
 * ланцюжок зникає і зверху формується новий ланцюжок.
 */
class Program
{
    
    public static void RandomChar(int colum, int height)
    {
        Random random = new Random();
        while (true)
        {
            int chainLength = random.Next(3, height / 2);
            for (int i = 0; i < colum + chainLength; i++)
            {
                if (i < height)
                {
                    Console.SetCursorPosition(colum, i);
                    char randomSimvol = (char)random.Next(0, 200);
                    switch (i)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            break;
                    }

                    Console.WriteLine(randomSimvol);
                }

                if (i -  height>= chainLength)
                {
                    Console.SetCursorPosition(colum, i - chainLength);
                    Console.Write(' ');
                }
                Thread.Sleep(40);
            }
        }
    }
    
    static void Main(string[] args)
    {
       Console.BackgroundColor = ConsoleColor.Black;//томущо на макі біла консоль
        Console.CursorVisible = true;
        int width, height;
        (width, height) = (Console.WindowWidth, Console.WindowHeight);
        Random rd = new Random();
        for (int i = 0; i < width; i++)
        {
            int column = rd.Next(0, width);
            Thread thread = new Thread(() => RandomChar(column, height));
            thread.Start();
            Thread.Sleep(100); 
        }
     
    }
}