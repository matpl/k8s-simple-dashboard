
<script>
    import { ingresses } from "../stores/ingresses";
</script>

<h2>Ingresses</h2>
{#each $ingresses as ingress}
    <a href="#" style="display:block;">{ingress}</a>
{/each}