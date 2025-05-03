using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSISCustomTasks
{
    public class VariablesNode
    {
        [Browsable(false)]
        public TaskHost TaskHost { get; }
        private LogVariableTask _task;

        public VariablesNode(TaskHost taskHost)
        {
            TaskHost = taskHost;
            _task = taskHost.InnerObject as LogVariableTask;
        }

        [Category("Variables")]
        [Description("Specifies which SSIS variables to log. Opens a checkbox list.")]
        [Editor(typeof(VariableSelectorEditor), typeof(UITypeEditor))]
        public string SelectedVariables
        {
            get => _task.SelectedVariables;
            set => _task.SelectedVariables = value;
        }
    }
}
