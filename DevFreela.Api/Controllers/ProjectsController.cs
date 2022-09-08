﻿using DevFreela.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        //api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            //Buscar ou filtrar todos os projetos
            return Ok();
        }

        //api/projects/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Buscar o projeto

            return Ok();
            //return NotFound() qd não encontrar nenhum elemento
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            if (createProject.Title.Length > 50)
            {
                return BadRequest();
            }
            //Cadastrar o projeto 
            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
        }

        //api/projects/2
        [HttpPut]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
            if (updateProject.Description.Length > 50)
            {
                return BadRequest();
            }

            //Atualizar o projeto
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Buscar o projeto, se não existir, retornar NotFound()
            //se existir, remover

            return NoContent();
        }

        //api/projects/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComment)
        {
            return NoContent();
        }

        //api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        //api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish (int id)
        {
            return NoContent();
        }


    }

}
