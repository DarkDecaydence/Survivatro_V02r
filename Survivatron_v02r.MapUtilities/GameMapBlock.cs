using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Survivatron_v02r.MapUtilities
{
    public class GameMapBlock<T> : IGameMapBlock
    {
        // All GameMapBlocks are assumed to be in row-major order.
        private Vector2 _contentDimensions;
        private List<T> _blockContents;

        public Vector2 Dimensions
        { 
            get { return _contentDimensions; }
            private set { _contentDimensions = value; }
        }
        public List<T> Contents
        {
            get { return _blockContents; }
            private set { _blockContents = value; }
        }

        public GameMapBlock(Vector2 dimensions)
        {
            Contents = new List<T>();
            if ((int)dimensions.X == 0 || (int)dimensions.Y == 0) 
                sanitizeVector(ref dimensions);
            Dimensions = new Vector2(Math.Abs(dimensions.X), Math.Abs(dimensions.Y));
        }

        public void AddContentElement(T element)
        { _blockContents.Add(element); }

        public IList Crop(Rectangle cropRect)
        {
            int idx = -1;
            List<T> croppedElements = new List<T>();
            sanitizeCrop(ref cropRect);

            for (int i = cropRect.Y; i < cropRect.Y + cropRect.Height; i++)
            {
                for (int j = cropRect.X; j < cropRect.X + cropRect.Width; j++)
                {
                    idx = (int)Dimensions.Y * i + j;
                    if (_blockContents.Count > idx)
                    { croppedElements.Add(_blockContents[idx]); }
                    else continue;
                }
            }

            if (croppedElements.Count < 1)
            { throw new ArgumentException("Crop returned less than 1 element. Make sure that crop uses valid rectangle"); }

            return croppedElements;
        }


        private void sanitizeCrop(ref Rectangle cropRect)
        {
            cropRect.X = cropRect.X < 0 ? 0 : cropRect.X;
            cropRect.Y = cropRect.Y < 0 ? 0 : cropRect.Y;
            cropRect.Width = cropRect.Width == 0 ? 1 : Math.Abs(cropRect.Width);
            cropRect.Height = cropRect.Height == 0 ? 1 : Math.Abs(cropRect.Height);
        }

        private void sanitizeVector(ref Vector2 refVector)
        {
            refVector.X = refVector.X == 0 ? 1 : Math.Abs(refVector.X);
            refVector.Y = refVector.Y == 0 ? 1 : Math.Abs(refVector.Y);
        }
    }
}
