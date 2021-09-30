using AutoMapper;
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
            private readonly IMapper _mapper;

            public UpdateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper)
            {
                _studentRepository = studentRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
            {
                Student input = _mapper.Map<Student>(command);
                await _studentRepository.UpdateAsync(input);

                return Unit.Value;
            }
        }
    }
}
