using System.Data;
using System.Drawing;
using System.Globalization;

namespace CuaHangNuocGiaiKhat.WinForms;

internal sealed class MainForm : Form
{
    private readonly StoreRepository _store = new();
    private readonly CultureInfo _vi = CultureInfo.GetCultureInfo("vi-VN");
    private readonly TabControl _tabs = new() { Dock = DockStyle.Fill };

    private readonly ComboBox _catalogGroup = Combo();
    private readonly TextBox _catalogSearch = new();
    private readonly TextBox _catalogCode = new();
    private readonly TextBox _catalogName = new();
    private readonly TextBox _catalogUnit = new();
    private readonly ComboBox _catalogType = Combo();
    private readonly ComboBox _catalogSupplier = Combo();
    private readonly ComboBox _catalogCustomerType = Combo();
    private readonly TextBox _catalogAddress = new();
    private readonly TextBox _catalogPhone = new();
    private readonly DataGridView _catalogGrid = Grid();
    private TableLayoutPanel _catalogFields = null!;

    private readonly ComboBox _purchaseSupplier = Combo();
    private readonly DateTimePicker _purchaseDate = Date();
    private readonly DateTimePicker _expectedDate = Date();
    private readonly TextBox _purchaseEmployee = DisplayText();
    private readonly TextBox _purchaseCode = DisplayText();
    private readonly DataGridView _purchaseGrid = Grid();

    private readonly ComboBox _receivingOrder = Combo();
    private readonly TextBox _receivedRounds = DisplayText();
    private readonly TextBox _receiptNumber = new();
    private readonly DateTimePicker _receiptDate = Date();
    private readonly NumericUpDown _receiptAmount = MoneyInput();
    private readonly TextBox _receivingEmployee = DisplayText();
    private readonly DataGridView _receivingGrid = Grid();

    private readonly ComboBox _salesCustomer = Combo();
    private readonly DateTimePicker _salesDate = Date();
    private readonly NumericUpDown _paidAmount = MoneyInput();
    private readonly DateTimePicker _appointmentDate = Date();
    private readonly ComboBox _appointment = Combo();
    private readonly DataGridView _salesGrid = Grid();

    private readonly ComboBox _debtInvoice = Combo();
    private readonly TextBox _debtCustomer = DisplayText();
    private readonly TextBox _debtAmount = DisplayText();
    private readonly TextBox _debtEmployee = DisplayText();
    private readonly DateTimePicker _debtDate = Date();
    private readonly DateTimePicker _dueDate = Date();
    private readonly TextBox _debtReason = new() { Multiline = true };
    private readonly DataGridView _debtGrid = Grid();

    private readonly ComboBox _searchKind = Combo();
    private readonly DateTimePicker _searchFrom = Date();
    private readonly DateTimePicker _searchTo = Date();
    private readonly TextBox _searchTerm = new();
    private readonly ComboBox _searchStatus = Combo();
    private readonly DataGridView _searchGrid = Grid();
    private readonly Label _searchTotal = new() { AutoSize = true, Text = "Tổng: —" };

    public MainForm()
    {
        Text = "LAB 8 - Cửa hàng nước giải khát";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(900, 680);
        Size = new Size(1120, 800);
        Font = new Font("Segoe UI", 10);

        BuildCatalog();
        BuildPurchaseOrder();
        BuildReceiving();
        BuildSales();
        BuildDebt();
        BuildSearch();
        Controls.Add(_tabs);
        Shown += (_, _) => LoadData();
    }

    private void BuildCatalog()
    {
        var (page, fields, buttons) = Page("F01 · Danh mục", _catalogGrid,
            "Chọn nhóm để xem danh mục. Các nút ghi dữ liệu được giữ theo mockup nhưng chưa sử dụng.");
        _catalogFields = fields;
        _catalogGroup.Items.AddRange(new object[] { "Nước giải khát", "Nhà cung ứng", "Loại nước", "Khách hàng", "Nhân viên" });
        _catalogCustomerType.Items.AddRange(new object[] { "QUEN", "VANG_LAI" });
        Field(fields, "Nhóm danh mục", _catalogGroup);
        Field(fields, "Tìm mã / tên", _catalogSearch);
        Field(fields, "Mã", _catalogCode);
        Field(fields, "Tên", _catalogName);
        Field(fields, "Đơn vị tính", _catalogUnit);
        Field(fields, "Loại", _catalogType);
        Field(fields, "Nhà cung ứng", _catalogSupplier);
        Field(fields, "Loại khách", _catalogCustomerType);
        Field(fields, "Địa chỉ", _catalogAddress);
        Field(fields, "Điện thoại", _catalogPhone);
        Button(buttons, "Thêm", null);
        Button(buttons, "Lưu", null);
        Button(buttons, "Xóa", null);
        Button(buttons, "Tìm", (_, _) => LoadCatalog());
        _catalogGroup.SelectionChangeCommitted += (_, _) => LoadCatalog();
        _catalogGrid.SelectionChanged += (_, _) => ShowSelectedCatalogRow();
    }

