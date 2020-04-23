namespace CognitiveSocialFrames {
    public class ValueContextFeature<T> : IContextFeature{

        public string Type { get; private set; }
        
        public T Value { get; private set; }

        public ValueContextFeature(string type, T value) {
            this.Type = type;
            this.Value = value;
        }

        public override bool Equals(object obj) {

            if (!(obj is ValueContextFeature<T>)) {
                return false;
            }
            ValueContextFeature<T> valueObj = (ValueContextFeature<T>) obj;
            
            return valueObj.Type.Equals(Type) && valueObj.Value.Equals(Value);
        }

        public override int GetHashCode() {
            return Type.GetHashCode()/2 + Value.GetHashCode()/2;
        }
    }
}