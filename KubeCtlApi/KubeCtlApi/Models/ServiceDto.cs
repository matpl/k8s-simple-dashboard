using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KubeCtlApi.Models
{
    public class ServiceDto : KubernetesObject
    {
        public IDictionary<string, string> Selector { get; set; }
        public ServiceSpecDto Spec { get; set; }
    }

    public class ServiceSpecDto
    {
        public IEnumerable<ServicePortDto> Ports { get; set; }
    }

    public class ServicePortDto
    {
        public string Name { get; set; }
        public int Port { get; set; }
        public string TargetPort { get; set; }
        public string Protocol { get; set; }
    }
}
