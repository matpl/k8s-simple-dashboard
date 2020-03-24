
<script>
    import { ingresses } from "../stores/ingresses";
</script>

<h2>Ingresses</h2>
{#if $ingresses}
    {#each $ingresses.items as ingress}
        <a href="#" style="display:block;">{ingress}</a>
    {/each}
{/if}