using AutoMapper;
using ContosoUniversity.Application.Interface.Repository;
using ContosoUniversity.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Instructors.Command
{
    public class CreateInstructorCommand : IRequest<int>
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }

        public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, int>
        {
            private readonly IInstructorRepository _instructorRepository;
            private readonly IMapper _mapper;

            public CreateInstructorCommandHandler(IInstructorRepository instructorRepository, IMapper mapper)
            {
                _instructorRepository = instructorRepository;
                _mapper = mapper;
            }

            public Task<int> Handle(CreateInstructorCommand command, CancellationToken cancellationToken)
            {
                Instructor input = _mapper.Map<Instructor>(command);
                var createdId = _instructorRepository.AddAsync(input);
                return createdId;
            }
        }
    }
}
