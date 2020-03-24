<script>
    import { namespaces, selectedNamespace } from "../stores/namespaces";
    import Deployments from "./Deployments.svelte";
    import Services from "./Services.svelte";
    import Ingresses from "./Ingresses.svelte";
    import Pods from "./Pods.svelte";
    import Links from "./Links.svelte";

    function handleClick(event) {
		selectedNamespace.set(event.target.innerHTML);
		return false;
	}
</script>

<style>
	h1 {
		color: purple;
	}
</style>

<h1>Namespaces</h1>
{#each $namespaces as namespace}
    <a href="#" on:click={handleClick} style="display:block;">{namespace}</a>
{/each}
{#if $selectedNamespace}
    <Deployments />
    <Services />
    <Ingresses />
    <Pods />
    <Links />
{/if}
