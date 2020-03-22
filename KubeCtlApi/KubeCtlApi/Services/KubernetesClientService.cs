using k8s;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KubeCtlApi.Services
{
    public class KubernetesClientService
    {
        private KubernetesClientConfiguration _config;
        private Kubernetes _client;

        private string _kubeConfigPath;
        public string KubeConfigPath {
            get => _kubeConfigPath;
            set {
                _kubeConfigPath = value;
                _config = KubernetesClientConfiguration.BuildConfigFromConfigFile(new FileInfo(_kubeConfigPath));
                _client = new Kubernetes(_config);
            }
        }

        public IEnumerable<string> GetNamespaces()
        {
            if (_client != null)
            {
                foreach (var i in _client.ListNamespace().Items)
                {
                    yield return i.Metadata.Name;
                }
            }
        }

        public IEnumerable<string> GetNamespacedDeployments(string @namespace)
        {
            if (_client != null)
            {
                foreach (var i in _client.ListNamespacedDeployment(@namespace).Items)
                {
                    yield return i.Metadata.Name;
                }
            }
        }

        public IEnumerable<string> GetNamespacedServices(string @namespace)
        {
            if (_client != null)
            {
                foreach (var i in _client.ListNamespacedService(@namespace).Items)
                {
                    yield return i.Metadata.Name;
                }
            }
        }

        public IEnumerable<string> GetNamespacedIngresses(string @namespace)
        {
            if (_client != null)
            {
                foreach (var i in _client.ListNamespacedIngress(@namespace).Items)
                {
                    yield return i.Metadata.Name;
                }
            }
        }

        public IEnumerable<string> GetNamespacedPods(string @namespace)
        {
            if (_client != null)
            {
                foreach (var i in _client.ListNamespacedPod(@namespace).Items)
                {
                    yield return i.Metadata.Name;
                }
            }
        }
    }
}
