<script setup lang="ts">

const fetchCategories = await useFetch("http://localhost:3000/development_data/categories.json");

const categories = computed(() => {
  return fetchCategories.data.value ?? [];
})

</script>

<template>
<div class="category-sidebar">
  <div class="sidepanel-header">
    Categories
  </div>
  <PanelMenu :model="categories">

  </PanelMenu>
</div>
</template>

<style scoped>
.category-sidebar {
  padding: 0.5rem 0.75rem;
  border: 2px solid #ebebeb;
  background-color: var(--surface-50);
  height: 100%;
}
.sidepanel-header {
  margin-left: 0.4rem;
  margin-bottom: 0.3rem;
  font-weight: 600;
}
</style>