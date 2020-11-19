using System;

namespace Ayte.Utility.Value.API {
    public interface IOptional<out T> : IValue<T> {
        IOptional<V> Map<V>(Func<T, V> transformer);
        IOptional<V> FlatMap<V>(Func<T, IOptional<V>> transformer);
    }
}
