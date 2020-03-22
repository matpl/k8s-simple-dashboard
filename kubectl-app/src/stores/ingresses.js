import { writable, derived, get } from "svelte/store";
import { selectedNamespace } from "./namespaces";
import { kubernetesApi } from "./api";

export const selectedIngress = writable(null);

const fetchIngresses = async (namespace) => {
    let res = await kubernetesApi.then(a => a.getIngresses({"namespace": namespace}));
    return res.body;
};

export const ingresses = derived(
    selectedNamespace,
    async ($selectedNamespace, set) => {
        set([]);
        if($selectedNamespace) {
            let ingresses = await fetchIngresses($selectedNamespace);
            // this check is necessary because in an async derived store, the promise can resolve after another change on the initial store
            if($selectedNamespace === get(selectedNamespace)) {
                set(ingresses);
            }
        }
    }
);