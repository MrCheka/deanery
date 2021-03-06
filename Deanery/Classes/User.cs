﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deanery.Classes
{
    public class User: IEquatable<User>
    {
        public enum UserRole
        {
            Admin = 0,
            Professor = 1,
            Student = 2
        };

        private int _userId;
        private string _login;
        private string _password;
        private string _fio;
        private UserRole _role;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Fio
        {
            get { return _fio; }
            set { _fio = value; }
        }

        public UserRole Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public User()
        {

        }

        public User(string login, string password)
        {
            _login = login;
            _password = password;
            _fio = string.Empty;
            _role = UserRole.Student;
        }

        public User(string login, string password, string fio, UserRole role)
        {
            _login = login;
            _password = password;
            _fio = fio;
            _role = role;
        }

        public static bool operator ==(User left, User right)
        {
            if (left is null && right is null)
                return true;
            else if (left is null)
                return false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(User left, User right)
        {
            return !(left == right);
        }

        public bool Equals(User other)
        {
            return other != null &&
                Login == other.Login &&
                Password == other.Password;
        }
    }
}
