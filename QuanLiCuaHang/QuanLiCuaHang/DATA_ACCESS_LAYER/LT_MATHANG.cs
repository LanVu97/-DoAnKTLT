using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using QuanLiCuaHang.ENTITIES;
using Newtonsoft.Json;

namespace QuanLiCuaHang.DATA_ACCESS_LAYER
{
    public class LT_MATHANG
    {
        public static List<MATHANG> DocMatHang()
        {

            string filePath = @"E:\mathang.json";
            List<MATHANG> listMatHang = new List<MATHANG>();
            // Kiểm tra đường dẫn này có tồn tại hay không?
            if (!File.Exists(filePath) )
            {
                FileStream file = File.Create(filePath);
                file.Close();

            }
            else
            {
                StreamReader reader = new StreamReader(filePath);
                
                String test = reader.ReadLine();
               if(string.IsNullOrEmpty(test))
                {
                    reader.Close();
                    return listMatHang;
                }
              int n = int.Parse(test);
                

                MATHANG MatHang;
                for (int i = 0; i < n; i++)
                {
                    String chuoiMatHang = reader.ReadLine();

                    MatHang = JsonConvert.DeserializeObject<MATHANG>(chuoiMatHang);
                    listMatHang.Add(MatHang);
                }

                reader.Close();
               
            }

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
            StreamWriter writer = new StreamWriter(@"E:\mathang.json");
            writer.WriteLine(listMatHang.Count());
          

            for (int i = 0; i < listMatHang.Count(); i++)
            { String num = (i + 1).ToString();
                MATHANG matHang = listMatHang[i];

                matHang.MaMatHang = num;
                
                String json = JsonConvert.SerializeObject(matHang);
                writer.WriteLine(json);
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

        public static void SuaLoaiHangCuaMatHang(String TenLoaiHangCu, String TenLoaiHangMoi)
        {
            List<MATHANG> listMatHang = DocMatHang();
            for (int i = 0; i < listMatHang.Count(); i++)
            {
                if (listMatHang[i].LoaiHang == TenLoaiHangCu)
                {
                    MATHANG matHang = listMatHang[i];
                    matHang.LoaiHang = TenLoaiHangMoi;
                    
                    listMatHang[i] = matHang;
                    
                }
            }

            LuuDanhSachMatHang(listMatHang);
        }

    }
}