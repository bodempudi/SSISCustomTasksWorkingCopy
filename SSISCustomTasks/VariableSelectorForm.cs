using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace SSISCustomTasks
{ 
    public class VariableSelectorForm : Form
    {
        private CheckedListBox listBox;
        private readonly Button okButton;
        private readonly Button cancelButton;
        private readonly Label titleLabel;

        public string SelectedVariables { get; private set; }

        public VariableSelectorForm(VariablesNode node)
        {
            Text = "Select Variables to Log";
            Width = 500;
            Height = 550;
            MinimumSize = new System.Drawing.Size(480, 450);
            StartPosition = FormStartPosition.CenterParent;

            // Title label
            titleLabel = new Label
            {
                Text = "Select variables to log:",
                Dock = DockStyle.Fill,
                AutoSize = true,
                Padding = new Padding(10, 10, 10, 5),
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
            };

            // Checked list box
            listBox = new CheckedListBox
            {
                Dock = DockStyle.Fill,
                CheckOnClick = true,
                Margin = new Padding(10)
            };

            var selected = node.SelectedVariables?.Split(';').ToHashSet() ?? new HashSet<string>();

            try
            {
                foreach (Variable v in node.TaskHost.Variables)
                {
                    string displayName = v.QualifiedName;
                    listBox.Items.Add(displayName, selected.Contains(displayName));
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Failed to load variables: " + ex.Message);
            }

            // OK and Cancel buttons styled and bottom-right aligned
            okButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                AutoSize = true,
                Margin = new Padding(5),
                Font = new System.Drawing.Font("Segoe UI", 9F)
            };

            cancelButton = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                AutoSize = true,
                Margin = new Padding(5),
                Font = new System.Drawing.Font("Segoe UI", 9F)
            };

            okButton.Click += (s, e) =>
            {
                var selectedVars = new List<string>();
                foreach (var item in listBox.CheckedItems)
                {
                    selectedVars.Add(item.ToString().Trim());
                }
                SelectedVariables = string.Join(";", selectedVars);
                Close();
            };

            cancelButton.Click += (s, e) => Close();

            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10),
                AutoSize = true,
                WrapContents = false
            };

            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Controls.Add(okButton);

            var buttonPanelContainer = new Panel
            {
                Dock = DockStyle.Right,
                Padding = new Padding(10),
                AutoSize = true
            };
            buttonPanelContainer.Controls.Add(buttonPanel);

            // Layout panel
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 1,
                Padding = new Padding(5)
            };

            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));     // Title
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // List
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));     // Buttons

            layout.Controls.Add(titleLabel, 0, 0);
            layout.Controls.Add(listBox, 0, 1);
            layout.Controls.Add(buttonPanelContainer, 0, 2);

            Controls.Add(layout);
        }
    }
}
