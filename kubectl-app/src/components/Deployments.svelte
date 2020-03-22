
<script>
    import { deployments } from "../stores/deployments";
</script>

<h2>Deployments</h2>
{#each $deployments as deployment}
    <a href="#" style="display:block;">{deployment}</a>
{/each}