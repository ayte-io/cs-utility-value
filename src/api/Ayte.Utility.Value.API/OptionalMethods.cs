using System;

namespace Ayte.Utility.Value.API {
    public static class OptionalMethods {
        public static IOptional<T> IfPresent<T>(this IOptional<T> @this, Action<T> action) {
            if (@this.HasValue) {
                action.Invoke(@this.Value);
            }
            
            return @this;
        }

        public static IOptional<T> IfAbsent<T>(this IOptional<T> @this, Action action) {
            if (!@this.HasValue) {
                action.Invoke();
            }

            return @this;
        }

        public static IOptional<T> Peek<T>(this IOptional<T> @this, Action<T> ifPresent, Action ifAbsent) {
            if (@this.HasValue) {
                ifPresent.Invoke(@this.Value);
            } else {
                ifAbsent.Invoke();
            }

            return @this;
        }

        public static IOptional<T> FallbackTo<T>(this IOptional<T> @this, IOptional<T> fallback) {
            return @this.HasValue ? @this : fallback;
        }

        public static IOptional<T> FallbackToComputed<T>(this IOptional<T> @this, Func<IOptional<T>> provider) {
            return @this.HasValue ? @this : provider.Invoke();
        }

        public static T OrElse<T>(this IOptional<T> @this, T fallback) {
            return @this.HasValue ? @this.Value : fallback;
        }

        public static T OrElseCompute<T>(this IOptional<T> @this, Func<T> provider) {
            return @this.HasValue ? @this.Value : provider.Invoke();
        }

        public static T OrElseThrow<T>(this IOptional<T> @this, Func<Exception> provider) {
            return @this.HasValue ? @this.Value : throw provider.Invoke();
        }
    }
}
