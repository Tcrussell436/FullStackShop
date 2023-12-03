// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },
  devServer: {
    https: true,
    port: 7000
  },
  modules: [
    'nuxt-primevue'
  ],
  css: [
    'primeflex/primeflex.min.css',
    'primeicons/primeicons.css',
    'primevue/resources/themes/viva-light/theme.css',
    '~/assets/site.css'
  ]
})
