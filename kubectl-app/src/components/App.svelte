<script>
	import { kubeConfigLoaded, loadKubeConfig } from "../stores/kubeconfig.js";
	import Namespaces from "./Namespaces.svelte";

	function fileChanged(event) {
		if(event.target.files.length > 0) {
			loadKubeConfig(event.target.files[0]);
		}
	}
</script>

{#if !$kubeConfigLoaded}
	<input type="file" on:change={fileChanged} />
{:else}
	<Namespaces />
{/if}