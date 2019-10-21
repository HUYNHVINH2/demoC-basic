using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace quan_ly_ban_hang
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối     
        string strConnectionString = "Data Source=DESKTOP-ASPTBGR;Initial Catalog=QuanLyBanHang;Integrated Security=True";
        // Đối tượng kết nối       
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho      
        SqlDataAdapter daThanhPho = null;         // Đối tượng hiển thị dữ liệu lên Form    
        DataTable dtThanhPho = null;   

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi          
            DialogResult traloi;             // Hiện hộp thoại hỏi đáp   
            traloi = MessageBox.Show("Chắc không?", "Trả lời",         
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);             // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) Application.Exit();   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {  
                // Khởi động connection      
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtThanhPho     
                daThanhPho = new SqlDataAdapter("SELECT * FROM THANHPHO", conn);
                dtThanhPho = new DataTable();
                dtThanhPho.Clear(); 
                daThanhPho.Fill(dtThanhPho);                 // Đưa dữ liệu lên ListBox           
                this.lstThanhPho.DataSource = dtThanhPho;
                this.lstThanhPho.DisplayMember = "TenThanhPho";
                this.lstThanhPho.ValueMember = "ThanhPho";
            }
            catch (SqlException) { MessageBox.Show("Không lấy được nội dung trong table THANHPHO. Lỗi rồi!!!"); }
        }

        private void lstThanhPho_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn chọn Thành phố :" + lstThanhPho.SelectedValue.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
