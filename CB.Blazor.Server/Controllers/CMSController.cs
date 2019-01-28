using CB.Blazor.CMS.Contracts;
using CB.Blazor.Email.Contracts;
using CB.Blazor.Interface.CMS;
using CB.Blazor.Interface.ServiceModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CB.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    public class CMSController
    {
        private readonly ICMSService _cmsService;
        private readonly IEmailService _emailService;

        public CMSController(ICMSService cmsService, IEmailService emailService)
        {
            _cmsService = cmsService;
            _emailService = emailService;
        }

        [Route("get-blog-posts")]
        public async Task<List<BlogPost>> GetBlogPosts()
        {
            return await _cmsService.GetBlogPosts();
        }

        [Route("get-blog-post")]
        public async Task<BlogPost> GetBlogPost([FromBody] GetBlogPostRequest request)
        {
            return await _cmsService.GetBlogPost(request.Id);
        }

        [Route("get-global")]
        public async Task<Global> GetGlobal()
        {
            return await _cmsService.GetGlobal();
        }

        [Route("get-portfolio")]
        public async Task<Portfolio> GetPortfolio()
        {
            return await _cmsService.GetPortfolio();
        }

        [Route("send-contact-email")]
        public async Task<SendContactEmailResponse> SendContactEmail([FromBody] SendContactEmailRequest request)
        {
            return await _emailService.SendContactEmail(request);
        }
    }
}
