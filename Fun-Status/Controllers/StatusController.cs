using Domain.Models;
using Fun_Status.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fun_Status.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILogger<StatusController> _logger;

        public StatusController(IRepositoryWrapper repositoryWrapper,
            ILogger<StatusController> logger)
        {
            _repository = repositoryWrapper;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var allStatus = _repository.Status.FindAll();
            return Ok(allStatus);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var status = _repository.Status.FindById(id);
            if (status == null) return NotFound("Resource was not found.");

            return Ok(status);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Status model)
        {
            _repository.Status.Create(model);
            await _repository.Save();

            return Ok(model);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Add(Status model, int id)
        {
            var status = _repository.Status.FindById(id);
            if (status == null) return NotFound("Resource was not found.");

            status.Color = model.Color;
            status.Icon = model.Icon;
            status.Name = model.Name;

            _repository.Status.Update(status);
            await _repository.Save();

            return Ok(new
            {
                message = "Status was updated."
            });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = _repository.Status.FindById(id);
            if (status == null) return NotFound("Resource was not found.");

            _repository.Status.Delete(status);
            await _repository.Save();

            return Ok(new
            {
                message = "Status was deleted"
            });
        }
    }
}
