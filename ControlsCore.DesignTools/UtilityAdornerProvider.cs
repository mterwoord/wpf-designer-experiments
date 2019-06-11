using System;
using System.IO;
using Microsoft.VisualStudio.DesignTools.Extensibility.Features;
using Microsoft.VisualStudio.DesignTools.Extensibility.Interaction;
using Microsoft.VisualStudio.DesignTools.Extensibility.Model;
using Microsoft.VisualStudio.DesignTools.Extensibility.Policies;

namespace ControlsCore.DesignTools
{
    //[FeatureConnector(typeof(OurFeatureConnector))]
    [UsesItemPolicy(typeof(PrimarySelectionPolicy))]
    public class UtilityAdornerProvider : PrimarySelectionAdornerProvider
    {
        private UtilitiesControl mButton;
        private AdornerPanel     mAdornerPanel;
        private ModelItem        mAdornedControlModel;

        public UtilityAdornerProvider()
        {
            ;
        }

        protected override void Activate(ModelItem item)
        {
            EnsurePanelCreated();
            mAdornedControlModel = item;
            if (mButton != null)
            {
                mButton.ControlModel = item;
                mButton.IsExpanded   = false;

                AdornerPanel.SetAdornerHorizontalAlignment(mButton, AdornerHorizontalAlignment.OutsideRight);
                AdornerPanel.SetAdornerVerticalAlignment(mButton, AdornerVerticalAlignment.Top);
            }

            base.Activate(item);
        }

        private void EnsurePanelCreated()
        {
            if (Panel == null)
            {
                throw new InvalidOperationException("Somehow, the panel wasn't created!");
            }
        }

        // The Panel utility property demand-creates the
        // adorner panel and adds it to the provider's
        // Adorners collection.
        private AdornerPanel Panel
        {
            get
            {
                if (this.mAdornerPanel == null)
                {
                    mAdornerPanel = new AdornerPanel();
                    try
                    {
                        mButton = new UtilitiesControl(Context);

                        // Add the adorner to the adorner panel.
                        mAdornerPanel.Children.Add(mButton);
                    }
                    catch
                    {
                    }

                    // Add the panel to the Adorners collection.
                    Adorners.Add(mAdornerPanel);
                }

                return this.mAdornerPanel;
            }
        }
    }
}