<script setup lang="ts">
const router = useRouter();
const menu = [
  {
    label: "Shop",
    action: "/shop"
  },
  {
    label: "About",
    action: "/about"
  }
]

const pt = {
  root: {
    class: 'px-4',
    style: {
      'border-radius': 0
    }
  },
  content: {
    class: 'flex h-full align-items-baseline',
  },
  menuitem: {
    class: 'h-full'
  },
  menu: {
    class: 'justify-content-center w-full',
    style: {
      'min-height': '3rem'
    }
  },
  end: {
    class: "ml-auto",
  }
}

</script>


<template>
  <Menubar :model="menu" :pt="pt">
    <template #start>
      <h4 class="m-0">FullStackShop</h4>
    </template>
    <template #item="{ item, props, hasSubmenu, root }">
      <NuxtLink :to="item.action" class="nav-link">{{item.label}}</NuxtLink>
    </template>
    <template #end>
      <Button label="Login"></Button>
    </template>
  </Menubar>
</template>

<style scoped>
a[href] {
  color: var(--text-color);
  text-decoration: none;
  padding: 0.5rem 0.75rem;
  height: 100%;
}
</style>