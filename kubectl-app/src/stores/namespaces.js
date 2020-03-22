import { writable, readable } from "svelte/store";
import { kubernetesApi } from "./api";

export const selectedNamespace = writable(null);

// this could probably be a derived store like the deployments

export const namespaces = readable([], (set) => {

    const fetchNamespaces = async () => {
        let res = await kubernetesApi.then(a => a.getNamespaces());
        let namespaces = res.body;
        if(namespaces && namespaces.length > 0) {
            clearInterval(interval);
        }
        set(namespaces);
    };
    fetchNamespaces();
    const interval = setInterval(fetchNamespaces, 10000);

    return () => clearInterval(interval);
});