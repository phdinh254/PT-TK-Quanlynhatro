using System;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyNhaTro.Helpers
{
    public static class PasswordHelper
    {
        // S? d?ng SHA256 k?t h?p v?i salt ?? hash password
        // Note: Trong production nên dùng BCrypt.Net ho?c Argon2
        public static string HashPassword(string password, out string salt)
        {
            // T?o salt ng?u nhiên
            salt = GenerateSalt();
            return HashPassword(password, salt);
        }

        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                // K?t h?p password v?i salt
                var saltedPassword = password + salt;
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                return Convert.ToBase64String(bytes);
            }
        }

        public static bool VerifyPassword(string password, string hash, string salt)
        {
            var newHash = HashPassword(password, salt);
            return newHash == hash;
        }

        private static string GenerateSalt()
        {
            var bytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return Convert.ToBase64String(bytes);
        }

        public static string GenerateToken()
        {
            var bytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return Convert.ToBase64String(bytes);
        }

        // Validate password strength
        public static bool IsPasswordStrong(string password, out string message)
        {
            message = "";
            
            if (string.IsNullOrWhiteSpace(password))
            {
                message = "M?t kh?u không ???c ?? tr?ng!";
                return false;
            }

            if (password.Length < 6)
            {
                message = "M?t kh?u ph?i có ít nh?t 6 ký t?!";
                return false;
            }

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                if (char.IsLower(c)) hasLower = true;
                if (char.IsDigit(c)) hasDigit = true;
            }

            if (!hasUpper || !hasLower || !hasDigit)
            {
                message = "M?t kh?u ph?i ch?a ch? hoa, ch? th??ng và s?!";
                return false;
            }

            return true;
        }

        // Validate email format
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
