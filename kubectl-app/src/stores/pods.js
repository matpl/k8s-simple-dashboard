import { writable, derived, get } from "svelte/store";
import { selectedNamespace } from "./namespaces";
import { kubernetesApi } from "./api";

export const selectedPod = writable(null);

const fetchPods = async (namespace) => {
    let res = await kubernetesApi.then(a => a.getPods({"namespace": namespace}));
    return res.body;
};

export const pods = derived(
    selectedNamespace,
    async ($selectedNamespace, set) => {
        set([]);
        if($selectedNamespace) {
            let pods = await fetchPods($selectedNamespace);
            // this check is necessary because in an async derived store, the promise can resolve after another change on the initial store
            if($selectedNamespace === get(selectedNamespace)) {
                set(pods);
            }
        }
    }
);