using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DesafioAPI.Dto.RealStateImage;
using DesafioAPI.Models;
using DesafioAPI.Respositories.Interfaces;
using DesafioAPI.Validators;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPI.Controllers
{
    [ApiController]
    [Route("api/realStateImage")]
    public class RealStateImageController : ControllerBase
    {
        // Injeção de dependência do repositório e mapper
        private readonly IRealStateImageRepository _realStateImageRepository;
        private readonly IMapper _mapper;

        public RealStateImageController(IRealStateImageRepository realStateImageRepository, IMapper mapper)
        {
            _realStateImageRepository = realStateImageRepository;
            _mapper = mapper;
        }

        [HttpGet("{realStateId}")]
        public ActionResult<IEnumerable<RealStateImageReadDTO> > GetAllByRealStateId(int realStateId)
        {
            try
            {
                List<RealStateImage> response; 
                
                response = _realStateImageRepository.GetAllByRealStateId(realStateId);

                // Caso nenhuma imagem seja encontrada
                if (response.Count() == 0)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                var imagesRead = _mapper.Map<List<RealStateImageReadDTO>>(response);

                return Ok(imagesRead);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public ActionResult<RealStateImageReadDTO> Post([FromBody] RealStateImageCreateDTO realStateImageCreateDTO)
        {
            try
            {
                // Mapeando para a model
                var newImage = _mapper.Map<RealStateImage>(realStateImageCreateDTO);

                // Validando os dados informados
                var realStateImageValidator = new RealStateImageValidator();
                var validatorResult = realStateImageValidator.Validate(newImage);

                if (validatorResult.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
                }

                _realStateImageRepository.Add(newImage);

                // Mapeando o retorno para o ReadDTO
                var newImageRead = _mapper.Map<RealStateImageReadDTO>(newImage);

                return Created("Imagem cadastrada com sucesso!", newImageRead);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<RealStateImageReadDTO> Put(int id, [FromBody] RealStateImageUpdateDTO realStateImageUpdateDTO)
        {
            try
            {
                var response = _realStateImageRepository.GetById(id);

                // Caso nenhuma imagem seja encontrada
                if (response == null)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                // Mapeando para a model
                response = _mapper.Map(realStateImageUpdateDTO, response);

                // Validando os dados informados
                var realStateImageValidator = new RealStateImageValidator();
                var validatorResult = realStateImageValidator.Validate(response);

                if (validatorResult.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
                }

                _realStateImageRepository.Update(response);

                // Mapeando o retorno para o ReadDTO
                var imageUpdatedRead = _mapper.Map<RealStateImageReadDTO>(response);

                return Ok(new
                {
                    Mensagem = "Imóvel atualizado com sucesso",
                    Image = imageUpdatedRead
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }


}