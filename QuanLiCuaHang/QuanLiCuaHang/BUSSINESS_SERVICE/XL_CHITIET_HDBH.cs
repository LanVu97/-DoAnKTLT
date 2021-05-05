using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiCuaHang.ENTITIES;
using QuanLiCuaHang.DATA_ACCESS_LAYER;
namespace QuanLiCuaHang.BUSSINESS_SERVICE
{
    public class XL_CHITIET_HDBH

    {
        public static CHITIET_HDBH TimHoaDon(string maMH, List<CHITIET_HDBH> listChiTietHoaDon)
        {
            int maMatHang = int.Parse(maMH);
            return listChiTietHoaDon[maMatHang - 1];
        }
        public static List<CHITIET_HDBH> UpdateMatHang(CHITIET_HDBH chiTietDonHang, List<CHITIET_HDBH> listChiTietHoaDon)
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
        public static List<CHITIET_HDBH> XoaMatHang(CHITIET_HDBH chiTietDonHang, List<CHITIET_HDBH> listChiTietHoaDon)
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
        public static List<CHITIET_HDBH> updateMaMatHang(List<CHITIET_HDBH> listChiTietHoaDon)
        {
            List<CHITIET_HDBH> result = new List<CHITIET_HDBH>();

            for (int i = 0; i < listChiTietHoaDon.Count(); i++)
            {
                CHITIET_HDBH chiTiet;
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