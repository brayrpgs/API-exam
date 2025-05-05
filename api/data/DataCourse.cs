using System.Data;
using Microsoft.Data.SqlClient;

class DataCourse : ConnectionSQL
{
    public SqlConnection conn = GetConnect();

    public Course InsertCourse(string name, string description, string imageUrl, string schedule, string professor)
    {
        //configures my sp
        SqlCommand sqlCommand = new("CREATE_COURSE", conn);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        //add my parameters
        sqlCommand.Parameters.AddWithValue("@NAME_COURSE", name);
        sqlCommand.Parameters.AddWithValue("@DESCRIPTION_COURSE", description);
        sqlCommand.Parameters.AddWithValue("@IMAGE_URL", imageUrl);
        sqlCommand.Parameters.AddWithValue("@SHEDULE", schedule);
        sqlCommand.Parameters.AddWithValue("@PROFESSOR", professor);

        //open connection
        conn.Open();

        //execute store procedure
        SqlDataReader reader = sqlCommand.ExecuteReader();
        if (reader.Read())
        {
            conn.Close();
            //map data to object course
            return new Course
            {
                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                Name = reader.GetString(reader.GetOrdinal("NAME_COURSE")),
                Description = reader.GetString(reader.GetOrdinal("DESCRIPTION_COURSE")),
                ImageUrl = reader.GetString(reader.GetOrdinal("IMAGE_URL")),
                Schedule = reader.GetString(reader.GetOrdinal("SHEDULE")),
                Professor = reader.GetString(reader.GetOrdinal("PROFESSOR"))
            };
        }
        else
        {
            conn.Close();
            return null;
        }
    }

    public List<Course> GetAllCourses()
    {
        List<Course> courses = new List<Course>();

        
        SqlCommand sqlCommand = new SqlCommand("SELECT_COURSE", conn);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        
        conn.Open();

        
        SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            
            courses.Add(new Course
            {
                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                Name = reader.GetString(reader.GetOrdinal("NAME_COURSE")),
                Description = reader.GetString(reader.GetOrdinal("DESCRIPTION_COURSE")),
                ImageUrl = reader.GetString(reader.GetOrdinal("IMAGE_URL")),
                Schedule = reader.GetString(reader.GetOrdinal("SHEDULE")),
                Professor = reader.GetString(reader.GetOrdinal("PROFESSOR"))
            });
        }

        conn.Close();
        return courses;
    }

    public Course UpdateCourse(int id, string name, string description, string imageUrl, string schedule, string professor)
    {
        SqlCommand sqlCommand = new("UPDATE_COURSE", conn);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        sqlCommand.Parameters.AddWithValue("@ID", id);
        sqlCommand.Parameters.AddWithValue("@NAME_COURSE", name);
        sqlCommand.Parameters.AddWithValue("@DESCRIPTION_COURSE", description);
        sqlCommand.Parameters.AddWithValue("@IMAGE_URL", imageUrl);
        sqlCommand.Parameters.AddWithValue("@SHEDULE", schedule);
        sqlCommand.Parameters.AddWithValue("@PROFESSOR", professor);

        conn.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        if (reader.Read())
        {
            var course = new Course
            {
                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                Name = reader.GetString(reader.GetOrdinal("NAME_COURSE")),
                Description = reader.GetString(reader.GetOrdinal("DESCRIPTION_COURSE")),
                ImageUrl = reader.GetString(reader.GetOrdinal("IMAGE_URL")),
                Schedule = reader.GetString(reader.GetOrdinal("SHEDULE")),
                Professor = reader.GetString(reader.GetOrdinal("PROFESSOR"))
            };
            conn.Close();
            return course;
        }

        conn.Close();
        return null;
    }

    public bool DeleteCourse(int id)
    {
        SqlCommand sqlCommand = new("DELETE_COURSE", conn);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@ID", id);

        conn.Open();
        int affectedRows = sqlCommand.ExecuteNonQuery();
        conn.Close();

        return affectedRows > 0; 
    }

    public List<Student> GetStudentsByCourseId(int courseId)
    {
        List<Student> students = new();

        SqlCommand sqlCommand = new SqlCommand("ALL_STUDENT_BY_COURSE", conn);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@ID", courseId);

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
    public Course GetCourseById(int id)
    {
        SqlCommand sqlCommand = new SqlCommand("GET_COURSE_BY_ID", conn);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@ID", id);

        conn.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        if (reader.Read())
        {
            var course = new Course
            {
                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                Name = reader.GetString(reader.GetOrdinal("NAME_COURSE")),
                Description = reader.GetString(reader.GetOrdinal("DESCRIPTION_COURSE")),
                ImageUrl = reader.GetString(reader.GetOrdinal("IMAGE_URL")),
                Schedule = reader.GetString(reader.GetOrdinal("SHEDULE")),
                Professor = reader.GetString(reader.GetOrdinal("PROFESSOR"))
            };
            conn.Close();
            return course;
        }

        conn.Close();
        return null;
    }


}