// Edit Mode tests for procedural Grid mesh math (vertex and triangle counts).
// Run in Unity: Window > General > Test Runner > EditMode > Run All.
using NUnit.Framework;

namespace _3D_ASMR_Slice.Tests.EditMode
{
    public class GridMeshTests
    {
        [Test]
        public void GetExpectedVertexCount_MatchesGridFormula()
        {
            Assert.AreEqual(4, Grid.GetExpectedVertexCount(1, 1));   // (1+1)*(1+1)
            Assert.AreEqual(6, Grid.GetExpectedVertexCount(2, 1));   // (2+1)*(1+1)
            Assert.AreEqual(6, Grid.GetExpectedVertexCount(1, 2));
            Assert.AreEqual(12, Grid.GetExpectedVertexCount(2, 2));  // (2+1)*(2+1)
            Assert.AreEqual(100, Grid.GetExpectedVertexCount(9, 9)); // 10*10
        }

        [Test]
        public void GetExpectedTriangleCount_MatchesGridFormula()
        {
            // Each quad = 2 triangles = 6 indices.
            Assert.AreEqual(6, Grid.GetExpectedTriangleCount(1, 1));   // 1*1*6
            Assert.AreEqual(12, Grid.GetExpectedTriangleCount(2, 1));  // 2*1*6
            Assert.AreEqual(24, Grid.GetExpectedTriangleCount(2, 2));   // 2*2*6
            Assert.AreEqual(54, Grid.GetExpectedTriangleCount(3, 3));   // 3*3*6
        }

        [Test]
        public void VertexAndTriangleCount_ConsistentForTypicalSizes()
        {
            int x = 5, y = 5;
            int vertices = Grid.GetExpectedVertexCount(x, y);
            int triangleIndices = Grid.GetExpectedTriangleCount(x, y);
            Assert.AreEqual(36, vertices);
            Assert.AreEqual(150, triangleIndices);
            Assert.AreEqual(x * y * 6, triangleIndices);
        }
    }
}
