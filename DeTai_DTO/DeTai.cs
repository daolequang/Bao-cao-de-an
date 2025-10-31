using System;

namespace DeTai_DTO
{
    // Interface để tính phí nghiên cứu
    public interface ITinhPhiNC
    {
        double TinhPhiNC();
    }

    // Class cơ sở trừu tượng cho đề tài
    public abstract class DeTai
    {
        public string MaSo { get; set; }
        public string TenDeTai { get; set; }
        public double KinhPhi { get; set; }
        public string TruongNhom { get; set; }
        public string GvHuongDan { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
       

        protected DeTai() { }

        protected DeTai(string maSo, string tenDeTai, double kinhPhi, string truongNhom,
                       string gvHuongDan, DateTime ngayBD, DateTime ngayKT)
        {
            this.MaSo = maSo;
            this.TenDeTai = tenDeTai;
            this.KinhPhi = kinhPhi;
            this.TruongNhom = truongNhom;
            this.GvHuongDan = gvHuongDan;
            this.NgayBD = ngayBD;
            this.NgayKT = ngayKT;
        }

        public abstract double TinhKinhPhi();
    }

    // Class Đề tài Kinh tế
    public class DeTaiKinhTe : DeTai, ITinhPhiNC
    {
        public int SoCauHoi { get; set; }

        public DeTaiKinhTe() { }

        public DeTaiKinhTe(string maSo, string tenDeTai, double kinhPhi, string truongNhom,
                          string gvHuongDan, DateTime ngayBD, DateTime ngayKT, int soCauHoi)
            : base(maSo, tenDeTai, kinhPhi, truongNhom, gvHuongDan, ngayBD, ngayKT)
        {
            this.SoCauHoi = soCauHoi;
        }

        public double TinhPhiNC()
        {
            if (SoCauHoi > 100)
                return 500 * SoCauHoi;
            return 450 * SoCauHoi;
        }

        public override double TinhKinhPhi()
        {
            if (SoCauHoi > 100)
                return 12000000;
            return 7000000;
        }
    }

    // Class Đề tài Lý thuyết
    public class DeTaiLyThuyet : DeTai
    {
        public bool ApDungThucTe { get; set; }

        public DeTaiLyThuyet() { }

        public DeTaiLyThuyet(string maSo, string tenDeTai, double kinhPhi, string truongNhom,
                            string gvHuongDan, DateTime ngayBD, DateTime ngayKT, bool apDungThucTe)
            : base(maSo, tenDeTai, kinhPhi, truongNhom, gvHuongDan, ngayBD, ngayKT)
        {
            this.ApDungThucTe = apDungThucTe;
        }

        public override double TinhKinhPhi()
        {
            if (ApDungThucTe == false)
                return 8000000;
            return 15000000;
        }
    }

    // Class Đề tài Công nghệ
    public class DeTaiCongNghe : DeTai, ITinhPhiNC
    {
        private string moiTruong;

        public string MoiTruong
        {
            get => moiTruong;
            set
            {

                if (value.Equals("mobile") || value.Equals("web") || value.Equals("window"))
                    moiTruong = value;
                else
                    throw new Exception("Môi trường không hợp lệ. Chỉ chấp nhận: Mobile, Web, Window");
            }
        }

        public DeTaiCongNghe() { }

        public DeTaiCongNghe(string maSo, string tenDeTai, double kinhPhi, string truongNhom,
                            string gvHuongDan, DateTime ngayBD, DateTime ngayKT, string moiTruong)
            : base(maSo, tenDeTai, kinhPhi, truongNhom, gvHuongDan, ngayBD, ngayKT)
        {
            this.MoiTruong = moiTruong;
        }

        public double TinhPhiNC()
        {
            string Phi = MoiTruong.ToLower();
            if (Phi == "mobile")
                return 1000000;
            else if (Phi == "web")
                return 800000;
            else
                return 500000;
        }

        public override double TinhKinhPhi()
        {
            string Phi = MoiTruong.ToLower();
            if (Phi == "mobile" || Phi == "web")
                return 15000000;
            return 10000000;
        }
    }
}
