using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoangpdph31561_CSharp2_BaiTap1
{
    internal class Program
    {
        public delegate void CheckDelegate<T> (T lst);
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Menu();
        }
        static void Menu()
        {
            int chonChuongTrinh;
            SERVICE sv = new SERVICE();
            List<Bike> lstXeDaps = new List<Bike>()
            {
                new Bike(1,"Thống nhất","alo"),
                new Bike(2,"Thống thiết","blo"),
                new Bike(3,"Thứ tha","clo"),
                new Bike(4,"Thông minh","dlo"),
            };
            string path = @"E:\FPT politechnic\Xuong_LV3_Trainning\Code_CS\hoangpdph31561_CSharp2_BaiTap1\QuanLyXeDap.txt";
            do
            {
                Console.WriteLine("----Menu----");
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("1. Nhập");
                Console.WriteLine("2. Xuất");
                Console.WriteLine("3. Lưu file");
                Console.WriteLine("4. Đọc file");
                Console.WriteLine("5. Xóa đối tượng theo id");
                Console.WriteLine("Chọn chương trình");
                chonChuongTrinh = Convert.ToInt32(Console.ReadLine());
                switch (chonChuongTrinh)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        CheckDelegate<List<Bike>> nhap = sv.Nhap;
                        nhap(lstXeDaps);
                        break;
                    case 2:
                        sv.Xuat(lstXeDaps);
                        break;
                    case 3:
                        File.WriteAllText(path, "");
                        sv.SaveFiles(path, lstXeDaps);
                        break;
                    case 4:
                        List<Bike> lstReadBike = sv.ReadFiles(path);
                        if (HamTao.CheckCount<Bike>(lstReadBike))
                        {
                            foreach (var item in lstReadBike)
                            {
                                item.InThongTin();
                            }
                        }
                        break;
                    case 5:
                        sv.XoaDoiTuong(lstXeDaps);
                        break;
                    default:
                        Console.WriteLine("Sai chương trình, mời chọn lại");
                        break;
                }
            } while (chonChuongTrinh != 0);
        }
    }
}
