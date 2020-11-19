using System;

namespace Ayte.Utility.Value.Kit {
    public static class TypePredicates<T> {
        public static readonly Predicate<T> NotNull = x => x != null;
    }
}
