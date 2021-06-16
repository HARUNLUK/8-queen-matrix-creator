using System;

namespace Soru1
{
    class Program
    {
        static string [,] table = new string[8,8];
        static Random rnd = new Random();
        static bool canBeSet(byte line , byte column)
        {
            for (byte i = 0; i<8; i++)
            {
               if (table[i,column] == "V" || table[line,i]=="V")
               {
                   return false;
               }
            }
            if (line>=column)
            {
                for (byte forLine=Convert.ToByte(line-column),forColumn =0;forLine<8;forLine++ , forColumn++)
                {
                    if (table[forLine,forColumn]=="V")
                    {
                        return false;
                    }
                }
                
            }
            else
            {
                for (byte forColumn = Convert.ToByte(column-line),forLine=0;forColumn<8;forColumn++,forLine++)
                {
                    if (table[forLine,forColumn]=="V")
                    {
                        return false;
                    }
                }
            }
            for (byte forLine = line, forColumn = column; forLine <8 && forColumn < 8; forLine--, forColumn++)
            {
                if (forLine == 0 || forColumn == 7)
                {
                    for (byte indexLine = forLine, indexColumn = forColumn; indexLine <= 7 && indexColumn >=0; indexLine++, indexColumn--)
                    {
                        if (indexColumn==255)
                        {
                            indexColumn = 0;
                        }
                        if (table[indexLine, indexColumn] == "V")
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        static void deleteV()
        {
            byte v = howManyV();
            byte whichV = Convert.ToByte(rnd.Next(v));
            byte vCounter=0;
            for (byte i = 0; i< 8;i++)
            {
                for (byte j=0;j<8;j++)
                {
                    if (table[i,j]=="V")
                    {
                        vCounter++;
                    }
                    if (vCounter==whichV)
                    {
                        table[i, j] = "*";
                    }
                }
            }
        }
        static byte howManyV()
        {
            byte vCounter=0;
            for (byte i = 0; i < 8; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    if (table[i, j] == "V")
                    {
                        vCounter++;
                    }
                }
            }
            return vCounter;
        }
        static void Main(string[] args)
        {
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    table[i,j]="*";
                }
            }
            byte x, y;
            byte v = 0;
            byte counter = 0;
            while(howManyV()<8)
            {
                x = Convert.ToByte(rnd.Next(8));
                y = Convert.ToByte(rnd.Next(8));
                if (canBeSet(x,y))
                {
                    table[x,y]="V";
                    v++;
                }
                if (counter>10)
                {
                    counter=0;
                    v--;
                    deleteV();
                }
                counter++;
            }
            for (byte i=0;i<8;i++)
            {
                for(byte j = 0; j < 8; j++)
                {
                    Console.Write(" "+table[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
