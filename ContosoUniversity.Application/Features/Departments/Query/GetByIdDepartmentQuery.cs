using AutoMapper;
using ContosoUniversity.Application.Dtos;
using ContosoUniversity.Application.Interface.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Departments.Query
{
    public class GetByIdDepartmentQuery : IRequest<DepartmentDto>
    {
        public int Id { get; set; }
        public class GetByIdDepartmentQueryHandler : IRequestHandler<GetByIdDepartmentQuery, DepartmentDto>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;

            public GetByIdDepartmentQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<DepartmentDto> Handle(GetByIdDepartmentQuery query, CancellationToken cancellationToken)
            {
                var response = await _departmentRepository.GetByIdAsync(query.Id);
                return _mapper.Map<DepartmentDto>(response);
            }
        }
    }
}
