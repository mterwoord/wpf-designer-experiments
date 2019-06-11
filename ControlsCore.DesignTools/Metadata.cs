using System;
using System.Diagnostics;
using System.Threading;
using ControlsCore.DesignTools;
using Microsoft.VisualStudio.DesignTools.Extensibility.Features;
using Microsoft.VisualStudio.DesignTools.Extensibility.Metadata;

[assembly: ProvideMetadata(typeof(Metadata))]

namespace ControlsCore.DesignTools
{
    internal class Metadata : IProvideAttributeTable
    {
        public AttributeTable AttributeTable
        {
            get
            {
                var xBuilder = new AttributeTableBuilder();
                xBuilder.AddCustomAttributes("System.Windows.Controls.Button", new FeatureAttribute(typeof(UtilityAdornerProvider)));
                return xBuilder.CreateTable();
            }
        }
    }
}