using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Windows.Forms;
using Microsoft.DataTransformationServices.Controls;

namespace SSISCustomTasks
{
    public class GeneralView : UserControl, IDTSTaskUIView
    {
        private PropertyGrid _propertyGrid;
        private GeneralNode _node;

        public GeneralView()
        {
            _propertyGrid = new PropertyGrid
            {
                Dock = DockStyle.Fill,
                PropertySort = PropertySort.Categorized,
                ToolbarVisible = false
            };

            Controls.Add(_propertyGrid);
        }

        public void OnInitialize(IDTSTaskUIHost host, TreeNode viewNode, object taskHost, object connections)
        {
            _node = new GeneralNode(taskHost as TaskHost);
            _propertyGrid.SelectedObject = _node;
        }

        public void OnCommit(object taskHost)
        {
            TaskHost th = taskHost as TaskHost;
            if (th != null)
            {
                th.Name = _node.TaskName;
                th.Description = _node.TaskDescription;
            }
        }

        public void OnValidate(ref bool viewIsValid, ref string reason)
        {
            if (string.IsNullOrWhiteSpace(_node.TaskName))
            {
                viewIsValid = false;
                reason = "Task name cannot be empty.";
            }
        }

        public void OnSelection() { }

        public void OnLoseSelection(ref bool canLeaveView, ref string reason) { }
    }
}
