using CognitiveSocialFrames;
using Xunit;

namespace CognitiveSocialFrames.tests {
    public class FrameCreationTest {

        private SocialContext _context;
        private Frame _frame;

        public FrameCreationTest() {
            _frame = new Frame();
            _context = new SocialContext();
        }
        
        [Fact]
        public void EmptyFrameCreation() {
            
        }
        
        [Fact]
        public void EmptyFrameAlwaysSalient() {
            Assert.True(_frame.TestSalience(_context));
        }
    }
}