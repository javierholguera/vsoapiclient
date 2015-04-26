namespace VsoApi.MsAgile.Entities.Linq
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;

    internal class BaseEntityReader<TContract, TEntity> : IEnumerable<TEntity> where TContract : new()
    {
        private Enumerator _enumerator;

        internal BaseEntityReader(IEnumerable<TContract> reader)
        {
            _enumerator = new Enumerator(reader);
        }

        public IEnumerator<TEntity> GetEnumerator()
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

        private class Enumerator : IEnumerator<TEntity>
        {
            private IList<TContract> _source;
            private int _index;

            internal Enumerator(IEnumerable<TContract> source)
            {
                _source = source.ToList();
                _index = 0;
            }

            public TEntity Current { get; private set; }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (_index >= _source.Count)
                    return false;
                
                Current = Mapper.Map<TContract, TEntity>(_source[_index]);
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