using System;

namespace DiamondGame
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int width, height;

            (width, height) = GetFieldBounds();

            string[,] field = CreateField(width, height);

            ConsoleKeyInfo key;

            int allDmCount = CountDiamonds(field);
            bool gameover = false;

            do
            {
                DrawField(field);

                Console.WriteLine("Press arrows or ESC = exit.");

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
                {
                    MoveOurGuy(field, "left");
                }
                else if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
                {
                    MoveOurGuy(field, "right");
                }
                else if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
                {
                    MoveOurGuy(field, "up");
                }
                else if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
                {
                    MoveOurGuy(field, "down");
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    gameover = true;
                }

                if (allDmCount == allDmCount - CountDiamonds(field))
                {
                    gameover = true;
                }

                Console.Clear();
            } while (!gameover);

            Console.WriteLine($"Collected Diamonds: {(allDmCount - CountDiamonds(field)) / (double)allDmCount * 100.0:f2}%");
            Console.WriteLine("Game Over!");
        }

        static (int width, int height) GetFieldBounds()
        {
            Console.Write("Width: ");
            int width = int.Parse(Console.ReadLine());
            Console.Write("Height: ");
            int height = int.Parse(Console.ReadLine());

            return (Math.Max(10, width), Math.Max(10, height));
        }

        static string[,] CreateField(int width, int height)
        {
            string[,] field = new string[width, height];

            Random random = new Random();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double randomNumber = random.NextDouble();
                    if (randomNumber < 0.1)
                    {
                        field[i, j] = "Diamond";
                    }
                    else if (randomNumber < 0.4)
                    {
                        field[i, j] = "Ground";
                    }
                    else if (randomNumber < 0.7)
                    {
                        field[i, j] = "Grass";
                    }
                    else if (randomNumber < 0.9)
                    {
                        field[i, j] = "Tree";
                    }
                    else
                    {
                        field[i, j] = "Stone";
                    }
                }
            }

            int randomX = random.Next(width);
            int randomY = random.Next(height);

            field[randomX, randomY] = "OurGuy";

            return field;
        }

        static void DrawField(string[,] field)
        {
            int width = field.GetLength(0);
            int height = field.GetLength(1);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    string cell = field[i, j];
                    Console.ForegroundColor = GetCellColor(cell);

                    if (cell == "Ground")
                    {
                        Console.Write("\u2592");
                    }
                    else if (cell == "Grass")
                    {
                        Console.Write("\u2593");
                    }
                    else if (cell == "Tree")
                    {
                        Console.Write("\u2663");
                    }
                    else if (cell == "Stone")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("\u0665");
                    }
                    else if (cell == "Diamond")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("\u2666");
                    }
                    else if (cell == "OurGuy")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\u263A");
                    }
                }
                Console.WriteLine();
            }

            Console.ResetColor();
        }

        static ConsoleColor GetCellColor(string cell)
        {
            if (cell == "Ground")
            {
                return ConsoleColor.DarkYellow;
            }
            else if (cell == "Grass")
            {
                return ConsoleColor.Green;
            }
            else if (cell == "Tree")
            {
                return ConsoleColor.DarkGreen;
            }
            else if (cell == "Stone")
            {
                return ConsoleColor.DarkGray;
            }
            else if (cell == "Diamond")
            {
                return ConsoleColor.Blue;
            }
            else if (cell == "OurGuy")
            {
                return ConsoleColor.Yellow;
            }

            return ConsoleColor.White;
        }

        static void MoveOurGuy(string[,] field, string direction)
        {
            int width = field.GetLength(0);
            int height = field.GetLength(1);

            int ourGuyX = -1;
            int ourGuyY = -1;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (field[i, j] == "OurGuy")
                    {
                        ourGuyX = i;
                        ourGuyY = j;
                        break;
                    }
                }
                if (ourGuyX != -1)
                {
                    break;
                }
            }

            if (ourGuyX == -1)
            {
                return;
            }

            int newOurGuyX = ourGuyX;
            int newOurGuyY = ourGuyY;

            if (direction == "left" && ourGuyX > 0)
            {
                newOurGuyX--;
            }
            else if (direction == "right" && ourGuyX < width - 1)
            {
                newOurGuyX++;
            }
            else if (direction == "up" && ourGuyY > 0)
            {
                newOurGuyY--;
            }
            else if (direction == "down" && ourGuyY < height - 1)
            {
                newOurGuyY++;
            }

            if (field[newOurGuyX, newOurGuyY] != "Tree")
            {
                field[ourGuyX, ourGuyY] = "Grass";
                field[newOurGuyX, newOurGuyY] = "OurGuy";
            }
        }

        static int CountDiamonds(string[,] field)
        {
            int count = 0;
            int width = field.GetLength(0);
            int height = field.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (field[i, j] == "Diamond")
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}