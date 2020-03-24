
<script>
    import { deployments } from "../stores/deployments";
</script>

<h2>Deployments</h2>
{#if $deployments}
    {#each $deployments.items as deployment}
        <a href="#" style="display:block;">{deployment.name}</a>
    {/each}
{/if}