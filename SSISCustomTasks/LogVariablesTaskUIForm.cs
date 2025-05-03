using Microsoft.DataTransformationServices.Controls;
using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSISCustomTasks
{
    public class LogVariablesTaskUIForm : DTSBaseTaskUI
    {
        //private static readonly Icon TaskIcon = SystemIcons.Information;
        //private static readonly Icon TaskIcon = new Icon("SSISCustomTasks.LogVariableTaskICON.ico");
        //public static Icon TaskIcon = new Icon("LogVariableTaskICON.ico");
        private static readonly Icon TaskIcon = new Icon(typeof(SSISCustomTasks.LogVariableTask), "LogVariableTaskICON.ico");

        public LogVariablesTaskUIForm(TaskHost taskHost, object connections)
            : base("NBK - Log Variables Task", TaskIcon, "Configure which variables to log..", taskHost, connections)
        {
            this.DTSTaskUIHost.AddView("General", new GeneralView(), null);
            this.DTSTaskUIHost.AddView("Variables", new VariablesView(), null);
        }
    }
}
