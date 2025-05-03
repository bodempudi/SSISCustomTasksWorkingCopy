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
    public class HelloWorldTaskUI : IDtsTaskUI
    {
        public void Delete(System.Windows.Forms.IWin32Window parentWindow)
        {
             
        }

        public System.Windows.Forms.ContainerControl GetView()
        {
            // Return a simple form as the UI
            var form = new Form();
            form.Text = "Minimal SSIS Task UI";
            form.Controls.Add(new Button
            {
                Text = "Click Me",
                Left = 50,
                Top = 50,
                Width = 100
            });
            return (ContainerControl)form;
        }

        public void Initialize(TaskHost taskHost, IServiceProvider serviceProvider)
        {
             
        }

        public void New(System.Windows.Forms.IWin32Window parentWindow)
        {
             
        }
    }
}
