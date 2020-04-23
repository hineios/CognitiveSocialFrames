using Xunit;
using Xunit.Sdk;

namespace CognitiveSocialFrames.tests {
    public class ValueContextFeatureConstructionTests {

        private ValueContextFeature<string> _stringFeature;
        private ValueContextFeature<int> _intFeature;

        public ValueContextFeatureConstructionTests() {
            _stringFeature = new ValueContextFeature<string>("Type string", "1");
            _intFeature = new ValueContextFeature<int>("Type int", 1);
        }

        [Fact]
        public void StringFeatureType() {
            Assert.Equal(_stringFeature.Type, "Type string");
        }
        
        [Fact]
        public void IntFeatureType() {
            Assert.Equal(_intFeature.Type, "Type int");
        }
        
        [Fact]
        public void StringFeatureValue() {
            Assert.Equal(_stringFeature.Value, "1");
        }
        
        [Fact]
        public void IntFeatureValue() {
            Assert.Equal(_intFeature.Value, 1);
        }
        
    }
}