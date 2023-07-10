using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoangpdph31561_CSharp2_BaiTap1
{
    internal class Bike
    {
        private int id;
        private string ten;
        private string HSX;
        public Bike()
        {
            
        }

        public Bike(int id, string ten, string hSX)
        {
            this.id = id;
            this.ten = ten;
            HSX = hSX;
        }

        public int Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        public string HSX1 { get => HSX; set => HSX = value; }
        public void InThongTin()
        {
            Console.WriteLine($"{id}|{ten}|{HSX}");
        }
        public string GetObj()
        {
            return $"{id}|{ten}|{HSX}\n";
        }
    }
}
