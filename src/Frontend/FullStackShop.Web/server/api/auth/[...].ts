import {NuxtAuthHandler} from "#auth";
import DuendeIDS6Provider from "next-auth/providers/duende-identity-server6"

export default NuxtAuthHandler({
  secret: process.env.AUTH_SECRET,
  providers: [
    DuendeIDS6Provider.default({
      name: "IDS",
      clientId: "fss-nuxt",
      clientSecret: "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0",
      issuer: "https://fullstackshop.identityserver:9999"
    })
  ]
})