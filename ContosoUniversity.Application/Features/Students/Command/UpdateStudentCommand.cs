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
    public class UpdateStudentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
        {
            private readonly IStudentRepository _studentRepository;

            public UpdateStudentCommandHandler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }

            public async Task<Unit> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
            {
                Student student = new Student();
                // Need Automapper
                student.Id = command.Id;
                student.LastName = command.LastName;
                student.FirstName = command.FirstName;
                student.EnrollmentDate = command.EnrollmentDate;
                await _studentRepository.UpdateAsync(student);

                return Unit.Value;
            }
        }
    }
}
