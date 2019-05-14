using System;
using System.Windows;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Model;

namespace Controls.VisualStudio.Designer.Tools
{
    /// <summary>
    /// Interaction logic for SetMinSizeToDesignerSizeControl.xaml
    /// </summary>
    public partial class SetMinSizeToDesignerSizeControl
    {
        public SetMinSizeToDesignerSizeControl()
        {
            InitializeComponent();
        }

        private ModelItem mDesignerWidth;
        private ModelItem mDesignerHeight;
        private ModelProperty mMinHeightProp;
        private ModelProperty mMinWidthProp;

        internal static UIElement CreateIfNeeded(EditingContext editingContext, ModelItem controlModel, Action afterEdit)
        {

            var xPropWidth = controlModel.Properties[OurPlatformTypes.DesignProperties.DesignWidthProperty];
            var xPropHeight = controlModel.Properties[OurPlatformTypes.DesignProperties.DesignHeightProperty];
            if (xPropWidth == null || xPropHeight == null)
            {
                return null;
            }

            var xDesignerWidth = xPropWidth.Value;
            var xDesignerHeight = xPropHeight.Value;

            var xMinHeightProp = controlModel.Properties[OurPlatformTypes.Control.MinHeightProperty];
            var xMinWidthProp = controlModel.Properties[OurPlatformTypes.Control.MinWidthProperty];

            return new SetMinSizeToDesignerSizeControl
                       {
                           //AfterEdit = afterEdit,
                           //mControlModel = controlModel,
                           //mEditingContext = editingContext,
                           mDesignerHeight = xDesignerHeight,
                           mDesignerWidth = xDesignerWidth,
                           mMinHeightProp = xMinHeightProp,
                           mMinWidthProp = xMinWidthProp
                       };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mMinHeightProp.SetValue(mDesignerHeight.GetCurrentValue());
            mMinWidthProp.SetValue(mDesignerWidth.GetCurrentValue());
        }
    }
}
