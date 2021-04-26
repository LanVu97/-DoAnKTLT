using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using QuanLiCuaHang.ENTITIES;
namespace QuanLiCuaHang.DATA_ACCESS_LAYER
{
    public class LT_MATHANG
    {
        public static List<MATHANG> DocMatHang()
        {
            StreamReader reader = new StreamReader("E:\\mathang.txt");
            List<MATHANG> listMatHang = new List<MATHANG>();
            String test = reader.ReadLine();
            int n;
            if (string.IsNullOrEmpty(test))
            {
                n = 0;
            }else
            {
               // String a = reader.ReadLine();
                n = int.Parse(test);
            }

            MATHANG MatHang;
            for (int i = 0; i < n; i++)
            {
                String chuoiMatHang = reader.ReadLine();
                MatHang = KhoiTaoMatHang(chuoiMatHang);
                listMatHang.Add(MatHang);

            }
      
            reader.Close();

            return listMatHang;
        }

        public static MATHANG KhoiTaoMatHang(String chuoiMatHang)
        {
            MATHANG MatHang;
            String[] s = chuoiMatHang.Split(',');
            MatHang.MaMatHang = s[0].Trim();
            MatHang.TenHang = s[1].Trim();
            MatHang.HanDung = s[2].Trim();
            MatHang.CongTySanXuat = s[3].Trim();
            MatHang.NamSanxuat = int.Parse(s[4].Trim());
            MatHang.LoaiHang = s[5].Trim();
            return MatHang;
        }

        public static void LuuMatHang(MATHANG matHang)
        {   
            List<MATHANG> listMatHang = DocMatHang();
            matHang.MaMatHang = (listMatHang.Count() + 1).ToString();
            listMatHang.Add(matHang);
            LuuDanhSachMatHang(listMatHang);
        }

        public static void LuuDanhSachMatHang(List<MATHANG> listMatHang)
        {
            StreamWriter writer = new StreamWriter("E:\\mathang.txt");
            writer.WriteLine(listMatHang.Count());
            for(int i = 0; i < listMatHang.Count(); i++)
            {
                writer.WriteLine($"{i + 1},{listMatHang[i].TenHang}, {listMatHang[i].HanDung}, {listMatHang[i].CongTySanXuat}, {listMatHang[i].NamSanxuat}, {listMatHang[i].LoaiHang}");
            }
            writer.Close();

        }

        public static void XoaMatHang(String keyword)
        {
            List<MATHANG> listMatHang = DocMatHang();
            for(int i = 0; i < listMatHang.Count(); i++)
            {
                if(listMatHang[i].MaMatHang == keyword)
                {
                    listMatHang.Remove(listMatHang[i]);
                    break;
                }
            }

            LuuDanhSachMatHang(listMatHang);
        }

        public static void SuaMatHang(MATHANG matHang)
        {
            List<MATHANG> listMatHang = DocMatHang();

            for(int i = 0; i < listMatHang.Count(); i++)
            {
                if(listMatHang[i].MaMatHang == matHang.MaMatHang)
                {
                    listMatHang[i] = matHang;
                    break;
                }
            }
            
            LuuDanhSachMatHang(listMatHang);
        }
    }
}