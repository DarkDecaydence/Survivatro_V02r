using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Survivatron_v02r.MapUtilities;

namespace Survivatron_v02r.UnitTests
{
    [TestClass]
    public class TestGameMapSegment
    {
        private long[] expectedLongArray = new long[] { -1, -1, -1, -1, -1, -1, -1, -1, -1 };

        [TestMethod]
        public void TestSegmentBaseConstruct()
        {
            GameMapSegment gms = new GameMapSegment(new Microsoft.Xna.Framework.Vector2(1, 1));
            long expectedResult = -1;

            foreach (long l in gms.Contents)
                Assert.AreEqual(expectedResult, l);
        }

        [TestMethod]
        public void TestSegmentNoArgConstruct()
        {
            GameMapSegment gms = new GameMapSegment();
            long[] expectedResult = expectedLongArray;

            CollectionAssert.AreEqual(expectedResult, gms.Contents);
        }
    }
}
