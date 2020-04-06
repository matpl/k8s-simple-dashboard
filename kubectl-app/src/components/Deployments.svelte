
<script>
    import { deployments } from "../stores/deployments";
</script>

<h2>Deployments</h2>
{#if $deployments}
    {#each $deployments.Items as deployment}
        <a href="#" style="display:block;">{deployment.Name}</a>
    {/each}
{/if}