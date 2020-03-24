
<script>
    import { pods } from "../stores/pods";
</script>

<h2>Pods</h2>
{#if $pods}
    {#each $pods.items as pod}
        <a href="#" style="display:block;">{pod}</a>
    {/each}
{/if}