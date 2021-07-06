using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{
    class TestCollections<TKey, TValue>
    {
        private List<TKey> testTKeyList = new List<TKey>();
        private List<string> testStringList = new List<string>();

        private Dictionary<TKey, TValue> dictionaryTKey = new Dictionary<TKey, TValue>();
        private Dictionary<string, TValue> dictionaryString = new Dictionary<string, TValue>();

        private GenerateElement<TKey, TValue> generateElement;

        public TestCollections(int count, GenerateElement<TKey, TValue> j)
        {
            if (count <= 0) throw new ArgumentException();

            generateElement = j;
            for (int i = 0; i < count; i++)
            {
                var element = generateElement(i);
                testTKeyList.Add(element.Key);
                testStringList.Add(element.Key.ToString());
                dictionaryTKey.Add(element.Key, element.Value);
                dictionaryString.Add(element.Key.ToString(), element.Value);
            }
        }

        public void searchInTKeyList()
        {
            var first = testTKeyList[0];
            var center = testTKeyList[testTKeyList.Count / 2];
            var last = testTKeyList[testTKeyList.Count - 1];
            var another = generateElement(testTKeyList.Count + 10).Key;

            int begin = Environment.TickCount;
            testTKeyList.Contains(first);
            int end = Environment.TickCount;
            Console.WriteLine("Время поиска в List<TKey>\nДля первого элемента:  " + (end - begin));
            
            begin = Environment.TickCount;
            testTKeyList.Contains(center);
            end = Environment.TickCount;
            Console.WriteLine("Для центрального элемента:  " + (end - begin));

            begin = Environment.TickCount;
            testTKeyList.Contains(last);
            end = Environment.TickCount;
            Console.WriteLine("Для последнего элемента:  " + (end - begin));

            begin = Environment.TickCount;
            testTKeyList.Contains(another);
            end = Environment.TickCount;
            Console.WriteLine("Для элемента, не входящего в коллекцию:  " + (end - begin) + "\n");

        }

        public void searchInStrList()
        {
            var first = testStringList[0];
            var center = testStringList[testStringList.Count / 2];
            var last = testStringList[testStringList.Count - 1];
            var another = generateElement(testStringList.Count + 10).Key.ToString();

            var begin = Environment.TickCount;
            testStringList.Contains(first);
            var end = Environment.TickCount;
            Console.WriteLine("Время поиска в List<String>\nДля первого элемента:  " + (end - begin));

            begin = Environment.TickCount;
            testStringList.Contains(center);
            end = Environment.TickCount;
            Console.WriteLine("Для центрального элемента:  " + (end - begin));

            begin = Environment.TickCount;
            testStringList.Contains(last);
            end = Environment.TickCount;
            Console.WriteLine("Для последнего элемента:  " + (end - begin));

            begin = Environment.TickCount;
            testStringList.Contains(another);
            end = Environment.TickCount;
            Console.WriteLine("Для элемента, не входящего в коллекцию:  " + (end - begin) + "\n");
        }

        public void searcInTKeyDictionary()
        {
            var first = dictionaryTKey.ElementAt(0).Key;
            var center = dictionaryTKey.ElementAt(dictionaryTKey.Count / 2).Key;
            var last = dictionaryTKey.ElementAt(dictionaryTKey.Count - 1).Key;
            var another = generateElement(dictionaryTKey.Count + 10).Key;

            int begin = Environment.TickCount;
            dictionaryTKey.ContainsKey(first);
            int end = Environment.TickCount;
            Console.WriteLine("Время поиска в Dictionary< TKey, TValue> с помощью метода ContainsKey\nДля первого элемента:  " + (end - begin));

            begin = Environment.TickCount;
            dictionaryTKey.ContainsKey(center);
            end = Environment.TickCount;
            Console.WriteLine("Для центрального элемента:  " + (end - begin));

            begin = Environment.TickCount;
            dictionaryTKey.ContainsKey(last);
            end = Environment.TickCount;
            Console.WriteLine("Для последнего элемента:  " + (end - begin));

            begin = Environment.TickCount;
            dictionaryTKey.ContainsKey(another);
            end = Environment.TickCount;
            Console.WriteLine("Для элемента, не входящего в коллекцию:  " + (end - begin) + "\n");
        }

        public void searcInStrDictionary()
        {
            var first = dictionaryString.ElementAt(0).Key;
            var center = dictionaryString.ElementAt(dictionaryString.Count / 2).Key;
            var last = dictionaryString.ElementAt(dictionaryString.Count - 1).Key;
            var another = generateElement(dictionaryString.Count + 10).Key.ToString();

            int begin = Environment.TickCount;
            dictionaryString.ContainsKey(first);
            int end = Environment.TickCount;
            Console.WriteLine("Время поиска в Dictionary <string, TValue > с помощью метода ContainsKey\nДля первого элемента:  " + (end - begin));

            begin = Environment.TickCount;
            dictionaryString.ContainsKey(center);
            end = Environment.TickCount;
            Console.WriteLine("Для центрального элемента:  " + (end - begin));

            begin = Environment.TickCount;
            dictionaryString.ContainsKey(last);
            end = Environment.TickCount;
            Console.WriteLine("Для последнего элемента:  " + (end - begin));

            begin = Environment.TickCount;
            dictionaryString.ContainsKey(another);
            end = Environment.TickCount;
            Console.WriteLine("Для элемента, не входящего в коллекцию:  " + (end - begin) + "\n");
        }

        public void searcInTKeyDictionaryByValue()
        {
            var first = dictionaryTKey.ElementAt(0).Value;
            var center = dictionaryTKey.ElementAt(dictionaryTKey.Count / 2).Value;
            var last = dictionaryTKey.ElementAt(dictionaryTKey.Count - 1).Value;
            var another = generateElement(dictionaryTKey.Count + 10).Value;

            int begin = Environment.TickCount;
            dictionaryTKey.ContainsValue(first);
            int end = Environment.TickCount;
            Console.WriteLine("Время поиска в Dictionary< TKey, TValue > с помощью метода ContainsValue\nДля первого элемента:  " + (end - begin));

            begin = Environment.TickCount;
            dictionaryTKey.ContainsValue(center);
            end = Environment.TickCount;
            Console.WriteLine("Для центрального элемента:  " + (end - begin));

            begin = Environment.TickCount;
            dictionaryTKey.ContainsValue(last);
            end = Environment.TickCount;
            Console.WriteLine("Для последнего элемента:  " + (end - begin));

            begin = Environment.TickCount;
            dictionaryTKey.ContainsValue(another);
            end = Environment.TickCount;
            Console.WriteLine("Для элемента, не входящего в коллекцию:  " + (end - begin) + "\n");
        }


    }
}
