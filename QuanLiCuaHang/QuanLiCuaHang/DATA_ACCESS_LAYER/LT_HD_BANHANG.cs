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
        public static List<HOADON> DocHDBanHang()
        {

            string filePath = @"E:\hd_banhang.json";
            List<HOADON> listHDBanHang = new List<HOADON>();
            // Kiểm tra đường dẫn này có tồn tại hay không?
            if (!File.Exists(filePath))
            {
                FileStream file = File.Create(filePath);
                file.Close();

            }
            else
            {
                StreamReader reader = new StreamReader(filePath);
                String number = reader.ReadLine();
                int n;
                if (string.IsNullOrEmpty(number))
                {
                    n = 0;
                }
                else
                {
                    // String a = reader.ReadLine();
                    n = int.Parse(number);
                    HOADON hdBanHang;
                    for (int i = 0; i < n; i++)
                    {
                        String chuoiHDBanHang = reader.ReadLine();

                        hdBanHang = JsonConvert.DeserializeObject<HOADON>(chuoiHDBanHang);
                        listHDBanHang.Add(hdBanHang);
                    }
                }
                reader.Close();
            }
            return listHDBanHang;
        }


        public static void LuuHDBanHang(HOADON hdBanHang)
        {
            List<HOADON> listHDBanHang = DocHDBanHang();
            hdBanHang.maHoaDon = (listHDBanHang.Count() + 1).ToString();
            listHDBanHang.Add(hdBanHang);
            LuuDanhSachHDBanHang(listHDBanHang);
        }

        public static void LuuDanhSachHDBanHang(List<HOADON> listHDBanHang)
        {
            StreamWriter writer = new StreamWriter(@"E:\hd_banhang.json");
            writer.WriteLine(listHDBanHang.Count());
            for (int i = 0; i < listHDBanHang.Count(); i++)
            {
                HOADON hoaDonBanHang = listHDBanHang[i];
                String num = (i + 1).ToString();
                hoaDonBanHang.maHoaDon = num;

                String json = JsonConvert.SerializeObject(hoaDonBanHang);
                writer.WriteLine(json);
            }
            writer.Close();

        }

        public static void XoaHDBanHang(String maHDBanHang)
        {
            List<HOADON> listHDBanHang = DocHDBanHang();
            for (int i = 0; i < listHDBanHang.Count(); i++)
            {
                if (listHDBanHang[i].maHoaDon == maHDBanHang)
                {
                    listHDBanHang.Remove(listHDBanHang[i]);
                    break;
                }
            }

            LuuDanhSachHDBanHang(listHDBanHang);
        }

        public static void SuaHDBanHang(HOADON HDBanHang)
        {
            List<HOADON> listHDBanHang = DocHDBanHang();

            for (int i = 0; i < listHDBanHang.Count(); i++)
            {
                if (listHDBanHang[i].maHoaDon == HDBanHang.maHoaDon)
                {
                    listHDBanHang[i] = HDBanHang;
                    break;
                }
            }

            LuuDanhSachHDBanHang(listHDBanHang);
        }
    }
}