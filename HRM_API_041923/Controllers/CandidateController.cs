using System;
using HRM_API_Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using RHRM_API_ApplicationCore.Models;
using RHRM_API_ApplicationCore.Services;

namespace HRM_API_041923.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        //private readonly ILogger _logger;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
            //_logger = logger;
        }

        [HttpGet("GetAllCandidates")]
        public async Task<IActionResult> AllCandidates()
        {
            var candidates = await _candidateService.GetAllCandidates();
            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCandidate(CandidateRequestModel candidate)
        {
            try
            {
                await _candidateService.AddCandidateAsync(candidate);
                return Ok(candidate);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCandidateById(int id)
        {
            try
            {
                await _candidateService.DeleteCandidateAsync(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCandidateInfo(CandidateRequestModel candidate)
        {
            try
            {
                await _candidateService.UpdateCandidateAsync(candidate);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound("Cannot found candidate: " + ex);
            }
        }

        [HttpGet("GetCandidateById/{id}")]
        public async Task<IActionResult> AllCandidates(int id)
        {
            var result = await _candidateService.GetCandidateByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Candidate not Found\n");
        }
    }
}

