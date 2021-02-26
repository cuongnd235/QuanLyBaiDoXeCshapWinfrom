using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLBDX
{
    /// <summary>
    /// Interaction logic for NhanVienUC.xaml
    /// </summary>
    public partial class NhanVienUC : UserControl
    {
       
        public NhanVienUC()
        {
            _list = new ObservableCollection<NhanVien>(DataProvider.Instance.DB.NhanViens);
            InitializeComponent();
        }

        private ObservableCollection<NhanVien> _list;

        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;

        private NhanVien _nhanvienSelected;


        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtIDNhanVien.Text = "";
            txtHoTen.Text = "";
            txtMatKhau.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";

            btnHuy.Visibility = Visibility.Visible;
            btnLuu.Visibility = Visibility.Visible;
            btnSua.IsEnabled = false;
            btnThem.IsEnabled = false;
            btnXoa.IsEnabled = false;
            userAction = UserAction.Them;
        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            btnHuy.Visibility = Visibility.Visible;
            btnLuu.Visibility = Visibility.Visible;
            btnSua.IsEnabled = false;
            btnThem.IsEnabled = false;
            btnXoa.IsEnabled = false;
            userAction = UserAction.Sua;
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            userAction = UserAction.Xoa;
            if (MessageBox.Show("Xóa", "Bạn có chắc sẽ xóa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var nhanvien = DataProvider.Instance.DB.NhanViens.SingleOrDefault(n => n.IDNhanVien == txtIDNhanVien.Text);
                if (nhanvien != null)
                {
                    DataProvider.Instance.DB.NhanViens.Remove(nhanvien);
                    DataProvider.Instance.DB.SaveChanges();
                    UserControl_Loaded(null, null);
                    MessageBox.Show("Xóa thành công");
                    return;
                }
                MessageBox.Show("Xóa không thành công");
                return;
            }
        }
        private void Them()
        {
            try
            {
                var nhanvien = new NhanVien();
               
                var alreadynv = DataProvider.Instance.DB.NhanViens.SingleOrDefault(n => n.IDNhanVien == nhanvien.IDNhanVien);
                if (alreadynv != null)
                {
                    MessageBox.Show("Số điện thoại của nhân viên đã tồn tại");
                    return;
                }
                nhanvien.IDNhanVien = txtIDNhanVien.Text;
                nhanvien.SDT = txtSDT.Text;
                nhanvien.HoTen = txtHoTen.Text;
                nhanvien.SinhNhat = pdSinhNhat.SelectedDate;
                nhanvien.DiaChi = txtDiaChi.Text;
                nhanvien.MatKhau =txtMatKhau.Text;
                nhanvien.Email = txtEmail.Text;
                nhanvien.IDQuyen = (int)cboQuyen.SelectedValue;
                DataProvider.Instance.DB.NhanViens.Add(nhanvien);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void Sua()
        {

            var nhanvien = DataProvider.Instance.DB.NhanViens.SingleOrDefault(n => n.IDNhanVien == txtIDNhanVien.Text);
            if (nhanvien != null)
            {
                nhanvien.HoTen = txtHoTen.Text;
                nhanvien.SDT = txtSDT.Text;
             
                nhanvien.SinhNhat = pdSinhNhat.SelectedDate;
                nhanvien.Email = txtEmail.Text;
                nhanvien.MatKhau = txtMatKhau.Text;
                nhanvien.DiaChi = txtDiaChi.Text;
                nhanvien.IDQuyen = (int)cboQuyen.SelectedValue;
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Sửa thành công");
            }

        }
        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (txtHoTen.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Không được để trống họ tên hoặc điện thoại");
                return;
            }
            switch (userAction)
            {
                case UserAction.Them:
                    Them();
                    break;
                case UserAction.Sua:
                    Sua();
                    break;
            }
            userAction = UserAction.Luu;
            UserControl_Loaded(null, null);
        }

        private void BtnHuy_Click(object sender, RoutedEventArgs e)
        {
            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
            userAction = UserAction.Huy;
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
           
            _list = new ObservableCollection<NhanVien>(DataProvider.Instance.DB.NhanViens);
            cboQuyen.ItemsSource = new ObservableCollection<Quyen>(DataProvider.Instance.DB.Quyens);
            cboQuyen.DisplayMemberPath = "TenQuyen";
            cboQuyen.SelectedValuePath = "IDQuyen";

            lsvData.ItemsSource = _list;
            

            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
        }

        private void LsvData_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _nhanvienSelected = item as NhanVien;
            if (_nhanvienSelected == null)
            {
                return;
            }
            txtIDNhanVien.Text = _nhanvienSelected.IDNhanVien;
            txtHoTen.Text = _nhanvienSelected.HoTen;
            txtEmail.Text = _nhanvienSelected.Email;
            txtSDT.Text = _nhanvienSelected.SDT;
            txtMatKhau.Text = _nhanvienSelected.MatKhau;
            txtDiaChi.Text = _nhanvienSelected.DiaChi;
            cboQuyen.SelectedValue = _nhanvienSelected.IDQuyen;
            btnSua.IsEnabled = true;
        }

        private void BtnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            lsvData.ItemsSource = new ObservableCollection<NhanVien>(DataProvider.Instance.DB.NhanViens.Where(n=>n.HoTen.Contains(txtTimKiem.Text)));
        }
    }
}
