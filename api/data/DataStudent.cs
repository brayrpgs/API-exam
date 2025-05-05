using System.Data;
using Microsoft.Data.SqlClient;

class DataStudent : ConnectionSQL
{
    public SqlConnection conn = GetConnect();

    public Student CreateStudent(string name, string email, string phone, int courseId)
    {
        SqlCommand sqlCommand = new("CREATE_STUDENT", conn);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        sqlCommand.Parameters.AddWithValue("@NAME_STUDENT", name);
        sqlCommand.Parameters.AddWithValue("@EMAIL", email);
        sqlCommand.Parameters.AddWithValue("@PHONE", phone);
        sqlCommand.Parameters.AddWithValue("@COURSE_ID", courseId);

        conn.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        if (reader.Read())
        {
            var student = new Student
            {
                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                Name = reader.GetString(reader.GetOrdinal("NAME_STUDENT")),
                Email = reader.GetString(reader.GetOrdinal("EMAIL")),
                Phone = reader.GetString(reader.GetOrdinal("PHONE")),
                CourseId = reader.GetInt32(reader.GetOrdinal("COURSE_ID"))
            };
            conn.Close();
            return student;
        }

        conn.Close();
        return null;
    }

    public List<Student> GetAllStudents()
    {
        List<Student> students = new List<Student>();

        SqlCommand sqlCommand = new SqlCommand("GET_ALL_STUDENTS", conn);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        while (reader.Read())
        {
            students.Add(new Student
            {
                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                Name = reader.GetString(reader.GetOrdinal("NAME_STUDENT")),
                Email = reader.GetString(reader.GetOrdinal("EMAIL")),
                Phone = reader.GetString(reader.GetOrdinal("PHONE")),
                CourseId = reader.GetInt32(reader.GetOrdinal("COURSE_ID"))
            });
        }

        conn.Close();
        return students;
    }

    public Student GetStudentById(int id)
    {
        SqlCommand sqlCommand = new SqlCommand("GET_STUDENT_BY_ID", conn);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@ID", id);

        conn.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        if (reader.Read())
        {
            var student = new Student
            {
                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                Name = reader.GetString(reader.GetOrdinal("NAME_STUDENT")),
                Email = reader.GetString(reader.GetOrdinal("EMAIL")),
                Phone = reader.GetString(reader.GetOrdinal("PHONE")),
                CourseId = reader.GetInt32(reader.GetOrdinal("COURSE_ID"))
            };
            conn.Close();
            return student;
        }

        conn.Close();
        return null;
    }
    public Student UpdateStudent(int id, string name, string email, string phone, int courseId)
    {
        SqlCommand sqlCommand = new SqlCommand("UPDATE_STUDENT", conn);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        sqlCommand.Parameters.AddWithValue("@ID", id);
        sqlCommand.Parameters.AddWithValue("@NAME_STUDENT", name);
        sqlCommand.Parameters.AddWithValue("@EMAIL", email);
        sqlCommand.Parameters.AddWithValue("@PHONE", phone);
        sqlCommand.Parameters.AddWithValue("@COURSE_ID", courseId);

        conn.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        if (reader.Read())
        {
            var student = new Student
            {
                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                Name = reader.GetString(reader.GetOrdinal("NAME_STUDENT")),
                Email = reader.GetString(reader.GetOrdinal("EMAIL")),
                Phone = reader.GetString(reader.GetOrdinal("PHONE")),
                CourseId = reader.GetInt32(reader.GetOrdinal("COURSE_ID"))
            };
            conn.Close();
            return student;
        }

        conn.Close();
        return null;
    }
    public bool DeleteStudent(int id)
    {
        SqlCommand sqlCommand = new SqlCommand("DELETE_STUDENT", conn);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@ID", id);

        conn.Open();
        int affectedRows = sqlCommand.ExecuteNonQuery();
        conn.Close();

        return affectedRows > 0;
    }
}