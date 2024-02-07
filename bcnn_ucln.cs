using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pheptinh
{
    public partial class bcnn : Form
    {
        public bcnn()
        {
            InitializeComponent();
            txt_bc.Enabled = false; txt_us.Enabled = false;
        }

        private void txt_a_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            //câu lệnh if chỉ thực thi nếu chuỗi ctr.Text không trống và ký tự cuối cùng của nó không phải là số. 
            if (ctr.Text.Length > 0 && !Char.IsDigit(ctr.Text[ctr.Text.Length - 1]))
            {
                this.errorProvider1.SetError(ctr, "Giá trị không hợp lệ.");
            }
            else
                this.errorProvider1.Clear();
        }

        private void txt_a_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt.Text.Length == 0)
            {
                this.errorProvider1.SetError(txt, "Bắt buộc nhập");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void btn_thuchien_Click(object sender, EventArgs e)
        {
            //tìm ucln
            int a, b;
            try
            {
                a = int.Parse(txt_a.Text); b = int.Parse(txt_b.Text);

                if (a == 0 || b == 0)
                {
                    txt_us.Text = (a + b).ToString();   
                }
                while (a != b)
                {
                    if (a > b) a -= b;
                    else b -= a; 
                }
                txt_us.Text = a.ToString();
            }
            catch(Exception ex){
                MessageBox.Show("Loi" + ex); return;
            }

            // tìm bcnn
            int so_a, so_b, ucln;
            try
            {
                so_a = int.Parse(txt_a.Text); so_b = int.Parse(txt_b.Text);
                ucln= a;
                txt_bc.Text = ((so_a * so_b) / ucln).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex); return;
            }
        }

        private void btn_tieptuc_Click(object sender, EventArgs e)
        {
            txt_a.Clear(); txt_b.Clear();
            txt_bc.Clear(); txt_us.Clear();
            txt_a.Focus(); txt_b.Focus();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bcnn_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn tiếp tục?", "Hỏi người dùng", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                Dispose();
        }

        private void bcnn_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
