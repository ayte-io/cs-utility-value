namespace Ayte.Utility.Value.API {
    public interface IValue<out T> {
        T Value { get; }
        bool HasValue { get; }
        T OrDefault { get; }
    }
}
