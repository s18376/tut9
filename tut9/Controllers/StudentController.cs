using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tut9.DTOs.Request;
using tut9.Exceptions;
using tut9.Models;
using tut9.Services;

namespace tut9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentDbService _service;

        public StudentController(IStudentDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult StudentList()
        {
            return Ok(_service.GetStudentList());
        }

        [HttpPost(Name = "InsertStudent")]
        public IActionResult InsertStudent(InsertStudentRequest request)
        {
            try
            {
                var student = _service.InsertStudent(request);
                return Created("InsertStudent", student);
            }
            catch (StudiesNotFound ex1)
            {
                return NotFound(ex1.Message);
            }
            catch (StudentAlreadyExists ex2)
            {
                return BadRequest(ex2.Message);
            }
        }

        [HttpPut(Name = "ModifyStudent")]
        public IActionResult ModifyStudent(ModifyStudentRequest request)
        {
            _service.ModifyStudent(request);
            return Ok("Student's data was successfully modified");
        }


        [HttpDelete]
        public IActionResult DeleteStudent(DeleteStudentRequest request)
        {
            _service.DeleteStudent(request);
            return Ok("Student has been deleted successfully");
        }
    }
}
