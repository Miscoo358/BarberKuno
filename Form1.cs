using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarberKuno
{
    public partial class Form1 : Form
    {
        // Declare controls
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblMessage;
        public Form1()
        {

            InitializeComponent();
            InitializeLoginForm();
        }
        private void InitializeLoginForm()
        {
            // Set up the form
            this.Text = "Login Form";
            this.Size = new Size(300, 200);

            // Username TextBox
            txtUsername = new TextBox();
            txtUsername.Location = new Point(50, 20);
            txtUsername.Size = new Size(200, 20);
            txtUsername.Text = "Username"; // Set placeholder text
            txtUsername.ForeColor = Color.Gray; // Set placeholder color
            txtUsername.Enter += new EventHandler(RemovePlaceholderText); // Remove placeholder on focus
            txtUsername.Leave += new EventHandler(AddPlaceholderText); // Add placeholder if empty
            this.Controls.Add(txtUsername);

            // Password TextBox
            txtPassword = new TextBox();
            txtPassword.Location = new Point(50, 60);
            txtPassword.Size = new Size(200, 20);
            txtPassword.Text = "Password"; // Set placeholder text
            txtPassword.ForeColor = Color.Gray; // Set placeholder color
            txtPassword.UseSystemPasswordChar = false; // Don't mask placeholder text
            txtPassword.Enter += new EventHandler(RemovePlaceholderText); // Remove placeholder on focus
            txtPassword.Leave += new EventHandler(AddPlaceholderText); // Add placeholder if empty
            this.Controls.Add(txtPassword);

            // Login Button
            btnLogin = new Button();
            btnLogin.Location = new Point(100, 100);
            btnLogin.Size = new Size(100, 30);
            btnLogin.Text = "Login";
            btnLogin.Click += new EventHandler(btnLogin_Click); // Attach click event handler
            this.Controls.Add(btnLogin);

            // Message Label
            lblMessage = new Label();
            lblMessage.Location = new Point(50, 140);
            lblMessage.Size = new Size(200, 20);
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblMessage);
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (textBox.Text == "Username" || textBox.Text == "Password")
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black; // Reset text color
                    if (textBox == txtPassword)
                    {
                        textBox.UseSystemPasswordChar = true; // Mask password
                    }
                }
            }
        }

        private void AddPlaceholderText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (textBox == txtUsername)
                    {
                        textBox.Text = "Username";
                    }
                    else if (textBox == txtPassword)
                    {
                        textBox.Text = "Password";
                        textBox.UseSystemPasswordChar = false; // Unmask placeholder text
                    }
                    textBox.ForeColor = Color.Gray; // Set placeholder color
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Simple validation for demonstration purposes
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "password")
            {
                lblMessage.Text = "Login successful!";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = "Invalid username or password!";
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}