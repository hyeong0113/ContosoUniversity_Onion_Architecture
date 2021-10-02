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
    public class GetAllDepartmentsQuery : IRequest<IEnumerable<DepartmentDto>>
    {
        public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmentDto>>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;

            public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DepartmentDto>> Handle(GetAllDepartmentsQuery query, CancellationToken cancellationToken)
            {
                var response = await _departmentRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<DepartmentDto>>(response);
            }
        }
    }
}
