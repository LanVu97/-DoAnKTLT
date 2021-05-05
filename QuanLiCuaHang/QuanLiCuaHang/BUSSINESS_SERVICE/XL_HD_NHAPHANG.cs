using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiCuaHang.ENTITIES;
using QuanLiCuaHang.DATA_ACCESS_LAYER;
namespace QuanLiCuaHang.BUSSINESS_SERVICE
{
    public class XL_HD_NHAPHANG

    {
        public static List<HOADON> DocHDNhapHang()
        {
            return LT_HD_NHAPHANG.DocHDNhapHang();
        }

        public static List<HOADON> TimKiemHDNhapHang(String keyword)
        {
            List<HOADON> listHDNhapHang = LT_HD_NHAPHANG.DocHDNhapHang();
            if (listHDNhapHang.Count() == 0)
            {
                return null;
            }
            List<HOADON> listKetQuaTimKiem = new List<HOADON>();
            for (int i = 0; i < listHDNhapHang.Count(); i++)
            {
                if (listHDNhapHang[i].maHoaDon.Contains(keyword) || listHDNhapHang[i].ngayTaoHoaDon.Contains(keyword))
                {
                    listKetQuaTimKiem.Add(listHDNhapHang[i]);
                }
            }
            return listKetQuaTimKiem;
        }

        public static HOADON TimKiemHDNhapHang_MaHD(String maHoaDon)
        {
            List<HOADON> listHDNhapHang = LT_HD_NHAPHANG.DocHDNhapHang();

            for (int i = 0; i < listHDNhapHang.Count(); i++)
            {
                if (listHDNhapHang[i].maHoaDon == maHoaDon)
                {
                    return listHDNhapHang[i];
                }
            }
            return new HOADON();
        }

        public static void ThemHDNhapHang(HOADON HDNhapHang)
        {
            LT_HD_NHAPHANG.LuuHDNhapHang(HDNhapHang);
        }

        public static void XoaHDNhapHang(String maHDNhapHang)
        {
            LT_HD_NHAPHANG.XoaHDNhapHang(maHDNhapHang);
        }

        public static void SuaHDNhapHang(HOADON HDNhapHang)
        {
            LT_HD_NHAPHANG.SuaHDNhapHang(HDNhapHang);
        }

        public static int TinhTongSoLuong(List<CHITIET_HD> ListChiTietHoaDon)
        {
            int sum = 0;
            for (int i = 0; ListChiTietHoaDon != null && i < ListChiTietHoaDon.Count(); i++)
            {
                sum += ListChiTietHoaDon[i].soLuong;
            }
            return sum;

        }
    }
}