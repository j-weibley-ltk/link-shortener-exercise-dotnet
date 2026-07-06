<script setup lang="ts"></script>

<template>
  <div class="app">
    <header class="app__header">
      <RouterLink to="/" class="app__brand">Link Shortener</RouterLink>
    </header>
    <main class="app__main">
      <RouterView />
    </main>
  </div>
</template>
