import { writable, derived, get } from "svelte/store";
import { selectedNamespace } from "./namespaces";
import { kubernetesApi } from "./api";

export const selectedService = writable(null);

const fetchServices = async (namespace) => {
    let res = await kubernetesApi.then(a => a.getServices({"namespace": namespace}));
    return res.body;
};

export const services = derived(
    selectedNamespace,
    async ($selectedNamespace, set) => {
        set(null);
        if($selectedNamespace) {
            let services = await fetchServices($selectedNamespace);
            // this check is necessary because in an async derived store, the promise can resolve after another change on the initial store
            if($selectedNamespace === get(selectedNamespace)) {
                set(services);
            }
        }
    }
);