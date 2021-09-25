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
    public class GetByIdStudentQuery : IRequest<Student>
    {
        public int Id { get; set; }
        public class GetByIdStudentQueryHandler : IRequestHandler<GetByIdStudentQuery, Student>
        {
            private readonly IStudentRepository _studentRepository;

            public GetByIdStudentQueryHandler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }

            public async Task<Student> Handle(GetByIdStudentQuery query, CancellationToken cancellationToken)
            {
                return await _studentRepository.GetByIdAsync(query.Id);
            }
        }
    }
}
