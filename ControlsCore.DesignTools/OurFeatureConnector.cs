using Microsoft.VisualStudio.DesignTools.Extensibility;
using Microsoft.VisualStudio.DesignTools.Extensibility.Features;
using Microsoft.VisualStudio.DesignTools.Extensibility.Services;

namespace ControlsCore.DesignTools
{
    [RequiresService(typeof(ModelService))]
    public class OurFeatureConnector : FeatureConnector<UtilityAdornerProvider>
    {
        public OurFeatureConnector(FeatureManager manager) : base(manager)
        {
        }
    }
}