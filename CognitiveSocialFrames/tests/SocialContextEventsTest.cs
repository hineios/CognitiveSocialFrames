using Xunit;

namespace CognitiveSocialFrames.tests {
    public class SocialContextEventsTest {
        private SocialContext _socialContext;
        private IContextFeature _contextFeature;

        public SocialContextEventsTest() {
            _socialContext = new SocialContext();
            _contextFeature = new ValueContextFeature<string>("", "");
        }

        [Fact]
        public void AddedFeatureEventRaised() {
            bool raisedEvent = false;
            _socialContext.OnAddedFeaturesToSocialContext += features => { raisedEvent = true; };
            _socialContext.AddContextFeatures(_contextFeature);          
            Assert.True(raisedEvent);
        }
        
        [Fact]
        public void AddedFeatureAlreadyAddedEventRaised() {
            bool raisedEvent = false;
            _socialContext.AddContextFeatures(_contextFeature);
            _socialContext.OnAddedFeaturesToSocialContext += features => { raisedEvent = true; };
            _socialContext.AddContextFeatures(_contextFeature);
            Assert.False(raisedEvent);
        }
        
        [Fact]
        public void RemovedFeatureEventRaised() {
            bool raisedEvent = false;
            _socialContext.OnRemovedFeaturesFromSocialContext += features => { raisedEvent = true; };
            _socialContext.AddContextFeatures(_contextFeature);
            _socialContext.RemoveContextFeatures(_contextFeature);
            Assert.True(raisedEvent);
        }
        
        [Fact]
        public void RemovedFeatureNotExitentEventRaised() {
            bool raisedEvent = false;
            _socialContext.OnRemovedFeaturesFromSocialContext += features => { raisedEvent = true; };
            _socialContext.RemoveContextFeatures(_contextFeature);
            Assert.False(raisedEvent);
        }
        
        [Fact]
        public void SocialContextChangedWhenAddingFeatureEventRaised() {
            bool whenAddedRaisedEvent = false;
            _socialContext.OnSocialContextChanged += () => { whenAddedRaisedEvent = true; };
            _socialContext.AddContextFeatures(_contextFeature);
            Assert.True(whenAddedRaisedEvent);
        }
        
        [Fact]
        public void SocialContextChangedWhenAddingDuplicateFeatureEventRaised() {
            bool whenAddedRaisedEvent = false;
            _socialContext.AddContextFeatures(_contextFeature);
            _socialContext.OnSocialContextChanged += () => { whenAddedRaisedEvent = true; };
            _socialContext.AddContextFeatures(_contextFeature);
            Assert.False(whenAddedRaisedEvent);
        }
        
        [Fact]
        public void SocialContextChangedWhenRemovingFeatureEventRaised() {
            bool whenRemovedRaisedEvent = false;
            _socialContext.AddContextFeatures(_contextFeature);
            _socialContext.OnSocialContextChanged += () => { whenRemovedRaisedEvent = true; };
            _socialContext.RemoveContextFeatures(_contextFeature);            
            Assert.True(whenRemovedRaisedEvent);
        }
        
        [Fact]
        public void SocialContextChangedWhenRemovingNotExistentFeatureEventRaised() {
            bool whenRemovedRaisedEvent = false;
            _socialContext.OnSocialContextChanged += () => { whenRemovedRaisedEvent = true; };
            _socialContext.RemoveContextFeatures(_contextFeature);            
            Assert.False(whenRemovedRaisedEvent);
        }
    }
}