using AutoMapper;
using ContosoUniversity.Application.Dtos;
using ContosoUniversity.Application.Features.Courses.Command;
using ContosoUniversity.Application.Features.Enrollments.Command;
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
            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudentCommand, Student>();
            CreateMap<UpdateStudentCommand, Student>();


            CreateMap<Enrollment, EnrollmentDto>();
            CreateMap<CreateEnrollmentCommand, Enrollment>();
            CreateMap<UpdateEnrollmentCommand, Enrollment>();

            CreateMap<Course, CourseDto>();
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<UpdateCourseCommand, Course>();
        }
    }
}
