namespace VsoApi.MsAgile.Entities.Linq
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Responses;

    internal class BaseEntityReader<T> : IEnumerable<T> where T : BaseEntity, new()
    {
        private Enumerator _enumerator;

        internal BaseEntityReader(CollectionResponse<WorkItem> reader)
        {
            _enumerator = new Enumerator(reader);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Enumerator e = _enumerator;
            if (e == null) {
                throw new InvalidOperationException("Cannot enumerate more than once");
            }

            _enumerator = null;
            return e;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Enumerator : IEnumerator<T>
        {
            private IList<WorkItem> _source;
            private int _index;

            internal Enumerator(CollectionResponse<WorkItem> source)
            {
                _source = source.Value.ToList();
                _index = 0;
            }

            public T Current { get; private set; }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (_index >= _source.Count)
                    return false;
                
                Current = Mapper.Map<WorkItem, T>(_source[_index]);
                _index++;
                return true;
            }

            public void Reset()
            {
            }

            public void Dispose()
            {
                _source = null;
                _index = 0;
            }
        }
    }
}