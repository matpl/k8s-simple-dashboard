import Swagger from "swagger-client";

export const apiPath = "https://localhost:5000";

const swaggerClient = (async () => await Swagger({ url: apiPath + "/swagger/v1/swagger.json" }))();

export const kubernetesApi = swaggerClient.then(c => c.apis.Kubernetes);