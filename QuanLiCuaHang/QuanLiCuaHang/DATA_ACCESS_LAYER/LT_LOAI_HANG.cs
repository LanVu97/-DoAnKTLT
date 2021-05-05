using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using QuanLiCuaHang.ENTITIES;
using Newtonsoft.Json;

namespace QuanLiCuaHang.DATA_ACCESS_LAYER
{
    public class LT_LOAI_HANG
    {
        public static List<LOAI_HANG> DocLoaiHang()
        {
            string filePath = @"E:\loaihang.json";
            List<LOAI_HANG> listLoaiHang = new List<LOAI_HANG>();
            // Kiểm tra đường dẫn này có tồn tại hay không?
            if (!File.Exists(filePath))
            {
                FileStream file = File.Create(filePath);
                file.Close();
            }
            else
            {
                StreamReader reader = new StreamReader(filePath);
                String test = reader.ReadLine();
                if (string.IsNullOrEmpty(test))
                {
                    reader.Close();
                    return listLoaiHang;
                }
                int n = int.Parse(test);
                LOAI_HANG LoaiHang;
                for (int i = 0; i < n; i++)
                {
                    String chuoiLoaiHang = reader.ReadLine();
                    LoaiHang = JsonConvert.DeserializeObject<LOAI_HANG>(chuoiLoaiHang);
                    listLoaiHang.Add(LoaiHang);
                }
                reader.Close();
            }
            return listLoaiHang;
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
            StreamWriter writer = new StreamWriter(@"E:\loaihang.json");
            writer.WriteLine(listLoaiHang.Count());
            for (int i = 0; i < listLoaiHang.Count(); i++)
            {
                String num = (i + 1).ToString();
                LOAI_HANG LoaiHang = listLoaiHang[i];

                LoaiHang.MaLoaiHang = num;

                String json = JsonConvert.SerializeObject(LoaiHang);
                writer.WriteLine(json);
            }
            writer.Close();


        }

        public static void XoaLoaiHang(String maLoaiHang)
        {
            List<LOAI_HANG> listLoaiHang = DocLoaiHang();
            for (int i = 0; i < listLoaiHang.Count(); i++)
            {
                if (listLoaiHang[i].MaLoaiHang == maLoaiHang)
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

            for (int i = 0; i < listLoaiHang.Count(); i++)
            {
                if (listLoaiHang[i].MaLoaiHang == LoaiHang.MaLoaiHang)
                {
                    listLoaiHang[i] = LoaiHang;
                    break;
                }
            }

            LuuDanhSachLoaiHang(listLoaiHang);
        }
    }
}