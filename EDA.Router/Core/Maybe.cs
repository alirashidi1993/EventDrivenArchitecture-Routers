using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDA.Router.Core
{
    public readonly struct Maybe<T> : IEquatable<Maybe<T>>
    {

        private readonly MaybeValueWrapper _value;
        public T Value
        {
            get
            {
                if(_value == null)
                {
                    throw new InvalidOperationException();
                }

                return _value.Value;
            }
        }

        public static Maybe<T> None => new Maybe<T>();

        private Maybe(T value)
        {
            _value = value == null ? null : new MaybeValueWrapper(value);
        }
        public static implicit operator Maybe<T>(T value)
        {
            if(value?.GetType()==typeof(Maybe<T>))
            {
                return (Maybe<T>)(object)value;
            }
            return new Maybe<T>(value);
        }

        public bool Equals(Maybe<T> other)
        {
            throw new NotImplementedException();
        }

        [Serializable]
        private class MaybeValueWrapper
        {
            internal readonly T Value;
            public MaybeValueWrapper(T value)
            {
                Value = value;
            }
        }
    }
}
