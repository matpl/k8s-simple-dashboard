
export abstract class KubernetesObject {
    public Name?: string;
    public Labels?: Record<string, string>;
}