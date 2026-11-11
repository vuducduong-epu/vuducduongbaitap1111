
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QuanLyBanHang
{
    public partial class Form1 : Form
    {
        private TextBox txtMaSP;
        private NumericUpDown numSoLuong;
        private Button btnThem;
        private Button btnXoa;
        private Button btnThanhToan;
        private Button btnDoanhThuNgay;
        private Button btnDoanhThuThang;
        private Button btnTop5;
        private ComboBox cboKhachHang;
        private DataGridView dgvGioHang;
        private DataGridView dgvTop5;
        private Label lblTongTien;
        private Label lblDiemTichLuy;
        private Label lblDoanhThuNgay;
        private Label lblDoanhThuThang;

        public Form1()
        {
            InitializeComponent();
            TaoGiaoDien();

            this.Load += Form1_Load;
            btnThem.Click += btnThem_Click;
            btnXoa.Click += btnXoa_Click;
            btnThanhToan.Click += btnThanhToan_Click;
            btnDoanhThuNgay.Click += btnDoanhThuNgay_Click;
            btnDoanhThuThang.Click += btnDoanhThuThang_Click;
            btnTop5.Click += btnTop5_Click;

            txtMaSP.KeyDown += txtMaSP_KeyDown;
            cboKhachHang.SelectedIndexChanged += cboKhachHang_SelectedIndexChanged;
        }

        private void TaoGiaoDien()
        {
            this.Text = "QUAN LY BAN HANG";
            this.Size = new Size(1300, 950);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.MinimumSize = new Size(1200, 850);

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "QUAN LY BAN HANG";
            lblTieuDe.Font = new Font("Arial", 22, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.DarkBlue;
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.Dock = DockStyle.Top;
            lblTieuDe.Height = 70;
            this.Controls.Add(lblTieuDe);

            GroupBox grpSanPham = new GroupBox();
            grpSanPham.Text = "THONG TIN SAN PHAM";
            grpSanPham.Font = new Font("Arial", 10, FontStyle.Bold);
            grpSanPham.Location = new Point(20, 85);
            grpSanPham.Size = new Size(340, 250);
            this.Controls.Add(grpSanPham);

            Label lblMaSP = new Label();
            lblMaSP.Text = "Ma san pham:";
            lblMaSP.Location = new Point(20, 40);
            lblMaSP.AutoSize = true;
            grpSanPham.Controls.Add(lblMaSP);

            txtMaSP = new TextBox();
            txtMaSP.Location = new Point(20, 65);
            txtMaSP.Size = new Size(290, 30);
            grpSanPham.Controls.Add(txtMaSP);

            Label lblSoLuong = new Label();
            lblSoLuong.Text = "So luong:";
            lblSoLuong.Location = new Point(20, 110);
            lblSoLuong.AutoSize = true;
            grpSanPham.Controls.Add(lblSoLuong);

            numSoLuong = new NumericUpDown();
            numSoLuong.Location = new Point(20, 135);
            numSoLuong.Size = new Size(290, 30);
            numSoLuong.Minimum = 1;
            numSoLuong.Maximum = 1000;
            numSoLuong.Value = 1;
            grpSanPham.Controls.Add(numSoLuong);

            btnThem = new Button();
            btnThem.Text = "THEM VAO GIO";
            btnThem.Location = new Point(20, 185);
            btnThem.Size = new Size(135, 40);
            btnThem.BackColor = Color.LightGreen;
            grpSanPham.Controls.Add(btnThem);

            btnXoa = new Button();
            btnXoa.Text = "XOA SAN PHAM";
            btnXoa.Location = new Point(170, 185);
            btnXoa.Size = new Size(140, 40);
            btnXoa.BackColor = Color.LightCoral;
            grpSanPham.Controls.Add(btnXoa);

            GroupBox grpGioHang = new GroupBox();
            grpGioHang.Text = "GIO HANG";
            grpGioHang.Font = new Font("Arial", 10, FontStyle.Bold);
            grpGioHang.Location = new Point(380, 85);
            grpGioHang.Size = new Size(880, 430);
            this.Controls.Add(grpGioHang);

            dgvGioHang = new DataGridView();
            dgvGioHang.Location = new Point(15, 30);
            dgvGioHang.Size = new Size(850, 385);
            dgvGioHang.AllowUserToAddRows = false;
            dgvGioHang.ReadOnly = true;
            dgvGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGioHang.MultiSelect = false;
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGioHang.RowHeadersVisible = false;
            dgvGioHang.BackgroundColor = Color.White;

            dgvGioHang.Columns.Add("MaSP", "Ma SP");
            dgvGioHang.Columns.Add("TenSP", "Ten san pham");
            dgvGioHang.Columns.Add("SoLuong", "So luong");
            dgvGioHang.Columns.Add("DonGia", "Don gia");
            dgvGioHang.Columns.Add("ThanhTien", "Thanh tien");

            dgvGioHang.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            grpGioHang.Controls.Add(dgvGioHang);

            GroupBox grpThanhToan = new GroupBox();
            grpThanhToan.Text = "THONG TIN THANH TOAN";
            grpThanhToan.Font = new Font("Arial", 10, FontStyle.Bold);
            grpThanhToan.Location = new Point(20, 530);
            grpThanhToan.Size = new Size(1240, 145);
            this.Controls.Add(grpThanhToan);

            Label lblKH = new Label();
            lblKH.Text = "Khach hang:";
            lblKH.Location = new Point(20, 40);
            lblKH.AutoSize = true;
            grpThanhToan.Controls.Add(lblKH);

            cboKhachHang = new ComboBox();
            cboKhachHang.Location = new Point(120, 35);
            cboKhachHang.Size = new Size(250, 30);
            cboKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;
            grpThanhToan.Controls.Add(cboKhachHang);

            Label lblTong = new Label();
            lblTong.Text = "Tong tien:";
            lblTong.Location = new Point(420, 40);
            lblTong.AutoSize = true;
            grpThanhToan.Controls.Add(lblTong);

            lblTongTien = new Label();
            lblTongTien.Text = "0 VND";
            lblTongTien.Location = new Point(510, 40);
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTongTien.ForeColor = Color.Red;
            grpThanhToan.Controls.Add(lblTongTien);

            Label lblDiem = new Label();
            lblDiem.Text = "Diem du kien:";
            lblDiem.Location = new Point(420, 85);
            lblDiem.AutoSize = true;
            grpThanhToan.Controls.Add(lblDiem);

            lblDiemTichLuy = new Label();
            lblDiemTichLuy.Text = "0";
            lblDiemTichLuy.Location = new Point(530, 85);
            lblDiemTichLuy.AutoSize = true;
            lblDiemTichLuy.Font = new Font("Arial", 11, FontStyle.Bold);
            grpThanhToan.Controls.Add(lblDiemTichLuy);

            btnThanhToan = new Button();
            btnThanhToan.Text = "THANH TOAN";
            btnThanhToan.Location = new Point(850, 40);
            btnThanhToan.Size = new Size(300, 70);
            btnThanhToan.Font = new Font("Arial", 14, FontStyle.Bold);
            btnThanhToan.BackColor = Color.Green;
            btnThanhToan.ForeColor = Color.White;
            grpThanhToan.Controls.Add(btnThanhToan);

            GroupBox grpThongKe = new GroupBox();
            grpThongKe.Text = "BAO CAO - THONG KE";
            grpThongKe.Font = new Font("Arial", 10, FontStyle.Bold);
            grpThongKe.Location = new Point(20, 690);
            grpThongKe.Size = new Size(1240, 200);
            this.Controls.Add(grpThongKe);

            btnDoanhThuNgay = new Button();
            btnDoanhThuNgay.Text = "DOANH THU NGAY";
            btnDoanhThuNgay.Location = new Point(20, 30);
            btnDoanhThuNgay.Size = new Size(160, 35);
            grpThongKe.Controls.Add(btnDoanhThuNgay);

            lblDoanhThuNgay = new Label();
            lblDoanhThuNgay.Text = "0 VND";
            lblDoanhThuNgay.Location = new Point(190, 38);
            lblDoanhThuNgay.AutoSize = true;
            grpThongKe.Controls.Add(lblDoanhThuNgay);

            btnDoanhThuThang = new Button();
            btnDoanhThuThang.Text = "DOANH THU THANG";
            btnDoanhThuThang.Location = new Point(420, 30);
            btnDoanhThuThang.Size = new Size(170, 35);
            grpThongKe.Controls.Add(btnDoanhThuThang);

            lblDoanhThuThang = new Label();
            lblDoanhThuThang.Text = "0 VND";
            lblDoanhThuThang.Location = new Point(600, 38);
            lblDoanhThuThang.AutoSize = true;
            grpThongKe.Controls.Add(lblDoanhThuThang);

            btnTop5 = new Button();
            btnTop5.Text = "TOP 5 SAN PHAM BAN CHAY";
            btnTop5.Location = new Point(850, 30);
            btnTop5.Size = new Size(300, 35);
            grpThongKe.Controls.Add(btnTop5);

            dgvTop5 = new DataGridView();
            dgvTop5.Location = new Point(20, 75);
            dgvTop5.Size = new Size(1190, 110);
            dgvTop5.ReadOnly = true;
            dgvTop5.AllowUserToAddRows = false;
            dgvTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTop5.RowHeadersVisible = false;
            dgvTop5.BackgroundColor = Color.White;
            grpThongKe.Controls.Add(dgvTop5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                }

                LoadKhachHang();
                CapNhatTongTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khoi tao: " + ex.Message);
            }
        }

        private void LoadKhachHang()
        {
            cboKhachHang.Items.Clear();
            cboKhachHang.Items.Add(new KhachHangItem(null, "Khach le"));

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = "SELECT MaKH, TenKH FROM KhachHang";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int maKH = Convert.ToInt32(reader["MaKH"]);
                        string tenKH = reader["TenKH"].ToString();

                        cboKhachHang.Items.Add(
                            new KhachHangItem(maKH, tenKH)
                        );
                    }
                }
            }

            cboKhachHang.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSanPhamVaoGio();
        }

        private void txtMaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThemSanPhamVaoGio();
                e.SuppressKeyPress = true;
            }
        }

        private void ThemSanPhamVaoGio()
        {
            if (!int.TryParse(txtMaSP.Text.Trim(), out int maSP))
            {
                MessageBox.Show("Vui long nhap ma san pham hop le!");
                txtMaSP.Focus();
                return;
            }

            int soLuong = Convert.ToInt32(numSoLuong.Value);

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                        SELECT MaSP, TenSP, DonGia, SoLuongTon
                        FROM SanPham
                        WHERE MaSP = @MaSP";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = maSP;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("Khong tim thay san pham!");
                                return;
                            }

                            string tenSP = reader["TenSP"].ToString();
                            decimal donGia = Convert.ToDecimal(reader["DonGia"]);
                            int tonKho = Convert.ToInt32(reader["SoLuongTon"]);

                            if (tonKho < soLuong)
                            {
                                MessageBox.Show("So luong ton kho khong du!");
                                return;
                            }

                            int index = -1;

                            foreach (DataGridViewRow row in dgvGioHang.Rows)
                            {
                                if (Convert.ToInt32(row.Cells["MaSP"].Value) == maSP)
                                {
                                    index = row.Index;
                                    break;
                                }
                            }

                            int tongSoLuong = soLuong;

                            if (index >= 0)
                            {
                                tongSoLuong += Convert.ToInt32(
                                    dgvGioHang.Rows[index].Cells["SoLuong"].Value
                                );
                            }

                            if (tongSoLuong > tonKho)
                            {
                                MessageBox.Show("Tong so luong trong gio vuot qua ton kho!");
                                return;
                            }

                            decimal thanhTien = tongSoLuong * donGia;

                            if (index >= 0)
                            {
                                dgvGioHang.Rows[index].Cells["SoLuong"].Value = tongSoLuong;
                                dgvGioHang.Rows[index].Cells["ThanhTien"].Value = thanhTien;
                            }
                            else
                            {
                                dgvGioHang.Rows.Add(
                                    maSP,
                                    tenSP,
                                    tongSoLuong,
                                    donGia,
                                    thanhTien
                                );
                            }
                        }
                    }
                }

                CapNhatTongTien();
                txtMaSP.Clear();
                numSoLuong.Value = 1;
                txtMaSP.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi them san pham: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui long chon san pham can xoa!");
                return;
            }

            dgvGioHang.Rows.RemoveAt(
                dgvGioHang.SelectedRows[0].Index
            );

            CapNhatTongTien();
        }

        private decimal TinhTongTien()
        {
            decimal tongTien = 0;

            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                tongTien += Convert.ToDecimal(
                    row.Cells["ThanhTien"].Value
                );
            }

            return tongTien;
        }

        private void CapNhatTongTien()
        {
            decimal tongTien = TinhTongTien();

            lblTongTien.Text = tongTien.ToString("N0") + " VND";

            int diemDuKien = (int)Math.Floor(tongTien / 100000m);

            lblDiemTichLuy.Text = diemDuKien.ToString();
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Gio hang dang trong!");
                return;
            }

            decimal tongTien = TinhTongTien();

            KhachHangItem khachHang =
                cboKhachHang.SelectedItem as KhachHangItem;

            int? maKH = khachHang == null ? null : khachHang.MaKH;

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlHoaDon = @"
                            INSERT INTO HoaDon(MaKH, TongTien)
                            VALUES(@MaKH, @TongTien);

                            SELECT SCOPE_IDENTITY();";

                        int maHD;

                        using (SqlCommand cmdHD =
                            new SqlCommand(sqlHoaDon, conn, trans))
                        {
                            cmdHD.Parameters.Add("@MaKH", SqlDbType.Int).Value =
                                maKH.HasValue ? (object)maKH.Value : DBNull.Value;

                            SqlParameter pTongTien =
                                cmdHD.Parameters.Add("@TongTien", SqlDbType.Decimal);

                            pTongTien.Precision = 18;
                            pTongTien.Scale = 2;
                            pTongTien.Value = tongTien;

                            maHD = Convert.ToInt32(cmdHD.ExecuteScalar());
                        }

                        foreach (DataGridViewRow row in dgvGioHang.Rows)
                        {
                            int maSP = Convert.ToInt32(row.Cells["MaSP"].Value);
                            int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                            decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);
                            decimal thanhTien = soLuong * donGia;

                            string sqlChiTiet = @"
                                INSERT INTO ChiTietHoaDon
                                (MaHD, MaSP, SoLuong, DonGia, ThanhTien)
                                VALUES
                                (@MaHD, @MaSP, @SoLuong, @DonGia, @ThanhTien)";

                            using (SqlCommand cmdCT =
                                new SqlCommand(sqlChiTiet, conn, trans))
                            {
                                cmdCT.Parameters.Add("@MaHD", SqlDbType.Int).Value = maHD;
                                cmdCT.Parameters.Add("@MaSP", SqlDbType.Int).Value = maSP;
                                cmdCT.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soLuong;

                                SqlParameter pDonGia =
                                    cmdCT.Parameters.Add("@DonGia", SqlDbType.Decimal);
                                pDonGia.Precision = 18;
                                pDonGia.Scale = 2;
                                pDonGia.Value = donGia;

                                SqlParameter pThanhTien =
                                    cmdCT.Parameters.Add("@ThanhTien", SqlDbType.Decimal);
                                pThanhTien.Precision = 18;
                                pThanhTien.Scale = 2;
                                pThanhTien.Value = thanhTien;

                                cmdCT.ExecuteNonQuery();
                            }

                            string sqlTonKho = @"
                                UPDATE SanPham
                                SET SoLuongTon = SoLuongTon - @SoLuong
                                WHERE MaSP = @MaSP
                                AND SoLuongTon >= @SoLuong";

                            using (SqlCommand cmdTonKho =
                                new SqlCommand(sqlTonKho, conn, trans))
                            {
                                cmdTonKho.Parameters.Add("@MaSP", SqlDbType.Int).Value = maSP;
                                cmdTonKho.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soLuong;

                                int ketQua = cmdTonKho.ExecuteNonQuery();

                                if (ketQua != 1)
                                {
                                    throw new Exception(
                                        "San pham ma " + maSP +
                                        " khong du so luong ton kho!"
                                    );
                                }
                            }
                        }

                        if (maKH.HasValue)
                        {
                            string sqlDiem = @"
                                UPDATE KhachHang
                                SET DiemTichLuy = DiemTichLuy +
                                    CAST(FLOOR(@TongTien / 100000.0) AS INT)
                                WHERE MaKH = @MaKH";

                            using (SqlCommand cmdDiem =
                                new SqlCommand(sqlDiem, conn, trans))
                            {
                                SqlParameter pTongTien =
                                    cmdDiem.Parameters.Add("@TongTien", SqlDbType.Decimal);
                                pTongTien.Precision = 18;
                                pTongTien.Scale = 2;
                                pTongTien.Value = tongTien;

                                cmdDiem.Parameters.Add("@MaKH", SqlDbType.Int).Value =
                                    maKH.Value;

                                if (cmdDiem.ExecuteNonQuery() != 1)
                                {
                                    throw new Exception("Khong tim thay khach hang!");
                                }
                            }
                        }

                        trans.Commit();

                        MessageBox.Show(
                            "Thanh toan thanh cong!\nMa hoa don: " + maHD +
                            "\nTong tien: " + tongTien.ToString("N0") + " VND",
                            "Thanh cong"
                        );

                        dgvGioHang.Rows.Clear();
                        CapNhatTongTien();
                        LoadKhachHang();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            trans.Rollback();
                        }
                        catch
                        {
                        }

                        MessageBox.Show(
                            "Thanh toan that bai!\nDu lieu da duoc huy bo.\n" +
                            ex.Message,
                            "Loi thanh toan"
                        );
                    }
                }
            }
        }

        private void btnDoanhThuNgay_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                        SELECT ISNULL(SUM(TongTien), 0)
                        FROM HoaDon
                        WHERE NgayLap >= @Ngay
                        AND NgayLap < DATEADD(DAY, 1, @Ngay)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@Ngay", SqlDbType.Date).Value =
                            DateTime.Today;

                        decimal doanhThu =
                            Convert.ToDecimal(cmd.ExecuteScalar());

                        lblDoanhThuNgay.Text =
                            doanhThu.ToString("N0") + " VND";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi thong ke ngay: " + ex.Message);
            }
        }

        private void btnDoanhThuThang_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    DateTime ngayDau = new DateTime(
                        DateTime.Today.Year,
                        DateTime.Today.Month,
                        1
                    );

                    DateTime ngaySau = ngayDau.AddMonths(1);

                    string sql = @"
                        SELECT ISNULL(SUM(TongTien), 0)
                        FROM HoaDon
                        WHERE NgayLap >= @NgayDau
                        AND NgayLap < @NgaySau";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@NgayDau", SqlDbType.DateTime).Value = ngayDau;
                        cmd.Parameters.Add("@NgaySau", SqlDbType.DateTime).Value = ngaySau;

                        decimal doanhThu =
                            Convert.ToDecimal(cmd.ExecuteScalar());

                        lblDoanhThuThang.Text =
                            doanhThu.ToString("N0") + " VND";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi thong ke thang: " + ex.Message);
            }
        }

        private void btnTop5_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                        SELECT TOP 5
                            SP.MaSP,
                            SP.TenSP,
                            SUM(CT.SoLuong) AS TongSoLuong
                        FROM ChiTietHoaDon CT
                        INNER JOIN SanPham SP
                            ON CT.MaSP = SP.MaSP
                        GROUP BY SP.MaSP, SP.TenSP
                        ORDER BY SUM(CT.SoLuong) DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dgvTop5.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi lay Top 5: " + ex.Message);
            }
        }

        private class KhachHangItem
        {
            public int? MaKH { get; set; }
            public string TenKH { get; set; }

            public KhachHangItem(int? maKH, string tenKH)
            {
                MaKH = maKH;
                TenKH = tenKH;
            }

            public override string ToString()
            {
                return TenKH;
            }
        }
    }
}
