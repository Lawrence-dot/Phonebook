using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;
using Phonebook.Services.Interfaces;
using System.Linq.Expressions;

namespace Phonebook.Services.Implementation
{
 
    public class StudentService : IStudent
    {
        private readonly StudentDbContext _students;

        public StudentService(StudentDbContext students)
        {
            _students = students;
        }


        public async Task<bool> AddNew(AddStudentViewModel student)
        {
            var data = new Student();
            try
            {
                 data = new Student()
                {
                    Id = new Guid(),
                    First_name = student.First_name,
                    Last_name = student.Last_name,
                    Middle_name = student.Middle_name,
                    Course_of_study = student.Course_of_study,
                    Email = student.Email,
                    Level = student.Level,
                    Gender = student.Gender,
                    Admission_date = (DateTime)student.Admission_date,
                    Admission_number = student.Admission_number,
                    Date_of_birth = (DateTime)student.Date_of_birth,
                    Department = student.Department,
                    Faculty = student.Faculty,
                    Home_address = student.Home_address,
                    Phone_number = student.Phone_number
                };
                await _students.Students.AddAsync(data);
                await _students.SaveChangesAsync();
               return  (data != null) ? true : false;   
                
            } catch {
                throw;
            }
        }

        public async Task<bool> Delete(Guid Id)
        {
            var student = _students.Students.FindAsync(Id);
            try
            {
                if (student.Result is Student)
                {
                    _students.Remove(student.Result);
                    await _students.SaveChangesAsync();
                    return true;
                } else
                {
                    return false;
                }
             
            } catch
            {
                throw;
            }
        }

        public IQueryable<Student> Query(Expression<Func<Student, bool>> predicate = null)
        {
            IQueryable<Student> students = null;    
            try
            {
                if (predicate == null)
                {
                    students =  _students.Students.AsQueryable();
                }
                else
                {
                    students = _students.Students.Where(predicate);
                }
            }
            catch
            {
                throw;
            } 
            return students;
        }

        public async Task<bool> Update(EditStudentViewModel student)
        {
            try
            {
                var data = await _students.Students.FindAsync(student.Id);
                if (data != null)
                {
                    data.First_name = student.First_name;
                    data.Last_name = student.Last_name;
                    data.Middle_name = student.Middle_name;
                    data.Course_of_study = student.Course_of_study;
                    data.Email = student.Email;
                    data.Level = student.Level;
                    data.Gender = student.Gender;
                    data.Date_of_birth = (DateTime)student.Date_of_birth;
                    data.Admission_number = student.Admission_number;
                    data.Department = student.Department;
                    data.Faculty = student.Faculty;
                    data.Admission_date = (DateTime)student.Admission_date;
                    data.Home_address = student.Home_address;
                    data.Phone_number = student.Phone_number;
                    await _students.SaveChangesAsync();
                }
                return (data != null) ? true : false;
            } catch
            {
                throw;
            }
        }
    }
}
