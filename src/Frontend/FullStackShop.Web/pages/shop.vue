<script setup lang="ts">

</script>

<template>
  <div class="flex h-full gap-3">
    <div class="shop-sidebar">
      <NavSide />
    </div>
    <main>

    </main>
  </div>
</template>

<style scoped>

@media (max-width: 992px) {
  .shop-sidebar {
    display: none;
  }
  main {
    max-width: 95vw;
  }
}
.shop-sidebar {
  margin: 1rem 0 0 0.25rem;
  max-width: 20vw;
}

main {
  background-color: var(--surface-100);
  height: 100%;
  width: 100%;
  margin: 0 1rem 0 0;
}
</style>