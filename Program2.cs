using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            new SquareFill().Calculate();
        }
    }

    class SquareFill
    {
        int _m, _n;
        float _area;
        const int countSquare = 100;

        public void Calculate()
        {
            _m = ReadInt();
            _n = ReadInt();
            _area = _m * _n;

            float lMax = (float)Math.Sqrt(_area / countSquare);
            float blankArea = float.MaxValue, length = 0;
            for (int i = (int)Math.Floor(_m / lMax); i <= 100; i++)
            {
                float area = CalculateBlankArea(i, out float l);
                if (area < blankArea)
                {
                    blankArea = area;
                    length = l;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(string.Concat("填充正方形边长为：", length));
            Console.ReadKey();
        }

        int ReadInt()
        {
            string str = string.Empty;
            while (true)
            {
                Console.Write("请输入边长数字：");
                str = Console.ReadLine();
                if (int.TryParse(str, out int num))
                {
                    if (num > 0)
                    {
                        return num;
                    }
                }
            }
        }

        /// <summary>
        /// 通过m边填充正方形数量计算空白区域面积
        /// </summary>
        /// <param name="countM">m边填充方块数</param>
        /// <param name="length">正方形边长</param>
        /// <returns>空白区域面积</returns>
        float CalculateBlankArea(int countM, out float length)
        {
            if (countM == 0)
            {
                length = 0;
                return _area;
            }
            int countN = (int)Math.Ceiling(countSquare / (float)countM);
            length = Math.Min(_m / (float)countM, _n / (float)countN);
            return _area - length * length * countSquare;
        }
    }
}
