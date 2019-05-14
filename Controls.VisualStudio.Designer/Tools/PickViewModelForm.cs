using System;
using System.Windows.Forms;

namespace Controls.VisualStudio.Designer.Tools
{
    public partial class PickViewModelForm : Form
    {
        public PickViewModelForm()
        {
            InitializeComponent();
        }

        public void AddType(Type type)
        {
            listBox1.Items.Add(type);
        }

        public Type GetSelectedType()
        {
            if (listBox1.SelectedItem == null)
            {
                return null;
            }
            return listBox1.SelectedItem as Type;
        }
    }
}