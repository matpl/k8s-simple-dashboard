using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KubeCtlApi.Models
{
    public interface IKubernetesObject
    {
        string Name { get; set; }

        IDictionary<string, string> Labels { get; set; }
    }
}
