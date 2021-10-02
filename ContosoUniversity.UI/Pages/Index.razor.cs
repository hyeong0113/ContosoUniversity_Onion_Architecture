using ContosoUniversity.UI.Services.Base;
using ContosoUniversity.UI.Services.Student;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.UI.Pages
{
    public partial class Index
    {
        public ICollection<StudentDto> students { get; set; }

        [Inject]
        private StudentService StudentService { get; set; }

        public Index()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            students = await StudentService.GetAllStudents();
        }
    }
}
