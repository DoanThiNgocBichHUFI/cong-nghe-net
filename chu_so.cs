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
    public partial class so_chu : Form
    {
        public so_chu()
        {
            InitializeComponent();
        }
        public string SoThanhChu(int so)
        {
            string[] donVi = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

            if (so == 0)
                return donVi[0];

            string chu = "";
            int hangNghin = so / 1000;
            int hangTram = (so % 1000) / 100;
            int hangChuc = (so % 100) / 10;
            int hangDonVi = so % 10;

            if (hangNghin > 0)
                chu += donVi[hangNghin] + " nghìn ";

            if (hangTram > 0)
                chu += donVi[hangTram] + " trăm ";

            if (hangChuc > 0)
            {
                if (hangChuc == 1)
                    chu += "mười ";
                else
                    chu += donVi[hangChuc] + " mươi ";
            }

            if (hangDonVi > 0)
            {
                if (hangDonVi == 1 && hangChuc > 0)
                    chu += "mốt";
                else
                    chu += donVi[hangDonVi];
            }

            return chu;
        }

        private void btn_thuchien_Click(object sender, EventArgs e)
        {
            string input = txt_so.Text;
            int so;
            bool isNumberic = int.TryParse(input, out so);
            if (isNumberic)
            {
                string chu = SoThanhChu(so);
                lb_kq.Text = chu;
            }
            else {
                MessageBox.Show("Vui lòng nhập một số hợp lệ.");
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            txt_so.Clear(); lb_kq.Text = " ";
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void so_chu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.OKCancel);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
