
<script>
    import { services } from "../stores/services";
</script>

<h2>Services</h2>
{#each $services as services}
    <a href="#" style="display:block;">{services}</a>
{/each}