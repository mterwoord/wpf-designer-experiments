# wpf-designer-experiments

This sample solution shows designer extensions for WPF. 

Right now, we need to have .VisualStudio.Designer.dll files in the same directory as a reference file. Next objective is to move that to an extension.

# How do I see it?

Start off by building the solution. Next, open MainWindow.xaml from the TestProject project in the designer. After selecting the window, you will see a expander right next to the upper-right corner of the window.

# .NET Core WPF

A good begin of things works for the new .NET Core WPF designer as well.
To test: 

1. Open the solution, do a full buid
2. Close visual studio
3. Copy the `ControlsCore.DesignTools.dll` and `ControlsCore.DesignTools.pdb` files from `ControlsCore\bin\Debug\Design\net462` to `ControlsCore\bin\Debug\netcoreapp3.0`.
4. Open the solution again
5. Open TestProjectNet\MainWindow. 
6. Select the Button, and see the expander appear to the right of the button.