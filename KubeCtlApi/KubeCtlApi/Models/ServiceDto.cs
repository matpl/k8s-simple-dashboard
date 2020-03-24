using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KubeCtlApi.Models
{
    public class ServiceDto : KubernetesObject
    {
        public IDictionary<string, string> Selector { get; set; }
    }
}
