import { writable } from "svelte/store";
import { apiPath } from "./api";
import Swagger from "swagger-client";

export const kubeConfigLoaded = writable(false);
export const kubeConfig = writable(null);

export async function loadKubeConfig(file) {
    var formData = new FormData();
    formData.set("uploadedFile", file);

    let res = await Swagger.http({
        "url": apiPath + "/Kubernetes",
        "method": "POST",
        "body": formData
    });

    if(res.status == 200) {
        kubeConfigLoaded.set(true);
    }
}