using System.Windows;
using System.Windows.Controls;

namespace ControlsCore.DesignTools
{
    public static class UIElementCollectionExtensions
    {
        public static void AddIfNotNull(this UIElementCollection aThis, UIElement item)
        {
            if (item != null)
            {
                aThis.Add(item);
            }
        }
    }
}