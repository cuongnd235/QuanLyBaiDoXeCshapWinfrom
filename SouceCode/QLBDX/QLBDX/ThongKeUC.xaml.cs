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
using LiveCharts;
using LiveCharts.Wpf;

namespace QLBDX
{
    /// <summary>
    /// Interaction logic for ThongKeUC.xaml
    /// </summary>
    public partial class ThongKeUC : UserControl
    {
        public ThongKeUC()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var listyear = DataProvider.Instance.DB.HoaDons.Select(n => n.ThoiGian.Value.Year).Union(DataProvider.Instance.DB.HoaDons.Select(n => n.ThoiGian.Value.Year));
            cboNam.ItemsSource = new ObservableCollection<int>(listyear);
        }

        class ThongKeResult
        {
            public int Thang { get; set; }
            public int TongTien { get; set; }
        }
       
        private void CboNam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sqlcmd = string.Format("select SUM(TongTien) as TongTien,MONTH(ThoiGian) as Thang from HoaDon where YEAR(ThoiGian) = {0} group by MONTH(ThoiGian)", cboNam.SelectedValue);
            var thongkethang =  DataProvider.Instance.DB.Database.SqlQuery<ThongKeResult>(sqlcmd);
            var sqlcmd2 = string.Format("select SUM(TongTien) as TongTien,MONTH(NgayDangKy) as Thang from XeThang where YEAR(NgayDangKy) = {0} group by MONTH(NgayDangKy)", cboNam.SelectedValue);
            var thongkethang2 = DataProvider.Instance.DB.Database.SqlQuery<ThongKeResult>(sqlcmd);
            ThongKeResult[] thongKeResults = new ThongKeResult[12];
            for(int i = 0; i < 12; i++)
            {
                thongKeResults[i] = new ThongKeResult();
                thongKeResults[i].Thang = i + 1;
                thongKeResults[i].TongTien = 0;
            }
            foreach(ThongKeResult thongKe in thongkethang)
            {
                thongKeResults[thongKe.Thang - 1].TongTien = thongKe.TongTien;
            }
            foreach (ThongKeResult thongKe in thongkethang2)
            {
                thongKeResults[thongKe.Thang - 1].TongTien += thongKe.TongTien;
            }
            int[] doanhthuthang = new int[12];
            for(int i = 0; i < 12; i++)
            {
                doanhthuthang[i] = thongKeResults[i].TongTien;
            }
            var SeriesDoanhThu = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title ="Doanh thu mỗi tháng",
                    Values = new ChartValues<int>(doanhthuthang),
                }
            };
            trucX.Labels = new string[] { "!", "2", "3", "4", "5","6","7","8","9","10","11","12"};
            thongkechart.Series = SeriesDoanhThu;
            txtTongTien.Text = thongKeResults.Sum(n => n.TongTien).ToString();
        }
    }
}
