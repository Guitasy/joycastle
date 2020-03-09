using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Reverse reverse = new Reverse();
            reverse.Write("Welcome to JoyCastle. Let's make an awesome game together. ");
            reverse.Write("Focused, hard work is the real key to success. Keep your eyes on the goal, and just keep taking the next step towards completing it. ");
            Console.ReadKey();
        }
    }

    class Reverse
    {
        StringBuilder _whole, _sentence;

        public Reverse()
        {
            _whole = new StringBuilder();
            _sentence = new StringBuilder();
        }

        public void Write(string str)
        {
            _whole.Clear();
            _sentence.Clear();
            int insertIndex = 0;
            bool isStartWithSpace = false;
            for (int i = 0, max = str.Length; i < max; i++)
            {
                if (str[i] == ' ')
                {
                    if (_sentence.Length == 0)
                    {
                        isStartWithSpace = true;
                        continue;
                    }
                    _sentence.Insert(0, ' ');
                    insertIndex = 0;
                    continue;
                }
                if (str[i] == '.' || str[i] == ',')
                {
                    _sentence.Append(str[i]);
                    if (isStartWithSpace)
                    {
                        _sentence.Insert(0, ' ');
                    }
                    _whole.Append(_sentence);
                    _sentence.Clear();
                    insertIndex = 0;
                    isStartWithSpace = false;
                }
                else
                {
                    _sentence.Insert(insertIndex, str[i]);
                    insertIndex++;
                }
            }
            Console.WriteLine(_whole.ToString());
        }
    }
}
