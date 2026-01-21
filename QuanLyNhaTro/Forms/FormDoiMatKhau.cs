using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro.Data;
using QuanLyNhaTro.Helpers;
using System.Linq;

namespace QuanLyNhaTro.Forms
{
    public partial class FormDoiMatKhau : Form
    {
        private string tenDangNhap;

        public FormDoiMatKhau(string username)
        {
            InitializeComponent();
            this.tenDangNhap = username;
            InitializeUI();
        }

        private void InitializeUI()
        {
            UIHelper.StandardizeForm(this);
            UIHelper.StylePrimaryButton(btnDoiMatKhau);
            UIHelper.StyleSecondaryButton(btnHuy);

            // C?n gi?a panelMain
            CenterPanel();

            txtMatKhauCu.PasswordChar = '*';
            txtMatKhauMoi.PasswordChar = '*';
            txtXacNhanMatKhau.PasswordChar = '*';
        }

        private void CenterPanel()
        {
            // C?n gi?a panelMain theo chi?u ngang
            var panelMain = this.Controls.Find("panelMain", true);
            if (panelMain.Length > 0)
            {
                var panel = panelMain[0];
                panel.Left = (this.ClientSize.Width - panel.Width) / 2;
                
                // C?n gi?a c�c controls b�n trong panel
                CenterControlsInPanel(panel);
            }
        }
        
        private void CenterControlsInPanel(Control panel)
        {
            // T�m width l?n nh?t c?a c�c label v� textbox
            int maxLabelWidth = 0;
            int maxControlWidth = 0;
            int leftMargin = 30;
            
            // T�m t?t c? label v� textbox
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Label lbl && !lbl.Name.Contains("Title") && !lbl.Name.Contains("Note"))
                {
                    if (lbl.Width > maxLabelWidth)
                        maxLabelWidth = lbl.Width;
                }
                else if (ctrl is TextBox)
                {
                    if (ctrl.Width > maxControlWidth)
                        maxControlWidth = ctrl.Width;
                }
            }
            
            // T�nh v? tr� c?n gi?a
            int totalWidth = maxLabelWidth + maxControlWidth + 30;
            int startX = (panel.Width - totalWidth) / 2;
            
            if (startX < leftMargin)
                startX = leftMargin;
            
            // C?n gi?a c�c controls
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Label lbl && !lbl.Name.Contains("Title") && !lbl.Name.Contains("Note"))
                {
                    lbl.Left = startX;
                }
                else if (ctrl is TextBox txt)
                {
                    txt.Left = startX + maxLabelWidth + 20;
                }
                else if (ctrl is Button btn)
                {
                    // C?n gi?a buttons
                    if (panel.Controls.Cast<Control>().Count(c => c is Button) == 2)
                    {
                        // 2 buttons c?nh nhau
                        int totalButtonWidth = 0;
                        foreach (Control c in panel.Controls)
                        {
                            if (c is Button b)
                                totalButtonWidth += b.Width + 10;
                        }
                        
                        int buttonStartX = (panel.Width - totalButtonWidth) / 2;
                        int currentX = buttonStartX;
                        
                        foreach (Control c in panel.Controls)
                        {
                            if (c is Button b && b.Name.Contains("DoiMatKhau"))
                            {
                                b.Left = currentX;
                                currentX += b.Width + 10;
                            }
                        }
                        
                        foreach (Control c in panel.Controls)
                        {
                            if (c is Button b && b.Name.Contains("Huy"))
                            {
                                b.Left = currentX;
                            }
                        }
                    }
                }
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text))
                {
                    UIHelper.ShowWarningMessage("Vui l�ng nh?p m?t kh?u c?!");
                    txtMatKhauCu.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
                {
                    UIHelper.ShowWarningMessage("Vui l�ng nh?p m?t kh?u m?i!");
                    txtMatKhauMoi.Focus();
                    return;
                }

                if (txtMatKhauMoi.Text != txtXacNhanMatKhau.Text)
                {
                    UIHelper.ShowWarningMessage("M?t kh?u x�c nh?n kh�ng kh?p!");
                    txtXacNhanMatKhau.Focus();
                    return;
                }

                // Validate password strength
                if (!PasswordHelper.IsPasswordStrong(txtMatKhauMoi.Text, out string message))
                {
                    UIHelper.ShowWarningMessage(message);
                    txtMatKhauMoi.Focus();
                    return;
                }

                // L?y th�ng tin m?t kh?u hi?n t?i
                string query = "SELECT MatKhau, Salt FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                SqlParameter[] parameters = { new SqlParameter("@TenDangNhap", tenDangNhap) };
                var dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    UIHelper.ShowErrorMessage("Kh�ng t�m th?y t�i kho?n!");
                    return;
                }

                string storedPassword = dt.Rows[0]["MatKhau"].ToString();
                string salt = dt.Rows[0]["Salt"]?.ToString();

                // Ki?m tra m?t kh?u c?
                bool isOldPasswordValid = false;
                if (!string.IsNullOrEmpty(salt))
                {
                    // Password đã được hash
                    isOldPasswordValid = PasswordHelper.VerifyPassword(txtMatKhauCu.Text, storedPassword, salt);
                }
                else
                {
                    // Password cũ chưa hash
                    isOldPasswordValid = (txtMatKhauCu.Text == storedPassword);
                }

                if (!isOldPasswordValid)
                {
                    UIHelper.ShowErrorMessage("M?t kh?u c? kh�ng ??ng!");
                    txtMatKhauCu.Focus();
                    return;
                }

                // Hash m?t kh?u m?i
                string newHashedPassword = PasswordHelper.HashPassword(txtMatKhauMoi.Text, out string newSalt);

                // C?p nh?t m?t kh?u
                string updateQuery = "UPDATE TaiKhoan SET MatKhau = @MatKhau, Salt = @Salt WHERE TenDangNhap = @TenDangNhap";
                SqlParameter[] updateParams = {
                    new SqlParameter("@MatKhau", newHashedPassword),
                    new SqlParameter("@Salt", newSalt),
                    new SqlParameter("@TenDangNhap", tenDangNhap)
                };

                DatabaseHelper.ExecuteNonQuery(updateQuery, updateParams);

                UIHelper.ShowSuccessMessage("??i m?t kh?u th�nh c�ng!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("L?i khi ??i m?t kh?u: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
