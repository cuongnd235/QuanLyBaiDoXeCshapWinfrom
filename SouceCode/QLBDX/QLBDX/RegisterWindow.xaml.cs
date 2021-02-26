using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLBDX
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }
        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtTenDangNhap.Text;
            var o = DataProvider.Instance.DB.NhanViens.SingleOrDefault(n => n.IDNhanVien == username);
            if (o != null)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại");
                return;
            }
            NhanVien user = new NhanVien { IDNhanVien = txtTenDangNhap.Text, MatKhau = FloatingPasswordBox.Password, Email = txtEmail.Text , IDQuyen=2 };
            DataProvider.Instance.DB.NhanViens.Add(user);
            DataProvider.Instance.DB.SaveChanges();
            MessageBox.Show("Đăng ký thành công ");
            this.Close();
        }
    }
}
