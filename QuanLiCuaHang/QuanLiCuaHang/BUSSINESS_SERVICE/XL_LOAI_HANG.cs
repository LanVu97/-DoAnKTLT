using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiCuaHang.ENTITIES;
using QuanLiCuaHang.DATA_ACCESS_LAYER;
namespace QuanLiCuaHang.BUSSINESS_SERVICE
{
    public class XL_LOAI_HANG

    {

        public static List<LOAI_HANG> DocLoaiHang()
        {
            return LT_LOAI_HANG.DocLoaiHang();
        }
        public static List<LOAI_HANG> TimKiemLoaiHang(String keyword)
        {
            
            List<LOAI_HANG> listLoaiHang = LT_LOAI_HANG.DocLoaiHang();
            if(listLoaiHang.Count() == 0)
            {
                return null;
            }

            List<LOAI_HANG> listKetQuaTimKiem = new List<LOAI_HANG>();

            for(int i = 0; i < listLoaiHang.Count(); i++)
            {
                if (listLoaiHang[i].TenLoaiHang.Contains(keyword))
                {
                    listKetQuaTimKiem.Add(listLoaiHang[i]);
                }
            }
            return listKetQuaTimKiem;
        }

        public static LOAI_HANG TimKiemLoaiHang_MaLH(String maLoaiHang)
        {
            List<LOAI_HANG> listLoaiHang = LT_LOAI_HANG.DocLoaiHang();
            
            for (int i = 0; i < listLoaiHang.Count(); i++)
            {
                if (listLoaiHang[i].MaLoaiHang == maLoaiHang)
                {
                    return listLoaiHang[i];
                }
            }
            return new LOAI_HANG();
        }

        public static void ThemLoaiHang(LOAI_HANG LoaiHang)
        {
            LT_LOAI_HANG.LuuMatHang(LoaiHang);
        }
        public static void XoaLoaiHang(String matLoaiHang)
        {
            LT_LOAI_HANG.XoaLoaiHang(matLoaiHang);
        }

        public static void SuaLoaiHang(LOAI_HANG LoaiHang)
        {
            LT_LOAI_HANG.SuaLoaiHang(LoaiHang);
        }
    }
}