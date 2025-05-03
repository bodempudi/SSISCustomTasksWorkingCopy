using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSISCustomTasks
{
    public class LogVariableTaskUI : IDtsTaskUI
    {
        private TaskHost _taskHost;
        private IDtsConnectionService _connections;

        public void Initialize(TaskHost taskHost, IServiceProvider serviceProvider)
        {
            _taskHost = taskHost;
            _connections = (IDtsConnectionService)serviceProvider.GetService(typeof(IDtsConnectionService));
        }

        public ContainerControl GetView()
        {
            return new LogVariablesTaskUIForm(_taskHost, _connections);
        }

        public void Delete(IWin32Window parentWindow) { }

        public void New(IWin32Window parentWindow) { }
    }
}
