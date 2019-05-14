using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Model;
using MessageBox = System.Windows.MessageBox;
using Path = System.IO.Path;
using UserControl = System.Windows.Controls.UserControl;

namespace Controls.VisualStudio.Designer.Tools
{
    /// <summary>
    /// Interaction logic for SetDesignDataTypeControl.xaml
    /// </summary>
    public partial class SetDesignDataTypeControl : UserControl
    {
        public SetDesignDataTypeControl()
        {
            InitializeComponent();
        }

        private Action AfterEdit;
        private Type mDataContextType;
        private ModelItem mControlModel;
        private EditingContext mEditingContext;

        internal static UIElement CreateIfNeeded(EditingContext editingContext, ModelItem controlModel, Action afterEdit)
        {
            return new SetDesignDataTypeControl
               {
                   AfterEdit = afterEdit,
                   mControlModel = controlModel,
                   mEditingContext = editingContext
               };
            return null;
        }

        private static string GetPath(EditingContext context)
        {
            var xType = context.GetType();
            var xProp = xType.GetField("path", BindingFlags.Public|BindingFlags.NonPublic | BindingFlags.Instance);
            if (xProp == null)
            {
                throw new Exception("path field not found!");
            }
            return xProp.GetValue(context) as string;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var xRefs = mEditingContext.Items.GetValue<AssemblyReferences>();
            dynamic xDynContext = mEditingContext;
            var xPath = GetPath(mEditingContext);
            string xBinPath = null;

            #region Find bin/Debug dir

            while (xBinPath == null && xPath != null)
            {
                if (Directory.Exists(Path.Combine(xPath, "bin\\Debug")))
                {
                    xBinPath = Path.Combine(xPath, "bin\\Debug");
                }
                else
                {
                    xPath = Path.GetDirectoryName(xPath);
                }
            }

            #endregion Find bin/Debug dir

            if (xBinPath == null)
            {
                MessageBox.Show("Unable to find bin\\Debug folder!");
                return;
            }

            var xLoaded = new List<Assembly>();

            foreach (var xAsmRef in xRefs.ReferencedAssemblies)
            {
                try
                {
                    var xFile = Path.Combine(xBinPath, xAsmRef.Name);
                    Assembly xAsm= AppDomain.CurrentDomain.GetAssemblies().Where(i => i.FullName == xAsmRef.FullName).SingleOrDefault();
                    if (xAsm == null)
                    {
                        if (File.Exists(xFile + ".dll"))
                        {
                            xAsm = Assembly.ReflectionOnlyLoadFrom(xFile + ".dll");
                        }
                        else if (File.Exists(xFile + ".exe"))
                        {
                            xAsm = Assembly.ReflectionOnlyLoadFrom(xFile + ".exe");
                        }
                    }
                    if (xAsm != null)
                    {
                        xAsm.GetExportedTypes();
                        xLoaded.Add(xAsm);
                    }
                }
                catch(Exception ex)
                {
                    Console.Write("");
                }
            }

            var xForm = new PickViewModelForm();
            //var xBaseViewModel = (from item in xLoaded
            //                      let theType = (from type in item.GetExportedTypes()
            //                                     //where type.FullName == typeof(BaseViewModel).FullName
            //                                     select type).SingleOrDefault()
            //                      where item.GetName().Name == typeof(BaseViewModel).Assembly.GetName().Name
            //                      && theType != null
            //                      select theType).SingleOrDefault();
            //if (xBaseViewModel == null)
            //{
            //    return;
            //}
            foreach (var xAsm in xLoaded)
            {
                try
                {
                    foreach (var xType in xAsm.GetExportedTypes())
                    {
                        if (xType.IsAbstract)
                        {
                            continue;
                        }
                        //if (xType.IsSubclassOf(xBaseViewModel))
                        {
                            xForm.AddType(xType);
                        }
                    }
                }
                catch
                {
                }
            }
            xForm.StartPosition = FormStartPosition.CenterParent;
            if (xForm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            var xSelected = xForm.GetSelectedType();
            using (var xEditScope = mControlModel.BeginEdit())
            {
                
                //var xProp = mControlModel.Properties[OurPlatformTypes.DesignDataContextProperty];
                var xProp = mControlModel.Properties[OurPlatformTypes.DataContextProperty];
                if (xProp == null)
                {
                //    //xProp = mControlModel.create
                    throw new Exception("DataContext property not found!");
                }
                 
                
                //var expr = ModelFactory.CreateItem(mControlModel.Context, OurPlatformTypes.DesignInstance, xSelected);

                //var typeProp = expr.Properties[OurPlatformTypes.TypeProperty];
                //typeProp.SetValue(xSelected);

                var xDataModelType = ModelFactory.CreateItem(mControlModel.Context, xSelected);
                //if (expr == null)
                //{
                //    throw new Exception("Creeren mislukt");
                //}
                //MessageBox.Show("Create gelukt");
                //xProp.SetValue(expr);
                xProp.SetValue(xDataModelType);

                xEditScope.Complete();
            }

            if (AfterEdit != null)
            {
                AfterEdit();
            }
        }
    }
}