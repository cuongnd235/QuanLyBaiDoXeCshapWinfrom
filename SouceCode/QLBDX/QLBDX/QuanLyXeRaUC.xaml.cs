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
    /// Interaction logic for QuanLyXeRaUC.xaml
    /// </summary>
    public partial class QuanLyXeRaUC : UserControl
    {
        public QuanLyXeRaUC()
        {
            InitializeComponent();
            txtThoiGianRa.Text = "";
            txtThoiGianGui.Text = "";
            txtThoiGianVao.Text = "";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cboNhanVien.ItemsSource= new ObservableCollection<NhanVien>(DataProvider.Instance.DB.NhanViens);
            cboNhanVien.DisplayMemberPath = "HoTen";
            cboNhanVien.SelectedValuePath = "IDNhanVien";
            
            cboLoaiXe.ItemsSource = new ObservableCollection<LoaiXe>(DataProvider.Instance.DB.LoaiXes);
            cboLoaiXe.DisplayMemberPath = "TenLoaiXe";
            cboLoaiXe.SelectedValuePath = "IDLoaiXe";
        }

        private void BtnXacNhan_Click(object sender, RoutedEventArgs e)
        {
            var xebai = DataProvider.Instance.DB.XeTrongBais.SingleOrDefault(n => n.IDXeTrongBai == xeTrongBai.IDXeTrongBai);
            if (xebai == null)
            {
                MessageBox.Show("Trong bãi không có xe này");

                return;
            }
            if (xebai.TheGuiXe.IDLoaiThe == 2)
            {
                MessageBox.Show("Xe theo tháng , cho phép qua");
                DataProvider.Instance.DB.XeTrongBais.Remove(xebai);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Xe đã được đưa ra khỏi bãi");
                return;
            }
            if (txtTheKhachDua.Text != txtMaThe.Text)
            {
                MessageBox.Show("Thẻ khách đưa không khớp với thông tin thẻ trong hệ thống ứng với biển số này");
                return;
            }


            HoaDon hoaDon = new HoaDon();
            hoaDon.BienSoXe = txtBienSoXe.Text;
            hoaDon.IDLoaiXe = xeTrongBai.IDLoaiXe;
            hoaDon.IDNhanVien = (string)cboNhanVien.SelectedValue;
            hoaDon.IDTheGuiXe = xeTrongBai.IDTheGuiXe;
            hoaDon.ThoiGian = DateTime.Now;
            hoaDon.TongTien = tongtien;
            DataProvider.Instance.DB.HoaDons.Add(hoaDon);
            DataProvider.Instance.DB.SaveChanges();
            MessageBox.Show("Thanh toán thành công");

            DataProvider.Instance.DB.XeTrongBais.Remove(xebai);
            DataProvider.Instance.DB.SaveChanges();
            MessageBox.Show("Xe đã được đưa ra khỏi bãi");
            var thexe = DataProvider.Instance.DB.TheGuiXes.SingleOrDefault(n => n.IDTheGuiXe == hoaDon.IDTheGuiXe);
            thexe.DangSuDung = false;
            DataProvider.Instance.DB.SaveChanges();
            MessageBox.Show("Hoàn tất");
        }
        XeTrongBai xeTrongBai;
        int tongtien;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtBienSoXe.Text = "Đang phân tích biển số xin đợi";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {

                imgsrc.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                txtBienSoXe.Text = LicensePlateRecognition.LicensePlateDetector.FindLicensePlate(openFileDialog.FileName);
                txtThoiGianRa.Text = "Thời gian xe ra: " + DateTime.Now;
                xeTrongBai = DataProvider.Instance.DB.XeTrongBais.SingleOrDefault(n => n.IDXeTrongBai == txtBienSoXe.Text);
                if (xeTrongBai == null)
                {
                    MessageBox.Show("Trong bãi không có xe này");
                    return;
                }
                txtLoaiThe.Text = xeTrongBai.TheGuiXe.LoaiThe.TenLoaiThe;
                txtCoHieuLuc.Text = xeTrongBai.TheGuiXe.NgayHetHan > DateTime.Now ? "Còn hiệu lực" : "Đã hết hạn";
                txtMaThe.Text = xeTrongBai.IDTheGuiXe.ToString();
                int soGioGui = (int)(DateTime.Now - (DateTime)xeTrongBai.ThoiGianVao).TotalHours;
                txtThoiGianVao.Text = "Thời gian vào: "+ (DateTime)xeTrongBai.ThoiGianVao;
                txtThoiGianGui.Text = "Số giờ gửi: " + soGioGui;
                tongtien = soGioGui * (int)xeTrongBai.LoaiXe.DonGia;
                txtTongTien.Text = "Tổng tiền:" + tongtien.ToString();
                cboLoaiXe.Text = xeTrongBai.LoaiXe.TenLoaiXe;

            }
        }
    }
}
