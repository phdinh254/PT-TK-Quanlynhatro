using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyNhaTro.Helpers
{
    public static class UIHelper
    {
        // Định nghĩa màu sắc chuẩn
        public static class Colors
        {
            public static readonly Color Primary = Color.FromArgb(52, 152, 219);      // Xanh dương
            public static readonly Color Secondary = Color.FromArgb(149, 165, 166);   // Xám
            public static readonly Color Success = Color.FromArgb(46, 204, 113);      // Xanh lá
            public static readonly Color Danger = Color.FromArgb(231, 76, 60);        // Đỏ
            public static readonly Color Warning = Color.FromArgb(241, 196, 15);      // Vàng
            public static readonly Color Info = Color.FromArgb(52, 152, 219);         // Xanh dương nhạt
            public static readonly Color Light = Color.FromArgb(236, 240, 241);       // Xám nhạt
            public static readonly Color Dark = Color.FromArgb(52, 73, 94);           // Xám đậm
            public static readonly Color White = Color.White;
            public static readonly Color Black = Color.FromArgb(44, 62, 80);
            public static readonly Color TextPrimary = Color.FromArgb(44, 62, 80);
            public static readonly Color TextSecondary = Color.FromArgb(127, 140, 141);
            
            // Màu nền mới - màu xám nhạt thay vì trắng
            public static readonly Color Background = Color.FromArgb(248, 249, 250);  // Xám rất nhạt
            public static readonly Color CardBackground = Color.FromArgb(240, 242, 245); // Trắng cho card
            public static readonly Color FormBackground = Color.FromArgb(240, 242, 245); // Xám nhạt cho form
        }

        // Định nghĩa font chuẩn - Times New Roman cho toàn bộ ứng dụng
        public static class Fonts
        {
            // Font chính cho toàn bộ ứng dụng
            public static readonly Font Default = new Font("Times New Roman", 10F, FontStyle.Regular);
            public static readonly Font DefaultBold = new Font("Times New Roman", 10F, FontStyle.Bold);
            
            // Font cho tiêu đề
            public static readonly Font Title = new Font("Times New Roman", 18F, FontStyle.Bold);
            public static readonly Font TitleLarge = new Font("Times New Roman", 22F, FontStyle.Bold);
            public static readonly Font TitleMedium = new Font("Times New Roman", 16F, FontStyle.Bold);
            public static readonly Font TitleSmall = new Font("Times New Roman", 14F, FontStyle.Bold);
            
            // Font cho header và label
            public static readonly Font Header = new Font("Times New Roman", 12F, FontStyle.Bold);
            public static readonly Font Label = new Font("Times New Roman", 10F, FontStyle.Regular);
            public static readonly Font LabelBold = new Font("Times New Roman", 10F, FontStyle.Bold);
            public static readonly Font LabelSmall = new Font("Times New Roman", 9F, FontStyle.Regular);
            
            // Font cho button
            public static readonly Font Button = new Font("Times New Roman", 10F, FontStyle.Bold);
            
            // Font cho input controls
            public static readonly Font Input = new Font("Times New Roman", 10F, FontStyle.Regular);
            public static readonly Font InputLarge = new Font("Times New Roman", 12F, FontStyle.Regular);
            
            // Font cho DataGridView
            public static readonly Font Grid = new Font("Times New Roman", 10F, FontStyle.Regular);
            public static readonly Font GridHeader = new Font("Times New Roman", 10F, FontStyle.Bold);
            
            // Font cho giá trị hiển thị
            public static readonly Font ValueLarge = new Font("Times New Roman", 26F, FontStyle.Bold);
            public static readonly Font ValueMedium = new Font("Times New Roman", 14F, FontStyle.Bold);
            public static readonly Font ValueSmall = new Font("Times New Roman", 12F, FontStyle.Bold);
        }

        // Giữ lại các font cũ để tương thích ngược
        public static readonly Font DefaultFont = Fonts.Default;
        public static readonly Font TitleFont = Fonts.Title;
        public static readonly Font HeaderFont = Fonts.Header;
        public static readonly Font ButtonFont = Fonts.Button;

        public static void ApplyModernStyle(Form form)
        {
            form.BackColor = Colors.FormBackground; // Sử dụng màu nền form mới
            form.Font = Fonts.Default;
            
            // Chuẩn hóa DPI scaling cho tất cả form
            form.AutoScaleDimensions = new SizeF(96F, 96F);
            form.AutoScaleMode = AutoScaleMode.Dpi;
        }

        public static void StyleButton(Button button, Color backgroundColor, Color textColor)
        {
            button.BackColor = backgroundColor;
            button.ForeColor = textColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = Fonts.Button;
            button.Cursor = Cursors.Hand;
            
            // Add rounded corners
            button.Region = CreateRoundedRegion(button.Size, 8);
            
            // Add hover effects
            button.MouseEnter += (s, e) => {
                button.BackColor = ControlPaint.Light(backgroundColor, 0.1f);
            };
            button.MouseLeave += (s, e) => {
                button.BackColor = backgroundColor;
            };
        }

        public static void StylePrimaryButton(Button button)
        {
            StyleButton(button, Colors.Primary, Colors.White);
        }

        public static void StyleSecondaryButton(Button button)
        {
            StyleButton(button, Colors.Secondary, Colors.White);
        }

        public static void StyleDangerButton(Button button)
        {
            StyleButton(button, Colors.Danger, Colors.White);
        }

        public static void StyleWarningButton(Button button)
        {
            StyleButton(button, Colors.Warning, Colors.White);
        }

        public static void StyleTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = Fonts.Input;
            textBox.BackColor = Colors.White;
            textBox.ForeColor = Colors.TextPrimary;
        }

        public static void StyleComboBox(ComboBox comboBox)
        {
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = Fonts.Input;
            comboBox.BackColor = Colors.White;
            comboBox.ForeColor = Colors.TextPrimary;
        }

        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Colors.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Colors.Primary;
            dgv.DefaultCellStyle.SelectionForeColor = Colors.White;
            dgv.DefaultCellStyle.BackColor = Colors.White;
            dgv.DefaultCellStyle.ForeColor = Colors.TextPrimary;
            dgv.DefaultCellStyle.Font = Fonts.Grid;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Colors.Light;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Colors.TextPrimary;
            dgv.ColumnHeadersDefaultCellStyle.Font = Fonts.GridHeader;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Colors.Light;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            // Auto resize columns when DataGridView size changes
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        public static void StyleGroupBox(GroupBox groupBox)
        {
            groupBox.Font = Fonts.Header;
            groupBox.ForeColor = Colors.TextPrimary;
        }

        public static void StyleLabel(Label label, bool isTitle = false)
        {
            if (isTitle)
            {
                label.Font = Fonts.Title;
                label.ForeColor = Colors.Primary;
            }
            else
            {
                label.Font = Fonts.Label;
                label.ForeColor = Colors.TextPrimary;
            }
        }

        public static Panel CreateCard(int width, int height)
        {
            Panel card = new Panel
            {
                Size = new Size(width, height),
                BackColor = Colors.CardBackground,
                Padding = new Padding(20)
            };
            
            // Add shadow effect
            card.Paint += (s, e) => {
                Rectangle rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                using (Pen pen = new Pen(Colors.Light, 1))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            };
            
            return card;
        }

        private static Region CreateRoundedRegion(Size size, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(size.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(size.Width - radius, size.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, size.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            return new Region(path);
        }

        public static void ShowSuccessMessage(string message, string title = "Thành công")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowErrorMessage(string message, string title = "Lỗi")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarningMessage(string message, string title = "Cảnh báo")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool ShowConfirmMessage(string message, string title = "Xác nhận")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Chuẩn hóa toàn bộ controls trong form
        /// </summary>
        public static void StandardizeForm(Form form)
        {
            ApplyModernStyle(form);
            
            // Enable form resize
            if (form.MinimumSize.Width == 0)
            {
                form.MinimumSize = new Size(800, 600);
            }
            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.MaximizeBox = true;
            
            StandardizeControls(form.Controls);
            
            // Fix responsive cho tất cả GroupBox và DataGridView
            FixResponsiveLayout(form);
        }

        /// <summary>
        /// Sửa layout responsive cho form - chỉ áp dụng cho containers chính
        /// </summary>
        private static void FixResponsiveLayout(Form form)
        {
            foreach (Control ctrl in form.Controls)
            {
                // GroupBox chứa DataGridView - anchor all sides
                if (ctrl is GroupBox gb)
                {
                    bool hasDataGridView = ContainsDataGridView(gb);
                    
                    if (hasDataGridView)
                    {
                        // GroupBox danh sách - anchor all
                        if (gb.Anchor == (AnchorStyles.Top | AnchorStyles.Left))
                        {
                            gb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                        }
                        
                        // Tìm và fix DataGridView bên trong
                        foreach (Control child in gb.Controls)
                        {
                            if (child is DataGridView dgv)
                            {
                                if (dgv.Anchor == (AnchorStyles.Top | AnchorStyles.Left))
                                {
                                    dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                }
                            }
                        }
                    }
                    else
                    {
                        // GroupBox thông tin - chỉ anchor ngang
                        if (gb.Anchor == (AnchorStyles.Top | AnchorStyles.Left))
                        {
                            gb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        }
                        
                        // Fix button panel bên trong
                        foreach (Control child in gb.Controls)
                        {
                            if (child is FlowLayoutPanel flp)
                            {
                                if (flp.Anchor == (AnchorStyles.Top | AnchorStyles.Left))
                                {
                                    flp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                                }
                            }
                            else if (child is Panel pnl && pnl.Name.Contains("Button"))
                            {
                                if (pnl.Anchor == (AnchorStyles.Top | AnchorStyles.Left))
                                {
                                    pnl.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Kiểm tra GroupBox có chứa DataGridView không
        /// </summary>
        private static bool ContainsDataGridView(GroupBox gb)
        {
            foreach (Control ctrl in gb.Controls)
            {
                if (ctrl is DataGridView)
                    return true;
            }
            return false;
        }

        // Kích thước chuẩn
        public static class Sizes
        {
            public const int LabelWidth = 100;
            public const int TextBoxWidth = 180;
            public const int TextBoxHeight = 28;
            public const int ComboBoxWidth = 180;
            public const int ComboBoxHeight = 28;
            public const int ButtonWidth = 100;
            public const int ButtonHeight = 35;
            public const int RowSpacing = 35;
            public const int ColumnSpacing = 20;
            public const int Margin = 15;
        }

        private static void StandardizeControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                // Label
                if (ctrl is Label lbl && !lbl.Name.Contains("Title") && !lbl.Name.Contains("Value") && !lbl.Name.Contains("TongTien"))
                {
                    lbl.Font = Fonts.Label;
                    lbl.ForeColor = Colors.TextPrimary;
                    lbl.AutoSize = true;
                }

                // TextBox
                if (ctrl is TextBox txt)
                {
                    txt.Font = Fonts.Input;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Height = Sizes.TextBoxHeight;
                    if (txt.Width < 100) txt.Width = Sizes.TextBoxWidth;
                }

                // ComboBox
                if (ctrl is ComboBox cmb)
                {
                    cmb.Font = Fonts.Input;
                    cmb.FlatStyle = FlatStyle.Flat;
                    cmb.Height = Sizes.ComboBoxHeight;
                    if (cmb.Width < 100) cmb.Width = Sizes.ComboBoxWidth;
                }

                // DateTimePicker
                if (ctrl is DateTimePicker dtp)
                {
                    dtp.Font = Fonts.Input;
                    dtp.Height = Sizes.TextBoxHeight;
                }

                // DataGridView
                if (ctrl is DataGridView dgv)
                {
                    StyleDataGridView(dgv);
                }

                // GroupBox
                if (ctrl is GroupBox gb)
                {
                    gb.Font = Fonts.Header;
                    gb.ForeColor = Colors.TextPrimary;
                }

                // Panel
                if (ctrl is Panel panel)
                {
                    panel.BackColor = Colors.CardBackground;
                }

                // Đệ quy cho các control con
                if (ctrl.HasChildren)
                {
                    StandardizeControls(ctrl.Controls);
                }
            }
        }

        /// <summary>
        /// Áp dụng Anchor/Dock tự động cho các control
        /// </summary>
        private static void ApplyResponsiveAnchoring(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                // Title labels - dock top
                if (ctrl is Label lbl && (lbl.Name.Contains("Title") || lbl.Name.Contains("lblTitle")))
                {
                    if (lbl.Dock != DockStyle.Top)
                    {
                        lbl.Dock = DockStyle.Top;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                    }
                }

                // Đệ quy cho các control con
                if (ctrl.HasChildren)
                {
                    ApplyResponsiveAnchoring(ctrl.Controls);
                }
            }
        }
    }
}