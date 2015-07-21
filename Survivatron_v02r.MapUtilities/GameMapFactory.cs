using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survivatron_v02r.MapUtilities
{
    public class GameMapFactory
    {
        /*
         * The factory constructs a quadratic GameMap, using the methods specified below.
         * Map dimensions are a consequence of treeDepth as follows:
         * *    Depth -- MapWidth
         * *    0     -- 24 * width
         * *    1     -- 72 * width
         * *    2     -- 216 * width
         * *    3     -- 648 * width
         * *    etc.
         */

        public GameMapBlock<IGameMapBlock> ConstructGameBlock(int blockWidth, int blockHeight, int currentDepth, int treeDepth)
        {
            GameMapBlock<IGameMapBlock> currentBlock = new GameMapBlock<IGameMapBlock>(new Microsoft.Xna.Framework.Vector2(blockWidth, blockHeight));

            for (int i = 0; i < blockWidth * blockHeight; i++)
            {
                if (currentDepth == treeDepth)
                { currentBlock.AddContentElement(new GameMapSegment()); }
                else
                { currentBlock.AddContentElement(ConstructGameBlock(blockWidth, blockHeight, currentDepth + 1, treeDepth)); }
            }

            return currentBlock;
        }

        public GameMapBlock<IGameMapBlock> ConstructGameBlock(int blockWidth, int blockHeight, int treeDepth)
        { return ConstructGameBlock(blockWidth, blockHeight, 0, treeDepth); }
    }
}
