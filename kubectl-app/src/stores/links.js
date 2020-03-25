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
                // link item: ingress -> service -> deployment -> pod
                let ingresses = [];
                let services = [];

                for(let i = 0; i < $services.items.length; i++) {
                    let selector = $services.items[i].selector;
                    let labels = [];
                    Object.keys(selector).forEach(p => {
                        labels.push({"key": p, "value": selector[p]});
                    });
                    for(let j = 0; j < $deployments.items.length; j++) {
                        let deploymentLabels = $deployments.items[j].labels;
                        let matches = true;
                        for(let k = 0; k < labels.length; k++) {
                            if(deploymentLabels[labels[k].key] !== labels[k].value) {
                                matches = false;
                                break;
                            }
                        }
                        if(matches) {
                            console.log("service : " + $services.items[i].name + " deployment : " + $deployments.items[j].name);
                        }
                    }
                }

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