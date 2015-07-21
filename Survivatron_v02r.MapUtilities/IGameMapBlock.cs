using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Survivatron_v02r.MapUtilities
{
    public interface IGameMapBlock
    {
        IList Crop(Rectangle cropRect);
    }
}
