using Microsoft.Windows.Design.Metadata;

namespace Controls.VisualStudio.Designer
{
    internal static class OurPlatformTypes
    {
        private const string BlendNamespace = "http://schemas.microsoft.com/expression/blend/2008";
        public static class DesignProperties
        {
            public static readonly TypeIdentifier TypeIdentifier = new TypeIdentifier(BlendNamespace, "DesignProperties");
            public static readonly PropertyIdentifier DesignDataContextProperty = new PropertyIdentifier(TypeIdentifier, "DataContext");
            public static readonly PropertyIdentifier DesignHeightProperty = new PropertyIdentifier(TypeIdentifier, "DesignHeight");
            public static readonly PropertyIdentifier DesignWidthProperty = new PropertyIdentifier(TypeIdentifier, "DesignWidth");
        }

        public static readonly TypeIdentifier DesignInstance = new TypeIdentifier(BlendNamespace, "DesignInstance");
        public static readonly PropertyIdentifier TypeProperty = new PropertyIdentifier(DesignInstance, "Type");
        public static readonly PropertyIdentifier IsDesignTimeCreatableProperty = new PropertyIdentifier(DesignInstance, "IsDesignTimeCreatable");

        private const string XamlNamespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
        public static readonly TypeIdentifier FrameworkElement = new TypeIdentifier(XamlNamespace, "FrameworkElement");
        public static readonly PropertyIdentifier DataContextProperty = new PropertyIdentifier(FrameworkElement, "DataContext");

        public static class Control
        {
            public static readonly TypeIdentifier TypeIdentifier = new TypeIdentifier(XamlNamespace, "Control");
            public static readonly PropertyIdentifier MinHeightProperty = new PropertyIdentifier(TypeIdentifier, "MinHeight");
            public static readonly PropertyIdentifier MinWidthProperty = new PropertyIdentifier(TypeIdentifier, "MinWidth");
                       
        }
    }
}