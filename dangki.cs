using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace pheptinh
{
    public partial class DangKi : Form
    {
        public DangKi()
        {
            InitializeComponent();
            // Đặt PasswordChar cho txt_pass ngay sau khi Form được tải
            txt_pass.PasswordChar = '*';
            txt_repass.PasswordChar = '*';
        }

        public bool IsEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch(FormatException)
            {
                return false;
            }
        }
        private void txt_email_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Length == 0)
            {
                this.errorProvider1.SetError(ctr, "Bắt buộc nhập");
            }
            else
            {
                string a = txt_email.Text;
                if (IsEmail(a) == true)
                    this.errorProvider1.Clear();
                else
                    this.errorProvider1.SetError(ctr, "Nhập đúng email.");
            }
        }

        private void txt_ten_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if(txt.Tag != null && txt.Tag.ToString()== "*")
            {
                if (txt.Text.Length == 0)
                {
                    this.errorProvider1.SetError(txt, "Bắt buộc nhập");
                }
                else
                {
                    this.errorProvider1.Clear();
                }
            }
        }

        private void txt_pass_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt.Tag != null && txt.Tag.ToString() == "*")
            {
                if (txt.Text.Length == 0)
                {
                    this.errorProvider1.SetError(txt, "Bắt buộc nhập");
                }
                else
                {
                    this.errorProvider1.Clear();
                }
            }
        }
        private void showTxtInfo()
        {
            string info = String.Format("Email: {0}\nTên: {1}\nMật khẩu: {2}", txt_email.Text, txt_ten.Text, txt_pass.Text);
            MessageBox.Show(info, "Thông tin đăng kí");
        }

        private void btn_dangki_Click(object sender, EventArgs e)
        {
            showTxtInfo();
        }

        private void txt_repass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                showTxtInfo();
            }
        }

        private void DangKi_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

    }
}
