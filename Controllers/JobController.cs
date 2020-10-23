using ThePieShop.Data.Repositories;
using ThePieShop.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThePieShop.WebAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : Controller
    {
        private readonly IJobRepository _jobRepository;

        public JobController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetJobs()
        {
            return Ok(_jobRepository.GetAllJobs());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetJobById(int id)
        {
            return Ok(_jobRepository.GetJobById(id));
        }

        [HttpPost]
        public IActionResult CreateJob([FromBody] Job job)
        {
            if (job == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdJob = _jobRepository.AddJob(job);

            return Created("Job", createdJob);
        }

        [HttpPut]
        public IActionResult UpdateJob([FromBody] Job updatedJob)
        {
            _jobRepository.UpdateJob(updatedJob);
            return Ok(updatedJob);
        }

        [HttpDelete]
        public IActionResult DeleteJob(int id)
        {
            _jobRepository.DeleteJob(id);
            return NoContent();
        }
    }
}
