using System.Data;
using System.Drawing;
using System.Globalization;

namespace EShopping.WinForms;

internal sealed class MainForm : Form
{
    private readonly ShopRepository _database = new();
    private readonly TabControl _tabs = new() { Dock = DockStyle.Fill };
    private readonly CultureInfo _vietnamese = CultureInfo.GetCultureInfo("vi-VN");

    private readonly ComboBox _category = Combo();
    private readonly TextBox _keyword = new();
    private readonly TextBox _productName = ReadOnlyText();
    private readonly TextBox _productPrice = ReadOnlyText();
    private readonly DataGridView _products = Grid();

    private readonly TextBox _cartProduct = ReadOnlyText();
    private readonly TextBox _cartQuantity = ReadOnlyText();
    private readonly TextBox _cartUnitPrice = ReadOnlyText();
    private readonly TextBox _cartLineTotal = ReadOnlyText();
    private readonly DataGridView _cart = Grid();

    private readonly TextBox _fullName = new();
    private readonly TextBox _email = new();
    private readonly TextBox _username = new();
    private readonly TextBox _password = new() { UseSystemPasswordChar = true };

    private readonly TextBox _recipient = new();
    private readonly TextBox _address = new();
    private readonly ComboBox _city = Combo();
    private readonly ComboBox _deliveryType = Combo();
    private readonly TextBox _deliveryFee = ReadOnlyText();

    private readonly ComboBox _cardType = Combo();
    private readonly TextBox _cardInfo = new() { PlaceholderText = "Số thẻ đã che hoặc mô tả thẻ" };
    private readonly TextBox _paymentTotal = ReadOnlyText();

    private readonly TextBox _orderCode = new();
    private readonly TextBox _orderDate = ReadOnlyText();
    private readonly TextBox _orderStatus = ReadOnlyText();
    private readonly TextBox _orderTotal = ReadOnlyText();
    private readonly DataGridView _orders = Grid();

    private long _cartSubtotal;
    private long _currentDeliveryFee;

    public MainForm()
    {
        Text = "LAB4 - e-SHOPPING";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(850, 650);
        Size = new Size(1060, 760);
        Font = new Font("Segoe UI", 10);

        BuildProducts();
        BuildCart();
        BuildAccount();
        BuildDelivery();
        BuildPayment();
        BuildOrders();
        Controls.Add(_tabs);
        Shown += (_, _) => LoadSampleData();
    }

    private void BuildProducts()
    {
        var (tab, layout, fields, actions) = Page("Tra cứu sản phẩm", _products);
        Field(fields, "Nhóm", _category);
        Field(fields, "Từ khóa", _keyword);
        Field(fields, "Sản phẩm", _productName);
        Field(fields, "Giá", _productPrice);
        Action(actions, "Tìm", (_, _) => SafeLoad(() => _products.DataSource = _database.Products(
            _category.SelectedValue?.ToString() ?? "", _keyword.Text.Trim())));
        Action(actions, "Chi tiết", (_, _) => ShowProductDetails());
        Action(actions, "Thêm vào giỏ", null);
        _products.SelectionChanged += (_, _) => ShowSelectedProduct();
        _products.DataBindingComplete += (_, _) =>
        {
            if (_products.Columns["MoTa"] is { } description) description.Visible = false;
            if (_products.Columns["GiaBan"] is { } price) price.DefaultCellStyle.Format = "N0";
        };
        Finish(tab, layout, "Danh sách sản phẩm đọc từ SQL Server LocalDB. Chọn một dòng để xem thông tin.");
    }

