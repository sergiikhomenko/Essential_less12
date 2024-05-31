namespace matrix2;
/*
 * Використовуючи Visual Studio, створіть проект за шаблоном Console Application.
 * Розширте завдання 2 так, щоб в одному стовпці одночасно могло бути два ланцюжки
 * символів. Дивіться example2.png, представлений як зразок.
 */
class Program
{
    public static void RandomChar(int colum, int height)
    {
        Random random = new Random();
        while (true)
        {
            int chainLength = random.Next(3, height);
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
                    Thread.Sleep(250);
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
        Random rd = new Random();
        (width, height) = (Console.WindowWidth, Console.WindowHeight);
        for (int i = 0; i < width; i++)
        {
            int column = i;
            int ther = rd.Next(0, 2);
            for (int j = 0; j < ther; j++)
            {
                Thread thread = new Thread(() => RandomChar(column, height));
                thread.Start();
                
            }Thread.Sleep(50);
        }
     
    }
}