using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public class EnrollStudentController : ControllerBase
    {
        private readonly IStudentDbService _service;
        public EnrollStudentController(IStudentDbService service)
        {
            _service = service;
        }

        [HttpPost(Name = "EnrollStudent")]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            try
            {
                var student = _service.EnrollStudent(request);
                return Created("EnrollStudent", student);
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

        [HttpPost]
        public IActionResult PromoteStudents(PromoteStudentsRequest request)
        {
            try
            {
                var responce = _service.PromoteStudents(request);
                return Ok("Students have been promoted successfully");
            }
            catch (StudiesNotFound ex1)
            {
                return NotFound(ex1.Message);
            }
            catch (NoStudentsToPromote ex2)
            {
                return NotFound(ex2.Message);
            }
        }
    }
}
