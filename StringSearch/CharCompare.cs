using System;
using System.Collections.Generic;
using System.Text;

namespace StringSearch
{
    class CharCompare
    {
        static Random random = new Random();
        public static bool CharCmp(char a, char b, int c, int delayed)
        {
            if (delayed == 1)
            {
                int k, x;
                x = random.Next(1000000);

                for (k = 0; k < 1000 * a; k++)
                {
                    if (x % 2 == 0)
                    {
                        x = x + 2;
                    }
                    else
                    {
                        x = x - 1;
                    }
                }
                for (k = 0; k < 1000 * b; k++)
                {
                    if (x % 2 == 0)
                    {
                        x = x + 2;
                    }
                    else
                    {
                        x = x - 1;
                    }
                }
            }

            if (c == 1)                                         // perfect match
            {
                if (a == b)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            a = char.ToUpper(a);                                   // convert a and b to the same case for case insensitive matches
            b = char.ToUpper(b);

            if (c == 2)                                        // perfect match and different case match
            {
                if (a == b)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (c == 3)                                                  // perfect, different case, and different digit match
            {
                if (a == b)
                {
                    return true;
                }
                else if ((a >= 48 && a <= 57) && (b >= 48 && b <= 57))  // if a or b are ascii digits
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
