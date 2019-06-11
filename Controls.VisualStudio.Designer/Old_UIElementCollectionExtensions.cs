using System.Windows;
using System.Windows.Controls;

namespace Controls.VisualStudio.Designer
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