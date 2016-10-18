using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Abstract;
using Domain.Entities;

namespace WebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        #region Fields

        private IStudentCrud _student;

        #endregion

        #region Constructor

        public StudentsController(IStudentCrud student)
        {
            _student = student;
        }
        #endregion

        #region SLP

        public IEnumerable<Student> GetStudents()
        {
            return _student.GetAll();
        }
        public Student GetStudent(string id)
        {
            return _student.Get(id);
        }

        public bool PostStudent(Student student)
        {
            return _student.Add(student);
        }

        public bool DeleteStudent(string id)
        {
            return _student.Delete(id);
        }

        #endregion
    }
}
