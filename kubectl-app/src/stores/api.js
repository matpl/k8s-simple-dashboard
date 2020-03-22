import Swagger from "swagger-client";

export const apiPath = "https://localhost:32770";

const swaggerClient = (async () => await Swagger({ url: apiPath + "/swagger/v1/swagger.json" }))();

export const kubernetesApi = swaggerClient.then(c => c.apis.Kubernetes);