import { KubernetesObject } from "./KubernetesObject.ts";

export abstract class NamespacedList<T extends KubernetesObject> {
    public Items?: T[];
    public Namespace?: string;
}