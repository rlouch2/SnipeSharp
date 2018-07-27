using System.Collections.Generic;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.Serialization;
using System.Collections;

namespace SnipeSharp.EndPoint.Models
{
    public sealed class ResponseCollection<T> : ApiObject, IList<T>
    {
        [Field("total")]
        public long Total { get; set; }

        [Field("rows")]
        private List<T> Rows { get; set; }

        #region IListWrapper
        public T this[int index]
        {
            get => Rows[index];
            set => Rows[index] = value;
        }
        public int Count => Rows.Count;
        public bool IsReadOnly => ((IList<T>)Rows).IsReadOnly;
        public void Add(T item) => Rows.Add(item);
        public void AddRange(IEnumerable<T> collection) => Rows.AddRange(collection);
        public void Clear() => Rows.Clear();
        public bool Contains(T item) => Rows.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => Rows.CopyTo(array, arrayIndex);
        public IEnumerator<T> GetEnumerator() => Rows.GetEnumerator();
        public int IndexOf(T item) => Rows.IndexOf(item);
        public void Insert(int index, T item) => Rows.Insert(index, item);
        public bool Remove(T item) => Rows.Remove(item);
        public void RemoveAt(int index) => Rows.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => Rows.GetEnumerator();
        #endregion
    }
}
