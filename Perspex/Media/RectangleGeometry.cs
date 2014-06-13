﻿// -----------------------------------------------------------------------
// <copyright file="RectangleGeometry.cs" company="Steven Kirk">
// Copyright 2014 MIT Licence. See licence.md for more information.
// </copyright>
// -----------------------------------------------------------------------

namespace Perspex.Media
{
    using Perspex.Platform;
    using Splat;

    public class RectangleGeometry : Geometry
    {
        public RectangleGeometry(Rect rect)
        {
            IPlatformFactory factory = Locator.Current.GetService<IPlatformFactory>();
            IStreamGeometryImpl impl = factory.CreateStreamGeometry();

            using (IStreamGeometryContextImpl context = impl.Open())
            {
                context.BeginFigure(rect.TopLeft, true);
                context.LineTo(rect.TopRight);
                context.LineTo(rect.BottomRight);
                context.LineTo(rect.BottomLeft);
                context.EndFigure(true);
            }

            this.PlatformImpl = impl;
        }

        public override Rect Bounds
        {
            get { return this.PlatformImpl.Bounds; }
        }
    }
}
