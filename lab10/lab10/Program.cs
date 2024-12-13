using System;
using System.Collections.Generic;


namespace Heap
{

    public class Heap<T> where T : IComparable<T>
    {
        private List<T> elements;
        private bool MaxHeap;

        public Heap(T[] array, bool maxHeap = true)
        {
            MaxHeap = maxHeap;
            elements = new List<T>(array);
            BuildHeap();
        }

        private void BuildHeap()
        {
            for (int i = Parent(elements.Count - 1); i >= 0; i--)
            {
                IfHeap(i);
            }
        }

        private void IfHeap(int index)
        {
            int left = LeftChild(index);
            int right = RightChild(index);
            int extremeIndex = index;

            if (left < elements.Count && Compare(elements[left], elements[extremeIndex]) > 0)
            {
                extremeIndex = left;
            }

            if (right < elements.Count && Compare(elements[right], elements[extremeIndex]) > 0)
            {
                extremeIndex = right;
            }

            if (extremeIndex != index)
            {
                Swap(index, extremeIndex);
                IfHeap(extremeIndex);
            }
        }

        public T GetExtreme()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            return elements[0];
        }

        public T RemoveExtreme()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            T extreme = elements[0];
            elements[0] = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            IfHeap(0);

            return extreme;
        }

        public void Key(int index, T newValue)
        {
            if (index < 0 || index >= elements.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (Compare(newValue, elements[index]) < 0)
                throw new ArgumentException("New value is smaller than current value.");

            elements[index] = newValue;
            while (index > 0 && Compare(elements[index], elements[Parent(index)]) > 0)
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        public void Add(T value)
        {
            elements.Add(value);
            int index = elements.Count - 1;

            while (index > 0 && Compare(elements[index], elements[Parent(index)]) > 0)
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        public Heap<T> Unity(Heap<T> otherHeap)
        {
            var UnEl = new List<T>(elements);
            UnEl.AddRange(otherHeap.elements);

            return new Heap<T>(UnEl.ToArray(), MaxHeap);
        }

        private int Parent(int index) => (index - 1) / 2;
        private int LeftChild(int index) => 2 * index + 1;
        private int RightChild(int index) => 2 * index + 2;

        private int Compare(T a, T b) => MaxHeap ? a.CompareTo(b) : b.CompareTo(a);

        private void Swap(int i, int j)
        {
            T tmp = elements[i];
            elements[i] = elements[j];
            elements[j] = tmp;
        }
        new void main(string[] args)
        {
            // Создание массива для инициализации кучи
            int[] array = { 10, 20, 5, 6, 1, 8 };

            // Создание max-кучи
            Heap<int> maxHeap = new Heap<int>(array, true);
            Console.WriteLine("Max-куча (максимальный элемент): " + maxHeap.GetExtreme());

            // Добавление элементов в кучу
            Console.WriteLine("Добавление элемента 15 в кучу.");
            maxHeap.Add(15);
            Console.WriteLine("Максимальный элемент после добавления: " + maxHeap.GetExtreme());

            // Удаление максимального элемента
            Console.WriteLine("Удаление максимального элемента: " + maxHeap.RemoveExtreme());
            Console.WriteLine("Максимальный элемент после удаления: " + maxHeap.GetExtreme());

            // Увеличение ключа
            Console.WriteLine("Увеличение ключа элемента на индексе 2 до 25.");
            maxHeap.Key(2, 25);
            Console.WriteLine("Максимальный элемент после увеличения ключа: " + maxHeap.GetExtreme());

            // Создание другой кучи для слияния
            int[] anotherArray = { 30, 40, 25 };
            Heap<int> anotherHeap = new Heap<int>(anotherArray, true);

            // Слияние двух куч
            Console.WriteLine("Слияние двух куч.");
            Heap<int> mergedHeap = maxHeap.Unity(anotherHeap);
            Console.WriteLine("Максимальный элемент после слияния: " + mergedHeap.GetExtreme());

            // Вывод всех элементов в объединенной куче
            Console.WriteLine("Элементы объединенной кучи:");
            while (mergedHeap.GetExtreme() != null)
            {
                Console.WriteLine(mergedHeap.RemoveExtreme());
            }
        }
    }
}