    private void BuildCart()
    {
        var (tab, layout, fields, actions) = Page("Giỏ hàng", _cart);
        Field(fields, "Mã sản phẩm", _cartProduct);
        Field(fields, "Số lượng", _cartQuantity);
        Field(fields, "Đơn giá", _cartUnitPrice);
        Field(fields, "Thành tiền", _cartLineTotal);
        Action(actions, "Cập nhật", null);
        Action(actions, "Bỏ hàng", null);
        Action(actions, "Tính tiền", (_, _) => MessageBox.Show(this,
            $"Tiền hàng trong giỏ mẫu: {Money(_cartSubtotal)}", "Giỏ hàng"));
        _cart.SelectionChanged += (_, _) => ShowSelectedCartLine();
        _cart.DataBindingComplete += (_, _) =>
        {
            foreach (var name in new[] { "DonGia", "ThanhTien" })
                if (_cart.Columns[name] is { } column) column.DefaultCellStyle.Format = "N0";
        };
        Finish(tab, layout, "Giỏ hàng mẫu trong database. Các thao tác thay đổi dữ liệu chưa nằm trong phạm vi bài giao diện.");
    }

    private void BuildAccount()
    {
        var (tab, layout, fields, actions) = Page("Đăng ký và đăng nhập");
        Field(fields, "Họ tên", _fullName);
        Field(fields, "Email", _email);
        Field(fields, "Tên đăng nhập", _username);
        Field(fields, "Mật khẩu", _password);
        Action(actions, "Đăng ký", null);
        Action(actions, "Đăng nhập", null);
        FillWithNote(layout, "Màn hình đăng ký và đăng nhập theo UI03 trong báo cáo.\n" +
            "Phần xử lý tài khoản chưa được triển khai.");
        Finish(tab, layout, "Các nút ghi dữ liệu được để ở trạng thái chưa sử dụng.");
    }

    private void BuildDelivery()
    {
        var (tab, layout, fields, actions) = Page("Đặt hàng");
        Field(fields, "Người nhận", _recipient);
        Field(fields, "Địa chỉ", _address);
        Field(fields, "Tỉnh", _city);
        Field(fields, "Loại phiếu", _deliveryType);
        Field(fields, "Phí giao", _deliveryFee);
        Action(actions, "Tính phí", (_, _) => CalculateDeliveryFee());
        Action(actions, "Tiếp tục", (_, _) =>
        {
            UpdatePaymentTotal();
            _tabs.SelectedIndex = 4;
        });
        FillWithNote(layout, "Tính phí sử dụng hàm FN_TinhPhiGiao của database với tổng tiền giỏ hàng mẫu.\n" +
            "Nút Tiếp tục chỉ chuyển sang màn hình thanh toán.");
        Finish(tab, layout, "Chưa ghi đơn đặt hàng vào database.");
    }

    private void BuildPayment()
    {
        var (tab, layout, fields, actions) = Page("Thanh toán");
        Field(fields, "Loại thẻ", _cardType);
        Field(fields, "Thông tin thẻ", _cardInfo);
        Field(fields, "Tổng thanh toán", _paymentTotal);
        Action(actions, "Xác nhận", null);
        Action(actions, "Quay lại", (_, _) => _tabs.SelectedIndex = 3);
        FillWithNote(layout, "Màn hình minh họa UI05. Không nhập số thẻ đầy đủ hoặc mã bảo mật thật.\n" +
            "Chưa có cổng thanh toán trong phạm vi bài giao diện.");
        Finish(tab, layout, "Không thực hiện giao dịch thanh toán.");
    }

    private void BuildOrders()
    {
        var (tab, layout, fields, actions) = Page("Tra cứu đơn hàng", _orders);
        Field(fields, "Mã đơn", _orderCode);
        Field(fields, "Ngày đặt", _orderDate);
        Field(fields, "Trạng thái", _orderStatus);
        Field(fields, "Tổng trị giá", _orderTotal);
        Action(actions, "Tra cứu", (_, _) => SafeLoad(() => _orders.DataSource = _database.Orders(_orderCode.Text.Trim())));
        Action(actions, "Xem chi tiết", (_, _) => ShowOrderDetails());
        _orders.SelectionChanged += (_, _) => ShowSelectedOrder();
        _orders.DataBindingComplete += (_, _) =>
        {
            if (_orders.Columns["TongTriGia"] is { } price) price.DefaultCellStyle.Format = "N0";
            if (_orders.Columns["DiaChiNhan"] is { } address) address.Visible = false;
        };
        Finish(tab, layout, "Để trống mã đơn và bấm Tra cứu để xem tất cả đơn hàng mẫu.");
    }

