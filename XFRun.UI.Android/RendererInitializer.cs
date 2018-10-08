using System;
using XFRun.UI.Android.Renderers;

namespace XFRun.UI.Android
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
