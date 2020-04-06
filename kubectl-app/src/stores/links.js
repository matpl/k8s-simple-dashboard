import { deployments } from "./deployments";
import { services } from "./services";
import { getMatchingDeployments } from "./types/Service.ts";
import { ingresses } from "./ingresses";

import { derived } from "svelte/store";

export const links = derived(
    [deployments, services, ingresses],
    ([$deployments, $services, $ingresses], set) => {
        if($deployments && $services && $ingresses) {
            if($deployments.Namespace === $services.Namespace && $services.Namespace === $ingresses.Namespace) {
                
                // build the links here!
                // link item: ingress -> service -> deployment -> pod
                let ingresses = [];
                let services = [];

                for(let i = 0; i < $services.Items.length; i++) {
                    getMatchingDeployments($services.Items[i], $deployments);
                }

                // ingress
                    // spec
                        // backend (default)
                            // service name
                            // service port
                        // rules[]
                            // host
                            // paths []
                                // backend
                                    // service name
                                    // service port
                                // path
                        // tls[]
                            // secret name
                            // hosts []

                let deployments = []
                set([ingresses, services, deployments]);

            } else {
                set([]);
            }
        } else {
            set([]);
        }
    }
);