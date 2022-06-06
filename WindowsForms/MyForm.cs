using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class MyForm : Form
    {
        //private TextBox MessageTextBox;
        private ListBox MessageListBox;
        private Label MessageLabel;
        private Button ShowMessageButton;


        public MyForm()
        {
            this.Text = "My Form";
            //MessageTextBox = new TextBox();
            //MessageTextBox.Left = 25;
            //MessageTextBox.Top = 25;
            //MessageTextBox.Width = 200;
            //this.Controls.Add(MessageTextBox);
            MessageListBox = new ListBox();
            MessageListBox.Left = 25;
            MessageListBox.Top = 25;
            MessageListBox.Width = 200;
            MessageListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(MessageListBox);

            ShowMessageButton = new Button();
            ShowMessageButton.Left = 25;
            ShowMessageButton.Top = 150;
            ShowMessageButton.Width = 200;
            ShowMessageButton.Text = "Show Message";
            ShowMessageButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.Controls.Add(ShowMessageButton);
            MessageLabel = new Label();
            MessageLabel.Left = 25;
            MessageLabel.Top = 190;
            MessageLabel.Width = 200;
            MessageLabel.Text = "[Label]";
            MessageLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.Controls.Add(MessageLabel);


            ShowMessageButton.Click += MyForm_Click;
            MyForm_Load(this, EventArgs.Empty);



            FormClosing += MyForm_FormClosing;
        }

        private void MyForm_Load(object sender, EventArgs e)
        {
           // MessageListBox.Items.Clear();
            MessageListBox.Items.Add("Oranges");
            MessageListBox.Items.Add("Grapes");
            MessageListBox.Items.Add("Bananas");
            MessageListBox.Items.Add("Peaches");
        }

        private void MyForm_Click(object sender, EventArgs e)
        {
            //MessageLabel.Text = MessageTextBox.Text;
            if(MessageListBox.SelectedIndex == -1)
            {
                var message = "Please Select an Item From the List Box";
                MessageBox.Show(message, this.Text);
                return;
            }
            MessageLabel.Text = MessageListBox.Text;
            MessageBox.Show("Congrats you clicked the button", this.Text);
        }

        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var message = "Are you sure that you want to close the form?";
            var closedApplication = "Congrats you are successfully closing the application";
            DialogResult dg = MessageBox.Show(message, this.Text, MessageBoxButtons.YesNo);
            if (dg == DialogResult.No)
            {
                e.Cancel = true;    

            }
            if(dg == DialogResult.Yes)
            {
                MessageBox.Show(closedApplication, this.Text);
            }
        }
    }
}
