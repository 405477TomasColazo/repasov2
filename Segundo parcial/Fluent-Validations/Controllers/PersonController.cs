using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonsApi.Domain;
using PersonsApi.Dto;
using System.Runtime.Intrinsics;

namespace PersonsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMapper _mapper;

        public PersonController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPut]
        public ActionResult<ApiResponse<PersonDto>> UpdatePerson([FromBody] UpdatePersonDto dto)
        {
            var person = _mapper.Map<Person>(dto);

            // llamar al servicio para actualizar persona
            
            // respuesta a la llamada al servicio
            var personDto = new PersonDto();

            var serviceResponse = true;

            ApiResponse<PersonDto> response;

            if (serviceResponse)
            {
                response = new ApiResponse<PersonDto>
                {
                    Status = System.Net.HttpStatusCode.OK,
                    Data = personDto,
                };
            }
            else
            {
                response = new ApiResponse<PersonDto>
                {
                    Status = System.Net.HttpStatusCode.BadRequest,
                    ErrorMessage = "Hubo un error en el servicio"
                };
            }

            return Ok(response);
        }

        [HttpGet]
        public ActionResult<ApiResponse<List<PersonDto>>> GetAll()
        {
            //var list = new List<PersonDto>
            //{
            //    new PersonDto{ Id = "ewqewqe", FirstName = "@@qwewqe", LastName = "adasd" }
            //};
            var list = new List<Person>
            {
                new Person { Id = Guid.NewGuid(), Email = "qwewqe@qwe.com", FirstName = "qwewq" }
            };

            var response = new ApiResponse<List<PersonDto>>();
            response.Data = _mapper.Map<List<PersonDto>>(list);

            return Ok(response);
        }
    }
}
