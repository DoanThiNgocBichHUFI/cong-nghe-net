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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txt_a_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Length > 0 && !Char.IsDigit(ctr.Text[ctr.Text.Length - 1]))
                this.errorProvider1.SetError(ctr,"This is not avalid number.");
            else
                this.errorProvider1.Clear();
        }

        private void btn_cong_Click(object sender, EventArgs e)
        {
            float a, b;
            try
            {
                a= float.Parse(txt_a.Text);
                b= float.Parse(txt_b.Text);
                txt_kq.Text= (a+b).ToString();
            }catch(Exception ex){
                MessageBox.Show("Loi " + ex);
                return;
            }
        }

        private void btn_tru_Click(object sender, EventArgs e)
        {
            float a, b;
            try
            {
                a = float.Parse(txt_a.Text); b = float.Parse(txt_b.Text);
                txt_kq.Text = (a - b).ToString();
            }catch(Exception ex){
                MessageBox.Show("Loi" + ex); return;
            }
        }

        private void btn_nhan_Click(object sender, EventArgs e)
        {
            float a, b;
            try {
                a = float.Parse(txt_a.Text); b = float.Parse(txt_b.Text);
                txt_kq.Text = (a * b).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex);
            }
        }

        private void btn_chia_Click(object sender, EventArgs e)
        {
            float a, b;
            try
            {
                a = float.Parse(txt_a.Text); b = float.Parse(txt_b.Text);
                txt_kq.Text = (a / b).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex);
            }
        }
    }
}
