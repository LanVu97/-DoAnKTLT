using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using QuanLiCuaHang.ENTITIES;
using Newtonsoft.Json;

namespace QuanLiCuaHang.DATA_ACCESS_LAYER
{
    public class LT_HD_BANHANG

    {
        public static List<HD_BANHANG> DocHDBanHang()
        {
            StreamReader reader = new StreamReader(@"E:\hd_banhang.json");
            List<HD_BANHANG> listHDBanHang = new List<HD_BANHANG>();
            
            String number = reader.ReadLine();
            int n;
            if (string.IsNullOrEmpty(number))
            {
                n = 0;
            }else
            {
               // String a = reader.ReadLine();
                n = int.Parse(number);
                HD_BANHANG hdBanHang;
                for (int i = 0; i < n; i++)
                {
                    String chuoiHDBanHang = reader.ReadLine();
                    
                    hdBanHang = JsonConvert.DeserializeObject<HD_BANHANG>(chuoiHDBanHang);
                    listHDBanHang.Add(hdBanHang);
                }
            }

            
      
            reader.Close();

            return listHDBanHang;
        }

        public static void LuuHDBanHang(HD_BANHANG hdBanHang)
        {   
            List<HD_BANHANG> listHDBanHang = DocHDBanHang();
            hdBanHang.maHoaDon = (listHDBanHang.Count() + 1).ToString();
            listHDBanHang.Add(hdBanHang);
            LuuDanhSachHDBanHang(listHDBanHang);
        }

        public static void LuuDanhSachHDBanHang(List<HD_BANHANG> listHDBanHang)
        {
            StreamWriter writer = new StreamWriter(@"E:\hd_banhang.json");
            writer.WriteLine(listHDBanHang.Count());
            for(int i = 0; i < listHDBanHang.Count(); i++)
            {
                HD_BANHANG hoaDonBanHang = listHDBanHang[i];
                String num = (i + 1).ToString();
                hoaDonBanHang.maHoaDon = num;

                String json = JsonConvert.SerializeObject(hoaDonBanHang);
                writer.WriteLine(json);
            }
            writer.Close();

        }

        public static void XoaHDBanHang(String maHDBanHang)
        {
            List<HD_BANHANG> listHDBanHang = DocHDBanHang();
            for(int i = 0; i < listHDBanHang.Count(); i++)
            {
                if(listHDBanHang[i].maHoaDon == maHDBanHang)
                {
                    listHDBanHang.Remove(listHDBanHang[i]);
                    break;
                }
            }

            LuuDanhSachHDBanHang(listHDBanHang);
        }

        public static void SuaHDBanHang(HD_BANHANG HDBanHang)
        {
            List<HD_BANHANG> listHDBanHang = DocHDBanHang();

            for(int i = 0; i < listHDBanHang.Count(); i++)
            {
                if(listHDBanHang[i].maHoaDon == HDBanHang.maHoaDon)
                {
                    listHDBanHang[i] = HDBanHang;
                    break;
                }
            }

            LuuDanhSachHDBanHang(listHDBanHang);
        }
    }
}