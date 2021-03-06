﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ConsoleUtils
    {
        #region seperator
        /// <summary>
        /// Print a line to console, made up of the character x. If the line's width is less than the console's width, it will have no left padding.
        /// </summary>
        /// <param name="x">The character which the seperator is made out of</param>
        /// <param name="width">Usually the console's width</param>
        public static void PrintSeperator(char x, int width)
        {
            for (int i = 0; i < width; i++)
            {
                Console.Write(x);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Print a line to console, made up of the character x. The line will span across the console's width.
        /// </summary>
        /// <param name="x">The character which the seperator is made out of</param>
        public static void PrintSeperator(char x)
        {
            PrintSeperator(x, Console.WindowWidth - 1);
        }

        public enum SeperatorAlign
        {
            Centre,
            Left,
            Right
        }

        /// <summary>
        /// Print a line to console, made up of the character x. Padding will be added to the line if it is smaller in width to the containerWidth so as to align itself according to the alignment parameter.
        /// </summary>
        /// <param name="x">The character which the seperator is made out of</param>
        /// <param name="y">The character which the padding is made out of (usually space)</param>
        /// <param name="width">Width of the seperator - cannot be more than containerWidth</param>
        /// <param name="containerWidth">Width of the container, usually the console's width</param>
        /// <param name="alignment"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the width is larger than the containerWidth</exception>
        public static void PrintSeperator(char x, char y, int width, int containerWidth, SeperatorAlign alignment = SeperatorAlign.Centre)
        {
            if (width > containerWidth)
            {
                throw new ArgumentOutOfRangeException("width", "A seperator's width cannot be larger than the container's width!");
            }
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException("width", "A seperator's width cannot be less than 0");
            }
            if (containerWidth < 0)
            {
                throw new ArgumentOutOfRangeException("containerWidth", "A seperator's containerWidth cannot be less than 0");
            }

            int offset = 0;

            switch (alignment)
            {
                case SeperatorAlign.Right:
                    offset = containerWidth - width;
                    break;
                case SeperatorAlign.Centre:
                    offset = (int)(((double)containerWidth - width) / 2);
                    break;
            }

            //do padding left
            for (int i = 0; i < offset; i++)
            {
                Console.Write(y);
            }

            //do seperator
            for (int i = 0; i < width; i++)
            {
                Console.Write(x);
            }

            //do padding right
            for (int i = 0; i < containerWidth - (width + offset); i++)
            {
                Console.Write(y);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Print a line to console, made up of the character x. Padding will be added to the line if it is smaller in width to the containerWidth so as to align itself according to the alignment parameter.
        /// </summary>
        /// <param name="x">The character which the seperator is made out of</param>
        /// <param name="y">The character which the padding is made out of (usually space)</param>
        /// <param name="width">Width of the seperator - cannot be more than containerWidth</param>
        /// <param name="alignment"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the width is larger than the containerWidth</exception>
        public static void PrintSeperator(char x, char y, int width, SeperatorAlign alignment = SeperatorAlign.Centre)
        {
            PrintSeperator(x, y, width, Console.WindowWidth - 1, alignment);
        }

        /// <summary>
        /// Prints a seperator to the console, but with some text in the seperator, positioned using the alignment parameter.
        /// </summary>
        /// <param name="text">Seperator text</param>
        /// <param name="y">text's padding symbol</param>
        /// <param name="z1">markers to seperate the text from the text padding (e.g '&lt;') (left)</param>
        /// <param name="z2">markers to seperate the text from the text padding (e.g '&gt;') (right)</param>
        /// <param name="alignment"></param>
        public static void PrintSeperator(string text, char y, char z1, char z2, int containerWidth, SeperatorAlign alignment = SeperatorAlign.Centre)
        {
            int width = text.Length + 4; //4 = 2 padding for markers + 2 padding for spaces
            if (width > containerWidth)
            {
                text = text.Substring(0, containerWidth - 7) + "..."; //7 = 4 padding from above + 3 padding for elipsis
            }

            int offset = 0;
            switch (alignment)
            {
                case SeperatorAlign.Right:
                    offset = containerWidth - width;
                    break;
                case SeperatorAlign.Centre:
                    offset = (int)(((double)containerWidth - width) / 2);
                    break;
            }

            for (int i = 0; i < offset; i++)
            {
                Console.Write(y);
            }
            Console.Write(z1 + " " + text + " " + z2);

            for (int i = 0; i < containerWidth - (width + offset); i++)
            {
                Console.Write(y);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Prints a seperator to the console, but with some text in the seperator, positioned using the alignment parameter.
        /// </summary>
        /// <param name="text">Seperator text</param>
        /// <param name="y">text's padding symbol</param>
        /// <param name="z">markers to seperate the text from the text padding (e.g '|') </param>
        /// <param name="alignment"></param>
        public static void PrintSeperator(string text, char y, char z, int containerWidth, SeperatorAlign alignment = SeperatorAlign.Centre)
        {
            PrintSeperator(text, y, z, z, containerWidth, alignment);
        }

        /// <summary>
        /// Prints a seperator to the console, but with some text in the seperator, positioned using the alignment parameter.
        /// </summary>
        /// <param name="text">Seperator text</param>
        /// <param name="y">text's padding symbol</param>
        /// <param name="z">markers to seperate the text from the text padding (e.g '|') </param>
        /// <param name="alignment"></param>
        public static void PrintSeperator(string text, char y, char z, SeperatorAlign alignment = SeperatorAlign.Centre)
        {
            PrintSeperator(text, y, z, z, Console.WindowWidth - 1, alignment);
        }

        /// <summary>
        /// Prints a seperator to the console, but with some text in the seperator, positioned using the alignment parameter.
        /// </summary>
        /// <param name="text">Seperator text</param>
        /// <param name="y">text's padding symbol</param>
        /// <param name="z1">markers to seperate the text from the text padding (e.g '&lt;') (left)</param>
        /// <param name="z2">markers to seperate the text from the text padding (e.g '&gt;') (right)</param>
        /// <param name="alignment"></param>
        public static void PrintSeperator(string text, char y, char z1, char z2, SeperatorAlign alignment = SeperatorAlign.Centre)
        {
            PrintSeperator(text, y, z1, z2, Console.WindowWidth - 1, alignment);
        }
        #endregion

        public static void WaitForKey(string text = "Press any key to continue...")
        {
            Console.WriteLine(text);
            ConsoleColor store = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.ReadKey();
            Console.ForegroundColor = store;
        }

        public static void Clear()
        {
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                for (int j = 0; j < Console.WindowWidth-1; j++)
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
            for (int j = 0; j < Console.WindowWidth - 1; j++)
            {
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
}


