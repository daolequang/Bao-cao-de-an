using DeTai_DTO;
using System;
using System.Collections.Generic;
using System.Xml;

namespace DeTai_DAL
{
    public class DeTaiDAL
    {
        // Đọc dữ liệu từ file XML
        public List<DeTai> DocDanhSachDeTai(string filename)
        {
            List<DeTai> dsDeTai = new List<DeTai>();

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);
                XmlNodeList deTaiNodes = doc.SelectNodes("DeTais/DeTai");

                foreach (XmlNode node in deTaiNodes)
                {
                    string loaiDeTai = node.Attributes["type"].Value;

                    // Đọc các thuộc tính chung
                    string maSo = node["MaSo"].InnerText;
                    string tenDeTai = node["TenDeTai"].InnerText;
                    string tenChuTri = node["TenChuTri"].InnerText;
                    string gvHuongDan = node["GvHuongDan"].InnerText;
                    DateTime ngayBD = DateTime.Parse(node["NgayBD"].InnerText);
                    DateTime ngayKT = DateTime.Parse(node["NgayKT"].InnerText);

                    // Tạo đối tượng theo loại đề tài
                    if (loaiDeTai == "KinhTe")
                    {
                        int soCauHoi = int.Parse(node["SoCauHoi"].InnerText);
                        DeTaiKinhTe deTai = new DeTaiKinhTe(maSo, tenDeTai, 0, tenChuTri,
                                                            gvHuongDan, ngayBD, ngayKT, soCauHoi);
                        dsDeTai.Add(deTai);
                    }
                    else if (loaiDeTai == "LyThuyet")
                    {
                        bool apDungThucTe = bool.Parse(node["ApDungThucTe"].InnerText);
                        DeTaiLyThuyet deTai = new DeTaiLyThuyet(maSo, tenDeTai, 0, tenChuTri,
                                                                gvHuongDan, ngayBD, ngayKT, apDungThucTe);
                        dsDeTai.Add(deTai);
                    }
                    else if (loaiDeTai == "CongNghe")
                    {
                        string moiTruong = node["MoiTruong"].InnerText;
                        DeTaiCongNghe deTai = new DeTaiCongNghe(maSo, tenDeTai, 0, tenChuTri,
                                                                gvHuongDan, ngayBD, ngayKT, moiTruong);
                        dsDeTai.Add(deTai);
                    }
                    else
                    {
                        throw new Exception($"Loại đề tài '{loaiDeTai}' không hợp lệ.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi đọc file XML: {ex.Message}");
            }

            return dsDeTai;
        }

        // Có thể thêm các phương thức khác như:
        // - GhiDanhSachDeTai(string filename, List<DeTai> dsDeTai)
        // - TimDeTaiTheoMa(string maSo)
        // - XoaDeTai(string maSo)
        // - CapNhatDeTai(DeTai deTai)
    }
}