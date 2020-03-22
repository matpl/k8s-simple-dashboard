
<script>
    import { pods } from "../stores/pods";
</script>

<h2>Pods</h2>
{#each $pods as pod}
    <a href="#" style="display:block;">{pod}</a>
{/each}