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
        public static List<CHITIET_HDBH> ThemVaoListCTHD(CHITIET_HDBH chiTietDonHang)
        {
            List<CHITIET_HDBH> listChiTietHD = new List<CHITIET_HDBH>();
            listChiTietHD.Add(chiTietDonHang);
            return listChiTietHD;
        }



    }
}