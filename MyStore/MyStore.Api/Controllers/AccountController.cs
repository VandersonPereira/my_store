using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MyStore.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class AccountController : BaseController
    {
        private readonly IUserApplicationService _service;

        public AccountController(IUserApplicationService userService)
        {
            _service = userService;
        }

        [HttpPost]
        [Route("account")]
        public Task<HttpResponseMessage> Post([FromBody] dynamic body)
        {
            var user = _service.Register(
                (string)body.email,
                (string)body.username,
                (string)body.password
                );

            return CreateResponse(HttpStatusCode.Created, user);
        }

        [HttpGet]
        [Route("account")]
        public Task<HttpResponseMessage> Get()
        {
            return CreateResponse(HttpStatusCode.Created, new { message = "API Online" });
        }
    }
}