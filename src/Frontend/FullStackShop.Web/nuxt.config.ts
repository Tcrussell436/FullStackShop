// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },
  devServer: {
    https: true,
    port: 7000,
    url: "https://+:7000"
  },
  modules: [
    '@sidebase/nuxt-auth',
    'nuxt-primevue'
  ],
  typescript: {
    shim: false
  },
  auth: {
    isEnabled: true,
    provider: {
      type: 'authjs',
    }
  },
  css: [
    'primeflex/primeflex.min.css',
    'primeicons/primeicons.css',
    'primevue/resources/themes/viva-light/theme.css',
    '~/assets/site.css'
  ]
})
