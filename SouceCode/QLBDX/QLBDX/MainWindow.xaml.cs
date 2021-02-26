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

namespace QLBDX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int quyenhan = 1;
        public MainWindow(int quyen =1)
        {

            InitializeComponent();
            this.quyenhan = quyen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;
            if (this.quyenhan == 2)
            {
                ItemNhanVien.Visibility = Visibility.Collapsed;
                ItemThongKe.Visibility = Visibility.Collapsed;
            }
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridMain.Children.Clear();
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemNhanVien":
                    {
                        NhanVienUC nhanVienUC = new NhanVienUC();
                        GridMain.Children.Add(nhanVienUC);
                        break;
                    }
                case "ItemTheGuiXe":
                    {
                        TheGuiXeUCxaml theGuiXe = new TheGuiXeUCxaml();
                        GridMain.Children.Add(theGuiXe);
                        break;
                    }
                case "ItemLoaiXe":
                    {
                        LoaiXeUC loaiXeUC = new LoaiXeUC();
                        GridMain.Children.Add(loaiXeUC);
                        break;
                    }
                case "ItemXeTrongBai":
                    {
                        XeTrongBaiUC xeTrongBaiUC = new XeTrongBaiUC();
                        GridMain.Children.Add(xeTrongBaiUC);
                        break;
                    }
                case "ItemXeVao":
                    {
                        QuanLyXeVaoUC quanLyXeVaoUC = new QuanLyXeVaoUC();
                        GridMain.Children.Add(quanLyXeVaoUC);
                        break;
                    }
                case "ItemXeRa":
                    {
                        QuanLyXeRaUC quanLyXeRaUC = new QuanLyXeRaUC();
                        GridMain.Children.Add(quanLyXeRaUC);
                        break;
                    }
                case "ItemXeThang":
                    {
                        QuanLyGuiXeThangUC quanLyGuiXeThangUC = new QuanLyGuiXeThangUC();
                        GridMain.Children.Add(quanLyGuiXeThangUC);
                        
                        break;
                    }
                case "ItemThongKe":
                    {
                        ThongKeUC thongKeUC = new ThongKeUC();
                        GridMain.Children.Add(thongKeUC);
                        break;
                    }
            }
        }
    }
}