    private void BuildPurchaseOrder()
    {
        var (_, fields, buttons) = Page("F02 · Lập đơn đặt hàng", _purchaseGrid,
            "Lưới hiển thị đơn DDH001 mẫu. Chưa lưu hoặc xuất chứng từ mới.");
        Field(fields, "Nhà cung ứng", _purchaseSupplier);
        Field(fields, "Ngày đặt", _purchaseDate);
        Field(fields, "Ngày nhận dự kiến", _expectedDate);
        Field(fields, "Người lập", _purchaseEmployee);
        Field(fields, "Số đơn", _purchaseCode);
        Button(buttons, "Thêm dòng", null);
        Button(buttons, "Bỏ dòng", null);
        Button(buttons, "Lưu đơn", null);
        Button(buttons, "Xuất đơn", null);
    }

    private void BuildReceiving()
    {
        var (_, fields, buttons) = Page("F03 · Tiếp nhận hàng", _receivingGrid,
            "Đã nhận và còn nhận được tính từ từng dòng đặt. Chưa ghi phiếu giao hàng mới.");
        Field(fields, "Đơn đặt", _receivingOrder);
        Field(fields, "Đợt đã nhận", _receivedRounds);
        Field(fields, "Số phiếu NCU", _receiptNumber);
        Field(fields, "Ngày giao", _receiptDate);
        Field(fields, "Số tiền phải trả", _receiptAmount);
        Field(fields, "Người nhận", _receivingEmployee);
        Button(buttons, "Đối chiếu", (_, _) => LoadReceiving());
        Button(buttons, "Lưu phiếu", null);
        _receivingOrder.SelectionChangeCommitted += (_, _) => LoadReceiving();
    }

    private void BuildSales()
    {
        var (_, fields, buttons) = Page("F04 · Bán hàng và giao hẹn", _salesGrid,
            "Lưới hiển thị HD001 và tồn suy ra. Chưa lưu hóa đơn, đổi hẹn hoặc xác nhận giao.");
        Field(fields, "Khách hàng", _salesCustomer);
        Field(fields, "Ngày bán", _salesDate);
        Field(fields, "Tiền đã trả", _paidAmount);
        Field(fields, "Ngày hẹn", _appointmentDate);
        Field(fields, "Phiếu hẹn", _appointment);
        Button(buttons, "Lưu HĐ", null);
        Button(buttons, "Lập hẹn", null);
        Button(buttons, "Đổi ngày", null);
        Button(buttons, "Xác nhận giao", null);
    }

    private void BuildDebt()
    {
        var (_, fields, buttons) = Page("F05 · Lập phiếu ghi nợ", _debtGrid,
            "Tiền nợ là tổng hóa đơn trừ tiền đã trả ban đầu. Chưa lưu hoặc in phiếu mới.");
        Field(fields, "Hóa đơn", _debtInvoice);
        Field(fields, "Khách hàng", _debtCustomer);
        Field(fields, "Tiền nợ (chỉ đọc)", _debtAmount);
        Field(fields, "Người lập", _debtEmployee);
        Field(fields, "Ngày lập", _debtDate);
        Field(fields, "Ngày dự kiến trả", _dueDate);
        Field(fields, "Lý do", _debtReason, 68);
        Button(buttons, "Kiểm tra", (_, _) => LoadDebt());
        Button(buttons, "Lưu phiếu", null);
        Button(buttons, "In", null);
        _debtInvoice.SelectionChangeCommitted += (_, _) => LoadDebt();
    }

    private void BuildSearch()
    {
        var (_, fields, buttons) = Page("F06 · Tra cứu và thống kê", _searchGrid,
            "Tra cứu chỉ đọc. Tồn kho là lượng thực nhận trừ lượng đã giao thực tế.");
        _searchKind.Items.AddRange(new object[] { "Hóa đơn", "Phiếu hẹn", "Phiếu ghi nợ", "Nhập hàng", "Tồn kho" });
        _searchStatus.Items.AddRange(new object[] { "Tất cả", "CHO_GIAO", "DA_GIAO" });
        Field(fields, "Loại dữ liệu", _searchKind);
        Field(fields, "Từ ngày", _searchFrom);
        Field(fields, "Đến ngày", _searchTo);
        Field(fields, "Mã khách / NGK", _searchTerm);
        Field(fields, "Trạng thái", _searchStatus);
        Button(buttons, "Tra cứu", (_, _) => Search());
        Button(buttons, "Xem chi tiết", (_, _) => ShowSearchDetails());
        Button(buttons, "In", null);
        buttons.Controls.Add(_searchTotal);
        _searchKind.SelectionChangeCommitted += (_, _) => Search();
    }

