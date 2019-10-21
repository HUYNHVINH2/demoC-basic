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
    public partial class Form2 : Form
    {

        // Chuỗi kết nối   
        string strConnectionString = "Data Source=DESKTOP-ASPTBGR;Initial Catalog=QuanLyBanHang;Integrated Security=True";         // Đối tượng kết nối     
        SqlConnection conn = null;         // Đối tượng đưa dữ liệu vào DataTable dtKhachHang    
        SqlDataAdapter daKhachHang = null;  
        DataTable dataKhachHang = null;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi động connection      
                // Khởi động connection 
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtKhachHang      
                daKhachHang = new SqlDataAdapter("SELECT * FROM KHACHHANG", conn);
                dataKhachHang = new DataTable();
                dataKhachHang.Clear();
                daKhachHang.Fill(dataKhachHang);     
                // Đưa dữ liệu lên DataGridView    
                dataGridView1.DataSource = dataKhachHang; 
            }
            catch (SqlException) { MessageBox.Show("Không lấy được nội dung trong table KhachHang. Lỗi rồi!!!"); }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên      
            dataKhachHang.Dispose();
            dataKhachHang = null;             // Hủy kết nối     
            conn = null;  
        }
    }
}
