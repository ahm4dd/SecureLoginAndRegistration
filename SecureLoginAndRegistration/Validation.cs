using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureLoginAndRegistration
{
    internal class Validation
    {
        public static bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUppercase = true;
                }
                else if (char.IsLower(c))
                {
                    hasLowercase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
                else if (!char.IsLetterOrDigit(c))
                {
                    hasSpecialChar = true;
                }
            }

            if (hasUppercase && hasLowercase && hasDigit && hasSpecialChar && password.Length >= 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return false;
            }

            foreach (char c in username)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidateName(string name) 
        { 
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            foreach (char c in name)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            int atIndex = email.IndexOf('@');
            if (atIndex <= 0 || atIndex >= email.Length - 1) return false; 

            string localPart = email.Substring(0, atIndex);
            string domainPart = email.Substring(atIndex + 1);

            if (string.IsNullOrEmpty(localPart) || localPart.Length > 64) return false;
            if (string.IsNullOrEmpty(domainPart) || domainPart.Length > 255) return false;
            if (localPart.Contains("..") || domainPart.Contains("..")) return false; 
            if (localPart.StartsWith(".") || localPart.EndsWith(".")) return false;   
            if (domainPart.StartsWith(".") || domainPart.EndsWith(".")) return false; 
            foreach (char c in localPart)
            {
                if (!char.IsLetterOrDigit(c) && c != '.' && c != '_' && c != '-' && c != '+') return false;
            }

            int dotIndex = domainPart.IndexOf('.');
            if (dotIndex <= 0 || dotIndex >= domainPart.Length - 1) return false; 

            foreach (char c in domainPart)
            {
                if (!char.IsLetterOrDigit(c) && c != '.' && c != '-') return false;
            }

            return true;
        }

        public static bool ValidatePhone(string phone) 
        { 
            if (string.IsNullOrWhiteSpace(phone)) return false;
            return phone.Length >= 10 && phone.Length <= 15;
        }

        public static bool ValidateAge(int age)
        {
            return age >= 18 && age <= 100;
        }
    }
}
