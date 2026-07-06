<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { fetchLinks } from '../api/links'
import type { Link } from '../types/link'
import LinkCreateForm from '../components/LinkCreateForm.vue'
import LinkList from '../components/LinkList.vue'

const links = ref<Link[]>([])

async function load() {
  links.value = await fetchLinks()
}

onMounted(load)
</script>

<template>
  <section class="dashboard">
    <h1>Your links</h1>
    <LinkCreateForm @created="load" />
    <LinkList :links="links" />
  </section>
</template>

<style scoped>
.dashboard h1 {
  font-size: 1.5rem;
  margin-bottom: 1.25rem;
}
</style>
