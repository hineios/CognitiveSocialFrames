using Xunit;

namespace CognitiveSocialFrames.tests {
    public class SocialContextManipulationTests {

        private SocialContext _socialContext;
        
        public SocialContextManipulationTests() {
            _socialContext = new SocialContext();
        }

        [Fact]
        public void StartsEmpty() {
            Assert.Empty(_socialContext.ContextFeatures);
        }
        
        [Fact]
        public void AddingFeature() {
            _socialContext.AddContextFeatures(new ValueContextFeature<string>("Type 1", "Entry 1"));
            Assert.Single(_socialContext.ContextFeatures);
        }
        
        [Fact]
        public void RemovingFeature() {
            IContextFeature contextFeature = new ValueContextFeature<string>("Type 1", "Entry 1");
            _socialContext.AddContextFeatures(contextFeature);
            _socialContext.RemoveContextFeatures(contextFeature);
            Assert.Empty(_socialContext.ContextFeatures);
        }
        
        [Fact]
        public void RemovingNonExistentFeature() {
            IContextFeature contextFeature = new ValueContextFeature<string>("Type 1", "Entry 1");
            _socialContext.RemoveContextFeatures(contextFeature);
            Assert.Empty(_socialContext.ContextFeatures);
        }
        
        [Fact]
        public void AddingSameFeatureTwice() {
            IContextFeature contextFeature = new ValueContextFeature<string>("Type 1", "Entry 1");
            _socialContext.AddContextFeatures(contextFeature);
            _socialContext.AddContextFeatures(contextFeature);
            Assert.Single(_socialContext.ContextFeatures);
        }

        [Fact]
        public void AddingClonedFeatureTwice() {
            IContextFeature contextFeature = new ValueContextFeature<string>("Type 1", "Entry 1");
            IContextFeature contextFeatureClone = new ValueContextFeature<string>("Type 1", "Entry 1");
            _socialContext.AddContextFeatures(contextFeature);
            _socialContext.AddContextFeatures(contextFeatureClone);
            Assert.Single(_socialContext.ContextFeatures);
        }
        
        [Fact]
        public void RemovingClonedFeature() {
            IContextFeature contextFeature = new ValueContextFeature<string>("Type 1", "Entry 1");
            IContextFeature contextFeatureClone = new ValueContextFeature<string>("Type 1", "Entry 1");
            _socialContext.AddContextFeatures(contextFeature);
            _socialContext.AddContextFeatures(contextFeatureClone);
            _socialContext.RemoveContextFeatures(contextFeatureClone);
            Assert.Empty(_socialContext.ContextFeatures);
        }
        
        [Fact]
        public void AddingAndRemovingDistinctFeatures() {
            IContextFeature contextFeature1 = new ValueContextFeature<string>("Type 1", "Entry 1");
            IContextFeature contextFeature2 = new ValueContextFeature<string>("Type 1", "Entry 2");
            _socialContext.AddContextFeatures(contextFeature1);
            _socialContext.AddContextFeatures(contextFeature2);
            _socialContext.RemoveContextFeatures(contextFeature1);
            Assert.Single(_socialContext.ContextFeatures);
        }

    }
}