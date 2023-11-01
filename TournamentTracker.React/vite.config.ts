import { defineConfig } from 'vite'
import dns from 'dns'
import react from '@vitejs/plugin-react'

dns.setDefaultResultOrder('verbatim');

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    cors: { origin: "localhost:7238" },
    proxy: {
      'api': {
        target: 'https://localhost:7238',
        changeOrigin: true,
        secure: false,
        rewrite: (path) => path.replace(/^\/api/, ''),
      }
    },
    host: 'localhost',
    port: 3000
  },
  define: {
    'process.env': process.env
  }
})
