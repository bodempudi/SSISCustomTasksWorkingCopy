using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSISCustomTasks
{
    internal class GeneralNode
    {
        private readonly LogVariableTask _task;

        public GeneralNode(TaskHost taskHost)
        {
            _task = taskHost.InnerObject as LogVariableTask;
        }

        [Category("General")]
        [Description("Task name shown in the control flow.")]
        public string TaskName
        {
            get => _task.TaskName;
            set => _task.TaskName = value;
        }

        [Category("General")]
        [Description("Description shown when hovering over the task.")]
        public string TaskDescription
        {
            get => _task.TaskDescription;
            set => _task.TaskDescription = value;
        }
    }
}
