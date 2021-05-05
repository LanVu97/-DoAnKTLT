using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiCuaHang.ENTITIES;
namespace QuanLiCuaHang.ENTITIES
{
    public struct HD_BANHANG
    {
        public String maHoaDon;
        public String ngayTaoHoaDon;
        public int tongSoLuong;
        public List<CHITIET_HDBH> listChitietHoaDon;
        
    }
}