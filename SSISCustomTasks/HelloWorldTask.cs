using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//f8eb48e173af245a
namespace SSISCustomTasks
{
    [DtsTask
    (
       DisplayName = "SSIS - Hello World Task"
        ,UITypeName = "SSISCustomTasks.HelloWorldTaskUI, SSISCustomTasks, Version=1.0.0.0, Culture=Neutral, PublicKeyToken=f8eb48e173af245a"
     )
     ]
    public class HelloWorldTask : Task
    {
    }
}
