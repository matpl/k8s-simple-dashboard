using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KubeCtlApi.Models
{
    public class KubernetesObject : IKubernetesObject
    {
        public string Name { get; set; }
        public IDictionary<string, string> Labels { get; set; }
    }
}
