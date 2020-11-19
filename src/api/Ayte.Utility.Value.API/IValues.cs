using System;

namespace Ayte.Utility.Value.API {
    public interface IValues<out F, out S> {
        F First { get; }
        bool HasFirst { get; }
        S Second { get; }
        bool HasSecond { get; }
    }

    public interface IValues<out F, out S, out T> : IValues<F, S> {
        T Third { get; }
        bool HasThird { get; }
    }
}
