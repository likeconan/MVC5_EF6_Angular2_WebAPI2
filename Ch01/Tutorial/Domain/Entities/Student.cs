using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class Student
    {
        // Every Model must has its Key attribute, it represents the Primary Key in Sql Server
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
    }
}
