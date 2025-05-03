using Microsoft.DataTransformationServices.Controls;
using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSISCustomTasks
{
    public class VariablesView : UserControl, IDTSTaskUIView
    {
        private PropertyGrid _propertyGrid;
        private VariablesNode _node;

        public VariablesView()
        {
            _propertyGrid = new PropertyGrid { Dock = DockStyle.Fill };
            Controls.Add(_propertyGrid);
        }

        public void OnInitialize(IDTSTaskUIHost host, TreeNode viewNode, object taskHost, object connections)
        {
            _node = new VariablesNode(taskHost as TaskHost);
            _propertyGrid.SelectedObject = _node;
        }

        public void OnCommit(object taskHost) { }

        public void OnValidate(ref bool viewIsValid, ref string reason) { }

        public void OnSelection() { }

        public void OnLoseSelection(ref bool canLeaveView, ref string reason) { }
    }
}
