
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
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {

        }


    }
}
