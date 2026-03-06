// Edit Mode tests for CubeSphere procedural vertex count formula.
// Run in Unity: Window > General > Test Runner > EditMode > Run All.
using NUnit.Framework;

namespace _3D_ASMR_Slice.Tests.EditMode
{
    public class CubeSphereVertexCountTests
    {
        [Test]
        public void GetExpectedVertexCount_MatchesCubeSphereFormula()
        {
            // gridSize 1: 8 corners + 0 edge + 0 face = 8
            Assert.AreEqual(8, CubeSphere.GetExpectedVertexCount(1));

            // gridSize 2: 8 + (6-3)*4 edge + 3*(1*1)*2 face = 8 + 12 + 6 = 26
            Assert.AreEqual(26, CubeSphere.GetExpectedVertexCount(2));

            // gridSize 3: 8 + (9-3)*4 + 3*(2*2)*2 = 8 + 24 + 24 = 56
            Assert.AreEqual(56, CubeSphere.GetExpectedVertexCount(3));
        }

        [Test]
        public void GetExpectedVertexCount_IncreasesWithGridSize()
        {
            int prev = CubeSphere.GetExpectedVertexCount(1);
            for (int n = 2; n <= 5; n++)
            {
                int current = CubeSphere.GetExpectedVertexCount(n);
                Assert.Greater(current, prev, $"Vertex count for gridSize={n} should be greater than {n - 1}");
                prev = current;
            }
        }
    }
}
