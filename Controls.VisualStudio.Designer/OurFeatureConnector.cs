using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Services;

namespace Controls.VisualStudio.Designer
{
    [RequiresService(typeof(ModelService))]
    public class OurFeatureConnector : FeatureConnector<UtilityAdornerProvider>
    {
        public OurFeatureConnector(FeatureManager manager)
            : base(manager)
        {
        }
    }
}