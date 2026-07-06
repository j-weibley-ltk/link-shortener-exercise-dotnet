<script setup lang="ts">
import type { Link } from '../types/link'

defineProps<{ link: Link }>()
</script>

<template>
  <tr class="link-row">
    <td class="link-row__code">
      <a :href="link.shortUrl" target="_blank" rel="noopener">{{ link.code }}</a>
    </td>
    <td class="link-row__target">{{ link.targetUrl }}</td>
    <td>{{ new Date(link.createdAt).toLocaleString() }}</td>
    <td>
      <RouterLink :to="`/links/${link.id}`">Details</RouterLink>
    </td>
  </tr>
</template>

<style scoped>
.link-row td {
  padding: 0.5rem 0.75rem;
  border-bottom: 1px solid var(--border);
}

.link-row__code a {
  font-family: var(--mono);
  font-weight: 600;
}

.link-row__target {
  max-width: 360px;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
  color: var(--muted);
}
</style>
