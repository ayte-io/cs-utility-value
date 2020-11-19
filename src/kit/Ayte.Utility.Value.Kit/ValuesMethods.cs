using Ayte.Utility.Value.API;

namespace Ayte.Utility.Value.Kit {
    public static class ValuesMethods {
        public static IOptional<F> GetFirst<F, S>(this IValues<F, S> @this) {
            return @this.HasFirst ? Optionals.Of(@this.First) : Optionals.Empty<F>();
        }
        
        public static IOptional<F> GetFirst<F>(this IValues<F, object> @this) {
            return @this.HasFirst ? Optionals.Of(@this.First) : Optionals.Empty<F>();
        }

        public static IOptional<S> GetSecond<F, S>(this IValues<F, S> @this) {
            return @this.HasSecond ? Optionals.Of(@this.Second) : Optionals.Empty<S>();
        }
    }
}
