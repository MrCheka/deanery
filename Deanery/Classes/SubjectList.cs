using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Deanery.Interfaces;

namespace Deanery.Classes
{
    class SubjectList: IMyList<Subject>
    {
        private List<Subject> _subjectList;

        public List<Subject> Value
        {
            get { return _subjectList; }
        }

        public SubjectList()
        {
            _subjectList = new List<Subject>();
        }

        public void Add(Subject item)
        {
            SqlConnection connection = Service.OpenConnection();

            string request = " INSERT INTO Subjects " +
                " (short_name, long_name) " +
                " VALUES (@short_name, @long_name) ";

            var command = new SqlCommand(request, connection);

            var parameter = new SqlParameter();
            parameter.ParameterName = "@short_name";
            parameter.Value = item.ShortName;
            parameter.SqlDbType = System.Data.SqlDbType.VarChar;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@long_name";
            parameter.Value = item.LongName;
            parameter.SqlDbType = System.Data.SqlDbType.VarChar;
            command.Parameters.Add(parameter);

            if (command.ExecuteNonQuery() != 0 && !_subjectList.Contains(item))
                _subjectList.Add(item);

            Service.CloseConnection(connection);
        }

        public bool Remove(Subject item)
        {
            SqlConnection connection = Service.OpenConnection();

            string request = " DELETE FROM Subjects " +
                " WHERE subject_id = @subject_id ";

            var command = new SqlCommand(request, connection);

            var parameter = new SqlParameter();
            parameter.ParameterName = "@subject_id";
            parameter.Value = item.SubjectId;
            parameter.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();

            Service.CloseConnection(connection);

            return _subjectList.RemoveAll(i => i.SubjectId == item.SubjectId) > 0;
        }

        public Subject Find(Subject item)
        {
            return _subjectList.Find(i => i == item);
        }

        public Subject Find(int id)
        {
            return _subjectList.Find(i => i.SubjectId == id);
        }

        public void Replace(int id, Subject item)
        {
            Subject subject = _subjectList.Find(i => i.SubjectId == id);
            subject.LongName = item.LongName;
            subject.ShortName = item.ShortName;
        }

        public void Fill()
        {
            _subjectList.Clear();
            SqlConnection connection = Service.OpenConnection();

            string request = " SELECT * FROM Subjects ";
            var command = new SqlCommand(request, connection);
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var newSubject = new Subject();
                    newSubject.SubjectId = Convert.ToInt32(dataReader["subject_id"]);
                    newSubject.ShortName = dataReader["short_name"].ToString();
                    newSubject.LongName = dataReader["long_name"].ToString();

                    _subjectList.Add(newSubject);
                }
            }

            Service.CloseConnection(connection);
        }

        public void Update()
        {
            SqlConnection connection = Service.OpenConnection();
            SqlTransaction transaction = connection.BeginTransaction();

            for (int i = 0; i < _subjectList.Count; i++)
            {
                if (_subjectList[i].SubjectId != 0)
                {
                    string request = " UPDATE Subjects " +
                        " SET short_name = @short_name, " +
                        " long_name = @long_name " +
                        " WHERE subject_id = @subject_id ";

                    var command = new SqlCommand();
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandText = request;

                    var parameter = new SqlParameter();
                    parameter.ParameterName = "@short_name";
                    parameter.Value = _subjectList[i].ShortName;
                    parameter.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@long_name";
                    parameter.Value = _subjectList[i].LongName;
                    parameter.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@subject_id";
                    parameter.Value = _subjectList[i].SubjectId;
                    parameter.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
                }
                else
                    Add(_subjectList[i]);
            }

            try
            {
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
                transaction.Rollback();
            }

            Service.CloseConnection(connection);
        }

        public int FindIndex(Subject item)
        {
            return _subjectList.FindIndex(i => i == item);
        }
    }
}
