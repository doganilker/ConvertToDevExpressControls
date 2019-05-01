using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ConvertToDevExpressControls
{
    public partial class FrmMainForm : Form
    {
        public FrmMainForm()
        {
            InitializeComponent();
        }

        private void AddLog(string message)
        {
            txtLog.AppendText(string.Format("{0}\r\n", message));
            Application.DoEvents();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                var fileDialog = new OpenFileDialog
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Filter = "C# Designer File|*.designer.cs;"
                };

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDesignerFilePath.Text = fileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = txtDesignerFilePath.Text;

                string backupPath = Path.Combine(Application.StartupPath,
                    string.Concat("Backup\\", string.Format("{0:yyyyMMddHHmmss}_", DateTime.Now),
                        Path.GetFileName(filePath)));

                AddLog("Backing up file...");

                if (!Directory.Exists(Path.GetDirectoryName(backupPath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(backupPath));

                File.Copy(filePath, backupPath);

                AddLog(string.Format("Backup path: {0}", backupPath));

                var code = File.ReadAllText(filePath);

                AddLog("System.Windows.Forms.Panel objects have been converting...");
                code = code.Replace("System.Windows.Forms.Panel", "DevExpress.XtraEditors.PanelControl");

                AddLog("System.Windows.Forms.TextBox objects have been converting...");
                code = code.Replace("System.Windows.Forms.TextBox", "DevExpress.XtraEditors.TextEdit");

                AddLog("System.Windows.Forms.Button objects have been converting...");
                code = code.Replace("System.Windows.Forms.Button", "DevExpress.XtraEditors.SimpleButton");

                var lastIndex = -1;
                var buttonList = new List<string>();
                while ((lastIndex = code.IndexOf("DevExpress.XtraEditors.SimpleButton ", lastIndex + 1, StringComparison.Ordinal)) > 0)
                {
                    var startIndex = code.IndexOf(" ", lastIndex, StringComparison.Ordinal);
                    lastIndex = code.IndexOf(";", lastIndex, StringComparison.Ordinal);

                    var controlName = code.Substring(startIndex, lastIndex - startIndex).Trim();
                    buttonList.Add(controlName);
                }

                AddLog("Properties of DevExpress.XtraEditors.SimpleButton objects have been correcting...");
                foreach (var controlName in buttonList)
                {
                    code = code.Replace(string.Format("this.{0}.UseVisualStyleBackColor = true;", controlName), string.Empty);

                    code = code.Replace(string.Format("this.{0}.UseVisualStyleBackColor = false;", controlName), string.Empty);

                    code = code.Replace(string.Format("{0}.Font", controlName),
                        string.Format("{0}.Appearance.Font", controlName));
                    code = code.Replace(string.Format("this.{0}.Appearance.Font", controlName),
                        string.Format("this.{0}.Appearance.Options.UseFont = true;\r\n\t\t\tthis.{0}.Appearance.Font",
                            controlName));

                    code = code.Replace(string.Format("{0}.BackColor", controlName),
                        string.Format("{0}.Appearance.BackColor", controlName));
                    code = code.Replace(string.Format("this.{0}.Appearance.BackColor", controlName),
                        string.Format(
                            "this.{0}.Appearance.Options.UseBackColor = true;\r\n\t\t\tthis.{0}.Appearance.BackColor",
                            controlName));

                    code = code.Replace(string.Format("{0}.ForeColor", controlName),
                        string.Format("{0}.Appearance.ForeColor", controlName));
                    code = code.Replace(string.Format("this.{0}.Appearance.ForeColor", controlName),
                        string.Format(
                            "this.{0}.Appearance.Options.UseForeColor = true;\r\n\t\t\tthis.{0}.Appearance.ForeColor",
                            controlName));
                }

                File.WriteAllText(filePath, code);

                AddLog("Designer file is converted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
