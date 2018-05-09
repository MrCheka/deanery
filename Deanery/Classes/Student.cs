using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deanery.Classes
{
    public class Student: IEquatable<Student>
    {
        public enum FormOfStudying
        {
            Free = 0,
            Pay = 1
        };

        private int _studentId;
        private string _name;
        private string _surname;
        private string _patronymic;
        private FormOfStudying _studyingForm;
        private string _speciality;
        private string _group;
        private int _year;
        private int _semester;
        private float _averageMark;

        public int StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Patronymic
        {
            get { return _patronymic; }
            set { _patronymic = value; }
        }

        public FormOfStudying StudyingForm
        {
            get { return _studyingForm; }
            set { _studyingForm = value; }
        }

        public string Speciality
        {
            get { return _speciality; }
            set { _speciality = value; }
        }

        public string Group
        {
            get { return _group; }
            set { _group = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public int Semester
        {
            get { return _semester; }
            set { _semester = value; }
        }

        public float AverageMark
        {
            get { return _averageMark; }
            set { _averageMark = value; }
        }

        public Student()
        {

        }

        public static bool operator ==(Student left, Student right)
        {
            if (left is null && right is null)
                return true;
            else if (left is null)
                return false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Student left, Student right)
        {
            return !(left == right);
        }

        public bool Equals(Student other)
        {
            return other != null &&
                Name == other.Name &&
                Surname == other.Surname &&
                Patronymic == other.Patronymic &&
                StudyingForm == other.StudyingForm &&
                Speciality == other.Speciality &&
                Group == other.Group &&
                Year == other.Year &&
                Semester == other.Semester &&
                AverageMark == other.AverageMark;
        }
    }
}
