import { log } from "node:console";

async function getBackendInfo() {
  const url = process.env.BACKEND_URL || "http://localhost:5000";

  log(url);

  try {
    const res = await fetch(url, { cache: "no-store" });
    return await res.json();
  } catch (e: any) {
    return { error: e.message };
  }
}

export default async function Home() {
  const data = await getBackendInfo();
  return (
    <main className="p-8 font-mono">
      <h1 className="text-2xl mb-4">Argus</h1>
      <p className="text-sm text-gray-400 mb-4">Backend response:</p>
      <pre className="bg-gray-400 text-gray-800 p-4 rounded">
        {JSON.stringify(data, null, 2)}
      </pre>
    </main>
  );
}
