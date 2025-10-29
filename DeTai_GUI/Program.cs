using DeTai_BLL;
using DeTai_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DeTai_GUI
{
    internal class Program
    {
        static DeTaiBLL deTaiBLL = new DeTaiBLL();
        static List<DeTai> danhSachDeTai = new List<DeTai>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Đọc dữ liệu từ file XML
            try
            {
                danhSachDeTai = deTaiBLL.LayDanhSachDeTai(@"../../../Data/Data.xml");
                Console.WriteLine("Đọc file thành công!");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                
                return;
            }

            // Menu chức năng
            int choice;
            do
            {
                HienThiMenu();
                Console.Write("Chọn chức năng: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Vui lòng nhập số!");
                    continue;
                }

                Console.WriteLine();
                XuLyChucNang(choice);

                if (choice != 0)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                }

            } while (choice != 0);

            Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
        }

        static void HienThiMenu()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║      QUẢN LÝ ĐỀ TÀI NGHIÊN CỨU KHOA HỌC            ║");
            Console.WriteLine("╠════════════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Hiển thị tất cả đề tài                          ║");
            Console.WriteLine("║ 2. Tìm kiếm đề tài theo mã số                      ║");
            Console.WriteLine("║ 3. Tìm kiếm đề tài theo tên                        ║");
            Console.WriteLine("║ 4. Hiển thị đề tài theo loại                       ║");
            Console.WriteLine("║ 5. Hiển thị đề tài theo giáo viên hướng dẫn        ║");
            Console.WriteLine("║ 6. Thống kê tổng kinh phí                          ║");
            Console.WriteLine("║ 7. Tìm đề tài có kinh phí cao nhất                 ║");
            Console.WriteLine("║ 8. Hiển thị đề tài đang thực hiện                  ║");
            Console.WriteLine("║ 9. Sắp xếp đề tài theo kinh phí                    ║");
            Console.WriteLine("║ 10. Cập nhật kinh phí tăng 10%                     ║");
            Console.WriteLine("║ 11. Xuất danh sách sau khi tăng 10% kinh phí       ║");
            Console.WriteLine("║ 12. Xuất đề tài có kinh phí trên 10 triệu          ║");
            Console.WriteLine("║ 13. Xuất đề tài Lý thuyết có khả năng triển khai   ║");
            Console.WriteLine("║ 14. Xuất đề tài Kinh tế có > 100 câu khảo sát      ║");
            Console.WriteLine("║ 15. Xuất đề tài có thời gian thực hiện > 4 tháng   ║");
            Console.WriteLine("║ 0. Thoát                                           ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝");
        }

        static void XuLyChucNang(int choice)
        {
            switch (choice)
            {
                case 1:
                    HienThiTatCaDeTai();
                    break;
                case 2:
                    TimKiemTheoMa();
                    break;
                case 3:
                    TimKiemTheoTen();
                    break;
                case 4:
                    HienThiTheoLoai();
                    break;
                case 5:
                    HienThiTheoGiaoVien();
                    break;
                case 6:
                    ThongKeTongKinhPhi();
                    break;
                case 7:
                    TimDeTaiKinhPhiCaoNhat();
                    break;
                case 8:
                    HienThiDeTaiDangThucHien();
                    break;
                case 9:
                    SapXepTheoKinhPhi();
                    break;
                case 10:
                    danhSachDeTai = deTaiBLL.CapNhatKinhPhiTang10PhanTram(danhSachDeTai);
                    Console.WriteLine(" Đã cập nhật kinh phí của tất cả đề tài tăng lên 10%!");
                    break;
                case 11:
                    XuatDanhSachSauKhiTang10PhanTram();
                    break;
                case 12:
                    XuatDeTaiKinhPhiTren10Trieu();
                    break;
                case 13:
                    XuatDeTaiLyThuyetApDungThucTe();
                    break;
                case 14:
                    XuatDeTaiKinhTeSoCauHoiTren100();
                    break;
                case 15:
                    XuatDeTaiThoiGianTren4Thang();
                    break;

                case 0:
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        }

        static void HienThiTatCaDeTai()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("                    DANH SÁCH TẤT CẢ ĐỀ TÀI");
            Console.WriteLine("------------------------------------------------------------");

            if (danhSachDeTai.Count == 0)
            {
                Console.WriteLine("Không có đề tài nào trong danh sách!");
                return;
            }

            foreach (var deTai in danhSachDeTai)
            {
                HienThiChiTietDeTai(deTai);
            }
        }

        static void HienThiChiTietDeTai(DeTai deTai)
        {
            Console.WriteLine($"Mã số: {deTai.MaSo}");
            Console.WriteLine($"Tên đề tài: {deTai.TenDeTai}");
            Console.WriteLine($"Trưởng nhóm: {deTai.TruongNhom}");
            Console.WriteLine($"Giáo viên hướng dẫn: {deTai.GvHuongDan}");
            Console.WriteLine($"Ngày bắt đầu: {deTai.NgayBD:dd/MM/yyyy}");
            Console.WriteLine($"Ngày kết thúc: {deTai.NgayKT:dd/MM/yyyy}");

            if (deTai is DeTaiKinhTe deTaiKinhTe)
            {
                Console.WriteLine($"Loại: Đề tài Kinh tế");
                Console.WriteLine($"Số câu hỏi: {deTaiKinhTe.SoCauHoi}");
                Console.WriteLine($"Kinh phí nghiên cứu: {deTaiKinhTe.TinhPhiNC():N0} VNĐ");
                Console.WriteLine($"Kinh phí tổng cộng: {deTaiKinhTe.TinhKinhPhi():N0} VNĐ");
            }
            else if (deTai is DeTaiLyThuyet deTaiLyThuyet)
            {
                Console.WriteLine($"Loại: Đề tài Lý thuyết");
                Console.WriteLine($"Áp dụng thực tế: {(deTaiLyThuyet.ApDungThucTe ? "Có" : "Không")}");
                Console.WriteLine($"Kinh phí tổng cộng: {deTaiLyThuyet.TinhKinhPhi():N0} VNĐ");
            }
            else if (deTai is DeTaiCongNghe deTaiCongNghe)
            {
                Console.WriteLine($"Loại: Đề tài Công nghệ");
                Console.WriteLine($"Môi trường: {deTaiCongNghe.MoiTruong}");
                Console.WriteLine($"Kinh phí nghiên cứu: {deTaiCongNghe.TinhPhiNC():N0} VNĐ");
                Console.WriteLine($"Kinh phí tổng cộng: {deTaiCongNghe.TinhKinhPhi():N0} VNĐ");
            }

            Console.WriteLine("------------------------------------------------------------");
        }

        static void TimKiemTheoMa()
        {
            Console.Write("Nhập mã số đề tài cần tìm: ");
            string maSo = Console.ReadLine();

            DeTai deTai = deTaiBLL.TimDeTaiTheoMa(danhSachDeTai, maSo);

            if (deTai != null)
            {
                Console.WriteLine("\nKết quả tìm kiếm:");
                Console.WriteLine("------------------------------------------------------------");
                HienThiChiTietDeTai(deTai);
            }
            else
            {
                Console.WriteLine($"Không tìm thấy đề tài có mã số: {maSo}");
            }
        }

        static void TimKiemTheoTen()
        {
            Console.Write("Nhập tên đề tài cần tìm: ");
            string tenDeTai = Console.ReadLine();

            List<DeTai> ketQua = deTaiBLL.TimDeTaiTheoTen(danhSachDeTai, tenDeTai);

            if (ketQua.Count > 0)
            {
                Console.WriteLine($"\nTìm thấy {ketQua.Count} đề tài:");
                Console.WriteLine("------------------------------------------------------------");
                foreach (var dt in ketQua)
                {
                    HienThiChiTietDeTai(dt);
                }
            }
            else
            {
                Console.WriteLine($"Không tìm thấy đề tài nào có tên chứa: {tenDeTai}");
            }
        }

        static void HienThiTheoLoai()
        {
            Console.WriteLine("Chọn loại đề tài:");
            Console.WriteLine("1. Đề tài Kinh tế");
            Console.WriteLine("2. Đề tài Lý thuyết");
            Console.WriteLine("3. Đề tài Công nghệ");
            Console.Write("Lựa chọn: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Lựa chọn không hợp lệ!");
                return;
            }

            Type loaiDeTai = null;
            string tenLoai = "";

            switch (choice)
            {
                case 1:
                    loaiDeTai = typeof(DeTaiKinhTe);
                    tenLoai = "Kinh tế";
                    break;
                case 2:
                    loaiDeTai = typeof(DeTaiLyThuyet);
                    tenLoai = "Lý thuyết";
                    break;
                case 3:
                    loaiDeTai = typeof(DeTaiCongNghe);
                    tenLoai = "Công nghệ";
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    return;
            }

            List<DeTai> ketQua = deTaiBLL.LayDeTaiTheoLoai(danhSachDeTai, loaiDeTai);

            Console.WriteLine($"\nCó {ketQua.Count} đề tài {tenLoai}:");
            Console.WriteLine("------------------------------------------------------------");
            foreach (var dt in ketQua)
            {
                HienThiChiTietDeTai(dt);
            }
        }

        static void HienThiTheoGiaoVien()
        {
            Console.Write("Nhập tên giáo viên hướng dẫn: ");
            string tenGV = Console.ReadLine();

            List<DeTai> ketQua = deTaiBLL.LayDeTaiTheoGiaoVien(danhSachDeTai, tenGV);

            if (ketQua.Count > 0)
            {
                Console.WriteLine($"\nGiáo viên {tenGV} đang hướng dẫn {ketQua.Count} đề tài:");
                Console.WriteLine("------------------------------------------------------------");
                foreach (var dt in ketQua)
                {
                    HienThiChiTietDeTai(dt);
                }
            }
            else
            {
                Console.WriteLine($"Không tìm thấy đề tài nào của giáo viên: {tenGV}");
            }
        }

        static void ThongKeTongKinhPhi()
        {
            double tongKinhPhi = deTaiBLL.TinhTongKinhPhi(danhSachDeTai);

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("                    THỐNG KÊ KINH PHÍ");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"Tổng số đề tài: {danhSachDeTai.Count}");
            Console.WriteLine($"Tổng kinh phí: {tongKinhPhi:N0} VNĐ");
            Console.WriteLine($"Kinh phí trung bình: {(tongKinhPhi / danhSachDeTai.Count):N0} VNĐ");
        }

        static void TimDeTaiKinhPhiCaoNhat()
        {
            DeTai deTai = deTaiBLL.LayDeTaiKinhPhiCaoNhat(danhSachDeTai);

            if (deTai != null)
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("              ĐỀ TÀI CÓ KINH PHÍ CAO NHẤT");
                Console.WriteLine("------------------------------------------------------------");
                HienThiChiTietDeTai(deTai);
            }
            else
            {
                Console.WriteLine("Không có đề tài nào trong danh sách!");
            }
        }

        static void HienThiDeTaiDangThucHien()
        {
            List<DeTai> ketQua = deTaiBLL.LayDeTaiDangThucHien(danhSachDeTai);

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("              ĐỀ TÀI ĐANG THỰC HIỆN");
            Console.WriteLine("------------------------------------------------------------");

            if (ketQua.Count > 0)
            {
                Console.WriteLine($"Có {ketQua.Count} đề tài đang thực hiện:");
                foreach (var dt in ketQua)
                {
                    HienThiChiTietDeTai(dt);
                }
            }
            else
            {
                Console.WriteLine("Không có đề tài nào đang thực hiện!");
            }
        }
        

        static void SapXepTheoKinhPhi()
        {
            Console.WriteLine("Chọn cách sắp xếp:");
            Console.WriteLine("1. Tăng dần");
            Console.WriteLine("2. Giảm dần");
            Console.Write("Lựa chọn: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Lựa chọn không hợp lệ!");
                return;
            }

            bool tangDan = (choice == 1);
            List<DeTai> ketQua = deTaiBLL.SapXepTheoKinhPhi(danhSachDeTai, tangDan);

            Console.WriteLine($"\nDanh sách đề tài sắp xếp theo kinh phí {(tangDan ? "tăng dần" : "giảm dần")}:");
            Console.WriteLine("------------------------------------------------------------");

            foreach (var dt in ketQua)
            {
                HienThiChiTietDeTai(dt);
            }

        }
        static void XuatDanhSachSauKhiTang10PhanTram()
        {
            Console.WriteLine("sau khi taang 10 % thi ");


            List<DeTai> ketqua = deTaiBLL.CapNhatKinhPhiTang10PhanTram(danhSachDeTai);
            foreach (var dt in danhSachDeTai)
            {
                Console.WriteLine($"Mã số: {dt.MaSo}");
                Console.WriteLine($"Tên đề tài: {dt.TenDeTai}");
                Console.WriteLine($"Trưởng nhóm: {dt.TruongNhom}");
                Console.WriteLine($"Giáo viên hướng dẫn: {dt.GvHuongDan}");
                Console.WriteLine($"Ngày bắt đầu: {dt.NgayBD:dd/MM/yyyy}");
                Console.WriteLine($"Ngày kết thúc: {dt.NgayKT:dd/MM/yyyy}");

                if (dt is DeTaiKinhTe ke)
                {
                    Console.WriteLine($"Loại: Đề tài Kinh tế");
                    Console.WriteLine($"Số câu hỏi: {ke.SoCauHoi}");
                    Console.WriteLine($"Kinh phí nghiên cứu: {ke.TinhPhiNC():N0} VNĐ");
                    Console.WriteLine($"Kinh phí tổng cộng sau tăng 10%: {ke.KinhPhi:N0} VNĐ");
                }
                else if (dt is DeTaiLyThuyet lt)
                {
                    Console.WriteLine($"Loại: Đề tài Lý thuyết");
                    Console.WriteLine($"Áp dụng thực tế: {(lt.ApDungThucTe ? "Có" : "Không")}");
                    Console.WriteLine($"Kinh phí tổng cộng sau tăng 10%: {lt.KinhPhi:N0} VNĐ");
                }
                else if (dt is DeTaiCongNghe cn)
                {
                    Console.WriteLine($"Loại: Đề tài Công nghệ");
                    Console.WriteLine($"Môi trường: {cn.MoiTruong}");
                    Console.WriteLine($"Kinh phí nghiên cứu: {cn.TinhPhiNC():N0} VNĐ");
                    Console.WriteLine($"Kinh phí tổng cộng sau tăng 10%: {cn.KinhPhi:N0} VNĐ");
                }
                Console.WriteLine("------------------------------------------------------------");
            }
        }
        static void XuatDeTaiKinhPhiTren10Trieu()
        {
            
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("     DANH SÁCH CÁC ĐỀ TÀI CÓ KINH PHÍ TRÊN 10 TRIỆU");
            Console.WriteLine("------------------------------------------------------------");

            var ketQua = deTaiBLL.LayDeTaiKinhPhiTren10Trieu(danhSachDeTai);

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Không có đề tài nào có kinh phí trên 10 triệu!");
                return;
            }

            foreach (var dt in ketQua)
            {
                HienThiChiTietDeTai(dt);
            }
            Console.WriteLine($"\n Tổng cộng có {ketQua.Count} đề tài có kinh phí trên 10 triệu!");
        }
        // 12) Lý thuyết & có khả năng triển khai
        static void XuatDeTaiLyThuyetApDungThucTe()
        {
            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("  ĐỀ TÀI LÝ THUYẾT CÓ KHẢ NĂNG TRIỂN KHAI THỰC TẾ");
            Console.WriteLine("------------------------------------------------------------\n");

            var ketQua = deTaiBLL.LayDeTaiLyThuyetApDungThucTe(danhSachDeTai);
            

            foreach (var dt in ketQua) HienThiChiTietDeTai(dt);
            Console.WriteLine($"\n Tổng cộng: {ketQua.Count} đề tài.");
        }

        // 13) Kinh tế có số câu hỏi > 100
        static void XuatDeTaiKinhTeSoCauHoiTren100()
        {
            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("     ĐỀ TÀI KINH TẾ VỚI SỐ CÂU HỎI KHẢO SÁT > 100");
            Console.WriteLine("------------------------------------------------------------\n");

            var ketQua = deTaiBLL.LayDeTaiKinhTeSoCauHoiTren100(danhSachDeTai);
            

            foreach (var dt in ketQua) HienThiChiTietDeTai(dt);
            Console.WriteLine($"\n Tổng cộng: {ketQua.Count} đề tài.");
        }

        // 14) Thời gian thực hiện > 4 tháng
        static void XuatDeTaiThoiGianTren4Thang()
        {
            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("       ĐỀ TÀI CÓ THỜI GIAN THỰC HIỆN TRÊN 4 THÁNG");
            Console.WriteLine("------------------------------------------------------------\n");

            var ketQua = deTaiBLL.LayDeTaiThoiGianTren4Thang(danhSachDeTai);
           

            foreach (var dt in ketQua) HienThiChiTietDeTai(dt);
            Console.WriteLine($"\n Tổng cộng: {ketQua.Count} đề tài.");
        }

    }
}