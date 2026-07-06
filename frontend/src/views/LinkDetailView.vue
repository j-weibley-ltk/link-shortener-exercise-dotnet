<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { useRoute } from 'vue-router'
import { fetchLink } from '../api/links'
import type { Link } from '../types/link'

const route = useRoute()
const link = ref<Link | null>(null)

async function load() {
  link.value = (await fetchLink(route.params.id as string)) ?? null
}

onMounted(load)
</script>

<template>
  <section class="link-detail">
    <RouterLink to="/" class="link-detail__back">&larr; Back to links</RouterLink>

    <div v-if="link" class="link-detail__info">
      <h1 class="link-detail__code">{{ link.code }}</h1>
      <dl>
        <dt>Short URL</dt>
        <dd>
          <a :href="link.shortUrl" target="_blank" rel="noopener">{{ link.shortUrl }}</a>
        </dd>
        <dt>Target</dt>
        <dd>{{ link.targetUrl }}</dd>
        <dt>Created</dt>
        <dd>{{ new Date(link.createdAt).toLocaleString() }}</dd>
      </dl>
    </div>

    <!-- TODO: implement click analytics — see README -->
    <div class="chart-placeholder">Click analytics — implement me (see README)</div>
  </section>
</template>

<style scoped>
.link-detail__back {
  display: inline-block;
  margin-bottom: 1rem;
  color: var(--muted);
}

.link-detail__code {
  font-family: var(--mono);
  font-size: 1.5rem;
  margin-bottom: 1rem;
}

.link-detail dl {
  display: grid;
  grid-template-columns: max-content 1fr;
  gap: 0.4rem 1.5rem;
  margin-bottom: 2rem;
}

.link-detail dt {
  color: var(--muted);
  font-weight: 600;
}

.chart-placeholder {
  display: flex;
  align-items: center;
  justify-content: center;
  min-height: 240px;
  border: 2px dashed var(--border);
  border-radius: 8px;
  color: var(--muted);
  font-size: 0.95rem;
}
</style>
