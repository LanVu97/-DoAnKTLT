using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using QuanLiCuaHang.ENTITIES;
namespace QuanLiCuaHang.DATA_ACCESS_LAYER
{
    public class LT_LOAI_HANG
    {
        public static List<LOAI_HANG> DocLoaiHang()
        {
            StreamReader reader = new StreamReader("E:\\loaihang.txt");
            List<LOAI_HANG> listLoaiHang = new List<LOAI_HANG>();
            String number = reader.ReadLine();
            int n;
            if (string.IsNullOrEmpty(number))
            {
                n = 0;
            }else
            {
               // String a = reader.ReadLine();
                n = int.Parse(number);
            }

            LOAI_HANG LoaiHang;
            for (int i = 0; i < n; i++)
            {
                String chuoiLoaiHang = reader.ReadLine();
                LoaiHang = KhoiTaoLoaiHang(chuoiLoaiHang);
                listLoaiHang.Add(LoaiHang);

            }
      
            reader.Close();

            return listLoaiHang;
        }

        public static LOAI_HANG KhoiTaoLoaiHang(String chuoiLoaiHang)
        {
            LOAI_HANG LoaiHang;
            String[] s = chuoiLoaiHang.Split(',');
            LoaiHang.MaLoaiHang = s[0].Trim();
            LoaiHang.TenLoaiHang = s[1].Trim();
            
            return LoaiHang;
        }

        public static void LuuMatHang(LOAI_HANG LoaiHang)
        {   
            List<LOAI_HANG> listLoaiHang = DocLoaiHang();
            LoaiHang.MaLoaiHang = (listLoaiHang.Count() + 1).ToString();
            listLoaiHang.Add(LoaiHang);
            LuuDanhSachLoaiHang(listLoaiHang);
        }

        public static void LuuDanhSachLoaiHang(List<LOAI_HANG> listLoaiHang)
        {
            StreamWriter writer = new StreamWriter("E:\\loaihang.txt");
            writer.WriteLine(listLoaiHang.Count());
            for(int i = 0; i < listLoaiHang.Count(); i++)
            {
                writer.WriteLine($"{i + 1},{listLoaiHang[i].TenLoaiHang}");
            }
            writer.Close();

        }

        public static void XoaLoaiHang(String maLoaiHang)
        {
            List<LOAI_HANG> listLoaiHang = DocLoaiHang();
            for(int i = 0; i < listLoaiHang.Count(); i++)
            {
                if(listLoaiHang[i].MaLoaiHang == maLoaiHang)
                {
                    listLoaiHang.Remove(listLoaiHang[i]);
                    break;
                }
            }

            LuuDanhSachLoaiHang(listLoaiHang);
        }

        public static void SuaLoaiHang(LOAI_HANG LoaiHang)
        {
            List<LOAI_HANG> listLoaiHang = DocLoaiHang();

            for(int i = 0; i < listLoaiHang.Count(); i++)
            {
                if(listLoaiHang[i].MaLoaiHang == LoaiHang.MaLoaiHang)
                {
                    listLoaiHang[i] = LoaiHang;
                    break;
                }
            }
            
            LuuDanhSachLoaiHang(listLoaiHang);
        }
    }
}