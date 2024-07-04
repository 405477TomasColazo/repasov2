using Api.Domain;
using Api.Dtos;
using Api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ApiResponse<List<UserDto>>>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            var response = new ApiResponse<List<UserDto>>();
            response.Data = _mapper.Map<List<UserDto>>(users);
            response.Status = System.Net.HttpStatusCode.OK;
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<UserDto>>> GeaById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var response = new ApiResponse<UserDto>();
            response.Data = _mapper.Map<UserDto>(user);
            response.Status = System.Net.HttpStatusCode.OK;
            return Ok(response);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ApiResponse<User>>> Create([FromBody] User user)
        {
            if (user == null) { return BadRequest(); }
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await _userRepository.CreateAsync(user));
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            if (id != user.Id) { return BadRequest(); }
            return Ok(await _userRepository.UpdateAsync(user));
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _userRepository.DeleteAsync(id));
        }

        //[Route("api/[controller]")]
        //[ApiController]
        //public class UserController : ControllerBase
        //{
        //    private readonly IUserRepository _userRepository;
        //    private readonly IMapper _mapper;

        //    public UserController(IUserRepository userRepository, IMapper mapper)
        //    {
        //        _userRepository = userRepository;
        //        _mapper = mapper;
        //    }

        //    private ActionResult<ApiResponse<T>> CreateResponse<T>(T data, HttpStatusCode status = HttpStatusCode.OK, string errorMessage = null)
        //    {
        //        var response = new ApiResponse<T>
        //        {
        //            Status = status,
        //            Data = data,
        //            ErrorMessage = errorMessage
        //        };

        //        return StatusCode((int)status, response);
        //    }

        //    [HttpGet]
        //    [Authorize]
        //    public async Task<ActionResult<ApiResponse<List<UserDto>>>> GetAll()
        //    {
        //        var users = await _userRepository.GetAllAsync();
        //        var userDtos = _mapper.Map<List<UserDto>>(users);
        //        return CreateResponse(userDtos);
        //    }

        //    [HttpGet("{id}")]
        //    [Authorize]
        //    public async Task<ActionResult<ApiResponse<UserDto>>> GetById(int id)
        //    {
        //        var user = await _userRepository.GetByIdAsync(id);
        //        if (user == null)
        //        {
        //            return CreateResponse<UserDto>(null, HttpStatusCode.NotFound, "Usuario no encontrado");
        //        }
        //        var userDto = _mapper.Map<UserDto>(user);
        //        return CreateResponse(userDto);
        //    }

        //    [HttpPost]
        //    [Authorize]
        //    public async Task<ActionResult<ApiResponse<User>>> Create([FromBody] User user)
        //    {
        //        if (user == null)
        //        {
        //            return CreateResponse<User>(null, HttpStatusCode.BadRequest, "Usuario inválido");
        //        }
        //        if (!ModelState.IsValid)
        //        {
        //            return CreateResponse<User>(null, HttpStatusCode.BadRequest, "Modelo no válido");
        //        }
        //        var createdUser = await _userRepository.CreateAsync(user);
        //        return CreateResponse(createdUser, HttpStatusCode.Created);
        //    }

        //    [HttpPut("{id}")]
        //    [Authorize]
        //    public async Task<ActionResult<ApiResponse<User>>> Update(int id, [FromBody] User user)
        //    {
        //        if (id != user.Id)
        //        {
        //            return CreateResponse<User>(null, HttpStatusCode.BadRequest, "ID de usuario no coincide");
        //        }
        //        var updatedUser = await _userRepository.UpdateAsync(user);
        //        if (updatedUser == null)
        //        {
        //            return CreateResponse<User>(null, HttpStatusCode.NotFound, "Usuario no encontrado");
        //        }
        //        return CreateResponse(updatedUser);
        //    }

        //    [HttpDelete("{id}")]
        //    [Authorize]
        //    public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        //    {
        //        var deleted = await _userRepository.DeleteAsync(id);
        //        if (!deleted)
        //        {
        //            return CreateResponse(false, HttpStatusCode.NotFound, "Usuario no encontrado");
        //        }
        //        return CreateResponse(true);
        //    }
        //}

        //public class ApiResponse<T>
        //{
        //    public HttpStatusCode Status { get; set; }
        //    public T Data { get; set; }
        //    public string ErrorMessage { get; set; }
        //}

    }
}
