using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("courses")]
public class CourseController : ControllerBase
{

    [HttpGet]
    public IEnumerable<Course> Get()
    {
        return new DataCourse().GetAllCourses();
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var course = new DataCourse().GetCourseById(id);
        if (course == null)
        {
            return NotFound();
        }
        return Ok(course);
    }
    
    [HttpGet("{id}/students")]
    public IActionResult GetStudentById(int id)
    {
        var student = new DataCourse().GetStudentsByCourseId(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Course course)
    {
        var insertedCourse = new DataCourse().InsertCourse(course.Name, course.Description, course.ImageUrl, course.Schedule, course.Professor);
        return Ok(insertedCourse);
    }

    [HttpPut]
    public IActionResult Put([FromBody] Course course)
    {
        var updatedCourse = new DataCourse().UpdateCourse(course.Id, course.Name, course.Description, course.ImageUrl, course.Schedule, course.Professor);
        return Ok(updatedCourse);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deletedCourse = new DataCourse().DeleteCourse(id);
        return Ok(deletedCourse);
    }

}