using System.Windows;
using Controls.VisualStudio.Designer;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Metadata;

[assembly: ProvideMetadata(typeof(Metadata))]

namespace Controls.VisualStudio.Designer
{
    internal class Metadata : IProvideAttributeTable
    {
        public AttributeTable AttributeTable
        {
            get
            {
                var xBuilder = new AttributeTableBuilder();
                xBuilder.AddCustomAttributes(typeof(UIElement), new FeatureAttribute(typeof(UtilityAdornerProvider)));
                return xBuilder.CreateTable();
            }
        }
    }
}