using System;
using XFRun.UI.Droid.Renderers;

namespace XFRun.UI.Droid
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
