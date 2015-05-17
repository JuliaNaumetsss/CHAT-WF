
namespace clientExample
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public partial class FormMain : Form
    {
        public static Client Client = new Client();

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern uint ScrollText(IntPtr hwnd, uint wMsg, uint wParam, uint lParam);
        private const int WM_VSCROLL = 0x115;
        private const int SB_BOTTOM = 7;

        public static string IPADDRESS = "127.0.0.1";
        public const int PORT = 1987;
        public static string CurrentNickname = "";
        public static int CurrentUserId = 0;
        public FormMain()
        {
            InitializeComponent();
            AcceptButton = buttonConnect;
            //Client.OnDataRecieved += OnDataRecieved;
            //Client.OnDisconnect += (() => ButtonLogoutClick(null, null));
            //Closing += FormMain_Closing;
            //messageBox.TextChanged += MessageBoxTextChanged;
            //Shown += FormMainShown;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (Sets.RegisterInstance != null)
                if (!Sets.RegisterInstance.IsDisposed)
                {
                    Sets.RegisterInstance.Close();
                }
            Sets.RegisterInstance = new FormRegister();
            Sets.RegisterInstance.ShowDialog();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            groupConnect.Enabled = false;
            if (!Client.Connect(IPADDRESS, PORT))
            {
                groupConnect.Enabled = true;
                textBoxEmail.Select();
                MessageBox.Show("Failed to connect to server.");
                return;
            }
            Client.WritePacket(
                new Packet(
                    "LOGIN REQUEST",
                    DataMap.Serialize(
                        new List<string>
                            {
                                textBoxEmail.Text, textBoxPassword.Text
                            })));
        }

        private void buttonChangeNick_Click(object sender, EventArgs e)
        {
            string newNickname = CurrentNickname;
            var result = InputBox.Show("Change your nickname", "Edit your nickname, then press submit to save changes", ref newNickname, false);
            if (result == DialogResult.OK)
            {
                Client.WritePacket(Packets.UpdateNickname(newNickname));
                CurrentNickname = newNickname;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            var msgPack = new Packet("MESSAGE REQUEST", textBoxMessage.Text);
            Client.WritePacket(msgPack);
            textBoxMessage.Clear();
            textBoxMessage.Select();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Client.TcpClient.Close();
            }
            catch
            {
            }
            /*messageBox.Clear();
            textBoxMessage.Clear();*/
            groupConnect.Enabled = true;
            //groupBox.Enabled = false;
        }

        private void buttonChangePass_Click(object sender, EventArgs e)
        {
            string newPass = "";
            var result = InputBox.Show("Change your password", "Edit your password, then press submit to save changes", ref newPass, true);
            if (result == DialogResult.OK)
            {
                Client.WritePacket(Packets.UpdatePassword(newPass));
            }
        }


    }
}