    private void LoadData() => SafeLoad(() =>
    {
        Bind(_catalogType, _store.Types(), "MaLoai", "TenLoai");
        Bind(_catalogSupplier, _store.Suppliers(), "MaNCU", "TenNCU");
        Bind(_purchaseSupplier, _store.Suppliers(), "MaNCU", "TenNCU");
        Bind(_receivingOrder, _store.PurchaseOrders(), "MaDDH", "MaDDH");
        Bind(_salesCustomer, _store.Customers(), "MaKH", "HoTen");
        Bind(_appointment, _store.Appointments(), "MaPH", "MaPH");
        Bind(_debtInvoice, _store.Invoices(), "MaHD", "MaHD");
        _catalogGroup.SelectedIndex = 0;
        _catalogCustomerType.SelectedIndex = 0;
        _searchKind.SelectedIndex = 0;
        _searchStatus.SelectedIndex = 0;
        _searchFrom.Value = new DateTime(2026, 11, 1);
        _searchTo.Value = new DateTime(2026, 11, 30);
        _purchaseDate.Value = new DateTime(2026, 11, 1);
        _expectedDate.Value = new DateTime(2026, 11, 2);
        _receiptDate.Value = new DateTime(2026, 11, 2);
        _salesDate.Value = new DateTime(2026, 11, 1);
        _appointmentDate.Value = new DateTime(2026, 11, 2);
        _debtDate.Value = new DateTime(2026, 11, 1);
        _dueDate.Value = new DateTime(2026, 11, 5);
        _purchaseEmployee.Text = _receivingEmployee.Text = _debtEmployee.Text = "NV01";
        _purchaseCode.Text = "DDH001 (mẫu)";
        _receiptNumber.Text = "PGH002";
        _receiptAmount.Value = 200000;
        _paidAmount.Value = 400000;
        _debtReason.Text = "Khách đề nghị trả chậm";
        _purchaseGrid.DataSource = _store.PurchaseLines("DDH001");
        _salesGrid.DataSource = _store.InvoiceLines("HD001");
        LoadCatalog();
        LoadReceiving();
        LoadDebt();
        Search();
    });

    private void LoadCatalog() => SafeLoad(() =>
    {
        var group = _catalogGroup.Text;
        var visible = group switch
        {
            "Nhà cung ứng" => new[] { 0, 1, 2, 3, 8, 9 },
            "Loại nước" => new[] { 0, 1, 2, 3, 6 },
            "Khách hàng" => new[] { 0, 1, 2, 3, 7, 8, 9 },
            "Nhân viên" => new[] { 0, 1, 2, 3 },
            _ => new[] { 0, 1, 2, 3, 4, 5 }
        };
        for (var row = 0; row < _catalogFields.RowCount; row++)
            _catalogFields.RowStyles[row].Height = visible.Contains(row) ? 40 : 0;
        _catalogGrid.DataSource = _store.Catalog(group, _catalogSearch.Text.Trim());
        ShowSelectedCatalogRow();
    });

    private void ShowSelectedCatalogRow()
    {
        if (_catalogGrid.CurrentRow?.DataBoundItem is not DataRowView view) return;
        var row = view.Row;
        _catalogCode.Text = row["Ma"].ToString();
        _catalogName.Text = row["Ten"].ToString();
        _catalogUnit.Text = Get(row, "DonViTinh");
        _catalogAddress.Text = Get(row, "DiaChi");
        _catalogPhone.Text = Get(row, "DienThoai");
        if (row.Table.Columns.Contains("MaLoai")) _catalogType.SelectedValue = Get(row, "MaLoai");
        if (row.Table.Columns.Contains("MaNCU")) _catalogSupplier.SelectedValue = Get(row, "MaNCU");
        if (row.Table.Columns.Contains("LoaiKhach")) _catalogCustomerType.SelectedItem = Get(row, "LoaiKhach");
    }

    private void LoadReceiving() => SafeLoad(() =>
    {
        var order = _receivingOrder.SelectedValue?.ToString();
        if (string.IsNullOrEmpty(order)) return;
        _receivedRounds.Text = $"{_store.ReceiptRounds(order)} / 3";
        var lines = _store.ReceiptLines(order);
        lines.Columns.Add("NhanDotNay", typeof(int));
        foreach (DataRow row in lines.Rows) row["NhanDotNay"] = row["ConNhan"];
        _receivingGrid.DataSource = lines;
    });

