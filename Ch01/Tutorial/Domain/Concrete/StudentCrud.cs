using System.Collections.Generic;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class StudentCrud : IStudentCrud
    {
        public List<Student> GetAll()
        {
            using (var context = new TutorialEfDbContext())
            {
                return context.Student.ToList();
            }
        }

        public Student Get(string id)
        {
            using (var context = new TutorialEfDbContext())
            {
                return context.Student.Find(id);
            }
        }

        public bool Update(string id, Student entity)
        {
            using (var context = new TutorialEfDbContext())
            {
                var res = context.Student.Find(id);
                res.Age = entity.Age;
                res.Name = entity.Name;
                res.Sex = entity.Sex;
                return context.SaveChanges() > 0;
            }
        }

        public bool Add(Student entity)
        {
            using (var context=new TutorialEfDbContext())
            {
                context.Student.Add(entity);
                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(string id)
        {
            using (var context=new TutorialEfDbContext())
            {
                var res=context.Student.Find(id);
                context.Student.Remove(res);
                return context.SaveChanges() > 0;
            }
        }
    }
}
