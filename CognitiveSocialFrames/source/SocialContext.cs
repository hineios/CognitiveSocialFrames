using System.Collections.Generic;

namespace CognitiveSocialFrames {
    public class SocialContext {

        public event RemovedFeaturesFromSocialContext OnRemovedFeaturesFromSocialContext;
        public delegate void RemovedFeaturesFromSocialContext(List<IContextFeature> removedFeatures);

        public event AddedFeaturesToSocialContext OnAddedFeaturesToSocialContext; 
        public delegate void AddedFeaturesToSocialContext(List<IContextFeature> addedFeatures);

        public event SocialContextChanged OnSocialContextChanged;
        public delegate void SocialContextChanged();
        
        public List<IContextFeature> ContextFeatures { get; private set; }
            
        public SocialContext() {
            ContextFeatures = new List<IContextFeature>();
        }

        public void AddContextFeatures(IContextFeature contextFeatureToAdd) {
            
            if (ContextFeatures.Contains(contextFeatureToAdd)) {
                //TODO: Show some warning (not an error)
                return;
            }
            
            ContextFeatures.Add(contextFeatureToAdd);
            
            OnAddedFeaturesToSocialContext?.Invoke(new List<IContextFeature>(){contextFeatureToAdd});
            OnSocialContextChanged?.Invoke();
        }

        public void RemoveContextFeatures(IContextFeature contextFeatureToRemove) {

            if (!ContextFeatures.Contains(contextFeatureToRemove)) {
                //TODO: Show some warning (not an error)
                return;
            }

            ContextFeatures.Remove(contextFeatureToRemove);
            
            OnRemovedFeaturesFromSocialContext?.Invoke(new List<IContextFeature>() {contextFeatureToRemove});
            OnSocialContextChanged?.Invoke();
        }
        
    }
}