using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace api.Controllers;

[ApiController]
[Route("student")]
public class StudentController : ControllerBase
{

    [HttpGet]
    public IEnumerable<Student> Get()
    {
        return new DataStudent().GetAllStudents();
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var student = new DataStudent().GetStudentById(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Student student)
    {
        try{
            var insertedStudent = new DataStudent().CreateStudent(student.Name, student.Email, student.Phone, student.CourseId);
            return Ok(insertedStudent);
            
        } 
        catch (SqlException e)
        {
            if(e.Number == 547) return BadRequest("Course ID not found.");   
            return BadRequest("An error occurred while creating the student.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpPut]
    public IActionResult Put([FromBody] Student student)
    {
        try {
            var updatedStudent = new DataStudent().UpdateStudent(student.Id, student.Name, student.Email, student.Phone, student.CourseId);
            return Ok(updatedStudent);
        }
        catch (SqlException e)
        {
            if(e.Number == 547) return BadRequest("Course ID not found.");   
            return BadRequest("An error occurred while creating the student.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deletedStudent = new DataStudent().DeleteStudent(id);
        return Ok(deletedStudent);
    }

}