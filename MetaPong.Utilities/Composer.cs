﻿namespace MetaPong.Utilities
{
    public class Composer
    {
        //╔
        private const char CornerTopL = (char)9556;
        //╚ 
        private const char CornerBottomL = (char)9562;
        //║
        private const char LineVertical = (char)9553;
        //╗
        private const char CornerTopR = (char)9559;
        //╝
        private const char CornerBottomR = (char)9565;
        //═ 
        private const char LineHorizontal = (char)9552;
        //╠ 
        private const char CornerMiddleL = (char)9568;
        //╣
        private const char CornerMiddleR = (char)9571;
        //╦
        private const char CornerMiddleTop = (char)9574;
        //╩
        private const char CornerMiddleBottom = (char)9577;

        public static string[] Compose(char[][] matrix)
        {
            string[] layout = new string[matrix.Length];

            for (int row = 0; row < layout.Length; row++)
            {
                layout[row] = string.Join("", matrix[row]);
            }

            return layout;
        }

        public static char[][] MakeBoxLayout(int width, int height)
        {
            char[][] matrix = new char[height][];

            if (height == 1)
            {
                AddHorizontalLine(matrix, height, 1, width);
                return matrix;
            }
            else if (width == 1)
            {
                AddVerticalLine(matrix,1,1,height);
                return matrix;
            }

            for (int y = 0; y < height; y++)
            {
                char[] line = new char[width];
                for (int x = 0; x < width; x++)
                {
                    char current;
                    if (x == 0)
                    {
                        if (y == 0)
                        {
                            current = CornerTopL;
                        }
                        else if (y == height - 1)
                        {
                            current = CornerBottomL;
                        }
                        else
                        {
                            current = LineVertical;
                        }
                    }
                    else if (x == width - 1)
                    {
                        if (y == 0)
                        {
                            current = CornerTopR;
                        }
                        else if (y == height - 1)
                        {
                            current = CornerBottomR;
                        }
                        else
                        {
                            current = LineVertical;
                        }
                    }
                    else
                    {
                        if (y == 0 || y == height - 1)
                        {
                            current = LineHorizontal;
                        }
                        else
                        {
                            current = ' ';
                        }
                    }
                    line[x] = current;
                }
                matrix[y] = line;
            }

            return matrix;
        }

        public static void AddHorizontalLine(char[][] matrix, int row, int begin, int end)
        {
            for (int col = begin; col <= end; col++)
            {
                if (col == begin)
                {
                    matrix[row][col] = CornerMiddleL;
                }
                else if (col == end)
                {
                    matrix[row][col] = CornerMiddleR;
                }
                else
                {
                    matrix[row][col] = LineHorizontal;
                }
            }
        }

        public static void AddVerticalLine(char[][] matrix, int column, int top, int bottom)
        {
            for (int row = top; row <= bottom; row++)
            {
                if (row == top)
                {
                    matrix[row][column] = CornerMiddleTop;
                }
                else if (row == bottom)
                {
                    matrix[row][column] = CornerMiddleBottom;
                }
                else
                {
                    matrix[row][column] = LineVertical;
                }
            }
        }
    }
}