    private void LoadDebt() => SafeLoad(() =>
    {
        var invoice = _debtInvoice.SelectedValue?.ToString();
        if (string.IsNullOrEmpty(invoice)) return;
        var data = _store.DebtForInvoice(invoice);
        _debtGrid.DataSource = data;
        if (data.Rows.Count == 0) return;
        var row = data.Rows[0];
        _debtCustomer.Text = $"{row["MaKH"]} - {row["HoTen"]} ({row["LoaiKhach"]})";
        _debtAmount.Text = Currency(row["ConNo"]);
    });

    private void Search() => SafeLoad(() =>
    {
        var kind = _searchKind.Text;
        var status = _searchStatus.Text == "Tất cả" ? "" : _searchStatus.Text;
        var data = _store.Search(kind, _searchFrom.Value, _searchTo.Value, _searchTerm.Text.Trim(), status);
        _searchGrid.DataSource = data;
        var sumColumn = kind switch
        {
            "Hóa đơn" => "TongTien",
            "Phiếu ghi nợ" => "SoTienNo",
            "Nhập hàng" => "SoTienPhaiTra",
            "Phiếu hẹn" => "SoLuong",
            _ => "SoLuongTon"
        };
        var sum = data.Rows.Cast<DataRow>().Sum(row => Convert.ToDecimal(row[sumColumn]));
        _searchTotal.Text = kind is "Phiếu hẹn" or "Tồn kho"
            ? $"Tổng số lượng: {sum:N0}" : $"Tổng tiền: {Currency(sum)}";
    });

    private void ShowSearchDetails()
    {
        if (_searchGrid.CurrentRow?.DataBoundItem is not DataRowView view) return;
        var lines = view.Row.Table.Columns.Cast<DataColumn>()
            .Select(column => $"{column.ColumnName}: {view.Row[column]}");
        MessageBox.Show(this, string.Join("\n", lines), "Chi tiết dữ liệu", MessageBoxButtons.OK);
    }

    private void SafeLoad(Action action)
    {
        try { action(); }
        catch (Exception error)
        {
            MessageBox.Show(this,
                "Không đọc được LAB8_NuocGiaiKhat trên (localdb)\\MSSQLLocalDB.\n" +
                "Kiểm tra LocalDB và chạy script SQL theo README.\n\n" + error.Message,
                "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string Currency(object value) => Convert.ToDecimal(value).ToString("N0", _vi) + " đ";
    private static string Get(DataRow row, string column) =>
        row.Table.Columns.Contains(column) ? row[column].ToString() ?? "" : "";

    private static void Bind(ComboBox box, DataTable data, string value, string display)
    {
        box.DataSource = data;
        box.ValueMember = value;
        box.DisplayMember = display;
    }

    private (TabPage Page, TableLayoutPanel Fields, FlowLayoutPanel Buttons) Page(
        string title, DataGridView grid, string note)
    {
        var page = new TabPage(title) { Padding = new Padding(12) };
        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 5 };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
        layout.Controls.Add(new Label
        {
            Text = title, Dock = DockStyle.Fill, BackColor = Color.FromArgb(236, 239, 243),
            Font = new Font(Font.FontFamily, 16, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(12, 0, 0, 0)
        }, 0, 0);
        var fields = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 2, Padding = new Padding(8) };
        fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190));
        fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.Controls.Add(fields, 0, 1);
        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(6, 4, 0, 0) };
        layout.Controls.Add(buttons, 0, 2);
        layout.Controls.Add(grid, 0, 3);
        layout.Controls.Add(new Label { Text = note, Dock = DockStyle.Fill,
            ForeColor = Color.DimGray, TextAlign = ContentAlignment.MiddleLeft }, 0, 4);
        page.Controls.Add(layout);
        _tabs.TabPages.Add(page);
        return (page, fields, buttons);
    }

    private static void Field(TableLayoutPanel fields, string caption, Control input, float height = 40)
    {
        var row = fields.RowCount++;
        fields.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
        fields.Controls.Add(new Label { Text = caption, Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft }, 0, row);
        input.Dock = DockStyle.Fill;
        input.Margin = new Padding(3, 4, 10, 4);
        fields.Controls.Add(input, 1, row);
    }

    private static void Button(FlowLayoutPanel area, string caption, EventHandler? handler)
    {
        var button = new Button { Text = caption, AutoSize = true,
            MinimumSize = new Size(108, 36), Enabled = handler != null };
        if (handler != null) button.Click += handler;
        area.Controls.Add(button);
    }

    private static ComboBox Combo() => new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private static DateTimePicker Date() => new() { Format = DateTimePickerFormat.Short };
    private static TextBox DisplayText() => new() { ReadOnly = true, BackColor = Color.White };
    private static NumericUpDown MoneyInput() => new() { Maximum = 1000000000, ThousandsSeparator = true };
    private static DataGridView Grid() => new()
    {
        Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
        AllowUserToDeleteRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        MultiSelect = false, RowHeadersVisible = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        BackgroundColor = Color.White
    };
}
