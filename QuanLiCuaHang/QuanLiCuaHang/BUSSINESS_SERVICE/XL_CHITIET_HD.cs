using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiCuaHang.ENTITIES;
using QuanLiCuaHang.DATA_ACCESS_LAYER;
namespace QuanLiCuaHang.BUSSINESS_SERVICE
{
    public class XL_CHITIET_HD

    {
        public static CHITIET_HD TimHoaDon(string maMH, List<CHITIET_HD> listChiTietHoaDon)
        {
            int maMatHang = int.Parse(maMH);
            return listChiTietHoaDon[maMatHang - 1];
        }
        public static List<CHITIET_HD> UpdateMatHang(CHITIET_HD chiTietDonHang, List<CHITIET_HD> listChiTietHoaDon)
        {
            for (int i = 0; i < listChiTietHoaDon.Count(); i++)
            {
                if (chiTietDonHang.matHang.MaMatHang == listChiTietHoaDon[i].matHang.MaMatHang)
                {
                    listChiTietHoaDon[i] = chiTietDonHang;
                }
            }
            return listChiTietHoaDon;
        }
        public static List<CHITIET_HD> XoaMatHang(CHITIET_HD chiTietDonHang, List<CHITIET_HD> listChiTietHoaDon)
        {
            for (int i = 0; i < listChiTietHoaDon.Count(); i++)
            {
                if (chiTietDonHang.matHang.MaMatHang == listChiTietHoaDon[i].matHang.MaMatHang)
                {
                    listChiTietHoaDon.Remove(listChiTietHoaDon[i]);
                }
            }

            return updateMaMatHang(listChiTietHoaDon);
        }
        public static List<CHITIET_HD> updateMaMatHang(List<CHITIET_HD> listChiTietHoaDon)
        {
            List<CHITIET_HD> result = new List<CHITIET_HD>();

            for (int i = 0; i < listChiTietHoaDon.Count(); i++)
            {
                CHITIET_HD chiTiet;
                int soLuong = listChiTietHoaDon[i].soLuong;
                MATHANG matHang = listChiTietHoaDon[i].matHang;
                string maMatHang = (i + 1).ToString();
                matHang.MaMatHang = maMatHang;
                chiTiet.soLuong = soLuong;
                chiTiet.matHang = matHang;
                result.Add(chiTiet);
            }
            return result;
        }

    }
}