﻿using BusinessLogic;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FileSystemForm : Form
    {
        private IFileSystemService ReaderService { get; set; }

        public FileSystemForm()
        {
            InitializeComponent();
            ReaderService = (IFileSystemService)Program.ServiceProvider.GetService(typeof(IFileSystemService));
            RegisterEvents();
        }
        private void RegisterEvents()
        {
            ReaderService.StartedEvent += Visitor_StartedEvent;
            ReaderService.FinishedEvent += Visitor_FinishedEvent;
            ReaderService.FileFoundEvent += ReaderService_FileFoundEvent;
            ReaderService.DirectoryFoundEvent += ReaderService_DirectoryFoundEvent;
            ReaderService.FilteredFileFoundEvent += ReaderService_FilteredFileFoundEvent;
            ReaderService.FilteredDirectoryFoundEvent += ReaderService_FilteredDirectoryFoundEvent;
        }        

        #region events
        private void ReaderService_FilteredDirectoryFoundEvent(object sender, string e)
        {
            //if (FDirStop.Checked == true)
            //{
            //    resultTree.Enabled = false;
            //}

            //if (FDirEx.Checked == false)
            //{
            //    resultTree.Nodes.Add(e);
            //}
             
        }

        private void ReaderService_FilteredFileFoundEvent(object sender, string e)
        {
            //if (FFileStop.Checked == true)
            //{
            //    resultTree.Enabled = false;
            //}

            //if (FFilesEx.Checked == false)
            //{
            //    if (resultTree.Nodes.Count > 0 && resultTree.Nodes[e.DirectoryId] != null)
            //    {
            //        resultTree.Nodes[e.DirectoryId].Nodes.Add(e.FileName);
            //    }
            //}
                     
        }

        private void ReaderService_DirectoryFoundEvent(object sender, string e)
        {
            //if (DirStop.Checked == true)
            //{
            //    resultTree.Enabled = false;
            //}

            //if (DirEx.Checked == false)
            //{
            //    resultTree.Nodes.Add(e);
            //}
        }

        private void ReaderService_FileFoundEvent(object sender, string e)
        {
            //if (FileStop.Checked == true)
            //{
            //    resultTree.Enabled = false;
            //}

            //if (FilesEx.Checked == false)
            //{
            //    if (resultTree.Nodes.Count > 0 && resultTree.Nodes[e.DirectoryId] != null)
            //    {
            //        resultTree.Nodes[e.DirectoryId].Nodes.Add(e.FileName);
            //    }
            //}
            
        }

        private void Visitor_FinishedEvent(object sender, string e)
        {
            //stopLabel.Text =$"Process finished for path: {e}";
            //stopLabel.Visible = true;
            //resultTree.EndUpdate();
        }

        private void Visitor_StartedEvent(object sender, string e)
        {
            //startLabel.Text = $"Process started for path: {e}";
            //startLabel.Visible = true;
            //resultTree.BeginUpdate();
        }
        #endregion

        private void TreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        //    var node = e.Node;
        //    if (node != null && e.Clicks > 1)
        //    {
        //        resultTree.Nodes.Remove(node);
        //    }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (addFiltersLabel.Checked == true)
            {
                label2.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                FDirEx.Visible = true;
                FDirStop.Visible = true;
                FFilesEx.Visible = true;
                FFileStop.Visible = true;
            }
            else
            {
                label2.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                FDirEx.Visible = false;
                FDirStop.Visible = false;
                FFilesEx.Visible = false;
                FFileStop.Visible = false;
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            resultTree.Nodes.Clear();

            resultTree.Enabled = true;
            noPathLabel.Visible = false;

            var path = textBox1.Text;
            if (string.IsNullOrEmpty(path))
            {
                noPathLabel.Visible = true;
                return;
            }

            FileSystemVisitor visitor;

            visitor = new FileSystemVisitor(ReaderService, path, GetFilter);

            var dirTree = visitor.GetDirectoryTree();

            var mappedTreeRoot = dirTree.ToWindowsFormsTreeNode();

            resultTree.Nodes.Add(mappedTreeRoot);
        }

        private Filter GetFilter()
        {
            if (addFiltersLabel.Checked)
            {
                return new Filter(
                    textBox2.Text,
                    textBox3.Text,
                    FDirStop.Checked,
                    FDirEx.Checked,
                    FFileStop.Checked,
                    FFilesEx.Checked
                    );
            }

            return null; 

        }
    }
}
