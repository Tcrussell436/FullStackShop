import { getServerSession } from "next-auth";

export default eventHandler(async (event) => {
  const session = await getServerSession(event);
  if (!session) {
    return { status: 'unauthenticated' }
  }
  return { status: 'authenticated', text: 'Test text', session }
})
