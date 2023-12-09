# FullStackShop

## Explanation
This is a large project and probably not something able to be looked through. It also is not yet functioning fully which will be explained.
I will instead explain things I have learned and shortly how I got about doing it. I went over many frameworks before choosing Nuxt.
Originally choosing Astro and even spent a few weeks on Blazor with the new .Net release

### Blazor
Orignally before picking a framework I chose to look at Blazor. Originally Blazor offered two modes, server rendering and web assembly. The server rendering mode gave
you typical server-side rendering for your page using razor components allowing you to avoid Javascript (yay). It also allows for JSInterop if you want do want
more control over your pages javascript. Web assembly mode is different in that your web site is compiled into a web assembly and downloaded by the user before being ran in the browser.
1. SSR
Server side rendering utilizes a SignalR socket to provide real time updates to the users page. This has the advantage of being very fast and providing real time data to the user.
The downside to this is each user requires an open websocket which should be taken into account for scaling.
2. WASM
Web assembly requires no socket and no backend server to run. Everything is executed in the browser after being downloaded. The positive to this is no web socket.
The drawback to WASM is download size and time. Before the page can be displayed it must be downloaded. WASM files can be quite large compared to typical pages.
This can be reduced with trimming techniques but will never beat SSR.
3. New Auto mode
Blazor released with a new auto rendering mode. This works by opening a web socket on the first page load for the user. This allows the server to provide the content faster and the WASM
files are downloaded in the background. On subsequent page loads the WASM file is used and no web socket is required. While this is what I was looking to use, the typical way
of calling backend API's is more tricky. Your page code must be able to be executed from the browser AND the server and should not be written to be dependent upon render mode.
This means implementing HttpMessageHandlers for handling cookies or access tokens needed for requests. This could be a good choice with time, but the technical debt seems higher.

### Nuxt
I chose Nuxt because one of my favorite UI frameworks for Vue has a supported Nuxt module. I have never used Nuxt and was very intrigued by the server side rendering and just
the ability to have a backend server. I was once making a frontend site to interface with google accounts using OAuth. This requires a backend for frontend approach.
The client is a bad place to store authentication sessioni information and some OAuth providers only have modules for node servers as they are only meant to run on the backend.
This means you need to implement a backend server to accept the callbacks from the oauth login. 
If you are interested this is a great resource for learning how these OAuth flows work.
https://auth0.com/docs/get-started/authentication-and-authorization-flow


## What didn't work
I wanted to provide a compose project that required no manual configuration before running. The issue with hosting IdentityServer inside of the container environment
is the user must be redirected to it as a front end in order allow consent. In the container the host name is fullstackshop.identityserver which is not resolable from
your host environment unless added to your DNS hosts entries. I do have a solution for this as I have been beginning to learn nginx for proxies. A solution would be
to set the OAuth issuer or authority in Nuxt to localhost:9999 (the identityserver port mapped to your host machine from inside the container). In the front ends container
I can set up nginx in the dockerfile and be sure the image includes nginx. In the nginx configuration I could route all localhost:9999 traffic to proxy to fullstackshop.identityserver.
This would allow my Nuxt server to still call the identity server using localhost:9999 but also allow the user to hit localhost:9999 for the login page since that is where the user
has access to it.
