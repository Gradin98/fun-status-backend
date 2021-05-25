using Domain.Models;
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
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILogger<IncidentController> _logger;

        public IncidentController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            var incidents = _repository.Incident.FindAll().OrderByDescending(x => x.CreatedOn);
            return Ok(incidents);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var incident = await _repository.Incident.FindByIdAsync(id);
            if(incident == null) return NotFound("Resource was not founded");

            return Ok(incident);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Incident incident)
        {
            _repository.Incident.Create(incident);
            await _repository.Save();

            return Ok(incident);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(Incident model, int id)
        {
            var incident = _repository.Incident.FindById(id);
            if (incident == null) return NotFound("Resource was not founded");

            incident.Description = model.Description;
            incident.ShortDescription = model.ShortDescription;
            incident.StatusId = model.StatusId;
            incident.TrackerId = model.TrackerId;
            incident.Title = model.Title;

            _repository.Incident.Update(incident);
            await _repository.Save();

            return Ok(new
            {
                message = "Incident was updated."
            });
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var incident = _repository.Incident.FindById(id);
            if (incident == null) return NotFound("Resource was not founded");

            _repository.Incident.Delete(incident);
            await _repository.Save();

            return Ok(new
            {
                message = "Incident was deleted"
            });
        }


    }



}
