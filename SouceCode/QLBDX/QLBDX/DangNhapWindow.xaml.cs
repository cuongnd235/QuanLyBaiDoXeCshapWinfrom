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
    /// Interaction logic for DangNhapWindow.xaml
    /// </summary>
    public partial class DangNhapWindow : Window
    {
        public DangNhapWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = DataProvider.Instance.DB.NhanViens.SingleOrDefault(n => n.IDNhanVien == txtTenDangNhap.Text && n.MatKhau == FloatingPasswordBox.Password);
            if (user == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác");
                return;
            }
            MessageBox.Show("Đăng nhập thành công");
            MainWindow mainWindow = new MainWindow((int)user.IDQuyen);
            mainWindow.Show();
            this.Close();
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }
    }
}
