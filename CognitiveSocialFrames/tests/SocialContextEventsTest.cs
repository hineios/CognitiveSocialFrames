using System;
using System.Collections.Generic;
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
            bool WhenAddedRaisedEvent = false;
            _socialContext.OnSocialContextChanged += () => { WhenAddedRaisedEvent = true; };
            _socialContext.AddContextFeatures(_contextFeature);
            Assert.True(WhenAddedRaisedEvent);
        }
        
        [Fact]
        public void SocialContextChangedWhenAddingDuplicateFeatureEventRaised() {
            bool WhenAddedRaisedEvent = false;
            _socialContext.AddContextFeatures(_contextFeature);
            _socialContext.OnSocialContextChanged += () => { WhenAddedRaisedEvent = true; };
            _socialContext.AddContextFeatures(_contextFeature);
            Assert.False(WhenAddedRaisedEvent);
        }
        
        [Fact]
        public void SocialContextChangedWhenRemovingFeatureEventRaised() {
            bool WhenRemovedRaisedEvent = false;
            _socialContext.AddContextFeatures(_contextFeature);
            _socialContext.OnSocialContextChanged += () => { WhenRemovedRaisedEvent = true; };
            _socialContext.RemoveContextFeatures(_contextFeature);            
            Assert.True(WhenRemovedRaisedEvent);
        }
        
        [Fact]
        public void SocialContextChangedWhenRemovingNotExistentFeatureEventRaised() {
            bool WhenRemovedRaisedEvent = false;
            _socialContext.OnSocialContextChanged += () => { WhenRemovedRaisedEvent = true; };
            _socialContext.RemoveContextFeatures(_contextFeature);            
            Assert.False(WhenRemovedRaisedEvent);
        }
    }
}