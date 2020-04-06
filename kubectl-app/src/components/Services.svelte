
<script>
    import { services } from "../stores/services";
</script>

<h2>Services</h2>
{#if $services}
    {#each $services.Items as service}
        <a href="#" style="display:block;">{service.Name}</a>
    {/each}
{/if}