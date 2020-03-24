using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KubeCtlApi.Models
{
    public class IngressDto : KubernetesObject
    {
        public IngressSpecDto Spec { get; set; }
    }

    public class IngressSpecDto
    {
        public IngressBackendDto Backend { get; set; }
        public IEnumerable<IngressRuleDto> Rules { get; set; }
        public IEnumerable<IngressTlsDto> Tls { get; set; }
    }

    public class IngressRuleDto
    {
        public string Host { get; set; }
        public IEnumerable<IngressPathDto> Paths { get; set; }
    }

    public class IngressPathDto
    {
        public IngressBackendDto Backend { get; set; }
        public string Path { get; set; }
    }

    public class IngressBackendDto
    {
        public string ServiceName { get; set; }
        public string ServicePort { get; set; }
    }

    public class IngressTlsDto
    {
        public string SecretName { get; set; }
        public IEnumerable<string> Hosts { get; set; }
    }
}
