using System.ComponentModel.DataAnnotations;

namespace API_CRUD_USING_DB.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }


        public required string Name { get; set; }


        public required string Email { get; set; }


        public  string? Phone { get; set; }


        public decimal Salary { get; set; }

       
    }
}
