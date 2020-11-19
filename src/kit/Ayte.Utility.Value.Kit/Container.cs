using System;
using Ayte.Utility.Value.API;

namespace Ayte.Utility.Value.Kit {
    internal readonly struct Container<T> : IOptional<T> {
        private readonly T value;

        public T Value => HasValue ? value : throw new InvalidOperationException();

        public T OrDefault => HasValue ? value : default;

        public bool HasValue { get; }
        
        public Container(T value, bool hasValue) {
            this.value = value;
            HasValue = hasValue;
        }

        public IOptional<V> Map<V>(Func<T, V> transformer) {
            return HasValue ? new Container<V>(transformer.Invoke(value), true) : new Container<V>(default, false);
        }

        public IOptional<V> FlatMap<V>(Func<T, IOptional<V>> transformer) {
            return HasValue ? transformer.Invoke(value) : new Container<V>(default, false);
        }
    }
}
