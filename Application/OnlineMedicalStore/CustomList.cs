

using System;

namespace OnlineMedicalStore
{
    public partial class CustomList <Type>
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

        //Default Construtors

        public CustomList()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];

        }

          public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }

        //Add Method

        public void Add(Type elements)
        {
            if (_count == _capacity)
            {
                GrowSize();
            }
            _array[_count] = elements;
            _count++;
        }

        public void AddRange(CustomList<Type> elements)
        {
            _capacity = _count + elements.Count + 4;
            Type [] temp = new Type[_capacity];
            for(int i = 0; i <_count;i++)
            {
                temp[i] = _array[i];
            }
            int k = 0;
            for(int i = _count; i< _count + elements.Count;i++)
            {
                temp[i] = _array[k];
                k++;
            }
            _array = temp;
            _count = _count + elements.Count;
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
        
        public bool Contains(Type elements)
        {
            bool temp = false;
            foreach(Type data in _array)
            {
                if(data.Equals(elements))
                {
                    temp = true;
                }
            }
            return temp;
        }

        public int IndexOf(Type elements)
        {
            int index = -1;
            for(int i = 0; i <_count;i++)
            {
                if(elements.Equals(_array[i]))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void Insert(int postion, Type element)
        {
            _capacity = _capacity + 1 + 4;
            Type [] temp = new Type [_capacity];
            for(int i = 0; i<_count + 1; i++)
            {
                if(i < position)
                {
                    temp[i] = _array[i];
                }else if(i == position)
                {
                    temp[i] = element;
                }
                else{
                    temp[i] = _array[i-1];
                }
            }
            _count++;
            _array = temp;
        }

    }
}