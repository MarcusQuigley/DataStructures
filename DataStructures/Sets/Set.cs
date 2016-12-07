using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sets
{
    class Set<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly List<T> _items = new List<T>();

        public Set() { }
        public Set(IEnumerable<T> items)
        {
            this.AddRange(items);
        }

        public void Add(T item)
        {
            if (Contains(item))
                throw new InvalidOperationException("Item already exists.");
            _items.Add(item);
        }

        private void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public bool Remove(T item)
        {
             return _items.Remove(item);
        }
        public bool Contains(T item)
        {
            //foreach (T entity in _items)
            //{
            //    if (entity.CompareTo(item) == 0)
            //        return true;
            //}
            return _items.Contains(item);
        }

        public int Count {
            get { return _items.Count; }
        }

        //[1, 2, 3, 4] union [3, 4, 5, 6] = [1, 2, 3, 4, 5, 6]
        public Set<T> Union(Set<T> other)
        {
            Set<T> union = new Set<T>(this._items);
            foreach (var item in other)
            {
                if (!Contains(item))
                    union.Add(item);
            }
            return union;
            
        }

        //[1, 2, 3, 4] intersect [3, 4, 5, 6] = [3, 4]
        public Set<T> Intersection(Set<T> other)
        {
            Set<T> intersection = new Set<T>();
            foreach (var item in other)
            {
                if (Contains(item))
                    intersection.Add(item);
            }
            return intersection;
        }

        //[1, 2, 3, 4] difference [3, 4, 5, 6] = [1, 2]
        public Set<T> Difference(Set<T> other)
        {
            Set<T> difference = new Set<T>(_items);
            foreach (var item in other)
            {
                difference.Remove(item);
            }
            return difference;
        }

        public Set<T> SymmetricDifference(Set<T> other)
        {
            Set<T> union = Union(other);
            Set<T> intersection = Intersection(other);
            return union.Difference(intersection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
