using System.ComponentModel.DataAnnotations;
using Xunit;

namespace CognitiveSocialFrames.tests {
    public class ValueContextFeatureEqualityTests {

        private ValueContextFeature<string> _stringFeature1,_stringFeature1Clone,_stringFeature2,_stringFeature3;
        private ValueContextFeature<int> _intFeature1,_intFeature1Clone,_intFeature2,_intFeature3;

        public ValueContextFeatureEqualityTests() {
            _stringFeature1 = new ValueContextFeature<string>("Type1" , "1");
            _stringFeature1Clone = new ValueContextFeature<string>("Type1" , "1");
            _stringFeature2 = new ValueContextFeature<string>("Type1" , "2");
            _stringFeature3 = new ValueContextFeature<string>("Type2" , "1");
            _intFeature1 = new ValueContextFeature<int>("Type1", 1);
            _intFeature1Clone = new ValueContextFeature<int>("Type1", 1);
            _intFeature2 = new ValueContextFeature<int>("Type1", 2);
            _intFeature3 = new ValueContextFeature<int>("Type2", 1);
        }
        
        //String Type
        
        [Fact]
        public void StringFeatureEqualTypeDifferentValue() {
            Assert.NotEqual(_stringFeature1, _stringFeature2);
        }
        
        [Fact]
        public void StringFeatureDifferentTypeEqualValue() {
            Assert.NotEqual(_stringFeature1, _stringFeature3);
        }
        
        [Fact]
        public void SameStringFeatureEqual() {
            Assert.Same(_stringFeature1, _stringFeature1);
            Assert.Equal(_stringFeature1, _stringFeature1);
        }
        
        [Fact]
        public void ClonedStringFeatureEqual() {
            Assert.NotSame(_stringFeature1, _stringFeature1Clone);
            Assert.Equal(_stringFeature1, _stringFeature1Clone);
        }
        
        //Int Type
        
        [Fact]
        public void IntFeatureEqualTypeDifferentValue() {
            Assert.NotEqual(_intFeature1, _intFeature2);
        }
        
        [Fact]
        public void IntFeatureDifferentTypeEqualValue() {
            Assert.NotEqual(_intFeature1, _intFeature3);
        }
        
        [Fact]
        public void SameIntFeatureEqual() {
            Assert.Same(_intFeature1, _intFeature1);
            Assert.Equal(_intFeature1, _intFeature1);
        }
        
        [Fact]
        public void ClonedIntFeatureEqual() {
            Assert.NotSame(_intFeature1, _intFeature1Clone);
            Assert.Equal(_intFeature1,_intFeature1Clone);
        }
        
        //Mixed Types
        
        [Fact]
        public void StringIntFeatureNotEqual() {
            Assert.False(_intFeature1.Equals(_stringFeature1));
        }
        
    }
}