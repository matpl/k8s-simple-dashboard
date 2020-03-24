using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using KubeCtlApi.Models;
using KubeCtlApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KubeCtlApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KubernetesController : ControllerBase
    {
        private readonly ILogger<KubernetesController> _logger;
        private readonly KubernetesClientService _k8sClient;

        public KubernetesController(ILogger<KubernetesController> logger, KubernetesClientService k8sClient)
        {
            _logger = logger;
            _k8sClient = k8sClient;
        }

        [HttpGet("Namespaces", Name = "getNamespaces")]
        [ApiExplorerSettings()]
        public IEnumerable<string> GetNamespaces()
        {
            return _k8sClient.GetNamespaces();
        }

        [HttpGet("Deployments", Name = "getDeployments")]
        public NamespacedList<DeploymentDto> GetDeployments(string @namespace)
        {
            return _k8sClient.GetNamespacedDeployments(@namespace);
        }

        [HttpGet("Services", Name = "getServices")]
        public NamespacedList<ServiceDto> GetServices(string @namespace)
        {
            return _k8sClient.GetNamespacedServices(@namespace);
        }

        [HttpGet("Ingresses", Name = "getIngresses")]
        public NamespacedList<IngressDto> GetIngresses(string @namespace)
        {
            return _k8sClient.GetNamespacedIngresses(@namespace);
        }

        [HttpGet("Pods", Name = "getPods")]
        public NamespacedList<string> GetPods(string @namespace)
        {
            return _k8sClient.GetNamespacedPods(@namespace);
        }

        [HttpPost(Name = "setConfig")]
        public async Task<IActionResult> CreateClient(IFormFile uploadedFile)
        {
            var filePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(filePath))
            {
                await uploadedFile.CopyToAsync(stream);
            }

            _k8sClient.KubeConfigPath = filePath;

            return Ok();
        }
    }
}
