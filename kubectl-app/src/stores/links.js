import { deployments } from "./deployments";
import { services } from "./services";
import { ingresses } from "./ingresses";

import { derived } from "svelte/store";

export const links = derived(
    [deployments, services, ingresses],
    ([$deployments, $services, $ingresses], set) => {
        if($deployments && $services && $ingresses) {
            if($deployments.namespace === $services.namespace && $services.namespace === $ingresses.namespace) {
                
                // build the links here!

            } else {
                set([]);
            }
        } else {
            set([]);
        }
    }
);