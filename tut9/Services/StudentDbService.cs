using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut9.DTOs.Request;
using tut9.DTOs.Response;
using tut9.Exceptions;
using tut9.Models;

namespace tut9.Services
{
    public class StudentDbService : IStudentDbService
    {
        private s18376Context _context;

        public StudentDbService(s18376Context context)
        {
            _context = context;
        }

        public void DeleteStudent(DeleteStudentRequest request)
        {
            var student = _context.Student.Find(request.IndexNumber);
            if(student == null)
            {
                throw new StudentNotFound();
            }
            _context.Remove(student);
            _context.SaveChanges();
        }

        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest request)
        {
            var study = _context.Studies.FirstOrDefault(s => s.Name == request.Studies);
            if (study == null)
            {
                throw new StudiesNotFound();
            }

            var enrollment = _context.Enrollment.Where(enr => enr.IdStudy == study.IdStudy 
                                                           && enr.Semester == request.Semester)
                                                .FirstOrDefault();
            if (enrollment == null)
            {
                enrollment = new Enrollment()
                {
                    IdEnrollment = _context.Enrollment.Max(enr => enr.IdEnrollment),
                    Semester = request.Semester,
                    IdStudy = study.IdStudy,
                    StartDate = DateTime.Now
                };
                _context.Enrollment.Add(enrollment);
            }

            if (_context.Student.FirstOrDefault(s => s.IndexNumber == request.IndexNumber) != null)
            {
                throw new StudentAlreadyExists();
            }

            var student = new Student()
            {
                IndexNumber = request.IndexNumber,
                BirthDate = request.BirthDate,
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdEnrollment = enrollment.IdEnrollment
            };

            _context.Student.Add(student);

            var response = new EnrollStudentResponse()
            {
                Semester = enrollment.Semester,
                StartDate = enrollment.StartDate
            };

            _context.SaveChanges();

            return response;
        }

        public List<Student> GetStudentList()
        {
            List<Student> StudentList = _context.Student.ToList();
            return StudentList;
            
        }

        public InsertStudentResponse InsertStudent(InsertStudentRequest request)
        {
            var study = _context.Studies.FirstOrDefault(s => s.Name == request.Studies);
            if (study == null)
            {
                throw new StudiesNotFound();
            }
            var enrollment = _context.Enrollment.Where(enr => enr.IdStudy == study.IdStudy && enr.Semester == 1).FirstOrDefault();
            if (enrollment == null)
            {
                enrollment = new Enrollment()
                {
                    IdEnrollment = _context.Enrollment.Max(enr => enr.IdEnrollment) + 1,
                    Semester = 1,
                    IdStudy = study.IdStudy,
                    StartDate = DateTime.Now
                };
                _context.Enrollment.Add(enrollment);
            }

            if (_context.Student.FirstOrDefault(s => s.IndexNumber == request.IndexNumber) != null)
            {
                throw new StudentAlreadyExists();
            }
            var student = new Student()
            {
                IndexNumber = request.IndexNumber,
                BirthDate = request.BirthDate,
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdEnrollment = enrollment.IdEnrollment
            };

            _context.Student.Add(student);

            var response = new InsertStudentResponse()
            {
                Semester = enrollment.Semester,
                StartDate = enrollment.StartDate
            };

            _context.SaveChanges();

            return response;
        }

        public void ModifyStudent(ModifyStudentRequest request)
        {
            var student = _context.Student.Find(request.IndexNumber);
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.BirthDate = request.BirthDate;
            _context.SaveChanges();
        }

        public PromoteStudentsResponse PromoteStudents(PromoteStudentsRequest request)
        {
            var study = _context.Studies.FirstOrDefault(s => s.Name == request.Name);

            if (study == null)
            {
                throw new StudiesNotFound();
            }

            var idStudy = _context.Studies.FirstOrDefault(s => s.Name == request.Name).IdStudy;

            var enrollment = _context.Enrollment.Where(en => en.Semester == request.Semester 
                                                          && en.IdStudy == idStudy)
                                                .FirstOrDefault();

            if (enrollment == null)
            {
                throw new NoStudentsToPromote();
            }

            var enrollments = _context.Enrollment.Where(enr => enr.Semester == request.Semester)
                                                 .ToList();
            enrollments.ForEach(e => e.Semester = request.Semester + 1);

            var response = new PromoteStudentsResponse()
            {
                Semester = request.Semester + 1,
                Name = request.Name
            };

            _context.SaveChanges();

            return response;
        }
    }
}
