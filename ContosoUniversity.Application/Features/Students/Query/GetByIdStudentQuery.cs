using AutoMapper;
using ContosoUniversity.Application.Dtos;
using ContosoUniversity.Application.Interface.Repository;
using ContosoUniversity.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Students.Query
{
    public class GetByIdStudentQuery : IRequest<StudentDto>
    {
        public int Id { get; set; }
        public class GetByIdStudentQueryHandler : IRequestHandler<GetByIdStudentQuery, StudentDto>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IMapper _mapper;

            public GetByIdStudentQueryHandler(IStudentRepository studentRepository, IMapper mapper)
            {
                _studentRepository = studentRepository;
                _mapper = mapper;
            }

            public async Task<StudentDto> Handle(GetByIdStudentQuery query, CancellationToken cancellationToken)
            {
                //var response = await _studentRepository.GetByIdAsync(query.Id);
                var response = await _studentRepository.GetStudentByIdWithEnrollments(query.Id);

                return _mapper.Map<StudentDto>(response);
            }
        }
    }
}
