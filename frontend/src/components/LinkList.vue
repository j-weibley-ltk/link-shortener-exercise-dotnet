<script setup lang="ts">
import type { Link } from '../types/link'
import LinkRow from './LinkRow.vue'

defineProps<{ links: Link[] }>()
</script>

<template>
  <table class="link-list">
    <thead>
      <tr>
        <th>Code</th>
        <th>Target</th>
        <th>Created</th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      <LinkRow v-for="link in links" :key="link.id" :link="link" />
    </tbody>
  </table>
</template>

<style scoped>
.link-list {
  width: 100%;
  border-collapse: collapse;
  font-size: 0.95rem;
}

.link-list th {
  text-align: left;
  padding: 0.5rem 0.75rem;
  border-bottom: 2px solid var(--border);
  color: var(--muted);
  font-weight: 600;
}
</style>
