using k8s;
using KubeCtlApi.Models;
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

        public NamespacedList<DeploymentDto> GetNamespacedDeployments(string @namespace)
        {
            if (_client != null)
            {
                var list = new NamespacedList<DeploymentDto>
                {
                    Namespace = @namespace
                };
                foreach (var i in _client.ListNamespacedDeployment(@namespace).Items)
                {
                    list.Items.Add(new DeploymentDto
                    {
                        Name = i.Metadata.Name,
                        Labels = new Dictionary<string, string>(i.Metadata.Labels)
                    });
                }

                return list;
            }

            return null;
        }

        public NamespacedList<ServiceDto> GetNamespacedServices(string @namespace)
        {
            if (_client != null)
            {
                var list = new NamespacedList<ServiceDto>
                {
                    Namespace = @namespace
                };
                foreach (var i in _client.ListNamespacedService(@namespace).Items)
                {
                    list.Items.Add(new ServiceDto
                    {
                        Name = i.Metadata.Name,
                        Labels = new Dictionary<string, string>(i.Metadata.Labels),
                        Selector = new Dictionary<string, string>(i.Spec.Selector),
                        Spec = new ServiceSpecDto()
                        {
                            Ports = i.Spec.Ports.Select(p => new ServicePortDto()
                            {
                                Name = p.Name,
                                Port = p.Port,
                                TargetPort = p.TargetPort,
                                Protocol = p.Protocol
                            })
                        }
                    });
                }
                return list;
            }

            return null;
        }

        public NamespacedList<IngressDto> GetNamespacedIngresses(string @namespace)
        {
            if (_client != null)
            {
                var list = new NamespacedList<IngressDto>
                {
                    Namespace = @namespace
                };
                foreach (var i in _client.ListNamespacedIngress(@namespace).Items)
                {
                    list.Items.Add(new IngressDto
                    {
                        Name = i.Metadata.Name,
                        Labels = new Dictionary<string, string>(i.Metadata.Labels),
                        Spec = new IngressSpecDto
                        {
                            Backend = new IngressBackendDto
                            {
                                ServiceName = i.Spec.Backend.ServiceName,
                                ServicePort = i.Spec.Backend.ServicePort
                            },
                            Rules = i.Spec.Rules.Select(r => new IngressRuleDto
                            {
                                Host = r.Host,
                                Paths = r.Http.Paths.Select(p => new IngressPathDto
                                {
                                    Backend = new IngressBackendDto
                                    {
                                        ServiceName = p.Backend.ServiceName,
                                        ServicePort = p.Backend.ServicePort
                                    },
                                    Path = p.Path
                                })
                            }),
                            Tls = i.Spec.Tls.Select(t => new IngressTlsDto
                            {
                                SecretName = t.SecretName,
                                Hosts = new List<string>(t.Hosts)
                            })
                        }
                    });
                }
                return list;
            }

            return null;
        }

        public NamespacedList<string> GetNamespacedPods(string @namespace)
        {
            if (_client != null)
            {
                var list = new NamespacedList<string>
                {
                    Namespace = @namespace
                };
                foreach (var i in _client.ListNamespacedPod(@namespace).Items)
                {
                    list.Items.Add(i.Metadata.Name);
                }
                return list;
            }
            return null;
        }
    }
}
