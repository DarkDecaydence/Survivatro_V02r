using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Survivatron_v02r.MapUtilities
{
    public class GameMapSegment : GameMapBlock<long>
    {
        public GameMapSegment(Vector2 dimensions)
            : base(dimensions)
        {
            for (int i = 0; i < dimensions.X * dimensions.Y; i++)
                Contents.Add(-1);
        }

        public GameMapSegment()
            : this(new Vector2(3, 3))
        { }
    }
}
