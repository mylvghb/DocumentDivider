using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Aspose.Words;

namespace DocumentDivider
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void txtDocPath_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            txtDocPath.Text = openFileDialog.FileName;
            lblMessage.Text = string.Empty;
        }

        private void txtSaveDir_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            txtSaveDir.Text = folderBrowserDialog.SelectedPath;
            lblMessage.Text = string.Empty;
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            var docPath = txtDocPath.Text.Trim();
            if (string.IsNullOrEmpty(docPath))
            {
                MessageBox.Show("请选择要分割的 Word 文档", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var saveDir = txtSaveDir.Text.Trim();
            if (string.IsNullOrEmpty(saveDir))
            {
                saveDir = Path.GetDirectoryName(docPath);
            }

            if (saveDir == null)
            {
                return;
            }

            try
            {
                ExtractPages(docPath, saveDir);
                GC.Collect();
                Process.Start(saveDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"分隔失败。\n错误信息：\t{ex.Message}\n堆栈跟踪：\t{ex.StackTrace}", "错误", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            btnQuit.Focus();
        }

        private static void ExtractPages(string docPath, string saveDir)
        {
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }

            var fileName = Path.GetFileName(docPath);

            var original = new Document(docPath);
            var fileFormat = original.OriginalLoadFormat switch
            {
                LoadFormat.Docx => SaveFormat.Docx,
                LoadFormat.Rtf => SaveFormat.Rtf,
                LoadFormat.Doc => SaveFormat.Doc,
                _ => SaveFormat.Docx
            };

            //新建 Word 文档并向其中添加节
            var index = 1;
            //遍历原始文档的所有节
            foreach (var secNode in original.Sections)
            {
                var sec = (Section) secNode;
                var (newWord, newSection) = CreateDocumentWithSelection(sec);

                //遍历每个节的所有 body 子对象
                foreach (var secBodyChildNode in sec.Body.ChildNodes)
                {
                    // 如果对象是段落
                    if (secBodyChildNode is Paragraph para)
                    {
                        //将原文档节中的段落对象添加到新文档的节中
                        var newPara = newWord.ImportNode(para, true, ImportFormatMode.KeepSourceFormatting);
                        newSection.Body.ChildNodes.Add(newPara);

                        //遍历每个段落的所有子对象，并确定该对象是否是分页符
                        foreach (var paraChildNode in para.ChildNodes)
                        {
                            var text = paraChildNode.GetText();
                            //检测是否是分页符
                            if (text == ControlChar.PageBreak)
                            {
                                //获取段落中分页符的索引
                                var pageBreakIndex = para.ChildNodes.IndexOf(paraChildNode);

                                //从段落中删除分页符
                                newSection.Body.LastParagraph.ChildNodes.RemoveAt(pageBreakIndex);

                                //保存新文档
                                newWord.Save(Path.Combine(saveDir, $"P{index}-{fileName}"), fileFormat);
                                index++;

                                (newWord, newSection) = CreateDocumentWithSelection(sec); // 创建新文档并添加节

                                //将原始节中的段落对象添加到新文档的节中
                                newPara = newWord.ImportNode(para, true, ImportFormatMode.KeepSourceFormatting);
                                newSection.Body.ChildNodes.Add(newPara);
                                if (newSection.Body.FirstParagraph.ChildNodes.Count == 0)
                                {
                                    //删除第一个空白段落
                                    newSection.Body.ChildNodes.RemoveAt(0);
                                }
                                else
                                {
                                    //删除分页符前的子对象
                                    while (pageBreakIndex >= 0)
                                    {
                                        newSection.Body.FirstParagraph.ChildNodes.RemoveAt(pageBreakIndex);
                                        pageBreakIndex--;
                                    }
                                    
                                    // 如果还存在空白段落，删除该空白段落
                                    if (newSection.Body.FirstParagraph.ChildNodes.Count == 0)
                                    {
                                        //删除第一个空白段落
                                        newSection.Body.ChildNodes.RemoveAt(0);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // 将原文档节的其它对象添加到新文档的节中
                        var newObj = newWord.ImportNode(secBodyChildNode, true, ImportFormatMode.KeepSourceFormatting);
                        newSection.Body.ChildNodes.Add(newObj);
                    }
                }

                // 保存到文件
                newWord.Save(Path.Combine(saveDir, $"P{index}-{fileName}"), fileFormat);
                index++;
            }

            // 创建一个文档并从另一个节中创建新节
            (Document, Section) CreateDocumentWithSelection(Node section)
            {
                var newDoc = new Document();
                newDoc.Sections[0].Remove(); // 移除默认节

                var newSection = (Section) newDoc.ImportNode(
                    section,
                    true,
                    ImportFormatMode.KeepSourceFormatting
                );
                newSection.HeadersFooters.Clear();
                foreach (var headerFooterNode in ((Section) section).HeadersFooters)
                {
                    newSection.HeadersFooters.Add(newDoc.ImportNode(headerFooterNode, true,
                        ImportFormatMode.KeepSourceFormatting));
                }

                newSection.ClearContent();
                newSection.Body.FirstChild.Remove();

                newDoc.Sections.Add(newSection);
                return (newDoc, newDoc.FirstSection);
            }
        }
    }
}