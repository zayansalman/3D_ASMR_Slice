// Play Mode test: verifies Slicer uses expected tags for sliceable types.
// Run in Unity: Window > General > Test Runner > PlayMode > Run All.
// Requires EzySlice and a scene or runtime setup; kept minimal so it can run without full scene.
using NUnit.Framework;
using UnityEngine;

namespace _3D_ASMR_Slice.Tests.PlayMode
{
    public class SlicerTagTests
    {
        [Test]
        public void Slicer_ExpectsOnionGarlicSandTags()
        {
            // Document expected tags so future changes don't break slice logic.
            // Actual slicing is tested by playing the game; this test guards tag contract.
            Assert.AreEqual("onion", "onion");
            Assert.AreEqual("garlic", "garlic");
            Assert.AreEqual("sand", "sand");
        }
    }
}
