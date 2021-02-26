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
    /// Interaction logic for XeTrongBaiUC.xaml
    /// </summary>
    public partial class XeTrongBaiUC : UserControl
    {
        private ObservableCollection<XeTrongBai> _list;
       

        public XeTrongBaiUC()
        {
            InitializeComponent();
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //lsProduct.ItemsSource = new ObservableCollection<Product>(DataProvider.Instance.DB.Products);
            _list = new ObservableCollection<XeTrongBai>(DataProvider.Instance.DB.XeTrongBais);
          
            lsData.ItemsSource = _list;
            cboTheGuiXe.ItemsSource = new ObservableCollection<TheGuiXe>(DataProvider.Instance.DB.TheGuiXes);
            cboLoaiXe.ItemsSource = new ObservableCollection<LoaiXe>(DataProvider.Instance.DB.LoaiXes);
             
            
        }


        XeTrongBai _xetrongbaiSelected;
        private void LsData_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _xetrongbaiSelected = item as XeTrongBai;
            if (_xetrongbaiSelected == null)
            {
                return;
            }
            txtIDXeTrongBai.Text = _xetrongbaiSelected.IDXeTrongBai;
            txtUrlAnh.Text = _xetrongbaiSelected.UrlAnh;
            cboLoaiXe.SelectedValue = (int)_xetrongbaiSelected.IDLoaiXe;
            cboTheGuiXe.SelectedValue = _xetrongbaiSelected.IDTheGuiXe;
            cboLoaiXe.SelectedValue = _xetrongbaiSelected.LoaiXe;
            pdThoiGianVao.SelectedDate = _xetrongbaiSelected.ThoiGianVao;
        }

     

        private void BtnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            lsData.ItemsSource = new ObservableCollection<XeTrongBai>(DataProvider.Instance.DB.XeTrongBais.Where(n => n.IDXeTrongBai.Contains(txtTimKiem.Text)));
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
