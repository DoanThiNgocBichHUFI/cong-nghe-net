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
    public partial class Dayso : Form
    {
        public Dayso()
        {
            InitializeComponent();
            txt_dayso.Enabled = false;
            txt_tong.Enabled = false;
            txt_tongChan.Enabled = false;
            txt_tongLe.Enabled = false;
        }

        private void btn_nhap_Click(object sender, EventArgs e)
        {
            string a = txt_nhap.Text;
            if (a.Length == 0 || a.All(char.IsDigit) == false)
            {
                MessageBox.Show("Nhap lai", "Thong bao ", MessageBoxButtons.OK);
                txt_nhap.Focus();
            }
            else
            {
                txt_dayso.Text = txt_dayso.Text + a + " ";
                txt_nhap.Clear(); txt_nhap.Focus();

                //tong
                int tong, tongChan, tongLe, so;
                tong = 0; tongChan = 0;  tongLe = 0;
                string s = txt_dayso.Text.Trim();
                string[] str= s.Split(' ');
                for (int i = 0; i < str.Length; i++)
                {
                    so = int.Parse(str[i]); tong += so;
                    if (so % 2 != 0)
                        tongLe += so;
                    else tongChan += so;
                }
                txt_tong.Text = tong.ToString();
                txt_tongChan.Text = tongChan.ToString();
                txt_tongLe.Text = tongLe.ToString();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dayso_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.OKCancel);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void txt_nhap_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            //câu lệnh if chỉ thực thi nếu chuỗi ctr.Text không trống và ký tự cuối cùng của nó không phải là số. 
            if (ctr.Text.Length > 0 && !Char.IsDigit(ctr.Text[ctr.Text.Length - 1]))
                this.errorProvider1.SetError(ctr, "Giá trị không hợp lệ");
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void btn_tiep_Click(object sender, EventArgs e)
        {
            txt_nhap.Clear(); txt_nhap.Focus();
            txt_dayso.Clear(); txt_tong.Clear(); txt_tongChan.Clear(); txt_tongLe.Clear();
        }

    }
}
