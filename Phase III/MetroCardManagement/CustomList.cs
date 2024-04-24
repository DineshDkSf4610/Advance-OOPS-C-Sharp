using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;


namespace MetroCardManagement
{
    public partial class CustomList<Type> //Generic Type
    {
        private int _count = 0;

        private int _capacity = 4;

        public int Count { get { return _count; } set { _count = value; } }

        public int Capacity { get { return _capacity; } set { _capacity = value; } }

        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[_capacity] = value; }
        }

        public Type[] _array;

        //CustomList
        public CustomList()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
            // _array = _array [_capacity];
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

        //GrowSize
        public void GrowSize()
        {
            _capacity = _capacity * 2;

            Type[] temp = new Type[_capacity];

            // for (int i = 0; i < _count + 1; i++)
            // {
            //     temp[i] = _array[i];
            // }

            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }

    }
}