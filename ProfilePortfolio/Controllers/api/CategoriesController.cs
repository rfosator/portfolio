﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfilePortfolio.Models;

using Data.Domain;
using Profile.Data;

namespace ProfilePortfolio.Controllers.api
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private Repository<Category> repository;
        public CategoriesController()
        {
            repository = new Repository<Category>();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var content = await repository.AllAsync();
                return Ok(content);
            }
            catch (Exception e)
            {
                return base.StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var content = await repository.GetByIdAsync(id);
                return Ok(content);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCategoryModel content)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await repository.Create(new Category
                {
                    Name = content.Name, 
                    Enabled = content.Enabled
                });
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
