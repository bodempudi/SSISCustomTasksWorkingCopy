using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace SSISCustomTasks
{
    public class VariableSelectorEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            => UITypeEditorEditStyle.Modal;

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider.GetService(typeof(IWindowsFormsEditorService)) is IWindowsFormsEditorService editorService &&
                context?.Instance is VariablesNode node)
            {
                using (var dialog = new VariableSelectorForm(node))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        return dialog.SelectedVariables;
                    }
                }
            }

            return value;
        }
    }
}
