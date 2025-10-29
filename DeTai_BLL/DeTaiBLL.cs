using DeTai_DAL;
using DeTai_DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeTai_BLL
{
    public class DeTaiBLL
    {
        private DeTaiDAL deTaiDAL;

        public DeTaiBLL()
        {
            deTaiDAL = new DeTaiDAL();
        }

        // Lấy danh sách đề tài từ file
        public List<DeTai> LayDanhSachDeTai(string filename)
        {
            try
            {
                return deTaiDAL.DocDanhSachDeTai(filename);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tại BLL: {ex.Message}");
            }
        }

        // Tính tổng kinh phí tất cả đề tài
        public double TinhTongKinhPhi(List<DeTai> dsDeTai)
        {
            return dsDeTai.Sum(dt => dt.TinhKinhPhi());
        }

        // Lấy đề tài có kinh phí cao nhất
        public DeTai LayDeTaiKinhPhiCaoNhat(List<DeTai> dsDeTai)
        {
            if (dsDeTai == null || dsDeTai.Count == 0)
                return null;

            return dsDeTai.OrderByDescending(dt => dt.TinhKinhPhi()).FirstOrDefault();
        }

        // Lấy danh sách đề tài theo loại
        public List<DeTai> LayDeTaiTheoLoai(List<DeTai> dsDeTai, Type loaiDeTai)
        {
            return dsDeTai.Where(dt => dt.GetType() == loaiDeTai).ToList();
        }

        // Tìm kiếm đề tài theo mã số
        public DeTai TimDeTaiTheoMa(List<DeTai> dsDeTai, string maSo)
        {
            return dsDeTai.FirstOrDefault(dt => dt.MaSo.ToLower() == maSo.ToLower());
        }

        // Tìm kiếm đề tài theo tên
        public List<DeTai> TimDeTaiTheoTen(List<DeTai> dsDeTai, string tenDeTai)
        {
            return dsDeTai.Where(dt => dt.TenDeTai.ToLower().Contains(tenDeTai.ToLower())).ToList();
        }

        // Lấy đề tài theo giáo viên hướng dẫn
        public List<DeTai> LayDeTaiTheoGiaoVien(List<DeTai> dsDeTai, string tenGV)
        {
            return dsDeTai.Where(dt => dt.GvHuongDan.ToLower() == tenGV.ToLower()) .ToList();

        }

        // Lấy đề tài đang trong thời gian thực hiện
        public List<DeTai> LayDeTaiDangThucHien(List<DeTai> dsDeTai)
        {
            DateTime now = DateTime.Now;
            return dsDeTai.Where(dt => dt.NgayBD <= now && dt.NgayKT >= now).ToList();
        }

        // Lấy đề tài đã hoàn thành
        public List<DeTai> LayDeTaiDaHoanThanh(List<DeTai> dsDeTai)
        {
            DateTime now = DateTime.Now;
            return dsDeTai.Where(dt => dt.NgayKT < now).ToList();
        }

        // Sắp xếp đề tài theo kinh phí giảm dần
        public List<DeTai> SapXepTheoKinhPhi(List<DeTai> dsDeTai, bool tangDan = false)
        {
            if (tangDan)
                return dsDeTai.OrderBy(dt => dt.TinhKinhPhi()).ToList();
            else
                return dsDeTai.OrderByDescending(dt => dt.TinhKinhPhi()).ToList();
        }


        // Cập nhật kinh phí của tất cả đề tài tăng 10% và trả về danh sách mới
        public List<DeTai> CapNhatKinhPhiTang10PhanTram(List<DeTai> danhSach )
        {
            if (danhSach == null || danhSach.Count == 0)
                return new List<DeTai>();

            foreach (var deTai in danhSach)
            {
                
                double kinhPhiMoi = deTai.TinhKinhPhi() * 1.10;
                deTai.KinhPhi = kinhPhiMoi;
            }

            return danhSach;
        }
        // Lọc danh sách các đề tài có kinh phí trên 10 triệu
        public List<DeTai> LayDeTaiKinhPhiTren10Trieu(List<DeTai> dsDeTai)
        {        
            var ketQua = dsDeTai.Where(dt => dt.TinhKinhPhi() > 10).ToList();
            return ketQua;
        }

        // Điều kiện tồn tại cho đề tài
        public bool DieuKienTonTai(DeTai deTai, out string message)
        {
            message = string.Empty;

            if (string.IsNullOrWhiteSpace(deTai.MaSo))
            {
                message = "Mã số không được để trống.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(deTai.TenDeTai))
            {
                message = "Tên đề tài không được để trống.";
                return false;
            }

            if (deTai.NgayBD >= deTai.NgayKT)
            {
                message = "Ngày bắt đầu phải trước ngày kết thúc.";
                return false;
            }

            return true;
        }
        // 13 Lý thuyết & có khả năng triển khai thực tế
        public List<DeTai> LayDeTaiLyThuyetApDungThucTe(List<DeTai> dsDeTai)
        {
            
            return dsDeTai.Where(dt => dt is DeTaiLyThuyet lt && lt.ApDungThucTe).ToList();
        }

        //14 Kinh tế có số câu hỏi khảo sát > 100
        public List<DeTai> LayDeTaiKinhTeSoCauHoiTren100(List<DeTai> dsDeTai)
        {
            
            return dsDeTai.Where(dt => dt is DeTaiKinhTe kt && kt.SoCauHoi > 100).ToList();
        }

        //15 Thời gian thực hiện > 4 tháng
        public List<DeTai> LayDeTaiThoiGianTren4Thang(List<DeTai> dsDeTai)
        {
         
            return dsDeTai.Where(dt => dt.NgayBD.AddMonths(4) < dt.NgayKT).ToList();
        }

    }
}