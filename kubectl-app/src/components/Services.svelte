
<script>
    import { services } from "../stores/services";
</script>

<h2>Services</h2>
{#if $services}
    {#each $services.items as service}
        <a href="#" style="display:block;">{service.name}</a>
    {/each}
{/if}