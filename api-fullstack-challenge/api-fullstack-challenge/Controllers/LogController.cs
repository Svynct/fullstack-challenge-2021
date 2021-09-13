using api_fullstack_challenge.Repository.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace api_fullstack_challenge.Controllers
{
    [Route("/Logs"), ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogRepository logRepository;

        public LogController(ILogRepository _logRepository)
        {
            logRepository = _logRepository;
        }

        [HttpGet, Route("Sync")]
        public ActionResult GetSyncLogs()
        {
            try
            {
                var logs = logRepository.GetSyncLogs();

                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet, Route("Delete")]
        public ActionResult GetDeleteLogs()
        {
            try
            {
                var logs = logRepository.GetDeleteLogs();

                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
