using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientExample
{
    using System;
    using System.Windows.Forms;
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }
        public string Email { get { return textEmail.Text; } }
        public string Password { get { return textPass.Text; } }
        public string ConfirmPassword { get { return textConfirmPass.Text; } }

        private void LinkNickHelpLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Your nickname is the name that will appear to other users.");
        }

        private void textPass_TextChanged(object sender, EventArgs e)
        {
            //textPass.PasswordChar = '*';
            textPass.TextAlign = HorizontalAlignment.Center;
        }

        private void textConfirmPass_TextChanged(object sender, EventArgs e)
        {
            //textConfirmPass.PasswordChar = '*';
            textConfirmPass.TextAlign = HorizontalAlignment.Center;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEmail.Text))
            {
                MessageBox.Show("Please enter an email");
                return;
            }
            if (string.IsNullOrEmpty(textNick.Text))
            {
                MessageBox.Show("Please enter a nickname");
                return;
            }
            if (string.IsNullOrEmpty(textPass.Text))
            {
                MessageBox.Show("Please enter a password");
                return;
            }
            if (textPass.Text != textConfirmPass.Text)
            {
                MessageBox.Show("Please ensure the password match");
                textPass.Text = "";
                textConfirmPass.Text = "";
                return;
            }
            string buf = textPass.Text;
            if (buf.Length < 5)
            {
                MessageBox.Show("Length your password must be more than 5 symbols");
                return;
            }
            FormMain.Client.Connect(FormMain.IPADDRESS, FormMain.PORT);
            var creq = Packets.CreateRequest(textEmail.Text, textPass.Text, textNick.Text);
            FormMain.Client.WritePacket(creq);
            labelRegister.Visible = true;
        }
    }
}
