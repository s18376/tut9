using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut9.DTOs.Request;
using tut9.Models;
using tut9.DTOs.Response;
namespace tut9.Services
{
    public interface IStudentDbService
    {
        public List<Student> GetStudentList();
        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest request);
        public InsertStudentResponse InsertStudent(InsertStudentRequest request);
        public void DeleteStudent(DeleteStudentRequest request);
        public void ModifyStudent(ModifyStudentRequest request);
        public PromoteStudentsResponse PromoteStudents(PromoteStudentsRequest request);
    }
}
