
import { kubernetesApi } from "../api";
import { KubernetesObject } from "./KubernetesObject.ts";
import { NamespacedList } from "./NamespacedList.ts";
import { DeploymentList, Deployment } from "./deployment";

export class ServiceList extends NamespacedList<Service> { }

export class Service extends KubernetesObject {
    public Spec?: ServiceSpec;
    public Selector?: Record<string, string>;
}

export class ServiceSpec {
    public Ports?: ServicePort[];
}

export class ServicePort {
    public Name?: string;
    public Port?: number;
    public TargetPort?: string;
    public Protocol?: string;
}

export const fetchServices = async (namespace):Promise<ServiceList> => {
    let res = await kubernetesApi.then(a => a.getServices({"namespace": namespace}));
    return res.body as ServiceList;
};

export const getMatchingDeployments = (service: Service, deployments: DeploymentList): Deployment[] => {
    let labels:any[] = [];
    Object.keys(service.Selector as {}).forEach(p => {
        labels.push({"Key": p, "Value": (service.Selector as {})[p]});
    });
    if(deployments && deployments.Items) {
        for(let j = 0; j < deployments.Items.length; j++) {
            let deploymentLabels = deployments.Items[j].Labels;
            if(deploymentLabels) {
                let matches = true;
                for(let k = 0; k < labels.length; k++) {
                    if(deploymentLabels[labels[k].Key] !== labels[k].Value) {
                        matches = false;
                        break;
                    }
                }
                if(matches) {
                    console.log("service : " + service.Name + " deployment : " + deployments.Items[j].Name);
                }
            }
        }
    }
    return [];
}