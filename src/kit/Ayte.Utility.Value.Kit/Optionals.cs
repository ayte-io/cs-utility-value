using System;
using Ayte.Utility.Value.API;

namespace Ayte.Utility.Value.Kit {
    public static class Optionals {
        public static IOptional<T> Empty<T>() {
            return new Container<T>(default, false);
        }

        public static IOptional<T> Of<T>(T value) {
            return new Container<T>(value, true);
        }

        public static IOptional<T> OfIndeterminate<T>(T value, Predicate<T> presenceValidator) {
            return presenceValidator.Invoke(value) ? Of(value) : Empty<T>();
        }

        public static IOptional<T> OfNullable<T>(T value) where T : class {
            return OfIndeterminate(value, TypePredicates<T>.NotNull);
        }
    }
}
