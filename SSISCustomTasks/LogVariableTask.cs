using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace SSISCustomTasks
{
    [DtsTask
    (
       DisplayName = "NBK - Log Variable Task"
        , IconResource = "SSISCustomTasks.LogVariableTaskICON.ico"
        , Description = "This task logs an SSIS package variable in an SSIS execution log."
        , UITypeName = "SSISCustomTasks.LogVariableTaskUI, SSISCustomTasks, Version=1.0.0.0, Culture=Neutral, PublicKeyToken=f8eb48e173af245a"
     )
     ]
    public class LogVariableTask : Task, IDTSComponentPersist
    {
        [DtsProperty]
        public string TaskName { get; set; } = "NBK - Log Variables Task";

        [DtsProperty]
        public string TaskDescription { get; set; } = "Logs selected SSIS variables.";

        [DtsProperty]
        public string SelectedVariables { get; set; } = "";

        public override DTSExecResult Execute(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents events, IDTSLogging log, object transaction)
        {
            foreach (var name in SelectedVariables.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                try
                {
                    Variables vars = null;
                    variableDispenser.LockOneForRead(name, ref vars);
                    object value = vars[name].Value;
                    vars.Unlock();
                    bool fireAgain = false;
                    events.FireInformation(0, "LogVariablesTask", $"{name} = {value}", "", 0, ref fireAgain);
                }
                catch (Exception ex)
                {
                    events.FireWarning(0, "LogVariablesTask", $"Error logging variable '{name}': {ex.Message}", "", 0);
                }
            }
            return DTSExecResult.Success;
        }

        public void LoadFromXML(System.Xml.XmlElement node, IDTSInfoEvents events)
        {
            TaskName = node.GetAttribute("TaskName");
            TaskDescription = node.GetAttribute("TaskDescription");
            SelectedVariables = node.GetAttribute("SelectedVariables");
        }

        public void SaveToXML(System.Xml.XmlDocument doc, IDTSInfoEvents events)
        {
            var element = doc.CreateElement("LogVariablesTask");
            element.SetAttribute("TaskName", TaskName);
            element.SetAttribute("TaskDescription", TaskDescription);
            element.SetAttribute("SelectedVariables", SelectedVariables);
            doc.AppendChild(element);
        }
    }
}
