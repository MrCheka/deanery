using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Deanery.Classes
{
    class Progress
    {
        private int _progressId;
        private List<Semester> _semesterList;

        public int ProgressId
        {
            get { return _progressId; }
            set { _progressId = value; }
        }

        public List<Semester> SemesterList
        {
            get { return _semesterList; }
            set { _semesterList = value; }
        }

        public Progress()
        {
            _semesterList = new List<Semester>();
        }

        public void Fill()
        {
            _semesterList.Clear();
            SqlConnection connection = Service.OpenConnection();

            string request = " ";

        }


    }
}
