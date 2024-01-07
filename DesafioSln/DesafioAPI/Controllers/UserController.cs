using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DesafioAPI.Dto.User;
using DesafioAPI.Models;
using DesafioAPI.Respositories.Interfaces;
using DesafioAPI.Validators;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        // Injeção de dependência do repositório e mapper
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // Endpoints
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDTO>> GetAllOrByAttributes(string? name, string? email, string? telephone)
        {
            try
            {
                List<User> response;

                response = _userRepository.GetAllOrByAttributes(name, email, telephone);

                // Caso nenhum usuário seja encontrado
                if (response.Count() == 0)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                var responseDTO = _mapper.Map<List<UserReadDTO>>(response);

                return Ok(responseDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpPost]
        public ActionResult<UserReadDTO> Post([FromBody] UserCreateDTO userCreateDTO)
        {
            try
            {
                // Mapeando para a model
                var newUser = _mapper.Map<User>(userCreateDTO);

                // Validando os dados informados
                var userValidator = new UserValidator();
                var validatorResult = userValidator.Validate(newUser);

                if (validatorResult.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
                }

                _userRepository.Add(newUser);

                // Mapeando o retorno para o ReadDTO
                var newUserRead = _mapper.Map<UserReadDTO>(newUser);

                return Created("Usuario criado com sucesso!", newUserRead);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            } 
        }

        [HttpPut("{id}")]
        public ActionResult<UserReadDTO> Put(int id, [FromBody] UserUpdateDTO userUpdateDTO)
        {
            try
            {
                var user = _userRepository.GetById(id);

                // Caso nenhum usuário seja encontrado
                if (user == null)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                // Mapeando para a model
                user = _mapper.Map(userUpdateDTO, user);

                // Validando os dados informados
                var userValidator = new UserValidator();
                var validatorResult = userValidator.Validate(user);

                if (validatorResult.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
                }

                _userRepository.Update(user);

                // Mapeando o retorno para o ReadDTO
                var userUpdatedRead = _mapper.Map<UserReadDTO>(user);
                
                return Ok(new
                {
                    Mensagem = "Usuário atualizado com sucesso",
                    User = userUpdatedRead
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}