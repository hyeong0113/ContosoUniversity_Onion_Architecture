using ContosoUniversity.Application.Interface.Repository;
using ContosoUniversity.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Students.Command
{
    public class CreateStudentCommand : IRequest<int>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
        {
            private readonly IStudentRepository _studentRepository;

            public CreateStudentCommandHandler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }

            public async Task<int> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
            {
                Student student = new Student();
                // Need Automapper
                student.LastName = command.LastName;
                student.FirstName = command.FirstName;
                student.EnrollmentDate = command.EnrollmentDate;

                var createdId = await _studentRepository.AddAsync(student);
                return createdId;
            }
        }
    }
}
