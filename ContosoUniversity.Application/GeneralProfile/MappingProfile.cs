using AutoMapper;
using ContosoUniversity.Application.Dtos;
using ContosoUniversity.Application.Features.Courses.Command;
using ContosoUniversity.Application.Features.Departments.Command;
using ContosoUniversity.Application.Features.Enrollments.Command;
using ContosoUniversity.Application.Features.Instructors.Command;
using ContosoUniversity.Application.Features.OfficeAssignments.Command;
using ContosoUniversity.Application.Features.Students.Command;
using ContosoUniversity.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Application.GeneralProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Student profile
            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudentCommand, Student>();
            CreateMap<UpdateStudentCommand, Student>();

            // Enrollment profile
            CreateMap<Enrollment, EnrollmentDto>();
            CreateMap<CreateEnrollmentCommand, Enrollment>();
            CreateMap<UpdateEnrollmentCommand, Enrollment>();

            // Course profile
            CreateMap<Course, CourseDto>();
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<UpdateCourseCommand, Course>();

            // Department profile
            CreateMap<Department, DepartmentDto>();
            CreateMap<CreateDepartmentCommand, Department>();
            CreateMap<UpdateDepartmentCommand, Department>();

            // Instructor profile
            CreateMap<Instructor, InstructorDto>();
            CreateMap<CreateInstructorCommand, Instructor>();
            CreateMap<UpdateInstructorCommand, Instructor>();

            // OfficeAssignment profile
            CreateMap<OfficeAssignment, OfficeAssignmentDto>();
            CreateMap<CreateOfficeAssignmentCommand, OfficeAssignment>();
            CreateMap<UpdateOfficeAssignmentCommand, OfficeAssignment>();
        }
    }
}
