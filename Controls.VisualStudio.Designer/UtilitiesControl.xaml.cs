using System.Windows;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Model;

namespace Controls.VisualStudio.Designer
{
    /// <summary>
    /// Interaction logic for UtilitiesControl.xaml
    /// </summary>
    public partial class UtilitiesControl
    {
        private EditingContext mContext;

        public UtilitiesControl(EditingContext context)
        {
            InitializeComponent();
            mContext = context;
        }

        public ModelItem ControlModel
        {
            get;
            set;
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            stackPanel.Children.Clear();

            if (IsExpanded)
            {
                if (ControlModel == null)
                {
                    return;
                }

                stackPanel.Children.AddIfNotNull(Tools.SizeToParentControl.CreateIfNeeded(mContext, ControlModel, AfterEdit));
                stackPanel.Children.AddIfNotNull(Tools.SetDesignDataTypeControl.CreateIfNeeded(mContext, ControlModel, AfterEdit));
                stackPanel.Children.AddIfNotNull(Tools.SetMinSizeToDesignerSizeControl.CreateIfNeeded(mContext, ControlModel, AfterEdit));
            }
        }

        private void AfterEdit()
        {
            IsExpanded = false;
        }
    }
}