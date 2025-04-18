using FileOpsDemo.src.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileOpsDemo.src.Views
{
    public partial class FileView : Form
    {
        private readonly FileController _controller;

        private TextBox txtFilePath;
        private TextBox txtContent;
        private Button btnOpen;
        private Button btnSave;
        private Button btnCreate;
        private Button btnDelete;
        private Label lblStatus;

        public FileView()
        {
            InitializeComponent();
            _controller = new FileController();
        }

        private void InitializeComponent()
        {
            this.txtFilePath = new TextBox();
            this.txtContent = new TextBox();
            this.btnOpen = new Button();
            this.btnSave = new Button();
            this.btnCreate = new Button();
            this.btnDelete = new Button();
            this.lblStatus = new Label();

            this.Text = "File Manager";
            this.ClientSize = new Size(500, 400);
            this.MinimumSize = new Size(500, 400); // اختياري

            // txtFilePath
            txtFilePath.Location = new Point(20, 20);
            txtFilePath.Size = new Size(350, 20);
            txtFilePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // btnOpen
            btnOpen.Location = new Point(380, 18);
            btnOpen.AutoSize = true;
            btnOpen.Text = "Open";
            btnOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpen.Click += BtnOpen_Click;

            // txtContent
            txtContent.Location = new Point(20, 60);
            txtContent.Multiline = true;
            txtContent.Size = new Size(450, 250);
            txtContent.ScrollBars = ScrollBars.Vertical;
            txtContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // btnSave
            btnSave.Location = new Point(20, 320);
            btnSave.Size = new Size(90, 30);
            btnSave.Text = "Save";
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.Click += BtnSave_Click;

            // btnCreate
            btnCreate.Location = new Point(140, 320);
            btnCreate.Size = new Size(90, 30);
            btnCreate.Text = "Create";
            btnCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCreate.Click += BtnCreate_Click;

            // btnDelete
            btnDelete.Location = new Point(260, 320);
            btnDelete.Size = new Size(90, 30);
            btnDelete.Text = "Delete";
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Click += BtnDelete_Click;

            // lblStatus
            lblStatus.Location = new Point(20, 360);
            lblStatus.Size = new Size(450, 30);
            lblStatus.Text = "Ready";
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            this.Controls.Add(txtFilePath);
            this.Controls.Add(txtContent);
            this.Controls.Add(btnOpen);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCreate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(lblStatus);
        }


        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a file";
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;

                try
                {
                    _controller.OpenFile(txtFilePath.Text);
                    txtContent.Text = _controller.GetFileContent();
                    lblStatus.Text = "File opened successfully";
                }
                catch (Exception ex)
                {
                    lblStatus.Text = $"Error: {ex.Message}";
                }
            }
        }



        private void BtnSave_Click(Object sender, EventArgs e)
        {
            try
            {
                _controller.SetFileContent(txtContent.Text);
                _controller.SaveFile();
                lblStatus.Text = "File saved successfully";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
            }
        }


        private void BtnCreate_Click(Object sender, EventArgs e)
        {
            try
            {
                _controller.CreateFile(txtFilePath.Text, txtContent.Text);
                lblStatus.Text = "File created successfully";
                //MessageBox.Show("File created at:\n" + txtFilePath.Text);

            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
            }
        }


        private void BtnDelete_Click(Object sender, EventArgs e)
        {
            try
            {
                _controller.DeleteFile(txtFilePath.Text);
                txtContent.Text = "";
                lblStatus.Text = "File deleted successfully";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
            }
        }


    }
}
