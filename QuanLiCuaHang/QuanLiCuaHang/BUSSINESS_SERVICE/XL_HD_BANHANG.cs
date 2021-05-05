using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiCuaHang.ENTITIES;
using QuanLiCuaHang.DATA_ACCESS_LAYER;
namespace QuanLiCuaHang.BUSSINESS_SERVICE
{
    public class XL_HD_BANHANG

    {

        public static List<HD_BANHANG> DocHDBanHang()
        {
            return LT_HD_BANHANG.DocHDBanHang();
        }
        public static List<HD_BANHANG> TimKiemHDBanHang(String keyword)
        {
            
            List<HD_BANHANG> listHDBanHang = LT_HD_BANHANG.DocHDBanHang();
            if(listHDBanHang.Count() == 0)
            {
                return null;
            }

            List<HD_BANHANG> listKetQuaTimKiem = new List<HD_BANHANG>();

            for(int i = 0; i < listHDBanHang.Count(); i++)
            {
                if (listHDBanHang[i].maHoaDon.Contains(keyword) || listHDBanHang[i].ngayTaoHoaDon.Contains(keyword))
                {
                    listKetQuaTimKiem.Add(listHDBanHang[i]);
                }
            }
            return listKetQuaTimKiem;
        }

        public static HD_BANHANG TimKiemHDBanHang_MaHD(String maHoaDon)
        {
            List<HD_BANHANG> listHDBanHang = LT_HD_BANHANG.DocHDBanHang();

            for (int i = 0; i < listHDBanHang.Count(); i++)
            {
                if (listHDBanHang[i].maHoaDon == maHoaDon)
                {
                    return listHDBanHang[i];
                }
            }
            return new HD_BANHANG();
        }

        public static void ThemHDBanHang(HD_BANHANG HDBanHang)
        {
            LT_HD_BANHANG.LuuHDBanHang(HDBanHang);
        }
        public static void XoaHDBanHang(String maHDBanHang)
        {
            LT_HD_BANHANG.XoaHDBanHang(maHDBanHang);
        }

        public static void SuaHDBanHang(HD_BANHANG HDBanHang)
        {
            LT_HD_BANHANG.SuaHDBanHang(HDBanHang);
        }

        public static int TinhTongSoLuong(List<CHITIET_HDBH> ListChiTietHoaDon)
        {
            int sum = 0;
            for(int i = 0; ListChiTietHoaDon != null && i < ListChiTietHoaDon.Count(); i++)
            {
                sum += ListChiTietHoaDon[i].soLuong;
            }
            return sum;

        }
    }
}