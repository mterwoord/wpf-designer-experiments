using System;
using System.Text;
using System.Windows;
using Microsoft.VisualStudio.DesignTools.Extensibility;
using Microsoft.VisualStudio.DesignTools.Extensibility.Metadata;
using Microsoft.VisualStudio.DesignTools.Extensibility.Model;
using Microsoft.VisualStudio.DesignTools.Extensibility.Services;

namespace ControlsCore.DesignTools.Tools
{
    /// <summary>
    /// Interaction logic for SizeToParentControl.xaml
    /// </summary>
    public partial class SizeToParentControl
    {
        public SizeToParentControl()
        {
            InitializeComponent();
        }

        private ModelItem mControlModel;
        public event Action AfterEdit;

        internal static UIElement CreateIfNeeded(EditingContext context, ModelItem controlModel, Action afterEdit)
        {
            var xSB = new StringBuilder();
            var xPropWidth = controlModel.Properties["Width"];
            var xPropHeight = controlModel.Properties["Height"];
            if (xPropWidth.IsSet && xPropHeight.IsSet)
            {
                var xResult = new SizeToParentControl();
                xResult.mControlModel = controlModel;
                xResult.AfterEdit += afterEdit;
                return xResult;
            }
            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var xEditScope = mControlModel.BeginEdit())
            {
                var buttonType = ModelFactory.ResolveType(mControlModel.Context, new TypeIdentifier("System.Windows.Controls.Button"));

                var modelService  = mControlModel.Context.Services.GetRequiredService<ModelService>();
                var buttonItem = ModelFactory.CreateItem(mControlModel.Context, buttonType);
                var allButtons = modelService.Find(buttonItem,
                                                   t => true);
                
                mControlModel.Properties["Height"].ClearValue();
                mControlModel.Properties["Width"].ClearValue();
                mControlModel.Properties["Margin"].ClearValue();
                mControlModel.Properties["HorizontalAlignment"].ClearValue();
                mControlModel.Properties["VerticalAlignment"].ClearValue();

                xEditScope.Complete();
            }

            if (AfterEdit != null)
            {
                AfterEdit();
                AfterEdit = null;
            }
        }
    }
}
