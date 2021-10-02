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
    public class GetAllStudentsQuery : IRequest<IEnumerable<StudentDto>>
    {
        public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDto>>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IMapper _mapper;

            public GetAllStudentsQueryHandler(IStudentRepository studentRepository, IMapper mapper)
            {
                _studentRepository = studentRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
            {
                //var response = await _studentRepository.GetAllAsync();
                var response = await _studentRepository.GetAllStudentsWithEnrollments();

                return _mapper.Map<IEnumerable<StudentDto>>(response);
            }
        }
    }
}
