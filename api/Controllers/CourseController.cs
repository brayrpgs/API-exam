using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/courses")]
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
    public async Task<IActionResult> Post([FromForm] string name,
                                      [FromForm] string description,
                                      [FromForm] string schedule,
                                      [FromForm] string professor,
                                      IFormFile image)
    {
        string ImageUrl = string.Empty;
        if (image != null && image.Length > 0)
        {
            // Generate a unique file name to avoid conflicts
            var fileName = Path.GetFileName(image.FileName);

            // Define the path to save the image
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages", fileName);

            var directoryPath = Path.GetDirectoryName(filePath);
            // Verifie if the directory exists, if not, create it
            if (directoryPath != null && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Save the image to the server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            // Relative Url to access the image
            ImageUrl = "/UploadedImages/" + fileName;
        }

        // Insert the course into the database
        var insertedCourse = new DataCourse().InsertCourse(name, description, ImageUrl, schedule, professor);
        return Ok(insertedCourse);
    }

    [HttpPut]
    public IActionResult Put([FromBody] Course course)
    {
        var updatedCourse = new DataCourse().UpdateCourse(course.Id, course.Name, course.Description, "", course.Schedule, course.Professor);
        return Ok(updatedCourse);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deletedCourse = new DataCourse().DeleteCourse(id);
        return Ok(deletedCourse);
    }

}