using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Collections.ObjectModel;

namespace QLBDX
{
    /// <summary>
    /// Interaction logic for QuanLyXeVaoUC.xaml
    /// </summary>
    public partial class QuanLyXeVaoUC : UserControl
    {
        public QuanLyXeVaoUC()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnXacNhan_Click(object sender, RoutedEventArgs e)
        {
            NhatKyVao nhatKyVao = new NhatKyVao();
            if(txtBienSoXe.Text== "Không nhận diện được biển số")
            {
                MessageBox.Show("Yêu cầu nhập thủ công biển số");
                return;
            }
            nhatKyVao.BienSoXe = txtBienSoXe.Text;
            nhatKyVao.ThoiGian = DateTime.Now;
            nhatKyVao.IDNhanVien = (string)cboNhanVien.SelectedValue;
            nhatKyVao.IDTheGuiXe = (int)cboTheGuiXe.SelectedValue;
            nhatKyVao.IDLoaiXe = (int)cboLoaiXe.SelectedValue;
            nhatKyVao.Urlanh = urlAnh;
            DataProvider.Instance.DB.NhatKyVaos.Add(nhatKyVao);
            DataProvider.Instance.DB.SaveChanges();
            MessageBox.Show("Thêm nhật ký vào thành công");
            var checkxe = DataProvider.Instance.DB.XeTrongBais.SingleOrDefault(n => n.IDXeTrongBai == nhatKyVao.BienSoXe);
            if (checkxe != null)
            {
                MessageBox.Show("Xe này đã có ở trong bãi đề nghị kiểm tra lại biển số");
                return;
            }
            XeTrongBai xeTrongBai = new XeTrongBai();
            xeTrongBai.IDLoaiXe = nhatKyVao.IDLoaiXe;
            xeTrongBai.IDTheGuiXe = nhatKyVao.IDTheGuiXe;
            xeTrongBai.IDXeTrongBai = nhatKyVao.BienSoXe;
            xeTrongBai.UrlAnh = nhatKyVao.Urlanh;
            xeTrongBai.ThoiGianVao = nhatKyVao.ThoiGian;
            DataProvider.Instance.DB.XeTrongBais.Add(xeTrongBai);
            DataProvider.Instance.DB.SaveChanges();
            MessageBox.Show("Xe đã được phép vào trong bãi đậu xe");
            var thegui = DataProvider.Instance.DB.TheGuiXes.SingleOrDefault(n => n.IDTheGuiXe == nhatKyVao.IDTheGuiXe);
            thegui.DangSuDung = true;
            DataProvider.Instance.DB.SaveChanges();
            MessageBox.Show("Cập nhật thành công");
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cboNhanVien.ItemsSource = new ObservableCollection<NhanVien>(DataProvider.Instance.DB.NhanViens);
            cboNhanVien.DisplayMemberPath = "HoTen";
            cboNhanVien.SelectedValuePath = "IDNhanVien";

            cboTheGuiXe.ItemsSource = new ObservableCollection<TheGuiXe>(DataProvider.Instance.DB.TheGuiXes.Where(n => n.DangSuDung == false && n.IDLoaiThe == 1));
            var dem = new ObservableCollection<TheGuiXe>(DataProvider.Instance.DB.TheGuiXes.Where(n => (n.DangSuDung == false && n.IDLoaiThe == 1) || n.IDLoaiThe == 2 || n.IDLoaiThe == 3));
            //MessageBox.Show(dem.Count.ToString());
            cboTheGuiXe.DisplayMemberPath = "IDTheGuiXe";
            cboTheGuiXe.SelectedValuePath = "IDTheGuiXe";

            cboLoaiXe.ItemsSource = new ObservableCollection<LoaiXe>(DataProvider.Instance.DB.LoaiXes);
            cboLoaiXe.DisplayMemberPath = "TenLoaiXe";
            cboLoaiXe.SelectedValuePath = "IDLoaiXe";

           
        }
        string urlAnh = "";
        private void BtnMoAnh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == true)
            {
                urlAnh = fileDialog.FileName;
                imgSrc.Source = new BitmapImage(new Uri(fileDialog.FileName));
                txtBienSoXe.Text = "Đang phân tích biển số xin chờ ...";
                txtBienSoXe.Text = LicensePlateRecognition.LicensePlateDetector.FindLicensePlate(fileDialog.FileName);
                var xethang = DataProvider.Instance.DB.XeThangs.SingleOrDefault(n => n.BienSo == txtBienSoXe.Text);
                if(xethang !=null)
                {
                    txtLoaiThe.Text = xethang.IDTheGuiXe.ToString();
                    txtCoHieuLuc.Text = xethang.NgayHetHan > DateTime.Now ? "Có hiệu lực" : "Đã hết hạn";
                    txtLoaiThe.Text = xethang.TheGuiXe.LoaiThe.TenLoaiThe;
                    MessageBox.Show(xethang.IDTheGuiXe.ToString());
                    cboTheGuiXe.Text = xethang.IDTheGuiXe.ToString();

                   
                    //cboTheGuiXe.Text = xethang.IDTheGuiXe.ToString();
                }
            }
        }

        private void CboTheGuiXe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedTheID = (int)cboTheGuiXe.SelectedValue;
            TheGuiXe theGuiXeSelected = DataProvider.Instance.DB.TheGuiXes.SingleOrDefault(n => n.IDTheGuiXe == selectedTheID);
            if (theGuiXeSelected == null) return;
            txtCoHieuLuc.Text = theGuiXeSelected.NgayHetHan > DateTime.Now ? "Có hiệu lực" : "Đã hết hạn";
            txtLoaiThe.Text = theGuiXeSelected.LoaiThe.TenLoaiThe;
        }
    }
}
