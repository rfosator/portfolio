using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Profile.Data;
using Profile.Data.Domain;
using ProfilePortfolio.Models;

namespace ProfilePortfolio.Controllers.api
{
    [Route("api/[controller]")]
    public class SkillsController : Controller
    {
        private IRepository<Skill> repository = null;
        public SkillsController(IUnitOfWork unitOfWork)
        {
            repository = unitOfWork.Get<Skill>();
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
                return StatusCode(500, e.Message);
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
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUpdateSkillModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var entity = new Skill
                {
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    LevelId = model.LevelId,
                    Enabled = model.Enabled
                };

                await repository.CreateAsync(entity);

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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
