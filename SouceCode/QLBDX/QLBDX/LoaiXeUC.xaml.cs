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
    /// Interaction logic for LoaiXeUC.xaml
    /// </summary>
    public partial class LoaiXeUC : UserControl
    {
        public LoaiXeUC()
        {
            _list = new ObservableCollection<LoaiXe>(DataProvider.Instance.DB.LoaiXes);
            InitializeComponent();

        }

        private ObservableCollection<LoaiXe> _list;

        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;

        private LoaiXe _loaixeSelected;


        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtIDLoaiXe.Text = "auto";
            txtDonGia.Text = "";
            txtTenLoaiXe.Text = "";
            txtMoTa.Text = "";

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
                int idloaixe = int.Parse(txtIDLoaiXe.Text);
                var loaixe = DataProvider.Instance.DB.LoaiXes.SingleOrDefault(n => n.IDLoaiXe == idloaixe);
                if (loaixe != null)
                {
                    DataProvider.Instance.DB.LoaiXes.Remove(loaixe);
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
                var loaixe = new LoaiXe();

                loaixe.MoTa = txtMoTa.Text;
                loaixe.TenLoaiXe = txtTenLoaiXe.Text;
                loaixe.DonGia = int.Parse(txtDonGia.Text);
          
              

                DataProvider.Instance.DB.LoaiXes.Add(loaixe);
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
            int idloaixe = int.Parse(txtIDLoaiXe.Text);
            var loaixe = DataProvider.Instance.DB.LoaiXes.SingleOrDefault(n => n.IDLoaiXe == idloaixe);
            if (loaixe != null)
            {
                loaixe.MoTa = txtMoTa.Text;
                loaixe.TenLoaiXe = txtTenLoaiXe.Text;
                loaixe.DonGia = int.Parse(txtDonGia.Text);
              
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


            _list = new ObservableCollection<LoaiXe>(DataProvider.Instance.DB.LoaiXes);
           
            lsvData.ItemsSource = _list;


            txtIDLoaiXe.IsReadOnly = true;
            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
        }

        private void LsvData_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _loaixeSelected = item as LoaiXe;
            if (_loaixeSelected == null)
            {
                return;
            }
            txtIDLoaiXe.Text = _loaixeSelected.IDLoaiXe.ToString();
            txtMoTa.Text = _loaixeSelected.MoTa;
            txtDonGia.Text = _loaixeSelected.DonGia.ToString();
           
           



            btnSua.IsEnabled = true;
        }
    }
}
