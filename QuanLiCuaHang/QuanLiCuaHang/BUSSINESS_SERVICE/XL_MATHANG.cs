using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiCuaHang.ENTITIES;
using QuanLiCuaHang.DATA_ACCESS_LAYER;
namespace QuanLiCuaHang.BUSSINESS_SERVICE
{
    public class XL_MATHANG
    {

        public static List<MATHANG> DocMatHang()
        {
            return LT_MATHANG.DocMatHang();
        }
        public static List<MATHANG> TimKiemMatHang(String keyword)
        {
            
            List<MATHANG> listMatHang = LT_MATHANG.DocMatHang();
            if(listMatHang.Count() == 0)
            {
                return null;
            }

            List<MATHANG> listKetQuaTimKiem = new List<MATHANG>();

            for(int i = 0; i < listMatHang.Count(); i++)
            {
                if (listMatHang[i].TenHang.Contains(keyword))
                {
                    listKetQuaTimKiem.Add(listMatHang[i]);
                }
            }
            return listKetQuaTimKiem;
        }

        public static MATHANG TimKiemMatHang_MaMH(String maMatHang)
        {
            List<MATHANG> listMatHang = LT_MATHANG.DocMatHang();
            
            for (int i = 0; i < listMatHang.Count(); i++)
            {
                if (listMatHang[i].MaMatHang == maMatHang)
                {
                    return listMatHang[i];
                }
            }
            return new MATHANG();
        }

        public static void ThemMatHang(MATHANG matHang)
        {
            LT_MATHANG.LuuMatHang(matHang);
        }
        public static void XoaMatHang(String keyword)
        {
              LT_MATHANG.XoaMatHang(keyword);
        }

        public static void SuaMatHang(MATHANG matHang)
        {
            LT_MATHANG.SuaMatHang(matHang);
        }

        public static void SuaLoaiHangCuaMatHang(String TenLoaiHangCu, String TenLoaiHangMoi)
        {
            LT_MATHANG.SuaLoaiHangCuaMatHang(TenLoaiHangCu, TenLoaiHangMoi);
        }

    }
}