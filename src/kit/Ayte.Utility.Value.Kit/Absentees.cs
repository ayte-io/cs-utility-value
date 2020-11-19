using System;
using System.Collections.Generic;
using Ayte.Utility.Value.API;

namespace Ayte.Utility.Value.Kit {
    public static class Absentees {
        public static bool TryTakeFirst<T>(IEnumerable<T> values, ref T result, Predicate<T> presenceValidator) {
            foreach (var value in values) {
                if (presenceValidator.Invoke(value)) {
                    result = value;
                    return true;
                }
            }

            return false;
        }

        public static bool TryTakeFirst<T>(IEnumerable<T> values, ref T result) where T : class {
            return TryTakeFirst(values, ref result, TypePredicates<T>.NotNull);
        }
        
        public static T TakeFirst<T>(IEnumerable<T> values, Predicate<T> presenceValidator) {
            T capture = default;

            return TryTakeFirst(values, ref capture, presenceValidator) ? capture : default;
        }
        
        public static T TakeFirst<T>(IEnumerable<T> values) where T : class {
            return TakeFirst(values, TypePredicates<T>.NotNull);
        }

        public static T TakeFirst<T>(params T[] values) where T : class {
            return TakeFirst(values as IEnumerable<T>);
        }

        public static T GetFirstOrElseThrow<T>(IEnumerable<T> values, Func<Exception> provider, Predicate<T> presenceValidator) {
            T capture = default;
            
            return TryTakeFirst(values, ref capture, presenceValidator) ? capture : throw provider.Invoke();
        }

        public static T GetFirstOrElseThrow<T>(IEnumerable<T> values, Func<Exception> provider) where T : class {
            return GetFirstOrElseThrow(values, provider, TypePredicates<T>.NotNull);
        }

        public static T GetFirst<T>(IEnumerable<T> values, Predicate<T> presenceValidator) {
            return GetFirstOrElseThrow(values, () => new ArgumentNullException(nameof(values), "All provided values were null"), presenceValidator);
        }

        public static T GetFirst<T>(IEnumerable<T> values) where T : class {
            return GetFirst(values, TypePredicates<T>.NotNull);
        }

        public static T GetFirst<T>(params T[] values) where T : class {
            return GetFirst(values as IEnumerable<T>);
        }

        public static T GetFirstOrElse<T>(IEnumerable<T> values, T fallback, Predicate<T> presenceValidator) {
            T capture = default;
            
            return TryTakeFirst(values, ref capture, presenceValidator) ? capture : fallback;
        }

        public static T GetFirstOrElse<T>(IEnumerable<T> values, T fallback) where T : class {
            return GetFirstOrElse(values, fallback, TypePredicates<T>.NotNull);
        }

        public static T GetFirstOrElseCompute<T>(IEnumerable<T> values, Func<T> provider, Predicate<T> presenceValidator) {
            T capture = default;
            
            return TryTakeFirst(values, ref capture, presenceValidator) ? capture : provider.Invoke();
        }

        public static T GetFirstOrElseCompute<T>(IEnumerable<T> values, Func<T> provider) where T : class {
            return GetFirstOrElseCompute(values, provider, TypePredicates<T>.NotNull);
        }

        public static IOptional<T> TryGetFirst<T>(IEnumerable<T> values, Predicate<T> presenceValidator) {
            foreach (var value in values) {
                if (presenceValidator.Invoke(value)) {
                    return Optionals.Of(value);
                }
            }

            return Optionals.Empty<T>();
        }

        public static IOptional<T> TryGetFirst<T>(IEnumerable<T> values) where T : class {
            return TryGetFirst(values, TypePredicates<T>.NotNull);
        }

        public static IOptional<T> TryGetFirst<T>(params T[] values) where T : class {
            return TryGetFirst(values as IEnumerable<T>);
        }

        public static V Map<T, V>(T value, Func<T, V> transformer, Predicate<T> presenceValidator) {
            return presenceValidator.Invoke(value) ? transformer.Invoke(value) : default;
        }

        public static V Map<T, V>(T value, Func<T, V> transformer) where T : class {
            return Map(value, transformer, TypePredicates<T>.NotNull);
        }

        public static T IfPresent<T>(T value, Action<T> action, Predicate<T> presenceValidator) {
            if (presenceValidator.Invoke(value)) {
                action.Invoke(value);
            }

            return value;
        }

        public static T IfPresent<T>(T value, Action<T> action) where T : class {
            return IfPresent(value, action, TypePredicates<T>.NotNull);
        }

        public static T IfAbsent<T>(T value, Action action, Predicate<T> presenceValidator) {
            if (!presenceValidator.Invoke(value)) {
                action.Invoke();
            }

            return value;
        }

        public static T IfAbsent<T>(T value, Action action) where T : class{
            return IfAbsent(value, action, TypePredicates<T>.NotNull);
        }

        public static T OrElseCompute<T>(T value, Func<T> provider, Predicate<T> presenceValidator) {
            return presenceValidator.Invoke(value) ? value : provider.Invoke();
        }

        public static T OrElseCompute<T>(T value, Func<T> provider) where T : class {
            return OrElseCompute(value, provider, TypePredicates<T>.NotNull);
        }

        public static T OrElseThrow<T>(T value, Func<Exception> provider, Predicate<T> presenceValidator) {
            return presenceValidator.Invoke(value) ? value : throw provider.Invoke();
        }

        public static T OrElseThrow<T>(T value, Func<Exception> provider) where T : class {
            return OrElseThrow(value, provider, TypePredicates<T>.NotNull);
        }
    }
}
