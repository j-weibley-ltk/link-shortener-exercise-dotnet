<script setup lang="ts">
import { ref } from 'vue'
import { createLink } from '../api/links'

const emit = defineEmits<{ created: [] }>()

const targetUrl = ref('')

async function submit() {
  await createLink(targetUrl.value)
  targetUrl.value = ''
  emit('created')
}
</script>

<template>
  <form class="create-form" @submit.prevent="submit">
    <input
      v-model="targetUrl"
      class="create-form__input"
      type="text"
      placeholder="https://example.com/a/very/long/url"
    />
    <button type="submit" class="create-form__button">Shorten</button>
  </form>
</template>

<style scoped>
.create-form {
  display: flex;
  gap: 0.5rem;
  margin-bottom: 1.5rem;
}

.create-form__input {
  flex: 1;
  padding: 0.55rem 0.75rem;
  border: 1px solid var(--border);
  border-radius: 6px;
  font-size: 0.95rem;
}

.create-form__button {
  padding: 0.55rem 1.1rem;
  border: none;
  border-radius: 6px;
  background: var(--accent);
  color: #fff;
  font-size: 0.95rem;
  cursor: pointer;
}

.create-form__button:hover {
  background: var(--accent-dark);
}
</style>
