using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiCuaHang.ENTITIES;
namespace QuanLiCuaHang.ENTITIES
{
    public struct HOADON
    {
        public String maHoaDon;
        public String ngayTaoHoaDon;
        public int tongSoLuong;
        public List<CHITIET_HD> listChitietHoaDon;
        
    }
}