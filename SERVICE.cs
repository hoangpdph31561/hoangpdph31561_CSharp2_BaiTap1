using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoangpdph31561_CSharp2_BaiTap1
{
    internal class SERVICE
    {
        int _genID = 1;
        private string _input;
        public SERVICE()
        {

        }
        public void Nhap(List<Bike> lstXeDaps)
        {
            do
            {
                Bike xeDap = new Bike();
                while(lstXeDaps.Any(x => x.Id == _genID))
                {
                    _genID++;
                }
                xeDap.Id = _genID;
                xeDap.Ten = HamTao.GetInputWithRegex("tên xe đạp", @"^[\w\d\s]+$");
                xeDap.HSX1 = HamTao.GetInput("HSX xe đạp");
                lstXeDaps.Add(xeDap);
                do
                {
                    _input = HamTao.GetInput("tiếp tục hay không");
                    if (String.Compare(_input, "có", true) != 0 && String.Compare(_input, "không", true) != 0)
                    {
                        Console.WriteLine("Chỉ được nhập có hoặc không, xin mời nhập lại");
                    }
                } while (String.Compare(_input, "có", true) != 0 && String.Compare(_input, "không", true) != 0);
            } while (String.Compare(_input, "có", true) == 0);
        }
        public void Xuat(List<Bike> lstBike)
        {
            if (HamTao.CheckCount<Bike>(lstBike))
            {
                foreach (var item in lstBike)
                {
                    item.InThongTin();
                }
            }
        }
        public void SaveFiles(string path, List<Bike> lstBike)
        {
            if (File.Exists(path))
            {
                if (HamTao.CheckCount<Bike>(lstBike))
                {
                    foreach (var item in lstBike)
                    {
                        string content = item.GetObj();
                        File.AppendAllText(path, content);
                    }
                    Console.WriteLine("Lưu thành công");
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy files để save");
            }
        }
        public List<Bike> ReadFiles(string path)
        {
            List<Bike> lstReadBike = new List<Bike> ();
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var item in lines)
                {
                    if(item.Trim().Length == 0)
                    {
                        continue;
                    }
                    string[] contents = item.Split('|');
                    Bike readBike = new Bike();
                    readBike.Id = Convert.ToInt32(contents[0].Trim());
                    readBike.Ten = contents[1].Trim();
                    readBike.HSX1 = contents[2].Trim();
                    lstReadBike.Add(readBike);
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy files để đọc");
            }
            return lstReadBike;
        }
        private int GetIndex(List<Bike> lstBike)
        {
            _input = HamTao.GetInputWithRegex("mã id cần tìm", @"^[\d]+$");
            int index = lstBike.FindIndex(x=> x.Id == (Convert.ToInt32(_input)));
            return index;
        }
        public void XoaDoiTuong(List<Bike> lstBike)
        {
            if (HamTao.CheckCount<Bike>(lstBike))
            {
                int index = GetIndex(lstBike);
                if(index == -1)
                {
                    Console.WriteLine("Không tồn tại để xóa");
                }
                else
                {
                    lstBike.RemoveAt(index);
                    Console.WriteLine("Xóa thành công");
                }
            }
        }
    }
}
