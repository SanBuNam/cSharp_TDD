

using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Lists
{
    /// <summary>
    /// The Array-Based List Data Structure.
    /// </summary>
     
    public class ArrayList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Instance variables.
        /// </summary>

        // This sets the default maximum array length to refer to MAXIMUM_ARRAY_LENGTH_xx64
        // Set the flag IsMaximumCapacityReached to false
        bool DefaultMaxCapacityIsX64 = true;
        bool IsMaximumCapacityReached = false;

        // The C# Maximum Array Length (before encountering overflow)
        // Reference: http://referencesource.microsoft.com/#mscorlib/system/array.cs,2d2b551eabe74985
        public const int MAXIMUM_ARRAY_LENGTH_x64 = 0X7FEFFFFF; //x64
        public const int MAXIMUM_ARRAY_LENGTH_x86 = 0x8000000; //x86

        // This is used as a default empty list initialization.
        private readonly T[] _emptyArray = new T[0];

        // The default capacity to resize to, when a minimum is lower than 5.
        private const int _defaultCapacity = 8;

        // The internal array of elements.
        // NOT A PROPERTY.
        private T[] _collection;

        // This keeps track of the number of elements added to the array.
        // Serves as an index of last item + 1.
        private int _size { get; set; }


        /// <summary>
        /// CONSTRUCTORS
        /// </summary>
        public ArrayList() : this(capacity: 0) { }
        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (capacity == 0)
            {
                _collection = _emptyArray;
            }
            else
            {
                _collection = new T[capacity];
            }

            // Zerofiy the _size;
            _size = 0;
        }

        /// <summary>
        /// Ensures the capacity.
        /// </summary>
        /// <param name="minCapacity">Minimum capacity.</param>
        private void _ensureCapacity(int minCapacity)
        {
            // If the length of the inner collection is less than the minCapacity
            // ... and if the maximum capacity wasn't reached yet,
            // ... then maximize the inner collection.

            if (_collection.Length < minCapacity && IsMaximumCapacityReached == false)
            {
                int newCapacity = (_collection.Length == 0 ? _defaultCapacity : _collection.Length * 2);

                // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
                // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
                int maxCapacity = (DefaultMaxCapacityIsX64 == true ? MAXIMUM_ARRAY_LENGTH_x64 : MAXIMUM_ARRAY_LENGTH_x86);

                if (newCapacity < minCapacity)
                    newCapacity = minCapacity;

                if (newCapacity >= maxCapacity)
                {
                    newCapacity = maxCapacity - 1;
                    IsMaximumCapacityReached = true;
                }

                this._resizeCapacity(newCapacity);
            }

        }

        /// <summary>
        /// Resizes the collection to a new maximum number of capacity.
        /// </summary>
        /// <param name="newCapacity">New capacity.</param>
        private void _resizeCapacity(int newCapacity)
        {
            if (newCapacity != _collection.Length && newCapacity > _size)
            {
                try
                {
                    Array.Resize<T>(ref _collection, newCapacity);
                }
                catch (OutOfMemoryException)
                {
                    if (DefaultMaxCapacityIsX64 == true)
                    {
                        DefaultMaxCapacityIsX64 = false;
                        _ensureCapacity(newCapacity);
                    }

                    throw;
                }
            }
        }

        /// <summary>
        /// Gets the the number of elements in list.
        /// </summary>
        /// <value>Int.</value>
        public int Count
        {
            get
            {
                return _size;
            }
        }

        /// <summary>
        /// Returns the capacity of list, which is the total number of slots.
        /// </summary>
        public int Capacity
        {
            get { return _collection.Length; }
        }

        /// <summary>
        /// Determines whether this list is empty.
        /// </summary>
        /// <returns><c>true</c> if list is empty; otherwise, <c>false</c>.</returns>
        public bool IsEmpty
        {
            get
            {
                return (Count == 0);
            }
        }

        /// <summary>
        /// Gets the first element in the list.
        /// </summary>
        /// <value>The first.</value>
        public T First
        {
            get
            {
                if (Count == 0)
                {
                    throw new IndexOutOfRangeException("List is empty.");
                }

                return _collection[0];
            }
        }

        /// <summary>
        /// Gets the last element in the list.
        /// </summary>
        /// <value>The last.</value>
        public T Last
        {
            get
            {
                if (IsEmpty)
                {
                    throw new IndexOutOfRangeException("List is empty.");
                }

                return _collection[Count - 1];
            }
        }

        /// <summary>
        /// Gets or sets the item at the specified index.
        /// example: var a = list[0];
        /// example: list[0] = 1;
        /// </summary>
        /// <param name="index">Index.</param>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _size)
                {
                    throw new IndexOutOfRangeException();
                }

                return _collection[index];
            }

            set
            {
                if (index < 0 || index >= _size)
                {
                    throw new IndexOutOfRangeException();
                }

                _collection[index] = value;
            }
        }


        /// <summary>
        /// Add the specified dataItem to list.
        /// </summary>
        /// <param name="dataItem">Data item.</param>
        public void Add(T dataItem)
        {
            if (_size == _collection.Length)
            {
                _ensureCapacity(_size + 1);
            }


            _collection[_size++] = dataItem;
        }

        /// <summary>
        /// Adds an enumerable collection of items to list.
        /// </summary>
        /// <param name="elements"></param>
        public void AddRange(IEnumerable<T> elements)
        {
            if (elements == null)
                throw new ArgumentNullException();
            // make sure the size won't overflow by adding the range
            if (((uint)_size + elements.Count()) > MAXIMUM_ARRAY_LENGTH_x64)
                throw new OverflowException();
            // grow the internal collection once to avoid doing multiple redundant grows
            if (elements.Any())
            {
                _ensureCapacity(_size + elements.Count());

                foreach (var element in elements)
                    this.Add(element);
            }
        }

        /// <summary>
        /// Adds an element to list repeatedly for a specified count.
        /// </summary>
        public void AddRepeatedly(T value, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException();

            if (((uint)_size + count) > MAXIMUM_ARRAY_LENGTH_x64)
                throw new OverflowException();

            // grow the internal collection once to avoid doing multiple redundant grows
            if (count > 0)
            {
                _ensureCapacity(_size + count);

                for (int i = 0; i < count; i++)
                    this.Add(value);
            }
        }



    }


}

/*
 The array (or vector). It offers great speed O(1) accessing any element from the array with very low space overhead and you can also iterate backward and forwards from the current element.
But the main problem is the array is fixed size, you have to know how many elements you will need when you create the data structure.
The list (double linked list). It offers a dynamically sized data structure (you don't have to know the number of elements at creation) with access to the previous and the new element at a fast speed.
But accessing any element is very slow O(n) and it has a slightly higher space overhead then the array.
The array-list (array based list). Like an array, it offers great speed O(1) access to any element and has very low space overhead. Like a list, 
you don't need to know how many elements will be in the data structure when you create it. 
But behind the scenes (the user doesn't realize) it is essentially an array which detects when the array will be "full" then it creates a new array (roughly twice the original size) 
and copies the elements from the old array to the new array.
Hash table is very different from the three data structures above. It doesn't allow access to the elements in the order by which they were inserted. 
Instead, it allows you to map a key to a value; so you have very fast access O(1) to the elements using a unique key.
 */