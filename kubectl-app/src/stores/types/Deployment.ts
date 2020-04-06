
import { kubernetesApi } from "../api";
import { KubernetesObject } from "./KubernetesObject.ts";
import { NamespacedList } from "./NamespacedList.ts";

export class DeploymentList extends NamespacedList<Deployment> { }

export class Deployment extends KubernetesObject { }

export const fetchDeployments = async (namespace): Promise<DeploymentList> => {
    let res = await kubernetesApi.then(a => a.getDeployments({"namespace": namespace}));
    return res.body as DeploymentList;
};