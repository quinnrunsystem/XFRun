using System;
using XFRun.UI.iOS.Renderers;

namespace XFRun.UI.iOS
{
    public class RendererInitializer
    {
        public RendererInitializer()
        {
        }

        public static void Init()
        {
            BorderlessEntryRenderer.Init();
            ExtendedFrameRenderer.Init();
            RoundedCornerViewRenderer.Init();
        }
    }
}
