using System;
using System.Windows.Forms;
using BusinessLogic;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public string UserName { get; set; }

        public Form1()
        {
            InitializeComponent();
        }
     
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            UserName = textBox1.Text;
        }
        private void ButtonHelloWorld_Click(object sender, EventArgs e)
        {
            lblHelloWorld.Text = Greeting.Welcome(UserName);            
        }

    }
}
