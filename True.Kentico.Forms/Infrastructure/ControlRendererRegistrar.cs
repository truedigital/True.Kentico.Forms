using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.Renderers;

namespace True.Kentico.Forms.Infrastructure
{
    public static class ControlRendererRegistrar
    {
        public static Dictionary<ControlType, IControlRenderer> ControlRenderers { get; set; }

        public static void InitialiseFormControls()
        {
            ControlRenderers = new Dictionary<ControlType, IControlRenderer>
            {
                {ControlType.Calendar, new DefaultCalendarControlRenderer()}
            };
        }

        public static void RegisterCustomRenderer(ControlType controlType, IControlRenderer renderer)
        {
            if (ControlRenderers == null)
            {
                InitialiseFormControls();
            }
            ControlRenderers[controlType] = renderer;
        }
    }
}
