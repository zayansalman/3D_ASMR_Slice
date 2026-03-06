// Edit Mode tests for MeshDeformer spring-damper physics (extracted SpringStep).
// Run in Unity: Window > General > Test Runner > EditMode > Run All.
using NUnit.Framework;
using UnityEngine;

namespace _3D_ASMR_Slice.Tests.EditMode
{
    public class MeshDeformerSpringTests
    {
        [Test]
        public void SpringStep_ReducesVelocityWithDamping()
        {
            var displacement = Vector3.zero;
            var velocity = new Vector3(10f, 0f, 0f);
            float springForce = 20f;
            float damping = 5f;
            float dt = 0.02f;

            MeshDeformer.SpringStep(ref displacement, ref velocity, springForce, damping, dt);

            // Velocity should be scaled by (1 - damping*dt); no spring contribution when displacement is zero.
            float expectedScale = Mathf.Clamp01(1f - damping * dt);
            Assert.AreEqual(10f * expectedScale, velocity.x, 0.001f);
            Assert.AreEqual(0f, velocity.y, 0.001f);
            Assert.AreEqual(0f, velocity.z, 0.001f);
        }

        [Test]
        public void SpringStep_SpringPullsBackTowardZero()
        {
            var displacement = new Vector3(1f, 0f, 0f);
            var velocity = Vector3.zero;
            float springForce = 20f;
            float damping = 2f;
            float dt = 0.02f;

            MeshDeformer.SpringStep(ref displacement, ref velocity, springForce, damping, dt);

            // velocity -= displacement * springForce * dt  => velocity = -1 * 20 * 0.02 = -0.4
            // then damped
            Assert.Less(velocity.x, 0f, "Spring should produce negative velocity (pull back)");
            Assert.AreEqual(0f, velocity.y, 0.001f);
            Assert.AreEqual(0f, velocity.z, 0.001f);
        }

        [Test]
        public void SpringStep_ZeroDampingLeavesSpringOnly()
        {
            var displacement = new Vector3(1f, 0f, 0f);
            var velocity = Vector3.zero;
            float springForce = 10f;
            float damping = 0f;
            float dt = 0.1f;

            MeshDeformer.SpringStep(ref displacement, ref velocity, springForce, damping, dt);

            // velocity = 0 - displacement * springForce * dt = -1 * 10 * 0.1 = -1
            Assert.AreEqual(-1f, velocity.x, 0.001f);
        }
    }
}
