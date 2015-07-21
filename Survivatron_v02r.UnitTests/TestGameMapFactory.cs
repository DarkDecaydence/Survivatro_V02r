using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Survivatron_v02r.MapUtilities;


namespace Survivatron_v02r.UnitTests
{
    [TestClass]
    public class TestGameMapFactory
    {
        [TestMethod]
        public void TestConstructGameBlockDepth()
        {
            GameMapFactory gmf = new GameMapFactory();

            GameMapBlock<IGameMapBlock> gmb = gmf.ConstructGameBlock(1, 1, 0);
            GameMapSegment expectedSegment = new GameMapSegment();

            foreach (GameMapSegment curGms in gmb.Contents)
                CollectionAssert.AreEqual(expectedSegment.Contents, curGms.Contents);
        }
    }
}
