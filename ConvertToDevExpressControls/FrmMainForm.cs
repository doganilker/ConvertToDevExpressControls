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

                #region System.Windows.Forms.Label
                AddLog("System.Windows.Forms.Label objects have been converting...");
                code = code.Replace("System.Windows.Forms.Label", "DevExpress.XtraEditors.LabelControl");

                var lastIndex = -1;
                var labelControlList = new List<string>();
                while ((lastIndex = code.IndexOf("DevExpress.XtraEditors.LabelControl ", lastIndex + 1, StringComparison.Ordinal)) > 0)
                {
                    var startIndex = code.IndexOf(" ", lastIndex, StringComparison.Ordinal);
                    lastIndex = code.IndexOf(";", lastIndex, StringComparison.Ordinal);

                    var controlName = code.Substring(startIndex, lastIndex - startIndex).Trim();
                    labelControlList.Add(controlName);
                }

                AddLog("Properties of DevExpress.XtraEditors.LabelControl objects have been correcting...");
                foreach (var controlName in labelControlList)
                {
                    if (code.IndexOf(string.Format("this.{0}.AutoSize", controlName)) > 0)
                    {
                        code = code.Replace(string.Format("{0}.AutoSize = false;", controlName),
                            string.Format("{0}.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;", controlName));

                        code = code.Replace(string.Format("{0}.AutoSize = true;", controlName),
                            string.Format("{0}.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Default;", controlName));
                    }
                    else
                    {
                        code = code.Replace(string.Format("this.{0}.Name", controlName),
                            string.Format("this.{0}.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;\r\n\t\t\tthis.{0}.Name", controlName));
                    }

                    code = code.Replace(string.Format("this.{0}.TextAlign = System.Drawing.ContentAlignment.BottomCenter;", controlName),
                        string.Format("this.{0}.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;\r\n\t\t\tthis.{0}.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;", controlName));

                    code = code.Replace(string.Format("this.{0}.TextAlign = System.Drawing.ContentAlignment.BottomLeft;", controlName),
                        string.Format("this.{0}.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;\r\n\t\t\tthis.{0}.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;", controlName));

                    code = code.Replace(string.Format("this.{0}.TextAlign = System.Drawing.ContentAlignment.BottomRight;", controlName),
                        string.Format("this.{0}.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;\r\n\t\t\tthis.{0}.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;", controlName));

                    code = code.Replace(string.Format("this.{0}.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;", controlName),
                        string.Format("this.{0}.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;\r\n\t\t\tthis.{0}.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;", controlName));

                    code = code.Replace(string.Format("this.{0}.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;", controlName),
                        string.Format("this.{0}.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;\r\n\t\t\tthis.{0}.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;", controlName));

                    code = code.Replace(string.Format("this.{0}.TextAlign = System.Drawing.ContentAlignment.MiddleRight;", controlName),
                        string.Format("this.{0}.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;\r\n\t\t\tthis.{0}.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;", controlName));

                    code = code.Replace(string.Format("this.{0}.TextAlign = System.Drawing.ContentAlignment.TopCenter;", controlName),
                        string.Format("this.{0}.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;\r\n\t\t\tthis.{0}.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;", controlName));

                    code = code.Replace(string.Format("this.{0}.TextAlign = System.Drawing.ContentAlignment.TopLeft;", controlName),
                        string.Format("this.{0}.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;\r\n\t\t\tthis.{0}.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;", controlName));

                    code = code.Replace(string.Format("this.{0}.TextAlign = System.Drawing.ContentAlignment.TopRight;", controlName),
                        string.Format("this.{0}.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;\r\n\t\t\tthis.{0}.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;", controlName));
                }
                #endregion

                #region System.Windows.Forms.Button
                AddLog("System.Windows.Forms.Button objects have been converting...");
                code = code.Replace("System.Windows.Forms.Button", "DevExpress.XtraEditors.SimpleButton");

                code = code.Replace("System.Windows.Forms.FlatStyle.Flat", "DevExpress.XtraEditors.Controls.BorderStyles.Flat");
                code = code.Replace("System.Windows.Forms.FlatStyle.Popup", "DevExpress.XtraEditors.Controls.BorderStyles.HotFlat");
                code = code.Replace("System.Windows.Forms.FlatStyle.Standard", "DevExpress.XtraEditors.Controls.BorderStyles.Simple");
                code = code.Replace("System.Windows.Forms.FlatStyle.System", "DevExpress.XtraEditors.Controls.BorderStyles.Default");

                code = code.Replace("System.Windows.Forms.TextImageRelation.ImageAboveText", "DevExpress.XtraEditors.ImageAlignToText.TopCenter");
                code = code.Replace("System.Windows.Forms.TextImageRelation.TextAboveImage", "DevExpress.XtraEditors.ImageAlignToText.BottomCenter");
                code = code.Replace("System.Windows.Forms.TextImageRelation.ImageBeforeText", "DevExpress.XtraEditors.ImageAlignToText.LeftCenter");
                code = code.Replace("System.Windows.Forms.TextImageRelation.TextBeforeImage", "DevExpress.XtraEditors.ImageAlignToText.RightCenter");

                lastIndex = -1;
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
                    code = code.Replace(string.Format("{0}.TextImageRelation", controlName),
                        string.Format("{0}.ImageToTextAlignment", controlName));

                    code = code.Replace(string.Format("{0}.FlatStyle", controlName),
                        string.Format("{0}.ButtonStyle", controlName));

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
                #endregion

                #region System.Windows.Forms.TextBox
                AddLog("System.Windows.Forms.TextBox objects have been converting...");
                code = code.Replace("System.Windows.Forms.TextBox", "DevExpress.XtraEditors.TextEdit");

                lastIndex = -1;
                var textEditList = new List<string>();
                while ((lastIndex = code.IndexOf("DevExpress.XtraEditors.TextEdit ", lastIndex + 1, StringComparison.Ordinal)) > 0)
                {
                    var startIndex = code.IndexOf(" ", lastIndex, StringComparison.Ordinal);
                    lastIndex = code.IndexOf(";", lastIndex, StringComparison.Ordinal);

                    var controlName = code.Substring(startIndex, lastIndex - startIndex).Trim();
                    textEditList.Add(controlName);
                }

                AddLog("Properties of DevExpress.XtraEditors.TextEdit objects have been correcting...");
                foreach (var controlName in textEditList)
                {
                    code = code.Replace(string.Format("{0}.MaxLength", controlName),
                        string.Format("{0}.Properties.MaxLength", controlName));

                    code = code.Replace(string.Format("{0}.PasswordChar", controlName),
                        string.Format("{0}.Properties.PasswordChar", controlName));

                    code = code.Replace(string.Format("{0}.AutoCompleteMode", controlName),
                        string.Format("{0}.MaskBox.AutoCompleteMode", controlName));

                    code = code.Replace(string.Format("{0}.AutoCompleteSource", controlName),
                        string.Format("{0}.MaskBox.AutoCompleteSource", controlName));
                }
                #endregion

                #region System.Windows.Forms.PictureBox
                AddLog("System.Windows.Forms.PictureBox objects have been converting...");

                code = code.Replace("System.Windows.Forms.PictureBoxSizeMode.AutoSize", "DevExpress.XtraEditors.Controls.PictureSizeMode.Clip");
                code = code.Replace("System.Windows.Forms.PictureBoxSizeMode.CenterImage", "DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze");
                code = code.Replace("System.Windows.Forms.PictureBoxSizeMode.Normal", "DevExpress.XtraEditors.Controls.PictureSizeMode.Clip");
                code = code.Replace("System.Windows.Forms.PictureBoxSizeMode.StretchImage", "DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch");
                code = code.Replace("System.Windows.Forms.PictureBoxSizeMode.Zoom", "DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom");

                // Replace PictureBox after PictureSizeMode enum
                code = code.Replace("System.Windows.Forms.PictureBox", "DevExpress.XtraEditors.PictureEdit");

                lastIndex = -1;
                var pictureEditList = new List<string>();
                while ((lastIndex = code.IndexOf("DevExpress.XtraEditors.PictureEdit ", lastIndex + 1, StringComparison.Ordinal)) > 0)
                {
                    var startIndex = code.IndexOf(" ", lastIndex, StringComparison.Ordinal);
                    lastIndex = code.IndexOf(";", lastIndex, StringComparison.Ordinal);

                    var controlName = code.Substring(startIndex, lastIndex - startIndex).Trim();
                    pictureEditList.Add(controlName);
                }

                AddLog("Properties of DevExpress.XtraEditors.PictureEdit objects have been correcting...");
                foreach (var controlName in pictureEditList)
                {
                    code = code.Replace(string.Format("{0}.SizeMode", controlName),
                        string.Format("{0}.Properties.SizeMode", controlName));
                }
                #endregion

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
