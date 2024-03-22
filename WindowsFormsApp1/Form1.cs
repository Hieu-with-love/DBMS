using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDropdownMenu();
        }

        private void InitializeDropdownMenu()
        {
            // Tạo một ContextMenuStrip mới
            ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();

            // Thêm các mục menu
            ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Mục 1");
            ToolStripMenuItem menuItem2 = new ToolStripMenuItem("Mục 2");
            ToolStripMenuItem menuItem3 = new ToolStripMenuItem("Mục 3");

            // Gắn các sự kiện xử lý cho các mục menu nếu cần
            menuItem1.Click += MenuItem_Click;
            menuItem2.Click += MenuItem_Click;
            menuItem3.Click += MenuItem_Click;

            // Thêm các mục menu vào ContextMenuStrip
            contextMenuStrip1.Items.Add(menuItem1);
            contextMenuStrip1.Items.Add(menuItem2);
            contextMenuStrip1.Items.Add(menuItem3);

            button1.AllowDrop = true;
            // Gán ContextMenuStrip cho button
            button1.ContextMenuStrip = contextMenuStrip1;
        }

        // Xử lý sự kiện khi một mục menu được chọn
        private void MenuItem_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện ở đây
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;
            MessageBox.Show("Bạn đã chọn: " + clickedItem.Text);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
