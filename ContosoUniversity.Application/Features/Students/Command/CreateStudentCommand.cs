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
    public class CreateStudentCommand : IRequest<int>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IMapper _mapper;

            public CreateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper)
            {
                _studentRepository = studentRepository;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
            {
                Student input = _mapper.Map<Student>(command);

                var createdId = await _studentRepository.AddAsync(input);
                return createdId;
            }
        }
    }
}
