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
    public class TrackerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILogger<TrackerController> _logger;

        public TrackerController(IRepositoryWrapper repositoryWrapper,
            ILogger<TrackerController> logger)
        {
            _repository = repositoryWrapper;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            var allTracker = _repository.Tracker.FindAll();
            return Ok(allTracker);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tracker = await _repository.Tracker.FindByIdAsyncWithData(id);
            if (tracker == null) return NotFound("Resource was not founded");

            return Ok(tracker);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Tracker tracker)
        {
            _repository.Tracker.Create(tracker);
            await _repository.Save();

            return Ok(tracker);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(Tracker model, int id)
        {
            var tracker = await _repository.Tracker.FindByIdAsyncWithData(id);
            if (tracker == null) return NotFound("Resource was not founded");

            tracker.About = model.About;
            tracker.Name = model.About;
            tracker.StatusId = model.Status.Id;
            tracker.Url = model.Url;

            _repository.Tracker.Update(tracker);
            await _repository.Save();

            return Ok(new
            {
                message = "Resource was updated"
            });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tracker = await _repository.Tracker.FindByIdAsyncWithData(id);
            if (tracker == null) return NotFound("Resource was not founded");

            _repository.Tracker.Delete(tracker);
            await _repository.Save();

            return Ok(new
            {
                message = "Resource was deleted"
            });
        }
    }
}
