
using System;
using System.Collections;
namespace QwickFoodz
{
    public partial class CustomList<Type>
    {
        private int _count = 0;

        private int _capacity = 4;

        public int Count { get { return _count; } }

        public int Capacity { get { return _capacity; } }

        public Type[] _array;

        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        //default 
        public CustomList()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
        }

        //method

        public void Add(Type element)
        {
            if (_count == _capacity)
            {
                GrowSize();
            }
            _array[_count] = element;
            _count++;
        }

        public void GrowSize()
        {
            _capacity = _capacity * 2;
            Type[] temp = new Type[_capacity];

            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }

        public void AddRange(CustomList<Type> elements)
        {
            _capacity = _count + elements.Count + 4;

            Type[] temp = new Type[_capacity];

            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            int k = 0;
            for (int i = 0; i < _count + elements.Count; i++)
            {
                temp[i] = elements[k];
                k++;
            }
            _array = temp;
            _count = _count + elements.Count;
        }
    }
}