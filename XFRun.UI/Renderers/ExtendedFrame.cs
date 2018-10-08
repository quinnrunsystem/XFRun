using System;
using Xamarin.Forms;

namespace XFRun.UI.Forms.Renderers
{
    public class ExtendedFrame : Frame
    {
        public new Thickness Padding { get; set; } = 0;
        public int BorderThickness { get; set; }
        public ExtendedFrame()
        {
            base.Padding = this.Padding;
        }
    }
}
