using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StuLessonsController : ControllerBase
    {
        IStudentLessonService _studentLesson;

        public StuLessonsController(IStudentLessonService studentLesson)
        {
            _studentLesson = studentLesson;
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int studentId)
        {
            var result = _studentLesson.GetStudentLessons(studentId);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("addlesson")]

        public IActionResult AddLesson(LessonDto lessonDto)
        {
            var result = _studentLesson.AddStudentLesson(lessonDto);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deletelesson")]

        public IActionResult DeleteLesson(LessonDto lessonDto)
        {
            var result = _studentLesson.DeleteStudentLesson(lessonDto);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
