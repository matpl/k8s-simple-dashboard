import { writable, derived, get } from "svelte/store";
import { selectedNamespace } from "./namespaces";
import { fetchDeployments } from "./types/Deployment.ts";
 
export const selectedDeployment = writable(null);

export const deployments = derived(
    selectedNamespace,
    async ($selectedNamespace, set) => {
        set(null);
        if($selectedNamespace) {
            let deployments = await fetchDeployments($selectedNamespace);
            // this check is necessary because in an async derived store, the promise can resolve after another change on the initial store
            if($selectedNamespace === get(selectedNamespace)) {
                set(deployments);
            }
        }
    }
);