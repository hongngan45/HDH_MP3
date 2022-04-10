using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        [DllImport("Winmm.dll", CharSet = CharSet.Unicode, EntryPoint = "mciSendStringW")]
        private static extern long mciSendString(
                        string lpszCommand,
                        StringBuilder lpszReturnString,
                        int cchReturn,
                        IntPtr hwndCallback
                        );
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sFileMP3 = "C:\\Users\\admin\\Downloads\\nhac.mp3";
            string sCmd = "OPEN \"" + sFileMP3 + "\" alias tuan";
            mciSendString(sCmd, null, 0, IntPtr.Zero);
            mciSendString("PLAY tuan", null, 0, IntPtr.Zero);
        }
        private void cmdStop_Click(object sender, EventArgs e)
        {
            mciSendString("STOP tuan", null, 0, IntPtr.Zero);
            mciSendString("CLOSE tuan", null, 0, IntPtr.Zero);
        }
    }
}
