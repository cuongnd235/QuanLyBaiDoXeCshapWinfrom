using Microsoft.Win32;
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
    /// Interaction logic for QuanLyGuiXeThangUC.xaml
    /// </summary>
    public partial class QuanLyGuiXeThangUC : UserControl
    {
        public QuanLyGuiXeThangUC()
        {
            _list = new ObservableCollection<XeThang>(DataProvider.Instance.DB.XeThangs);
            InitializeComponent();

        }

        private ObservableCollection<XeThang> _list;

        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;

        private XeThang _xethangSelected;


        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtBienSoXe.Text = "";

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
               
                var xeThang = DataProvider.Instance.DB.XeThangs.SingleOrDefault(n => n.BienSo == txtBienSoXe.Text);
                if (xeThang != null)
                {
                    var thegui = DataProvider.Instance.DB.TheGuiXes.SingleOrDefault(n => n.IDTheGuiXe == xeThang.IDTheGuiXe);
                    if(thegui == null)
                    {
                        return;
                    }
                    DataProvider.Instance.DB.XeThangs.Remove(xeThang);
                  
                    
                    thegui.DangSuDung = false;
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
                var xeThang = new XeThang();

                xeThang.IDTheGuiXe = (int)cboTheThang.SelectedValue;
                xeThang.BienSo = txtBienSoXe.Text;
                xeThang.MoTa = txtMoTa.Text;
                xeThang.NgayDangKy = pdNgayDangKy.SelectedDate;
                xeThang.NgayHetHan = pdNgayHetHan.SelectedDate;
                xeThang.UrlAnh = txtUrlAnh.Text;
                xeThang.TongTien = int.Parse(txtTongTien.Text);

                DataProvider.Instance.DB.XeThangs.Add(xeThang);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Thêm thành công");

                var theguixe = DataProvider.Instance.DB.TheGuiXes.SingleOrDefault(n => n.IDTheGuiXe == xeThang.IDTheGuiXe);
                if(theguixe != null)
                {
                    theguixe.DangSuDung = true;
                    DataProvider.Instance.DB.SaveChanges();
                    MessageBox.Show("OK");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void Sua()
        {
            
            var xeThang = DataProvider.Instance.DB.XeThangs.SingleOrDefault(n => n.BienSo == txtBienSoXe.Text);
            if (xeThang != null)
            {
                xeThang.IDTheGuiXe = int.Parse(cboTheThang.Text);
                xeThang.MoTa = txtMoTa.Text;
                xeThang.UrlAnh = txtUrlAnh.Text;
                xeThang.TongTien = int.Parse(txtTongTien.Text);
                xeThang.NgayDangKy = pdNgayDangKy.SelectedDate;
                xeThang.NgayHetHan = pdNgayHetHan.SelectedDate;
                

                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Sửa thành công");
            }

        }
        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {
           
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


            _list = new ObservableCollection<XeThang>(DataProvider.Instance.DB.XeThangs);
            cboTheThang.ItemsSource = new ObservableCollection<TheGuiXe>(DataProvider.Instance.DB.TheGuiXes.Where(n => n.IDLoaiThe == 2 && n.NgayHetHan > DateTime.Now && n.DangSuDung == false));

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
            _xethangSelected = item as XeThang;
            if (_xethangSelected == null)
            {
                return;
            }

            txtBienSoXe.Text = _xethangSelected.BienSo;
            txtTongTien.Text = _xethangSelected.TongTien.ToString();
            txtUrlAnh.Text = _xethangSelected.UrlAnh;
            txtMoTa.Text = _xethangSelected.MoTa;
            cboTheThang.SelectedValue = _xethangSelected.IDTheGuiXe;

            btnSua.IsEnabled = true;
        }

        private void TxtTongTien_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void BtnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            lsvData.ItemsSource = new ObservableCollection<XeThang>(DataProvider.Instance.DB.XeThangs.Where(n=>n.BienSo.Contains(txtTimKiem.Text)));
        }



        private void TxtUrlAnh_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtUrlAnh.Text = openFileDialog.FileName;
            }
        }
    }

}
