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
    public partial class banVe : Form
    {
        public banVe()
        {
            InitializeComponent();
        }
        public void change(object sender)
        {
            try
            {
                Button btn = sender as Button;
                if(btn != null){
                    btn.BackColor = Color.Yellow;
                    btn.Tag = "Locked";   
                }else{
                    Console.WriteLine("The sender is not a Button!");
                }
            }catch(InvalidCastException ex){
                Console.WriteLine("Error content: " + ex.Message);
            }
        }
        public void locked(object sender)
        {
            try
            {
                Button btn = sender as Button;
                if (btn != null)
                {
                    if (btn.Tag as string != "Locked")
                    {
                        // Change the color of the button
                        btn.BackColor = Color.Blue;
                    }
                }
            }catch(InvalidCastException ex){
                Console.WriteLine("Error cont. : " + ex.Message);
            }
        }
        public void tinhtien()
        {
            
            double lo_A, lo_B, lo_C;
            lo_A = 1000; lo_B = 1500; lo_C = 2000;
            //
            
            Dictionary<Button, double> all_Btn = new Dictionary<Button, double>{
                {btn_1,lo_A},{btn_2,lo_A} ,{btn_3,lo_A},{btn_4,lo_A},{btn_5,lo_A},
                {btn_6,lo_B},{btn_7,lo_B}, {btn_8,lo_B}, {btn_9,lo_B}, {btn_10,lo_B},
                {btn_11,lo_C} ,{btn_12,lo_C},{btn_13,lo_C},{btn_14,lo_C},{btn_15,lo_C}
            };
            
            double tong = 0;
            foreach (var btn in all_Btn.Keys)
            {
                if (btn.BackColor == Color.Blue)
                {
                    tong += all_Btn[btn];
                    change(btn); locked(btn);
                }
            }
            txt_thtien.Text = tong.ToString();
        }
        
        public void dangChon(Button btn)
        {
            //c1
            //if (btn.Tag as string != "Locked")
            //{
            //    if (btn.BackColor == Color.Blue)
            //        btn.BackColor = Color.White;
            //    else
            //        btn.BackColor = Color.Blue;
            //}

            //c2
            if (btn.Tag as string != "Locked")
            {
                btn.BackColor = btn.BackColor == Color.Blue ? Color.White : Color.Blue;
            }
        }
        public void daBan(Button btn)
        {
            btn.BackColor = Color.Yellow;
            MessageBox.Show("Vé đã bán!");
        }
        private void btn_1_Click(object sender, EventArgs e)
        {
            dangChon(btn_1);
        }
        
        private void btn_12_Click(object sender, EventArgs e)
        {
            dangChon(btn_12);
            locked(btn_12);
            
        }

        private void btn_13_Click(object sender, EventArgs e)
        {
            dangChon(btn_13); 
        }

        private void btn_14_Click(object sender, EventArgs e)
        {
            dangChon(btn_14); 
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            daBan(btn_2);
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            daBan(btn_7);
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            daBan(btn_9);
        }

        private void btn_11_Click(object sender, EventArgs e)
        {
            daBan(btn_11);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tinhtien();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create a list of all buttons
            List<Button> allButtons = new List<Button> { btn_1, btn_2, btn_3, btn_4, btn_5, btn_6, btn_7, btn_8, btn_9, btn_10, btn_11, btn_12, btn_13, btn_14, btn_15 };

            // Change the color of all buttons with Blue backcolor to White
            foreach (Button btn in allButtons)
            {
                if (btn.BackColor == Color.Blue)
                {
                    btn.BackColor = Color.White;
                }
            }
            txt_thtien.Text = "0";
        }
        //public void huy(object sender)
        //{
        //    Button btn = sender as Button;
        //    if (button3.Enabled == true)
        //        if ( btn.BackColor == Color.Blue)
        //            btn.BackColor = Color.White;
        //}
        
    }
}
