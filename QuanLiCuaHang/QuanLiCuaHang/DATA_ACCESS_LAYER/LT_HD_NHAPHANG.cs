using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using QuanLiCuaHang.ENTITIES;
using Newtonsoft.Json;

namespace QuanLiCuaHang.DATA_ACCESS_LAYER
{
    public class LT_HD_NHAPHANG

    {
        public static List<HOADON> DocHDNhapHang()
        {
            string filePath = @"E:\hd_nhaphang.json";
            List<HOADON> listHDNhapHang = new List<HOADON>();
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
                    n = int.Parse(number);
                    HOADON hdNhapHang;
                    for (int i = 0; i < n; i++)
                    {
                        String chuoiHDNhapHang = reader.ReadLine();
                        hdNhapHang = JsonConvert.DeserializeObject<HOADON>(chuoiHDNhapHang);
                        listHDNhapHang.Add(hdNhapHang);
                    }
                }
                reader.Close();
            }
            return listHDNhapHang;
        }

        public static void LuuHDNhapHang(HOADON hdNhapHang)
        {
            List<HOADON> listHDNhapHang = DocHDNhapHang();
            hdNhapHang.maHoaDon = (listHDNhapHang.Count() + 1).ToString();
            listHDNhapHang.Add(hdNhapHang);
            LuuDanhSachHDNhapHang(listHDNhapHang);
        }

        public static void LuuDanhSachHDNhapHang(List<HOADON> listHDNhapHang)
        {
            StreamWriter writer = new StreamWriter(@"E:\hd_nhaphang.json");
            writer.WriteLine(listHDNhapHang.Count());
            for (int i = 0; i < listHDNhapHang.Count(); i++)
            {
                HOADON hoaDonNhapHang = listHDNhapHang[i];
                String num = (i + 1).ToString();
                hoaDonNhapHang.maHoaDon = num;

                String json = JsonConvert.SerializeObject(hoaDonNhapHang);
                writer.WriteLine(json);
            }
            writer.Close();

        }

        public static void XoaHDNhapHang(String maHDNhapHang)
        {
            List<HOADON> listHDNhapHang = DocHDNhapHang();
            for (int i = 0; i < listHDNhapHang.Count(); i++)
            {
                if (listHDNhapHang[i].maHoaDon == maHDNhapHang)
                {
                    listHDNhapHang.Remove(listHDNhapHang[i]);
                    break;
                }
            }
            LuuDanhSachHDNhapHang(listHDNhapHang);
        }

        public static void SuaHDNhapHang(HOADON HDNhapHang)
        {
            List<HOADON> listHDNhapHang = DocHDNhapHang();

            for (int i = 0; i < listHDNhapHang.Count(); i++)
            {
                if (listHDNhapHang[i].maHoaDon == HDNhapHang.maHoaDon)
                {
                    listHDNhapHang[i] = HDNhapHang;
                    break;
                }
            }

            LuuDanhSachHDNhapHang(listHDNhapHang);
        }
    }
}