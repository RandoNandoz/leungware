using System;
using System.Windows.Forms;

namespace leungware_v420
{
    public partial class LeungWareToolBoard : Form
    {
        public bool DoExcecuteWithAdminRights = false;
        public LeungWareToolBoard()
        {
            InitializeComponent();
        }

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DoExcecuteWithAdminRights = true;
        }

        private void LeungWareToolBoard_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var instance = new ExecutorClass();
            instance.LaunchFileOfExeExt("Chrome.exe", DoExcecuteWithAdminRights);
        }
    }
}