    private void LoadSampleData() => SafeLoad(() =>
    {
        _category.DataSource = WithAllOption(_database.Categories(), "MaNhom", "TenNhom", "Tất cả nhóm");
        _category.DisplayMember = "TenNhom";
        _category.ValueMember = "MaNhom";
        _city.DataSource = _database.Cities();
        _city.DisplayMember = "TenTinh";
        _city.ValueMember = "MaTinh";
        _deliveryType.DataSource = _database.DeliveryTypes();
        _deliveryType.DisplayMember = "TenLoai";
        _deliveryType.ValueMember = "MaLoaiPhieu";
        _cardType.DataSource = _database.CardTypes();
        _cardType.DisplayMember = "TenLoaiThe";
        _cardType.ValueMember = "MaLoaiThe";
        _products.DataSource = _database.Products("", "");
        var cart = _database.Cart();
        _cart.DataSource = cart;
        _cartSubtotal = cart.Rows.Cast<DataRow>().Sum(row => Convert.ToInt64(row["ThanhTien"]));
        _orders.DataSource = _database.Orders("");
        UpdatePaymentTotal();
    });

    private static DataTable WithAllOption(DataTable table, string key, string name, string label)
    {
        var row = table.NewRow();
        row[key] = "";
        row[name] = label;
        table.Rows.InsertAt(row, 0);
        return table;
    }

