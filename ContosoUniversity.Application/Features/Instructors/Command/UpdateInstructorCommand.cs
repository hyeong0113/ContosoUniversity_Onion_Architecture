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
    public class UpdateInstructorCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }

        public class UpdateInstructorCommandHandler : IRequestHandler<UpdateInstructorCommand, Unit>
        {
            private readonly IInstructorRepository _instructorRepository;
            private readonly IMapper _mapper;

            public UpdateInstructorCommandHandler(IInstructorRepository instructorRepository, IMapper mapper)
            {
                _instructorRepository = instructorRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateInstructorCommand command, CancellationToken cancellationToken)
            {
                Instructor input = _mapper.Map<Instructor>(command);
                await _instructorRepository.UpdateAsync(input);

                return Unit.Value;
            }
        }
    }
}
