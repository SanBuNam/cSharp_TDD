

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


        /// <summary>
        /// Inserts a new element at an index. Doesn't override the cell at index.
        /// </summary>
        /// <param name="dataItem">Data item to insert.</param>
        /// <param name="index">Index of insertion.</param>
        public void InsertAt(T dataItem, int index)
        {
            if (index < 0 || index > _size)
            {
                throw new IndexOutOfRangeException("Please provide a valid index.");
            }

            // If the inner array is full and there are no extra spaces,
            // ... then maximize it's capacity to a minimum of _size + 1.
            if (_size == _collection.Length)
            {
                _ensureCapacity(_size + 1);
            }

            // If the index is not "at the end", then copy the elements of the array
            // ... between the specified index and the last index to the new range (index +1, _size);
            // The call at "index" will become available.
            if (index < _size)
            {
                Array.Copy(_collection, index, _collection, index + 1, (_size - index));
            }

            // Write the dataItem to the available cell.
            _collection[index] = dataItem;

            // Increase the size.
            _size++;
        }


        /// <summary>
        /// Removes the specified dataItem from list.
        /// </summary>
        /// <returns>>True if removed successfully, false otherwise.</returns>
        /// <param name="dataItem">Data item.</param>
        public bool Remove(T dataItem)
        {
            int index = IndexOf(dataItem);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }


        /// <summary>
        /// Removes the list element at the specified index.
        /// </summary>
        /// <param name="index">Index of element.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException("Please pass a valid index.");
            }

            // Decrease the size by 1, to avoid doing Array. Copy if the element is to be removed from the tail of list.
            _size--;

            // If the index is still less than size, perform an Array.Copy to override the cell at index.
            // This operation is O(N), where N = size - index.
            if (index < _size)
            {
                Array.Copy(_collection, index + 1, _collection, index, (_size - index));
            }

            // Reset the writable cell to the default value of type T.
            _collection[_size] = default(T);
        }


        /// <summary>
        /// Clear this instance.
        /// </summary>
        public void Clear()
        {
            if (_size > 0)
            {
                _size = 0;
                Array.Clear(_collection, 0, _size);
                _collection = _emptyArray;
            }
        }

        /// <summary>
        /// Resize the List to a new size.
        /// </summary>
        public void Resize(int newSize)
        {
            Resize(newSize, default(T));
        }

        /// <summary>
        /// Resize the list to a new size.
        /// </summary>
        public void Resize(int newSize, T defaultValue)
        {
            int currentSize = this.Count;

            if (newSize < currentSize)
            {
                this._ensureCapacity(newSize);
            }
            else if (newSize > currentSize)
            {
                // Optimisation step.
                // This is just to avoid multiple automatic capacity changes.
                if (newSize > this._collection.Length)
                    this._ensureCapacity(newSize + 1);

                this.AddRange(Enumerable.Repeat<T>(defaultValue, newSize - currentSize));
            }
        }

        /// <summary>
        /// Reverses this list.
        /// </summary>
        public void Reverse()
        {
            Reverse(0, _size);
        }

        /// <summary>
        /// Reverses the order of a number of elements. Starting a specific index.
        /// </summary>
        /// <param name="startIndex">Start index.</param>
        /// <param name="count">Count of elements to reverse.</param>
        public void Reverse(int startIndex, int count)
        {
            // Handle the bounds of startIndex
            if (startIndex < 0 || startIndex >= _size)
            {
                throw new IndexOutOfRangeException("Please pass a valid starting index.");
            }

            // Handle the bounds of count and startIndex with respect to _size.
            if (count < 0 || startIndex > (_size - count))
            {
                throw new ArgumentOutOfRangeException();
            }

            // Use Array.Reverse
            // Running complexity is better than O(N). But unknow.
            // Array.Reverse uses the closed-source function TrySZReverse.
            Array.Reverse(_collection, startIndex, count);
        }

        /// <summary>
        /// For each element in list, apply the specified action to it.
        /// </summary>
        /// <param name="action">Typed Action.</param>
        public void ForEach(Action<T> action)
        {
            // Null actions are not allowed.
            if (action == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < _size; ++i)
            {
                action(_collection[i]);
            }
        }

        /// <summary>
        /// Checks whether the list contains the specified dataItem.
        /// </summary>
        /// <returns>True if list contains the dataItem, false otherwise.</returns>
        /// <param name="dataItem">Data item.</param>
        public bool Contains(T dataItem)
        {
            // Null-value check
            if ((Object)dataItem == null)
            {
                for (int i = 0; i < _size; ++i)
                {
                    if ((Object)_collection[i] == null) return true;
                }
            }
            else
            {
                // Construct a default equality comparer for this Type T
                // Use it to get the equal match for the dataItem
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;

                for (int i = 0; i < _size; ++i)
                {
                    if (comparer.Equals(_collection[i], dataItem)) return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether the list contains the specified dataItem.
        /// </summary>
        /// <returns>True if list contains the dataItem, false otherwise.</returns>
        /// <param name="dataItem">Data item.</param>
        /// <param name="comparer">The Equality Comparer object.</param>
       public bool Contains(T dataItem, IEqualityComparer<T> comparer)
       {
            // Null comparers are not allowed.
            if (comparer == null)
            {
                throw new ArgumentNullException();
            }

            // Null-value check
            if ((Object)dataItem == null)
            {
                for (int i=0; i < _size; ++i)
                {
                    if ((Object)_collection[i] == null) return true;
                }
            }
            else
            {
                for (int i = 0; i < _size; ++i)
                {
                    if (comparer.Equals(_collection[i], dataItem)) return true;
                }
            }

            return false;
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