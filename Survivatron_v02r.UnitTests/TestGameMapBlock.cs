using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Survivatron_v02r.MapUtilities;

namespace Survivatron_v02r.UnitTests
{
    [TestClass]
    public class TestGameMapBlock
    {
        [TestMethod]
        public void TestBlockBase()
        {
            GameMapBlock<long> testBlock = new GameMapBlock<long>(new Vector2(2, 2));
            Vector2 expectedDimensions = new Vector2(2, 2);

            Assert.AreEqual(expectedDimensions, testBlock.Dimensions);
            CollectionAssert.AreEqual(new List<long>(), (List<long>)testBlock.Contents);
        }

        [TestMethod]
        public void TestBlockNullVector()
        {
            GameMapBlock<long> testBlock = new GameMapBlock<long>(new Vector2(0, 0));
            Vector2 expectedDimensions = new Vector2(1, 1);

            Assert.AreEqual(expectedDimensions, testBlock.Dimensions);
        }

        [TestMethod]
        public void TestBlockNegativeVector()
        {
            GameMapBlock<long> testBlock = new GameMapBlock<long>(new Vector2(-2, -2));
            Assert.AreEqual(new Vector2(2, 2), testBlock.Dimensions);
        }

        [TestMethod]
        public void TestCropBase()
        {
            GameMapBlock<long> testBlock = new GameMapBlock<long>(new Vector2(2,2));
            for (int i = 0; i < 4; i++)
                testBlock.AddContentElement(-1);

            object croppedResults = testBlock.Crop(new Rectangle(0,0,2,2));

            CollectionAssert.AreEqual((ICollection)testBlock.Contents, (croppedResults as List<long>));
        }

        [TestMethod]
        public void TestCropNullRectangle()
        {
            GameMapBlock<long> testBlock = new GameMapBlock<long>(new Vector2(0, 0));
            testBlock.AddContentElement(-1);
            long[] expectedResult = new long[] { -1 };

            long[] testCrop = (testBlock.Crop(new Rectangle(0, 0, 0, 0)) as List<long>).ToArray();

            CollectionAssert.AreEqual(expectedResult, testCrop);
        }

        [TestMethod]
        public void TestCropNegativeRectangle()
        {
            GameMapBlock<long> testBlock = new GameMapBlock<long>(new Vector2(2, 2));
            for (int i = 0; i < testBlock.Dimensions.X * testBlock.Dimensions.Y; i++)
                testBlock.AddContentElement(-1);

            List<long> croppedContents = (List<long>)testBlock.Crop(new Rectangle(0, 0, -2, -2));

            long[] expectedResult = new long[] { -1, -1, -1, -1 };

            CollectionAssert.AreEqual(expectedResult, croppedContents.ToArray());
        }
    }
}
