using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using QuanLiCuaHang.ENTITIES;
using QuanLiCuaHang.BUSSINESS_SERVICE; 
namespace QuanLiCuaHang.BUSSINESS_SERVICE
{
    public class XL_THONGKE_HANGTON
    {
        public static List<CHITIET_HD> TimKiemHangTonTheoTheLoai(String theLoai)
        {
            List<MATHANG> listMatHang = XL_MATHANG.DocMatHang();
            int length = listMatHang.Count() + 1;

            int[] listSoLuong = new int[length];
            int[] HangNhapTheoTheLoai = ThongKeHangNhapTheoTheLoai(theLoai, length);
            int[] HangDaBanTheoTheLoai = ThongKeHangDaBanTheoTheLoai(theLoai, length);

            for(int i = 0; i < HangNhapTheoTheLoai.Count(); i++)
            {
                listSoLuong[i] = HangNhapTheoTheLoai[i] - HangDaBanTheoTheLoai[i];
                
            }

            List<CHITIET_HD> listHangTon = new List<CHITIET_HD>();
            for(int i = 1; i < length; i++)
            {
                if(listSoLuong[i] != 0)
                {
                    CHITIET_HD hangTon = new CHITIET_HD();
                    hangTon.matHang = listMatHang[i -1];
                    hangTon.soLuong = listSoLuong[i];
                    listHangTon.Add(hangTon);
                }
            }

            return listHangTon;
        }
        public static int[] ThongKeHangNhapTheoTheLoai(String theloai, int length)
        {
            int[] listHanhNhapTheoTheLoai = new int[length];
            List<HOADON> listHoaDonHangNhap = XL_HD_NHAPHANG.DocHDNhapHang();
            for(int i = 0; i <listHoaDonHangNhap.Count(); i++)
            {
                var listHangNhap = listHoaDonHangNhap[i].listChitietHoaDon;
                for(int j = 0; j < listHangNhap.Count(); j++)
                {
                  if( listHangNhap[j].matHang.LoaiHang == theloai){
                        int maMatHang = int.Parse(listHangNhap[j].matHang.MaMatHang);
                        listHanhNhapTheoTheLoai[maMatHang] += listHangNhap[j].soLuong;
            }
                }
            }

            return listHanhNhapTheoTheLoai;
        }
        public static int[] ThongKeHangDaBanTheoTheLoai(String theloai, int length)
        {
            int[] listHangDaBanTheoTheLoai = new int[length];
            List<HOADON> listHoaDonHangBan = XL_HD_BANHANG.DocHDBanHang();
            for (int i = 0; i < listHoaDonHangBan.Count(); i++)
            {
                var listHangBan = listHoaDonHangBan[i].listChitietHoaDon;
                for (int j = 0; j < listHangBan.Count(); j++)
                {
                    if (listHangBan[j].matHang.LoaiHang == theloai)
                    {
                        int maMatHang = int.Parse(listHangBan[j].matHang.MaMatHang);
                        listHangDaBanTheoTheLoai[maMatHang] += listHangBan[j].soLuong;
                    }
                }
            }

            return listHangDaBanTheoTheLoai;
        }

        public static List<CHITIET_HD> TimKiemHangTonDaHetHan()
        {
            DateTime today = DateTime.Now;
            List<MATHANG> listMatHang = XL_MATHANG.DocMatHang();
            int length = listMatHang.Count() + 1;

            int[] listSoLuong = new int[length];
            int[] HangNhapDaHetHan = ThongKeHangNhapDaHetHan(today, length);
            int[] HangDaBanHetHan = ThongKeHangDaBanHetHan(today, length);

            for (int i = 0; i < HangNhapDaHetHan.Count(); i++)
            {
                listSoLuong[i] = HangNhapDaHetHan[i] - HangDaBanHetHan[i];

            }

            List<CHITIET_HD> listHangTon = new List<CHITIET_HD>();
            for (int i = 1; i < length; i++)
            {
                if (listSoLuong[i] != 0)
                {
                    CHITIET_HD hangTon = new CHITIET_HD();
                    hangTon.matHang = listMatHang[i - 1];
                    hangTon.soLuong = listSoLuong[i];
                    listHangTon.Add(hangTon);
                }
            }

            return listHangTon;
        }
        public static int[] ThongKeHangNhapDaHetHan(DateTime today, int length)
        {
            int[] listHanhNhapDaHetHan = new int[length];
            List<HOADON> listHoaDonHangNhap = XL_HD_NHAPHANG.DocHDNhapHang();
            for (int i = 0; i < listHoaDonHangNhap.Count(); i++)
            {
                var listHangNhap = listHoaDonHangNhap[i].listChitietHoaDon;
                for (int j = 0; j < listHangNhap.Count(); j++)
                {
                    String hanDung = listHangNhap[j].matHang.HanDung;
                    DateTime dt = DateTime.ParseExact(hanDung, "dd/MM/yyyy", null);
                    int compare = DateTime.Compare(dt, today);
                    if (compare < 0)
                    {
                        int maMatHang = int.Parse(listHangNhap[j].matHang.MaMatHang);
                        listHanhNhapDaHetHan[maMatHang] += listHangNhap[j].soLuong;
                    }
                }
            }
            
            return listHanhNhapDaHetHan;
        }
        public static int[] ThongKeHangDaBanHetHan(DateTime today, int length)
        {
            int[] listHangDaBanDaHetHan = new int[length];
            List<HOADON> listHoaDonHangBan = XL_HD_BANHANG.DocHDBanHang();
            for (int i = 0; i < listHoaDonHangBan.Count(); i++)
            {
                var listHangBan = listHoaDonHangBan[i].listChitietHoaDon;
                for (int j = 0; j < listHangBan.Count(); j++)
                {
                    String hanDung = listHangBan[j].matHang.HanDung;
                    DateTime dt = DateTime.ParseExact(hanDung, "dd/MM/yyyy", null);
                    int compare = DateTime.Compare(dt, today);
                    if (compare < 0)
                    {
                        int maMatHang = int.Parse(listHangBan[j].matHang.MaMatHang);
                        listHangDaBanDaHetHan[maMatHang] += listHangBan[j].soLuong;
                    }
                }
            }

            return listHangDaBanDaHetHan;
        }


    }
}