    private void CalculateDeliveryFee() => SafeLoad(() =>
    {
        var city = _city.SelectedValue?.ToString();
        var type = _deliveryType.SelectedValue?.ToString();
        if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(type)) return;
        var fee = _database.DeliveryFee(city, type, _cartSubtotal);
        if (fee < 0)
        {
            _deliveryFee.Text = "Chưa có biểu phí";
            return;
        }
        _currentDeliveryFee = fee;
        _deliveryFee.Text = Money(fee);
        UpdatePaymentTotal();
    });

    private void UpdatePaymentTotal() => _paymentTotal.Text = Money(_cartSubtotal + _currentDeliveryFee);

    private void ShowSelectedProduct()
    {
        if (_products.CurrentRow?.DataBoundItem is not DataRowView row) return;
        _productName.Text = row["TenSP"].ToString();
        _productPrice.Text = Money(row["GiaBan"]);
    }

    private void ShowProductDetails()
    {
        if (_products.CurrentRow?.DataBoundItem is not DataRowView row) return;
        MessageBox.Show(this,
            $"{row["TenSP"]}\n\nMã: {row["MaSP"]}\nNhóm: {row["TenNhom"]}\n" +
            $"Nhà sản xuất: {row["NhaSanXuat"]}\nGiá: {Money(row["GiaBan"])}\n" +
            $"Tình trạng: {row["TinhTrang"]}\n\n{row["MoTa"]}", "Chi tiết sản phẩm");
    }

    private void ShowSelectedCartLine()
    {
        if (_cart.CurrentRow?.DataBoundItem is not DataRowView row) return;
        _cartProduct.Text = row["MaSP"].ToString();
        _cartQuantity.Text = row["SoLuong"].ToString();
        _cartUnitPrice.Text = Money(row["DonGia"]);
        _cartLineTotal.Text = Money(row["ThanhTien"]);
    }

    private void ShowSelectedOrder()
    {
        if (_orders.CurrentRow?.DataBoundItem is not DataRowView row) return;
        _orderCode.Text = row["SoDonHang"].ToString();
        _orderDate.Text = Convert.ToDateTime(row["ThoiDiemDat"]).ToString("dd/MM/yyyy HH:mm");
        _orderStatus.Text = row["TrangThai"].ToString();
        _orderTotal.Text = Money(row["TongTriGia"]);
    }

    private void ShowOrderDetails() => SafeLoad(() =>
    {
        var code = _orders.CurrentRow?.Cells["SoDonHang"].Value?.ToString();
        if (string.IsNullOrEmpty(code)) return;
        var lines = _database.OrderLines(code);
        var summary = string.Join("\n", lines.Rows.Cast<DataRow>().Select(row =>
            $"{row["TenSP"]} × {row["SoLuong"]}: {Money(row["ThanhTien"])}"));
        MessageBox.Show(this, $"Đơn {code}\n\n{summary}\n\nTổng trị giá: {_orderTotal.Text}",
            "Chi tiết đơn hàng");
    });

    private void SafeLoad(Action action)
    {
        try { action(); }
        catch (Exception error)
        {
            MessageBox.Show(this,
                "Không đọc được dữ liệu từ EShopping_LAB4 trên (localdb)\\MSSQLLocalDB.\n" +
                "Hãy kiểm tra LocalDB và nạp Eshopping.sql theo README.\n\n" + error.Message,
                "Lỗi kết nối database", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string Money(object value) => Convert.ToInt64(value).ToString("N0", _vietnamese) + " đ";

    private (TabPage Tab, TableLayoutPanel Layout, TableLayoutPanel Fields, FlowLayoutPanel Actions)
        Page(string title, DataGridView? grid = null)
    {
        var tab = new TabPage(title) { Padding = new Padding(12) };
        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 5 };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54));
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        var header = new Label
        {
            Text = title, Dock = DockStyle.Fill, BackColor = Color.FromArgb(236, 240, 245),
            ForeColor = Color.FromArgb(30, 50, 75), Font = new Font(Font.FontFamily, 17, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(12, 0, 0, 0)
        };
        var fields = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 2, Padding = new Padding(8) };
        fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180));
        fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        var actions = new FlowLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(6, 4, 0, 0) };
        layout.Controls.Add(header, 0, 0);
        layout.Controls.Add(fields, 0, 1);
        layout.Controls.Add(actions, 0, 2);
        if (grid != null) layout.Controls.Add(grid, 0, 3);
        tab.Controls.Add(layout);
        _tabs.TabPages.Add(tab);
        return (tab, layout, fields, actions);
    }

    private static void Field(TableLayoutPanel fields, string label, Control control)
    {
        var row = fields.RowCount++;
        fields.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
        fields.Controls.Add(new Label { Text = label, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, row);
        control.Dock = DockStyle.Fill;
        control.Margin = new Padding(3, 5, 10, 5);
        fields.Controls.Add(control, 1, row);
    }

    private static void Action(FlowLayoutPanel actions, string text, EventHandler? click)
    {
        var button = new Button { Text = text, AutoSize = true, MinimumSize = new Size(112, 36), Enabled = click != null };
        if (click != null) button.Click += click;
        actions.Controls.Add(button);
    }

    private static void FillWithNote(TableLayoutPanel layout, string message) => layout.Controls.Add(
        new Label { Text = message, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.DimGray, Font = new Font("Segoe UI", 11) }, 0, 3);

    private static void Finish(TabPage tab, TableLayoutPanel layout, string note) => layout.Controls.Add(
        new Label { Text = note, Dock = DockStyle.Fill, ForeColor = Color.DimGray,
            TextAlign = ContentAlignment.MiddleLeft }, 0, 4);

    private static ComboBox Combo() => new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private static TextBox ReadOnlyText() => new() { ReadOnly = true, BackColor = Color.White };
    private static DataGridView Grid() => new()
    {
        Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
        AllowUserToDeleteRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false,
        RowHeadersVisible = false, BackgroundColor = Color.White
    };
}
