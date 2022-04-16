using BusinessLogic;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FileSystemForm : Form
    {
        private IFileProvider Provider { get; set; }
        private TextWriter LogWriter;
        private const string LogFilePath = "LOGS.txt";
        private FileSystemVisitor Visitor { get; set; }

        public FileSystemForm()
        {
            InitializeComponent();
            Provider = (IFileProvider)Program.ServiceProvider.GetService(typeof(IFileProvider));           
            LogWriter = new StreamWriter("LOGS.txt", true);
        }
        private void RegisterEvents()
        {
            Visitor.StartedEvent += Visitor_StartedEvent;
            Visitor.FinishedEvent += Visitor_FinishedEvent;
            Visitor.FileFoundEvent += ReaderService_FileFoundEvent;
            Visitor.DirectoryFoundEvent += ReaderService_DirectoryFoundEvent;
            Visitor.FilteredFileFoundEvent += ReaderService_FilteredFileFoundEvent;
            Visitor.FilteredDirectoryFoundEvent += ReaderService_FilteredDirectoryFoundEvent;
        }

        #region events
        private void ReaderService_FilteredDirectoryFoundEvent(object sender, string e)
        {
            LogWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} Filtered Directory Found: {e}");
        }

        private void ReaderService_FilteredFileFoundEvent(object sender, string e)
        {
            LogWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} Filtered File Found: {e}");
        }

        private void ReaderService_DirectoryFoundEvent(object sender, string e)
        {
            LogWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} Directory Found: {e}");
        }

        private void ReaderService_FileFoundEvent(object sender, string e)
        {
            LogWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} File Found: {e}");
        }

        private void Visitor_FinishedEvent(object sender, string e)
        {
            LogWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} Process finished for path: {e}");
        }

        private void Visitor_StartedEvent(object sender, string e)
        {
            LogWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} Process started for path: {e}");
        }
        #endregion       

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
         
            Visitor = new FileSystemVisitor(Provider,new Flag(FDirStop.Checked,FDirEx.Checked,FFileStop.Checked,FFilesEx.Checked), IsDirValid, IsFileValid);

            RegisterEvents();

            var resultList = Visitor.GetAllFilesAndDirs(path);

            foreach (var element in resultList)
            {
                resultTree.Nodes.Add(element);
            }            
        }

        public bool IsDirValid(string path)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                return true;
            }
            else
            {
                Regex rx = new Regex(textBox2.Text);
                return rx.IsMatch(path);               
            }
        }

        public bool IsFileValid(string path)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                return true;
            }
            else
            {
                Regex rx = new Regex(textBox3.Text);
                return rx.IsMatch(path);
            }
        }
    }    
}
