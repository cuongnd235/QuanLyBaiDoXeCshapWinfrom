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
    /// Interaction logic for TheGuiXeUCxaml.xaml
    /// </summary>
    public partial class TheGuiXeUCxaml : UserControl
    {
        public TheGuiXeUCxaml()
        {
            _list = new ObservableCollection<TheGuiXe>(DataProvider.Instance.DB.TheGuiXes);
            InitializeComponent();

        }

        private ObservableCollection<TheGuiXe> _list;

        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;

        private TheGuiXe _theguixeSelected;


        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtIDTheGuiXe.Text = "auto";
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
                int idthe = int.Parse(txtIDTheGuiXe.Text);
                var theGui = DataProvider.Instance.DB.TheGuiXes.SingleOrDefault(n => n.IDTheGuiXe == idthe);
                if (theGui != null)
                {
                    DataProvider.Instance.DB.TheGuiXes.Remove(theGui);
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
                var thegui = new TheGuiXe();

                thegui.MoTa = txtMoTa.Text;
                thegui.NgayCap = pdNgayCap.SelectedDate;
                thegui.NgayHetHan = pdHetHan.SelectedDate;
                thegui.IDLoaiThe = (int)cboLoaiThe.SelectedValue;
                thegui.DangSuDung = chkDangSuDung.IsChecked;
               
                DataProvider.Instance.DB.TheGuiXes.Add(thegui);
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
            int idthegui = int.Parse(txtIDTheGuiXe.Text);
            var thegui = DataProvider.Instance.DB.TheGuiXes.SingleOrDefault(n => n.IDTheGuiXe == idthegui);
            if (thegui != null)
            {
                thegui.MoTa = txtMoTa.Text;
                thegui.NgayCap = pdHetHan.SelectedDate;
                thegui.NgayHetHan = pdHetHan.SelectedDate;
                thegui.IDLoaiThe = (int)cboLoaiThe.SelectedValue;
                thegui.DangSuDung = chkDangSuDung.IsChecked;
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Sửa thành công");
            }

        }
        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {
            //if (txtHoTen.Text == "" || txtSDT.Text == "")
            //{
            //    MessageBox.Show("Không được để trống họ tên hoặc điện thoại");
            //    return;
            //}
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


            _list = new ObservableCollection<TheGuiXe>(DataProvider.Instance.DB.TheGuiXes);
            cboLoaiThe.ItemsSource = new ObservableCollection<LoaiThe>(DataProvider.Instance.DB.LoaiThes);

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
            _theguixeSelected = item as TheGuiXe;
            if (_theguixeSelected == null)
            {
                return;
            }
            txtIDTheGuiXe.Text = _theguixeSelected.IDTheGuiXe.ToString();
            txtMoTa.Text = _theguixeSelected.MoTa;
            pdNgayCap.SelectedDate = _theguixeSelected.NgayCap;
            pdHetHan.SelectedDate = _theguixeSelected.NgayHetHan;
            
          
       
            btnSua.IsEnabled = true;
        }

        private void BtnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idtim = int.Parse(txtTimKiem.Text);
                lsvData.ItemsSource = new ObservableCollection<TheGuiXe>(DataProvider.Instance.DB.TheGuiXes.Where(n => n.IDTheGuiXe == idtim));
            }
            catch
            {
                lsvData.ItemsSource = new ObservableCollection<TheGuiXe>(DataProvider.Instance.DB.TheGuiXes);
            }
           
        }
    }
}
