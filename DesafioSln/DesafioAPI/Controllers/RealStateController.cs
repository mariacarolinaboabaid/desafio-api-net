using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DesafioAPI.Dto.RealState;
using DesafioAPI.Models;
using DesafioAPI.Respositories.Interfaces;
using DesafioAPI.Validators;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPI.Controllers
{
    [ApiController]
    [Route("api/realState")]
    public class RealStateController : ControllerBase
    {
        // Injeção de dependência do repositório e mapper
        private readonly IRealStateRepository _realStateRepository;
      
        private readonly IMapper _mapper;

        public RealStateController(IRealStateRepository realStateRepository, IRealStateImageRepository realStateImageRepository, IMapper mapper)
        {
            _realStateRepository = realStateRepository;
            _mapper = mapper;
        }

        // Endpoints
        [HttpGet]
        public ActionResult<IEnumerable<RealStateReadDTO>> GetAllOrByAttributes(string? title, double? value, string? neighborhood, int? bedroomQuantity, string? businessType, string? adress)
        {
            try
            {
                List<RealState> response;

                response = _realStateRepository.GetAllOrByAttributes(title, value, neighborhood, bedroomQuantity, businessType, adress);

                // Caso nenhum imóvel seja encontrado
                if (response.Count() == 0)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                var responseDTO = _mapper.Map<List<RealStateReadDTO>>(response);

                return Ok(responseDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public ActionResult<RealStateReadDTO> Post([FromBody] RealStateCreateDTO realStateCreateDTO)
        {
            try
            {
                // Mapeando para a model
                var newProperty = _mapper.Map<RealState>(realStateCreateDTO);

                // Validando os dados informados
                var realStateValidator = new RealStateValidator();
                var validatorResult = realStateValidator.Validate(newProperty);

                if (validatorResult.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
                }

                _realStateRepository.Add(newProperty);

                // Mapeando o retorno para o ReadDTO
                var newPropertyRead = _mapper.Map<RealStateReadDTO>(newProperty);

                return Created("Imóvel cadastrado com sucesso!", newPropertyRead);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<RealStateReadDTO> Put(int id, [FromBody] RealStateUpdateDTO realStateUpdateDTO)
        {
            try
            {
                var response = _realStateRepository.GetById(id);

                // Caso nenhum imóvel seja encontrado
                if (response == null)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                // Mapeando para a model
                response = _mapper.Map(realStateUpdateDTO, response);

                // Validando os dados informados
                var realStateValidator = new RealStateValidator();
                var validatorResult = realStateValidator.Validate(response);

                if (validatorResult.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
                }

                _realStateRepository.Update(response);

                // Mapeando o retorno para o ReadDTO
                var propertyUpdatedRead = _mapper.Map<RealStateReadDTO>(response);

                return Ok(new
                {
                    Mensagem = "Imóvel atualizado com sucesso",
                    Property = propertyUpdatedRead
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}